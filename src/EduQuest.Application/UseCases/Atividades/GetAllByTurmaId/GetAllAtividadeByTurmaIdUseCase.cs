using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Atividades.GetAllByTurmaId
{
    internal class GetAllAtividadeByTurmaIdUseCase : IGetAllAtividadeByTurmaIdUseCase
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public GetAllAtividadeByTurmaIdUseCase(IAtividadeRepository atividadeRepository,
            IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAtividadeJson>> Execute(int turmaId)
        {
            var result = await _atividadeRepository.GetAllAtividadeByTurmaId(turmaId);

            if (result is null)
                throw new NotFoundException("Atividades não encontradas");

            return _mapper.Map<List<ResponseAtividadeJson>>(result);
        }
    }
}
