namespace EduQuest.Communication.Responses
{
    public class ResponseRegisteredUsuarioJson
    {
        public ResponseShortUsuarioJson Usuario { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
