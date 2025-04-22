namespace EduQuest.Communication.Responses
{
    public class ResponseRegisteredEscolaJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public string Inep { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int TipoUnidadeId { get; set; }
    }
}
