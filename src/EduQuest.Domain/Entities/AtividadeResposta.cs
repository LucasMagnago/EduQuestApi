using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AtividadeResposta
    {
        [Key]
        public int Id { get; set; }
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }

        public int AtividadeAlunoId { get; set; }
        public virtual AtividadeAluno AtividadeAluno { get; set; } = null!;

        public int QuestaoId { get; set; }
        public virtual Questao Questao { get; set; } = null!;

        public int AlternativaEscolhaId { get; set; }
        public virtual Alternativa AlternativaEscolha { get; set; } = null!;
    }
}
