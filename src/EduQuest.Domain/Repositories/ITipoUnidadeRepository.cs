using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface ITipoUnidadeRepository
    {
        Task Add(TipoUnidade tipoUnidade);
        Task Delete(TipoUnidade tipoUnidade);
        void Update(TipoUnidade tipoUnidade);
        Task<TipoUnidade> GetById(long id);
    }
}
