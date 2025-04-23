using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Atividades.Register
{
    public class RegisterAtividadeUseCase : IRegisterAtividadeUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeRepository _atiividadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAtividadeUseCase(IMapper mapper,
            IAtividadeRepository atividadeRepository,
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atiividadeRepository = atividadeRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredAtividadeJson> Execute(RequestRegisterAtividadeJson request)
        {
            await Validate(request);

            var atividade = _mapper.Map<Atividade>(request);
            atividade.DataCriacao = DateTime.Now;

            await _atiividadeRepository.SaveAsync(atividade);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredAtividadeJson>(request);
        }

        private async Task Validate(RequestRegisterAtividadeJson request)
        {
            var result = new RegisterAtividadeValidator().Validate(request);

            bool existsProfessor = await _usuarioRepository.ExistsWithIdAsync(request.ProfessorId);
            if (!existsProfessor)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O professor informado não existe"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
