namespace EduQuest.Communication.Responses
{
    public class ResponseShortAtividadeRespostaJson
    {
        public int Id { get; set; }
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }
        public int AtividadeAlunoId { get; set; }
        public int QuestaoId { get; set; }
        public int AlternativaEscolhaId { get; set; }
    }
}
