using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        public string Generate(Usuario usuario, Matricula? matricula, List<UsuarioEscolaPerfil>? perfis);
    }
}
