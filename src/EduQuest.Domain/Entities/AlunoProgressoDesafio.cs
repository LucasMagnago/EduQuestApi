using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoProgressoDesafio
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataConclusao { get; set; }

        // 1. Aluno ---> AlunoProgressoDesafio <--- Desafio
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; } = null!;

    }
}
