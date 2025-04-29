using EduQuest.Domain.Entities;

namespace EduQuest.Communication.Responses
{
    public class ResponseBatalhaJson
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public int XpConcedidoVencedor { get; set; }
        public int XpConcedidoPerdedor { get; set; }
        public int MoedasConcedidasVencedor { get; set; }
        public int MoedasConcedidasPerdedor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AlunoAId { get; set; }
        public int AlunoBId { get; set; }
        public ICollection<Questao> BatalhaQuestoes { get; set; } = new HashSet<Questao>();
        public virtual ICollection<BatalhaResposta> BatalhaRespostas { get; set; } = new HashSet<BatalhaResposta>();
    }
}
