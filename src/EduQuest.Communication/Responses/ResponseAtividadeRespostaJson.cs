﻿namespace EduQuest.Communication.Responses
{
    public class ResponseAtividadeRespostaJson
    {
        public int Id { get; set; }
        public bool Acertou { get; set; }
        public DateTime DataResposta { get; set; }
        public int AtividadeAlunoId { get; set; }
        public int QuestaoId { get; set; }
        public ResponseShortAlternativaJson AlternativaEscolha { get; set; } = null!;
    }
}
