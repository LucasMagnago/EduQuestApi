using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class QuestaoRepository : IQuestaoRepository
    {
        private readonly EduQuestDbContext _context;

        public QuestaoRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IQuestaoRepository.Add(Questao questao)
        {
            throw new NotImplementedException();
        }

        Task IQuestaoRepository.Delete(Questao questao)
        {
            throw new NotImplementedException();
        }

        Task<Questao> IQuestaoRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IQuestaoRepository.Update(Questao questao)
        {
            throw new NotImplementedException();
        }
    }
}
