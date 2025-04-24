using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AtividadeTurmas.Unassign
{
    internal class UnassignAtividadeFromTurmaUseCase : IUnassignAtividadeFromTurmaUseCase
    {
        public readonly IMapper _mapper;
        public readonly IAtividadeTurmaRepository _atividadeTurmaRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UnassignAtividadeFromTurmaUseCase(IMapper mapper,
            IAtividadeTurmaRepository atividadeTurmaRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _atividadeTurmaRepository = atividadeTurmaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseUnassignedAtividadeFromTurmaJson> Execute(int atividadeTurmaId)
        {
            var atividadeTurma = await _atividadeTurmaRepository.GetByIdAsync(atividadeTurmaId);
            if (atividadeTurma == null)
            {
                throw new NotFoundException("Atividade não encontrada");
            }

            var response = _mapper.Map<ResponseUnassignedAtividadeFromTurmaJson>(atividadeTurma);
            response.DeletedAt = DateTime.Now;

            await _atividadeTurmaRepository.DeleteAsync(atividadeTurma);
            await _unitOfWork.Commit();

            return response;
        }
    }
}
