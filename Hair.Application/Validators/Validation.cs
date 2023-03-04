using FluentValidation.Results;
using Hair.Application.Common;

namespace Hair.Application.Validators
{
    public class Validation
    {
        public static ValidationResultDto Verify(ValidationResult result)
        {
            if (result.IsValid)
                return new ValidationResultDto(true);

            List<object> output = new();

            foreach (var message in result.Errors)
            {
                var error = new { message.ErrorMessage };
                output.Add(error);
            }

            var sucess = new { Sucess = false };
            
            output.Add(sucess);

            return new ValidationResultDto(false, output);
        }
    }
}