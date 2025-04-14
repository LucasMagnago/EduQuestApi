using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class TipoUnidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
    }
}
