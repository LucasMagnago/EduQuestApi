namespace EduQuest.Communication.Responses
{
    public class ResponseShortUsuarioJson
    {
        public int Id { get; set; }
        public Guid UsuarioIdentifier { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
