using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoProgressoCondicao
    {
        [Key]
        public int Id { get; set; }
        public int ValorAtual { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        // 1. Aluno ---> AlunoProgressoCondicao <--- Desafio
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;
        public int DesafioConficaoId { get; set; }
        public DesafioCondicao DesafioCondicao { get; set; } = null!;
    }
}
