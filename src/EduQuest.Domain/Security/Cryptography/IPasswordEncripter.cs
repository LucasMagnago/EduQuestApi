namespace EduQuest.Domain.Security.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string senha);
        bool Verify(string senha, string senhaHash);
    }
}
