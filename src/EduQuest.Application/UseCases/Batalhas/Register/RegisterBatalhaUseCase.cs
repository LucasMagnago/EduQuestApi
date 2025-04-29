using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Batalhas.Register
{
    internal class RegisterBatalhaUseCase : IRegisterBatalhaUseCase
    {
        private readonly IBatalhaQuestaoRepository _batalhaQuestaoRepository;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterBatalhaUseCase(IBatalhaQuestaoRepository batalhaQuestaoRepository,
            IBatalhaRepository batalhaRepository,
            IQuestaoRepository questaoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _batalhaQuestaoRepository = batalhaQuestaoRepository;
            _batalhaRepository = batalhaRepository;
            _questaoRepository = questaoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseBatalhaJson> Execute(RequestRegisterBatalhaJson request)
        {
            var batalha = _mapper.Map<Batalha>(request);
            batalha.DataCriacao = DateTime.Now;
            batalha.Status = StatusBatalha.AguardandoInicio;
            batalha.XpConcedidoVencedor = 100;
            batalha.XpConcedidoPerdedor = 50;
            batalha.MoedasConcedidasVencedor = 100;
            batalha.MoedasConcedidasPerdedor = 50;

            await _batalhaRepository.SaveAsync(batalha);
            await _unitOfWork.Commit();

            var questoes = await _questaoRepository.GetRandomQuestoesAsync(10);
            if (questoes is null || questoes.Count < 10)
            {
                throw new InsufficientQuestoesException("Não existem questões suficientes para criar a batalha.");
            }

            var batalhaQuestoes = questoes.Select((questao, index) => new BatalhaQuestao
            {
                BatalhaId = batalha.Id,
                QuestaoId = questao.Id,
                Ordem = index + 1
            }).ToList();

            foreach (var batalhaQuestao in batalhaQuestoes)
            {
                await _batalhaQuestaoRepository.SaveAsync(batalhaQuestao);
            }

            batalha.BatalhaQuestoes = batalhaQuestoes;

            return _mapper.Map<ResponseBatalhaJson>(batalha);
        }
    }
}
