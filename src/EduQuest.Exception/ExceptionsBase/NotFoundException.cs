using System.Net;

namespace EduQuest.Exception.ExceptionsBase
{
    internal class NotFoundException : EduQuestException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message)
        {
        }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
