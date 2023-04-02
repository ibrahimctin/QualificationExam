namespace QualificationExam.Application.Behaviors
{
    public class ValidationPipeLineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ServiceResponse, new()
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipeLineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (!_validators.Any())
            {
                return await next.Invoke();
            }

            var context = new ValidationContext<TRequest>(request);
            var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (!failures.Any())
            {
                return await next.Invoke();
            }

            var response = CreateValidationErrorResponse(failures);

            return await Task.FromResult(response as TResponse);
        }

        private ValidationErrorResponse CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
        {
            var errors = failures.Select(failure => new ValidationError(failure.PropertyName, failure.ErrorMessage)).ToList();

            return ValidationErrorResponse.Create(errors);
        }
    }
 }