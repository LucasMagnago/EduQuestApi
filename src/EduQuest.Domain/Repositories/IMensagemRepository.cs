using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IMensagemRepository
    {
        Task Add(Mensagem mensagem);
        Task Delete(Mensagem mensagem);
        void Update(Mensagem mensagem);
        Task<Mensagem> GetById(long id);
    }
}
