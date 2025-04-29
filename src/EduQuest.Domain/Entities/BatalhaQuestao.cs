using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class BatalhaQuestao
    {
        [Key]
        public int Id { get; set; }
        public int Ordem { get; set; }

        public int BatalhaId { get; set; }
        [JsonIgnore]
        public virtual Batalha Batalha { get; set; } = null!;
        public int QuestaoId { get; set; }
        [JsonIgnore]
        public virtual Questao Questao { get; set; } = null!;
    }
}
