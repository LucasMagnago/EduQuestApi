using EduQuest.Domain.Entities;

namespace EduQuest.Communication.Responses
{
    public class ResponseEscolaJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public string Inep { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public TipoUnidade TipoUnidade { get; set; } = null!;
    }
}
