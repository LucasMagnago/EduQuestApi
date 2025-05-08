using EduQuest.Domain.Enums;

namespace EduQuest.Communication.Responses
{
    public class ResponseItemJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoItem Tipo { get; set; }
        public int Custo { get; set; }
        public int XpDesbloqueio { get; set; }
        public string ImagemBase64 { get; set; } = string.Empty;
    }
}
