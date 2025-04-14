using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class MensagemRepository : IMensagemRepository
    {
        private readonly EduQuestDbContext _context;

        public MensagemRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IMensagemRepository.Add(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }

        Task IMensagemRepository.Delete(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }

        Task<Mensagem> IMensagemRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IMensagemRepository.Update(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
