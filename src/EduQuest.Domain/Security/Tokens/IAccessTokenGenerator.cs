using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        public string Generate(Usuario usuario, Turma? turma, List<UsuarioEscolaPerfil>? perfis);
    }
}
