using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class DesafioCondicao
    {
        [Key]
        public int Id { get; set; }
        public Desafio Desafio { get; set; } = default!;
        public string TipoCondicao { get; set; } = string.Empty;
        public string DescricaoCondicao { get; set; } = string.Empty;
        public int ValorObjetivo { get; set; }
        public DateTime DataInicioContagem { get; set; }
        public DateTime DataFimContagem { get; set; }
    }
}
