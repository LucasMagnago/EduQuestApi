using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor
{
    internal class RemoveProfessorFromTurmaUseCase : IRemoveProfessorFromTurmaUseCase
    {
        private readonly IAlocacaoProfessorRepository _alocacaoProfessorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveProfessorFromTurmaUseCase(IAlocacaoProfessorRepository alocacaoProfessorRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alocacaoProfessorRepository = alocacaoProfessorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(RequestRemoveProfessorFromTurmaJson request)
        {

            var alocacaoProfessor = _mapper.Map<AlocacaoProfessor>(request);

            var doesProfessorTeachDisciplinaInturma = await _alocacaoProfessorRepository.DoesProfessorTeachDisciplinaInTurma(request.ProfessorId, request.DisciplinaId, request.TurmaId);
            if (!doesProfessorTeachDisciplinaInturma)
                throw new NotFoundException("Professor não encontrado na turma informada");

            await _alocacaoProfessorRepository.DeleteAsync(alocacaoProfessor);
            await _unitOfWork.Commit();
        }
    }
}
