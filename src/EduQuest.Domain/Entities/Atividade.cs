using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public int TempoLimiteSegundos { get; set; }
        public DateTime DataCriacao { get; set; }

        // Apenas a navegação para AlunoRealizaAtividade (que contêm o payload)
        public virtual ICollection<AlunoRealizaAtividade> AlunoRealizaAtividades { get; set; } = new HashSet<AlunoRealizaAtividade>();
    }
}
