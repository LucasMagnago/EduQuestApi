using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IMatriculaRepository : IGenericRepository<Matricula>
    {
        Task<Matricula?> GetMatriculaAtivaByUsuarioId(int alunoId);
        Task<Matricula?> GetMatriculaAtivaByUsuarioGuid(Guid alunoGuid);
    }
}
