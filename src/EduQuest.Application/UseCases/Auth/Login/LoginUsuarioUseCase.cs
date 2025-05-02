using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Domain.Security.Cryptography;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Auth.Login
{
    internal class LoginUsuarioUseCase : ILoginUsuarioUseCase
    {
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUsuarioEscolaPerfilRepository _usuarioEscolaPerfilRepository;
        private readonly IAccessTokenGenerator _tokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginUsuarioUseCase(IPasswordEncripter passwordEncripter,
            IUsuarioRepository usuarioRepository,
            IAlunoRepository alunoRepository,
            IUsuarioEscolaPerfilRepository usuarioEscolaPerfilRepository,
            IAccessTokenGenerator tokenGenerator,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _passwordEncripter = passwordEncripter;
            _usuarioRepository = usuarioRepository;
            _alunoRepository = alunoRepository;
            _usuarioEscolaPerfilRepository = usuarioEscolaPerfilRepository;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseLoggedUsuarioJson> Execute(RequestLoginUsuarioJson request)
        {
            var usuario = await _usuarioRepository.GetByEmail(request.Email);
            if (usuario is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Senha, usuario.SenhaHash);
            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            var response = new ResponseLoggedUsuarioJson
            {
                Usuario = new ResponseShortUsuarioJson(),
                Token = string.Empty
            };

            var turma = await _alunoRepository.GetTurmaByAlunoId(usuario.Id);
            var perfis = await _usuarioEscolaPerfilRepository.GetAllByUsuarioIdAsync(usuario.Id);

            usuario.DataUltimoLogin = DateTime.Now;

            UpdateStreakIfAluno(usuario);

            return new ResponseLoggedUsuarioJson
            {
                Usuario = _mapper.Map<ResponseShortUsuarioJson>(usuario),
                Token = _tokenGenerator.Generate(usuario, turma, perfis)
            };
        }

        private void UpdateStreakIfAluno(Usuario usuario)
        {
            if (usuario is not Aluno aluno)
                return;

            if (aluno.DataUltimoAcessoStreak.Date.AddDays(1) == DateTime.Now.Date)
            {
                aluno.StreakDiasConsecutivos += 1;
                aluno.DataUltimoAcessoStreak = DateTime.Now;
            }
            else if (aluno.DataUltimoAcessoStreak.Date.AddDays(1) < DateTime.Now.Date)
            {
                aluno.StreakDiasConsecutivos = 0;
                aluno.DataUltimoAcessoStreak = DateTime.Now;
            }
        }
    }
}
