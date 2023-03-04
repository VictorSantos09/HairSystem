namespace Hair.Application.Common
{
    public class ValidationErrorDto
    {
        public string ErrorMessage { get; set; }

        public ValidationErrorDto(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}