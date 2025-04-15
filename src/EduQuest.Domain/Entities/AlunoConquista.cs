using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoConquista
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataObtencao { get; set; }

        // 1. Aluno ---> AlunoConquista <--- Conquista
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;
        public int ConquistaId { get; set; }
        public Conquista Conquista { get; set; } = default!;
    }
}
