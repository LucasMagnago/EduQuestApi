using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
