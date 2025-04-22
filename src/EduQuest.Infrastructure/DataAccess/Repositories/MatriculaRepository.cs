namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    //internal class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    //{
    //    public MatriculaRepository(EduQuestDbContext context) : base(context)
    //    {

    //    }

    //    public async Task<Matricula?> GetMatriculaAtivaByAlunoId(int alunoId)
    //    {
    //        return await _context.Matriculas
    //            .Where(m => m.AlunoId == alunoId && m.Situacao == SituacaoMatricula.Normal)
    //            .FirstOrDefaultAsync();
    //    }

    //    public async Task<Matricula?> GetMatriculaAtivaByAlunoGuid(Guid alunoGuid)
    //    {
    //        return await _context.Matriculas
    //            .Where(m => m.Aluno.UsuarioIdentifier == alunoGuid && m.Situacao == SituacaoMatricula.Normal)
    //            .FirstOrDefaultAsync();
    //    }

    //    public async Task<Matricula?> GetMatriculaAtivaByAlunoIdAndPeriodoLetivoId(int alunoId, int periodoLetivoId)
    //    {
    //        return await _context.Matriculas
    //            .Include(m => m.Turma)
    //            .Where(m => m.AlunoId == alunoId &&
    //                m.Turma.PeriodoLetivoId == periodoLetivoId &&
    //                m.Situacao == SituacaoMatricula.Normal)
    //            .FirstOrDefaultAsync();
    //    }

    //    public async Task<bool> ExistsMatriculaAtivaByAlunoIdAndPeriodoLetivoId(int alunoId, int periodoLetivoId)
    //    {
    //        return await _context.Matriculas
    //        .Where(m =>
    //            m.AlunoId == alunoId &&
    //            m.Turma.PeriodoLetivoId == periodoLetivoId &&
    //            m.Situacao == SituacaoMatricula.Normal)
    //        .AnyAsync();
    //    }

    //    public async Task<List<Matricula>?> GetAllByAlunoId(int alunoId)
    //    {
    //        return await _context.Matriculas
    //        .Where(m => m.AlunoId == alunoId)
    //        .ToListAsync();
    //    }
    //}
}
