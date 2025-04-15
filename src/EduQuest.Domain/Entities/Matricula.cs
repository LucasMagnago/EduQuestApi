using EduQuest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; }

        public SituacaoMatricula Situacao { get; set; } = SituacaoMatricula.Normal;
        public DateTime DataMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
        public DateTime DataExclusao { get; set; }

        // 1. Matricula ---> Aluno
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; } = null!;
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; } = null!;

        // 2. Matricula ---> Usuário (Criação)
        public int UsuarioCriacaoId { get; set; }
        public Usuario UsuarioCriacao { get; set; } = default!;

        // 3. Matricula ---> Usuário (Situação)
        public int UsuarioSituacaoId { get; set; }
        public Usuario UsuarioSituacao { get; set; } = default!;

        // 4. Matricula ---> Usuário (Alteração)
        public int UsuarioExclusaoId { get; set; }
        public Usuario? UsuarioExclusao { get; set; }


    }
}
