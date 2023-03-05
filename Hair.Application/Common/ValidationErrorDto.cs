namespace Hair.Application.Common
{
    /// <summary>
    /// DTO para transfência de informações de validações refentes a erro
    /// </summary>
    internal class ValidationErrorDto
    {
        /// <summary>
        /// Mensagem de erro da validação
        /// </summary>
        public string ErrorMessage { get; set; }

        public ValidationErrorDto(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}