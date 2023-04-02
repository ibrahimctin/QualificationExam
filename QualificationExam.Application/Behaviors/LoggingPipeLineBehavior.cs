namespace QualificationExam.Application.Behaviors
{
    public class LoggingPipeLineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest  : notnull , IRequest<TResponse>
        where TResponse : ServiceResponse
    {
        private readonly ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipeLineBehavior(ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            //Structure Logging (we can filter the log , we take the meta data serialed them in to json.
            //we would able to search and filter the log message.
            //we can filter the log request and see what information get from that )
            
            _logger.LogInformation(
                "Starting request {@RequestName},{@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            var result = await next();

            if (result.Success is false)
            {
                _logger.LogError(
                    "Request failure {@RequestName}, {@Error}, {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    result,
                    DateTime.UtcNow);
            }

            _logger.LogInformation(
                  "Completed request {@RequestName},{@DateTimeUtc}",
                  typeof(TRequest).Name,
                  DateTime.UtcNow,
                  result);

            return result;
        }
    }
}
