using FluentValidation.Results;

namespace Base.Application.Exceptions
{
    public class ValidationExceptionP : Exception
    {
        public List<string> Errors { get; set; } = [];

        public ValidationExceptionP(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }

    }
}
