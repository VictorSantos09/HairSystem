using FluentValidation.Results;
using Hair.Application.Common;

namespace Hair.Application.Validators
{
    /// <summary>
    /// 
    /// Implementa funções para facilitar a verificação e uso de validações
    /// 
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// 
        /// Verifica o resultado de uma validação
        /// 
        /// </summary>
        /// 
        /// <param name="result">Item do tipo de retorno do método de validação tipo <see cref="FluentValidation.Results"/></param>
        /// 
        /// <returns>
        /// 
        /// Retorna uma lista com os dados inválidos, senão não há erros Condition de <see cref="ValidationResultDto"/> será <see langword="true"/>
        /// 
        /// </returns>
        public static ValidationResultDto Verify(ValidationResult result)
        {
            if (result.IsValid)
                return new ValidationResultDto(true);

            List<ValidationErrorDto> errors = new List<ValidationErrorDto>();

            foreach (var error in result.Errors)
            {
                ValidationErrorDto dto = new ValidationErrorDto(error.ErrorMessage);
                errors.Add(dto);
            }

            ValidationResultDto output = new ValidationResultDto(false, errors);

            return new ValidationResultDto(false, output);
        }

        /// <summary>
        /// 
        /// Converte <paramref name="result"/> para sua representação como <see cref="BaseDto"/>
        /// 
        /// </summary>
        /// 
        /// <param name="result">Resultado da validação para converter</param>
        /// 
        /// <returns>
        /// 
        /// Retorna Data contendo os erros caso encontrado
        /// 
        /// </returns>
        public static BaseDto ToBaseDto(ValidationResultDto result) => result.Condition == true ? new BaseDto(200, "Dados válidos") : new BaseDto(406, result.Data);
    }
}