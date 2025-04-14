using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IPeriodoLetivoRepository
    {
        Task Add(PeriodoLetivo periodoLetivo);
        Task Delete(PeriodoLetivo periodoLetivo);
        void Update(PeriodoLetivo periodoLetivo);
        Task<PeriodoLetivo> GetById(long id);
    }
}
