using FluentValidation.Results;

namespace Base.Application.Exceptions
{
    public class ValidationExceptionFluent : Exception
    {
        public List<string> Errors { get; set; } = [];

        public ValidationExceptionFluent(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }

    }
}
