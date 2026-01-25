using Base.Application.Exceptions;
using Base.Application.Utils.Result;
using FluentValidation;
using FluentValidation.Results;

namespace Base.Application.Utils.Mediator
{
    public class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public async Task<Result<TResponse>> Send<TResponse>(IRequest<TResponse> request)
        {

            await ValidationMediator(request);

            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = serviceProvider.GetService(handlerType) ?? throw new MediatorException($"No handler found for request of type {request.GetType().Name}");
            var methodInfo = handlerType.GetMethod("Handle")!;

            return await (Task<Result<TResponse>>)methodInfo.Invoke(handler, [request])!;
        }

        public async Task Send(IRequest request)
        {
            await ValidationMediator(request);

            var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());

            var handler = serviceProvider.GetService(handlerType) ?? throw new MediatorException($"No handler found for request of type {request.GetType().Name}");
            var methodInfo = handlerType.GetMethod("Handle")!;

             await (Task)methodInfo.Invoke(handler, [request])!;

        }

        private async Task ValidationMediator(object request)
        {

            var typeValidator = typeof(IValidator<>).MakeGenericType(request.GetType());

            var validator = serviceProvider.GetService(typeValidator);

            if (validator is not null)
            {
                var validateMethod = typeValidator.GetMethod("ValidateAsync")!;
                var validateTask = (Task)validateMethod!.Invoke(validator, [request, CancellationToken.None])!;

                await validateTask.ConfigureAwait(false);

                var resultProperty = validateTask.GetType().GetProperty("Result")!;

                var validationResult = (ValidationResult)resultProperty.GetValue(validateTask)!;

                if (!validationResult.IsValid)
                {
                    throw new ValidationExceptionP(validationResult);
                }
            }

        }

    }
}