namespace EduQuest.Exception.ExceptionsBase
{
    public abstract class EduQuestException : SystemException
    {
        public abstract int StatusCode { get; }

        protected EduQuestException(string message) : base(message)
        {

        }

        public abstract List<string> GetErrors();
    }
}
