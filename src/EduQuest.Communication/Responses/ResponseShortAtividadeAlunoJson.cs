﻿using EduQuest.Domain.Enums;

namespace EduQuest.Communication.Responses
{
    public class ResponseShortAtividadeAlunoJson
    {
        public int Id { get; set; }
        public int AtividadeId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? PontuacaoObtida { get; set; }
        public int? XpGanho { get; set; }
        public int? MoedasGanhas { get; set; }
        public string FeedbackProfessor { get; set; } = string.Empty;
        public StatusAtividade Status { get; set; } = StatusAtividade.Pendente;
    }
}
