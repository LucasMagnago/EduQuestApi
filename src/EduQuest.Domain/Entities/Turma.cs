using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Turno { get; set; }
        public int Inep { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public Curso Curso { get; set; } = default!;
        public PeriodoLetivo PeriodoLetivo { get; set; } = default!;

        // Apenas a navegação para as Matrículas (que contêm o payload)
        public virtual ICollection<Matricula> Matriculas { get; set; } = new HashSet<Matricula>();

    }
}
