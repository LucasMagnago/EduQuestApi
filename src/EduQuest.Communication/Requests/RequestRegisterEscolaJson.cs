namespace EduQuest.Communication.Requests
{
    public class RequestRegisterEscolaJson
    {
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public string Inep { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int TipoUnidadeId { get; set; }
    }
}
