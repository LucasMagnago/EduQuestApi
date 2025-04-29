namespace EduQuest.Communication.Responses
{
    public class ResponseBatalhaRespostaJson
    {
        public int Id { get; set; }
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }
        public int BatalhaId { get; set; }
        public int QuestaoId { get; set; }
        public int AlternativaEscolhaId { get; set; }
        public int AlunoId { get; set; }
    }
}
