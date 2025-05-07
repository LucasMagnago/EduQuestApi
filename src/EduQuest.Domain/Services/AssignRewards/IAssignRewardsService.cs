namespace EduQuest.Domain.Services.AssignRewards
{
    public interface IAssignRewardsService
    {
        Task AssignByBatalha(int batalhaId);
        Task AssignByAtividade(int atividadeAlunoId);
    }
}
