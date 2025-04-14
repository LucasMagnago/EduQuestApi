using EduQuest.Domain.Enums;

namespace EduQuest.Domain.Entities
{
    public class Matricula
    {
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; } = null!;
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; } = null!;

        public SituacaoMatricula Situacao { get; set; } = SituacaoMatricula.Normal;
        public DateTime DataMatricula { get; set; }

        public int UsuarioCriacaoId { get; set; }
        public Usuario UsuarioCriacao { get; set; } = default!;

        public DateTime DataSituacao { get; set; }
        public int UsuarioSituacaoId { get; set; }
        public Usuario UsuarioSituacao { get; set; } = default!;

        public DateTime DataExclusao { get; set; }
        public int UsuarioExclusaoId { get; set; }
        public Usuario UsuarioExclusao { get; set; } = default!;


    }
}
