namespace EduQuest.Domain.Services.AssignRewards
{
    public interface IAssignRewardsService
    {
        Task AssignByBatalha(int alunoId, int batalhaId, bool venceu);
        Task AssignByAtividade(int alunoId, int atividadeId);
    }
}
