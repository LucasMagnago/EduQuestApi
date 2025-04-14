using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoItem Tipo { get; set; }

        public List<Aluno> Alunos { get; } = [];
    }
}
