using EduQuest.Domain.Enums;

namespace EduQuest.Communication.Responses
{
    public class ResponseBatalhaJson
    {
        public int Id { get; set; }
        public StatusBatalha Status { get; set; }
        public int XpConcedidoVencedor { get; set; }
        public int XpConcedidoPerdedor { get; set; }
        public int MoedasConcedidasVencedor { get; set; }
        public int MoedasConcedidasPerdedor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int AlunoAId { get; set; }
        public int AlunoBId { get; set; }
        public ICollection<ResponseBatalhaQuestaoJson> BatalhaQuestoes { get; set; } = new HashSet<ResponseBatalhaQuestaoJson>();
        public virtual ICollection<ResponseShortBatalhaRespostaJson> BatalhaRespostas { get; set; } = new HashSet<ResponseShortBatalhaRespostaJson>();
    }
}
