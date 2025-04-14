using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        Task<Usuario> Get();
    }
}
