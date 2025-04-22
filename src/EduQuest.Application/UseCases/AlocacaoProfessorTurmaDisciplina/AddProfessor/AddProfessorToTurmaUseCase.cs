using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor
{
    internal class AddProfessorToTurmaUseCase : IAddProfessorToTurmaUseCase
    {
        private readonly IAlocacaoProfessorRepository _alocacaoProfessorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProfessorToTurmaUseCase(IAlocacaoProfessorRepository alocacaoProfessorRepository,
            IUsuarioRepository usuarioRepository,
            ITurmaRepository turmaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alocacaoProfessorRepository = alocacaoProfessorRepository;
            _usuarioRepository = usuarioRepository;
            _turmaRepository = turmaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseAlocacaoProfessorJson> Execute(RequestAddProfessorToTurmaJson request)
        {
            await Validate(request);

            var alocacaoProfessor = _mapper.Map<AlocacaoProfessor>(request);

            await _alocacaoProfessorRepository.SaveAsync(alocacaoProfessor);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseAlocacaoProfessorJson>(alocacaoProfessor);
        }

        private async Task Validate(RequestAddProfessorToTurmaJson request)
        {
            var result = new AddProfessorToTurmaValidator().Validate(request);

            var existsUsuario = await _usuarioRepository.ExistsWithIdAsync(request.ProfessorId);
            if (!existsUsuario)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O professor informado não foi encontrado"));
            }

            var existsTurma = await _turmaRepository.ExistsWithIdAsync(request.TurmaId);
            if (!existsTurma)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A turma informada não foi encontrada"));
            }

            var existsDisciplina = await _usuarioRepository.ExistsWithIdAsync(request.DisciplinaId);
            if (!existsDisciplina)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "A disciplina informada não foi encontrada"));
            }

            var doesProfessorTeachDisciplinaInturma = await _alocacaoProfessorRepository.DoesProfessorTeachDisciplinaInTurma(request.ProfessorId, request.TurmaId, request.DisciplinaId);
            if (doesProfessorTeachDisciplinaInturma)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "O professor já leciona esta disciplina na turma"));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
