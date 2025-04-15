using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class AlunoPossuiItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataAquisicao { get; set; }

        // 1. Aluno ---> AlunoPossuiItem <--- Item
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = default!;
    }
}
