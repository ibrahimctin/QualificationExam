namespace QualificationExam.Domain.Exceptions
{
    public class HandledExceptionList : Exception
    {
        public ICollection<string> ExceptionMessages { get; set; }
        public HandledExceptionList(ICollection<string> exceptionMessages)
        {
            ExceptionMessages = exceptionMessages;
        }
    }
}