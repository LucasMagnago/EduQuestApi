namespace EduQuest.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
