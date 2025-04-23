using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Atividades.GetAllByAlunoId
{
    internal class GetAllAtividadeByAlunoIdUseCase : IGetAllAtividadeByAlunoIdUseCase
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public GetAllAtividadeByAlunoIdUseCase(IAtividadeRepository atividadeRepository,
            IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAtividadeJson>> Execute(int alunoId)
        {
            var result = await _atividadeRepository.GetAllAtividadeByAlunoId(alunoId);

            if (result is null)
                throw new NotFoundException("Atividades não encontradas");

            return _mapper.Map<List<ResponseAtividadeJson>>(result);
        }
    }
}
