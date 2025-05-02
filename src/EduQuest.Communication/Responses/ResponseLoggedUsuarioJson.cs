namespace EduQuest.Communication.Responses
{
    public class ResponseLoggedUsuarioJson
    {
        public ResponseShortUsuarioJson Usuario { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
