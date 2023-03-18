using FluentValidation.Results;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Classe auxílar para validações
    /// </summary>
    internal class BuildErrorValidation
    {
        /// <summary>
        /// 
        /// Efetua a busca de um ou mais dados inválidos
        /// 
        /// </summary>
        /// 
        /// <param name="result">Resultado da validação para busca</param>
        /// 
        /// <returns>
        /// 
        /// Retorna uma <see cref="ValidationFailure"/> onde a mensagem de erro recebe o valor da falha de <paramref name="result"/>
        /// 
        /// </returns>
        public static ValidationFailure? Build(ValidationResult result)
        {
            ValidationFailure output = new ValidationFailure();

            if (result.IsValid)
            {
                return null;
            }

            while (true)
            {
                foreach (var error in result.Errors)
                {
                    output.ErrorMessage = error.ErrorMessage;
                    break;
                }

                break;
            }

            return output;
        }
    }
}