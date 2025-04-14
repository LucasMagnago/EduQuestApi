namespace EduQuest.Domain.Entities
{
    public class BatalhaRespostaParticipante
    {
        public int Id { get; set; }
        public string RespostaDada { get; set; } = string.Empty;
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }

        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; } = default!;

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;

        public int QuestaoId { get; set; }
        public Questao Questao { get; set; } = default!;
    }
}
