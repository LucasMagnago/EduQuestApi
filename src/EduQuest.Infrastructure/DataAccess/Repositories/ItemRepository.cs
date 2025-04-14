using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly EduQuestDbContext _context;

        public ItemRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IItemRepository.Add(Item item)
        {
            throw new NotImplementedException();
        }

        Task IItemRepository.Delete(Item item)
        {
            throw new NotImplementedException();
        }

        Task<Item> IItemRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IItemRepository.Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
