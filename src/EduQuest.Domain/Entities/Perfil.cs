using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        // 1. Usuario ---> UsuarioPerfilEscola <--- Escola
        //                        ^
        //                        |
        //                      Perfil
        public ICollection<UsuarioEscolaPerfil> UsuarioEscolaPerfis { get; set; } = new List<UsuarioEscolaPerfil>();
    }
}
