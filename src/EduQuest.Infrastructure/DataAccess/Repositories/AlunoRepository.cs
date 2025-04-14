using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlunoRepository : IAlunoRepository
    {
        private readonly EduQuestDbContext _context;

        public AlunoRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
        }

        public async Task Delete(Aluno aluno)
        {
            var alunoToRemove = await _context.Alunos.FindAsync(aluno.Id);
            _context.Usuarios.Remove(alunoToRemove!);
        }

        public async Task<Aluno> GetById(int id)
        {
            return await _context.Alunos.FirstAsync(aluno => aluno.Id == id);
        }

        public void Update(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public Task<bool> Matricular(int turmaId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remanejar(int turmaDestinoId)
        {
            throw new NotImplementedException();
        }
    }
}
