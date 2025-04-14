using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Questao
    {
        [Key]
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;

        //public Disciplina Disciplina { get; set; } = default!;
        //public Curso Curso { get; set; } = default!;
        //public Alternativa AlternativaCorreta { get; set; } = default!;
        //public Usuario UsuarioCriacao { get; set; } = default!;
    }
}
