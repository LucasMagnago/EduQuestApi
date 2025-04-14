using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoProgressoCondicaoDesafio
    {
        [Key]
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int CondicaoId { get; set; }
        public int ValorAtual { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
    }
}
