namespace EduQuest.Communication.Requests
{
    public class RequestRegisterPeriodoLetivoJson
    {
        public Int16 Ano { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public bool Ativo { get; set; }
        public int EscolaId { get; set; }
    }
}
