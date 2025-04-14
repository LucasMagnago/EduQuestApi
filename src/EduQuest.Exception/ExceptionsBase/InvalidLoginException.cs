using System.Net;

namespace EduQuest.Exception.ExceptionsBase
{
    public class InvalidLoginException : EduQuestException
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public InvalidLoginException() : base("E-mail e/ou senha inválidos.")
        {
        }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
