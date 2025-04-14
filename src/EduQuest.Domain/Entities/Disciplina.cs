using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
    }
}
