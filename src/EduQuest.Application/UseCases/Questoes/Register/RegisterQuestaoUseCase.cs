using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Questoes.Register
{
    internal class RegisterQuestaoUseCase : IRegisterQuestaoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterQuestaoUseCase(IMapper mapper, IQuestaoRepository questaoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _questaoRepository = questaoRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseQuestaoJson> Execute(RequestRegisterQuestaoJson request)
        {
            await Validate(request);

            var questao = _mapper.Map<Questao>(request);

            await _questaoRepository.SaveAsync(questao);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseQuestaoJson>(questao);
        }

        private async Task Validate(RequestRegisterQuestaoJson request)
        {
            var result = new RegisterQuestaoValidator().Validate(request);

            var existsUsuario = await _usuarioRepository.ExistsWithIdAsync(request.UsuarioCriacaoId);
            if (!existsUsuario)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A pessoa informada não foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
