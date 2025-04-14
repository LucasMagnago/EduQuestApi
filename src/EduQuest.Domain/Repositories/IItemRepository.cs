using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IItemRepository
    {
        Task Add(Item item);
        Task Delete(Item item);
        void Update(Item item);
        Task<Item> GetById(long id);
    }
}
