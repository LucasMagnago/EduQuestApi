using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Alternativa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Ordem { get; set; }

        // Altenativa ---> Questao
        public int QuestaoId { get; set; }
        [JsonIgnore]
        public Questao Questao { get; set; } = default!;
    }
}
