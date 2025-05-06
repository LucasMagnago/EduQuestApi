using EduQuest.Domain.Repositories;
using EduQuest.Domain.Services.AssignRewards;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.Services.AssignRewards
{
    internal class AssignRewardsService : IAssignRewardsService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignRewardsService(IAlunoRepository alunoRepository,
            IAtividadeRepository atividadeRepository,
            IBatalhaRepository batalhaRepository,
            IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _atividadeRepository = atividadeRepository;
            _batalhaRepository = batalhaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AssignByBatalha(int alunoId, int batalhaId, bool venceu)
        {
            var aluno = await _alunoRepository.GetByIdAsync(alunoId);
            if (aluno == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }

            var batalha = await _batalhaRepository.GetByIdAsync(batalhaId);
            if (batalha == null)
            {
                throw new NotFoundException("Batalha não encontrada");
            }

            var xp = venceu ? batalha.XpConcedidoVencedor : batalha.XpConcedidoPerdedor;
            var moedas = venceu ? batalha.MoedasConcedidasVencedor : batalha.MoedasConcedidasPerdedor;

            aluno.AddXp(xp);
            aluno.AddMoedas(moedas);

            await _unitOfWork.Commit();
        }

        public async Task AssignByAtividade(int alunoId, int atividadeId)
        {
            var aluno = await _alunoRepository.GetByIdAsync(alunoId);
            if (aluno == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }

            var atividade = await _atividadeRepository.GetByIdAsync(atividadeId);
            if (atividade == null)
            {
                throw new NotFoundException("Atividade não encontrada");
            }

            // Você pode ter regras por tipo/dificuldade da atividade
            var xp = atividade.XpRecompensa;
            var moedas = atividade.MoedasRecompensa;

            aluno.AddXp(xp);
            aluno.AddMoedas(moedas);

            await _unitOfWork.Commit();
        }
    }
}
