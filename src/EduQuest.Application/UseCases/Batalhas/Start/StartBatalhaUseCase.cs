using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Batalhas.Start
{
    internal class StartBatalhaUseCase : IStartBatalhaUseCase
    {
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StartBatalhaUseCase(IBatalhaRepository batalhaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _batalhaRepository = batalhaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaJson> Execute(RequestStartBatalhaJson request)
        {
            await Validate(request);

            var batalha = await _batalhaRepository.GetByIdAsync(request.BatalhaId);
            if (batalha == null)
            {
                throw new NotFoundException("Batalha não encontrada");
            }

            batalha.Status = StatusBatalha.EmAndamento;
            batalha.DataInicio = DateTime.Now;

            await _batalhaRepository.UpdateAsync(batalha);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseBatalhaJson>(batalha);
        }


        public async Task Validate(RequestStartBatalhaJson request)
        {
            var result = new StartBatalhaValidator().Validate(request);

            var batalha = await _batalhaRepository.GetByIdAsync(request.BatalhaId);
            if (batalha == null)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Batalha não encontrada"));
            }

            if (batalha!.Status != StatusBatalha.AguardandoInicio)
            {
                throw new ConflictException("A batalha não pode ser iniciada devido ao status atual");

            }

            if (batalha.AlunoAId == 0 || batalha.AlunoBId == 0)
            {
                throw new ConflictException("A batalha não possui dois alunos");
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

