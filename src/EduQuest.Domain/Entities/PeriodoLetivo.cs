using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class PeriodoLetivo
    {
        [Key]
        public int Id { get; set; }
        public Int16 Ano { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public bool Ativo { get; set; }
        public Escola Escola { get; set; } = default!;
    }
}
