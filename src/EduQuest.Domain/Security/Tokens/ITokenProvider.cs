namespace EduQuest.Domain.Security.Tokens
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
