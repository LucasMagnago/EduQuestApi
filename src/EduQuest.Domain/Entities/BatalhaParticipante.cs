using EduQuest.Domain.Enums;

namespace EduQuest.Domain.Entities
{
    public class BatalhaParticipante
    {
        public int Id { get; set; }
        public int Pontuacao { get; set; }
        public int TempoTotalSegundos { get; set; }
        public int XpRecebido { get; set; }
        public int MoedaRecebidas { get; set; }
        public StatusParticipanteBatalha Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int batalhaId { get; set; }
        public Batalha Batalha { get; set; } = default!;

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;
    }
}
