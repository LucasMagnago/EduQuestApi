using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Escola
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public string Inep { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }

        // 1. Escola ---> TipoUnidade
        public int TipoUnidadeId { get; set; }
        public TipoUnidade TipoUnidade { get; set; } = default!;

        // 2. Escola ---> DesafioEscola <--- Desafio
        [JsonIgnore]
        public virtual ICollection<DesafioEscola> DesafiosEscolas { get; set; } = new HashSet<DesafioEscola>();

        // 2. Usuario ---> UsuarioPerfilEscola <--- Escola
        //                        ^
        //                        |
        //                      Perfil
        [JsonIgnore]
        public virtual ICollection<UsuarioEscolaPerfil> UsuarioEscolaPerfis { get; set; } = new List<UsuarioEscolaPerfil>();
    }
}
