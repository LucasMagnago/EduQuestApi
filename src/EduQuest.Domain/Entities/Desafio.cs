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
        public DateTime dataInicioVigencia { get; set; }
        public DateTime dataFimVigencia { get; set; }
        public EscopoDesafio Escopo { get; set; }
        public int XpRecompensa { get; set; }
        public int MoedasRecompensa { get; set; }
        public bool Ativo { get; set; }

        // 1. Questao ---> Disciplina
        public int UsuarioId { get; set; }
        public Usuario UsuarioCriacao { get; set; } = null!;

        // 2. Turma ---> DesafioEscola <--- Escola
        public virtual ICollection<DesafioEscola> DesafioEscolas { get; set; } = new HashSet<DesafioEscola>();

        // 3. Turma ---> DesafioTurma <--- Desafio
        public virtual ICollection<DesafioTurma> DesafioTurmas { get; set; } = new HashSet<DesafioTurma>();

        // 4. Aluno ---> AlunoProgressoCondicao <--- Desafio
        public virtual ICollection<DesafioCondicao> DesafioCondicoes { get; set; } = new HashSet<DesafioCondicao>();

        // 5. Aluno ---> ProgressoDesafioAluno <--- Desafio
        public virtual ICollection<AlunoProgressoDesafio> AlunoProgressoDesafios { get; set; } = new HashSet<AlunoProgressoDesafio>();
    }
}
