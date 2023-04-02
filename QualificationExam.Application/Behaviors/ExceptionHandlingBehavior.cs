namespace QualificationExam.Application.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<IRequest<TResponse>, TResponse, TException>
     where TRequest : notnull
     where TException : Exception
     where TResponse : notnull, ServiceResponse
    {
        private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> _logger;

        public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }

        public Task Handle(IRequest<TResponse> request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var error = CreateExceptionError(exception);

            _logger.LogError(JsonSerializer.Serialize(error));

            var response = ServiceResponse.CreateExceptionError();

            state.SetHandled(response as TResponse);

            return Task.FromResult(response);
        }

        private static ExceptionError CreateExceptionError(TException exception)
        {
            var methodName = exception.TargetSite?.DeclaringType?.DeclaringType?.FullName;
            var message = exception.Message;
            var innerException = exception.InnerException?.Message;
            var stackTrace = exception.StackTrace;

            return new ExceptionError(methodName, message, innerException, stackTrace);
        }
    }
}
