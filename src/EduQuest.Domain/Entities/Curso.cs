using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Curso? ProximoCurso { get; set; }
    }
}
