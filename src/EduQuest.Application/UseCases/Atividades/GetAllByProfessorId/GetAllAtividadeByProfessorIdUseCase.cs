using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Atividades.GetAllByProfessorId
{
    internal class GetAllAtividadeByProfessorIdUseCase : IGetAllAtividadeByProfessorIdUseCase
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMapper _mapper;

        public GetAllAtividadeByProfessorIdUseCase(IAtividadeRepository atividadeRepository,
            IMapper mapper)
        {
            _atividadeRepository = atividadeRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseAtividadeJson>> Execute(int professorId)
        {
            var result = await _atividadeRepository.GetAllAtividadeByProfessorId(professorId);

            if (result is null)
                throw new NotFoundException("Atividades não encontradas");

            return _mapper.Map<List<ResponseAtividadeJson>>(result);
        }
    }
}
