namespace EduQuest.Domain.Services.UpdateStatistics
{
    public interface IUpdateStatisticsService
    {
        Task UpdateAlunoStatistics(int alunoId);
        Task UpdateTurmaStatistics(int turmaId);
        Task UpdateEscolaStatistics(int escolaId);
    }
}
