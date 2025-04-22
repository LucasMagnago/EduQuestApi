using EduQuest.Domain.Enums;

namespace EduQuest.Communication.Responses
{
    public class ResponseRegisteredMatriculaJson
    {
        public int Id { get; set; }
        public SituacaoMatricula Situacao { get; set; } = SituacaoMatricula.Normal;
        public DateTime DataMatricula { get; set; }
        public DateTime DataSituacao { get; set; }
        public DateTime DataExclusao { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public int UsuarioSituacaoId { get; set; }
        public int UsuarioExclusaoId { get; set; }
    }
}
