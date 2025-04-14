using System.ComponentModel.DataAnnotations;

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
        public bool ativo { get; set; }
        public TipoUnidade TipoUnidade { get; set; } = default!;
        public ICollection<UsuarioPerfilEscola> UsuarioEscolaPerfis { get; set; } = new List<UsuarioPerfilEscola>();
    }
}
