namespace QualificationExam.Domain.Exceptions
{
    public class HandledException : Exception
    {
        public HandledException(string exceptionMessage) : base(exceptionMessage) { }
    }
}