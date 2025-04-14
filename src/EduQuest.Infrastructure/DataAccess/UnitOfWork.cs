using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly EduQuestDbContext _dbContext;

        public UnitOfWork(EduQuestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
