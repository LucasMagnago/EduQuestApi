using EduQuest.Domain.Repositories;
using EduQuest.Domain.Services.AssignRewards;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.Services.AssignRewards
{
    internal class AssignRewardsService : IAssignRewardsService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IAtividadeAlunoRepository _atividadeAlunoRepository;
        private readonly IBatalhaRepository _batalhaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignRewardsService(IAlunoRepository alunoRepository,
            IAtividadeRepository atividadeRepository,
            IAtividadeAlunoRepository atividadeAlunoRepository,
            IBatalhaRepository batalhaRepository,
            IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _atividadeRepository = atividadeRepository;
            _atividadeAlunoRepository = atividadeAlunoRepository;
            _batalhaRepository = batalhaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AssignByBatalha(int batalhaId)
        {
            var batalha = await _batalhaRepository.GetByIdAsync(batalhaId)
                ?? throw new NotFoundException("Batalha não encontrada.");

            if (batalha.AlunoAId is null || batalha.AlunoBId is null)
                throw new NotFoundException("Um ou mais alunos não foram encontrados.");

            var alunoA = await _alunoRepository.GetByIdAsync(batalha.AlunoAId.Value)
                ?? throw new NotFoundException("Aluno A não encontrado.");

            var alunoB = await _alunoRepository.GetByIdAsync(batalha.AlunoBId.Value)
                ?? throw new NotFoundException("Aluno B não encontrado.");

            var xpAlunoA = batalha.AlunoVencedorId == batalha.AlunoAId
                ? batalha.XpConcedidoVencedor
                : batalha.XpConcedidoPerdedor;
            var moedasAlunoA = batalha.AlunoVencedorId == batalha.AlunoAId
                ? batalha.MoedasConcedidasVencedor
                : batalha.MoedasConcedidasPerdedor;

            var xpAlunoB = batalha.AlunoVencedorId == batalha.AlunoBId
                ? batalha.XpConcedidoVencedor
                : batalha.XpConcedidoPerdedor;
            var moedasAlunoB = batalha.AlunoVencedorId == batalha.AlunoBId
                ? batalha.MoedasConcedidasVencedor
                : batalha.MoedasConcedidasPerdedor;

            alunoA.AddXp(xpAlunoA);
            alunoA.AddMoedas(xpAlunoA);
            alunoB.AddXp(xpAlunoB);
            alunoB.AddMoedas(xpAlunoB);

            await _alunoRepository.UpdateAsync(alunoA);
            await _alunoRepository.UpdateAsync(alunoB);
            await _unitOfWork.Commit();
        }

        public async Task AssignByAtividade(int atividadeAlunoId)
        {
            var atividadeAluno = await _atividadeAlunoRepository.GetByIdAsync(atividadeAlunoId);
            if (atividadeAluno is null)
            {
                throw new NotFoundException("Atividade do aluno não encontrada");
            }

            var aluno = await _alunoRepository.GetByIdAsync(atividadeAluno.AlunoId);
            if (aluno is null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }

            var atividade = await _atividadeRepository.GetByIdAsync(atividadeAluno.AtividadeId);
            if (atividade is null)
            {
                throw new NotFoundException("Atividade não encontrada");
            }

            // Você pode ter regras por tipo/dificuldade da atividade
            var xp = atividadeAluno.XpGanho > 0 ? (int)atividadeAluno.XpGanho : 0;
            var moedas = atividadeAluno.MoedasGanhas > 0 ? (int)atividadeAluno.MoedasGanhas : 0;

            aluno.AddXp(xp);
            aluno.AddMoedas(moedas);

            await _unitOfWork.Commit();
        }
    }
}
