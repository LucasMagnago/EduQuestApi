using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoItem Tipo { get; set; }

        // 1. Aluno ---> AlunoPossuiItem <--- Item
        [JsonIgnore]
        public virtual ICollection<AlunoPossuiItem> AlunoPossuiItens { get; set; } = new HashSet<AlunoPossuiItem>();
    }
}
