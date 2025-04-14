using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface ITipoAtividadeRepository
    {
        Task Add(TipoAtividade tipoAtividade);
        Task Delete(TipoAtividade tipoAtividade);
        void Update(TipoAtividade tipoAtividade);
        Task<TipoAtividade> GetById(long id);
    }
}
