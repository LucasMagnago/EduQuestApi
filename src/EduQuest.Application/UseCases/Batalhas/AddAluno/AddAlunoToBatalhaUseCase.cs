using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.Batalhas.AddAluno
{
    internal class AddAlunoToBatalhaUseCase : IAddAlunoToBatalhaUseCase
    {
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddAlunoToBatalhaUseCase(IBatalhaRepository batalhaRepository, IAlunoRepository alunoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _batalhaRepository = batalhaRepository;
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaJson> Execute(RequestAddAlunoToBatalhaJson request)
        {
            await Validate(request);

            var batalha = await _batalhaRepository.GetByIdAsync(request.BatalhaId);

            var batalhaFull = (batalha!.AlunoAId != 0 && batalha.AlunoBId != 0);
            if (batalhaFull)
            {
                throw new ConflictException("A batalha já possui dois alunos");
            }

            if (batalha.AlunoAId == 0)
            {
                batalha.AlunoAId = request.AlunoId;
            }
            else
            {
                batalha.AlunoBId = request.AlunoId;
            }

            await _batalhaRepository.UpdateAsync(batalha);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseBatalhaJson>(batalha);
        }

        private async Task Validate(RequestAddAlunoToBatalhaJson request)
        {
            var result = new AddAlunoToBatalhaValidator().Validate(request);

            bool existsAluno = await _alunoRepository.ExistsWithIdAsync(request.AlunoId);
            if (!existsAluno)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O aluno informado não existe"));
            }

            bool existsBatalha = await _batalhaRepository.ExistsWithIdAsync(request.BatalhaId);
            if (!existsBatalha)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A batalha informada foi encontrada"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
