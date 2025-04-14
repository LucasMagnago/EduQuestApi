using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        string Generate(Usuario usuario);
    }
}
