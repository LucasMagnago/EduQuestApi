using EduQuest.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace EduQuest.Infrastructure.Security.Cryptography
{
    public class BCrypt : IPasswordEncripter
    {
        public string Encrypt(string senha)
        {
            string senhaHash = BC.HashPassword(senha);

            return senhaHash;
        }

        public bool Verify(string senha, string senhaHash) => BC.Verify(senha, senhaHash);
    }
}


