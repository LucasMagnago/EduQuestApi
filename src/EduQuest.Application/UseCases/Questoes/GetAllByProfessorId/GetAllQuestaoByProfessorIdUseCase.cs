using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Questoes.GetAllByProfessorId
{
    internal class GetAllQuestaoByProfessorIdUseCase : IGetAllQuestaoByProfessorIdUseCase
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IMapper _mapper;

        public GetAllQuestaoByProfessorIdUseCase(IQuestaoRepository questaoRepository, IMapper mapper)
        {
            _questaoRepository = questaoRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseQuestaoJson>> Execute(int professorId)
        {
            var questoes = await _questaoRepository.GetAllByProfessorId(professorId);
            if (questoes == null || questoes.Count == 0)
            {
                throw new NotFoundException("Nenhuma qustão encontrada para o professor informado.");
            }
            return _mapper.Map<List<ResponseQuestaoJson>>(questoes);
        }
    }
}
