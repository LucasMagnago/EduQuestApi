using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class DesafioCondicao
    {
        [Key]
        public int Id { get; set; }

        public string TipoCondicao { get; set; } = string.Empty;
        public string DescricaoCondicao { get; set; } = string.Empty;
        public int ValorObjetivo { get; set; }
        public DateTime DataInicioContagem { get; set; }
        public DateTime DataFimContagem { get; set; }

        // 1. Desafio ---> DesafioCondicao
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; } = null!;

        // 2. TipoCondicao ---> DesafioCondicao
        public int TipoCondicaoId { get; set; }
        public TipoCondicao TipoCondicaoNavigation { get; set; } = null!;

        // 3. Aluno ---> AlunoProgressoCondicao <--- DesafioCondicao
        public virtual ICollection<AlunoProgressoCondicao> AlunoProgressoCondicoes { get; set; } = new HashSet<AlunoProgressoCondicao>();
    }
}
