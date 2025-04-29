using System.Net;

namespace EduQuest.Exception.ExceptionsBase
{
    public class ConflictException : EduQuestException
    {
        public override int StatusCode => (int)HttpStatusCode.Conflict;

        public ConflictException(string message) : base(message)
        {
        }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
