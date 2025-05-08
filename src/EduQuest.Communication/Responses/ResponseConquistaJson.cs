namespace EduQuest.Communication.Responses
{
    public class ResponseConquistaJson
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string IconeUrl { get; set; } = string.Empty;
        public string CriterioTipo { get; set; } = string.Empty;
        public string CriterioValor { get; set; } = string.Empty;
    }
}
