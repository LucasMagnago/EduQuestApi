using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Desafio
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Usuario UsuarioCriacao { get; set; } = default!;
        public DateTime dataInicioVigencia { get; set; }
        public DateTime dataFimVigencia { get; set; }
        public EscopoDesafio Escopo { get; set; }
        public int XpRecompensa { get; set; }
        public int MoedasRecompensa { get; set; }
        public Conquista? Conquista { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Escola>? Escolas { get; set; }
        public ICollection<Turma>? Turmas { get; set; }
    }
}
