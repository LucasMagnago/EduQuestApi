using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduQuest.Domain.Entities
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;

        // 1. Usuario ---> AlocacaoProfessor <--- Turma
        //                        ^
        //                        |
        //                    Disciplina
        [JsonIgnore]
        public virtual ICollection<AlocacaoProfessor> AlocacaoProfessores { get; set; } = new HashSet<AlocacaoProfessor>();
    }
}
