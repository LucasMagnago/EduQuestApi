namespace EduQuest.Communication.Requests
{
    public class RequestRegisterUsuarioJson
    {
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool IsAluno { get; set; }
    }
}
