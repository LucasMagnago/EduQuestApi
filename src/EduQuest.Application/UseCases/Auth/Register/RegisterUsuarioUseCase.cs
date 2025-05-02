using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Security.Cryptography;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Auth.Register
{
    internal class RegisterUsuarioUseCase : IRegisterUsuarioUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessTokenGenerator _tokenGenerator;

        public RegisterUsuarioUseCase(IMapper mapper,
            IPasswordEncripter passwordEncripter,
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork,
            IAccessTokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseRegisteredUsuarioJson> Execute(RequestRegisterUsuarioJson request)
        {
            await Validate(request);

            var usuario = request.IsAluno ? new Aluno() { StreakDiasConsecutivos = 1, DataUltimoAcessoStreak = DateTime.Now } : new Usuario();

            usuario = _mapper.Map(request, usuario);
            usuario.SenhaHash = _passwordEncripter.Encrypt(request.Senha);
            usuario.UsuarioIdentifier = Guid.NewGuid();
            usuario.Ativo = true;
            usuario.DataCadastro = DateTime.Now;
            usuario.DataUltimoLogin = DateTime.Now;

            await _usuarioRepository.SaveAsync(usuario);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUsuarioJson
            {
                Usuario = _mapper.Map<ResponseShortUsuarioJson>(usuario),
                Token = _tokenGenerator.Generate(usuario, null, null)
            };
        }

        private async Task Validate(RequestRegisterUsuarioJson request)
        {
            var result = new RegisterUsuarioValidator().Validate(request);

            var emailExist = await _usuarioRepository.ExistsActiveUsuarioWithEmail(request.Email);

            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "E-mail já cadastrado"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
