using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Security.Cryptography;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Usuarios.Register
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

            var user = _mapper.Map<Domain.Entities.Usuario>(request);
            user.Senha = _passwordEncripter.Encrypt(request.Senha);
            user.UsuarioIdentifier = Guid.NewGuid();
            user.Ativo = true;
            user.DataCadastro = DateTime.Now;

            await _usuarioRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUsuarioJson
            {
                Nome = user.Nome,
                Token = _tokenGenerator.Generate(user)
            };
        }

        private async Task Validate(RequestRegisterUsuarioJson request)
        {
            var result = new RegisterUsuarioValidator().Validate(request);

            var emailExist = await _usuarioRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Email already exists"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
