namespace QualificationExam.Domain.Exceptions
{
    public class TokenException : Exception
    {
        public TokenException(string exceptionMessage) : base(exceptionMessage) { }
    }
}