using System.Net;

namespace EduQuest.Exception.ExceptionsBase
{
    public class InsufficientQuestoesException : EduQuestException
    {
        public override int StatusCode => (int)HttpStatusCode.Conflict;

        public InsufficientQuestoesException(string message) : base(message)
        {
        }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
