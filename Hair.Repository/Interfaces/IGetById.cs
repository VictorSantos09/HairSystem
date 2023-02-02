using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para selecionar uma única entidade do repositório por seu Id. Qualquer classe que o implemente
    /// deve fornecer um método GetById que recebe um ID do tipo Guid como parâmetro e retorna uma entidade do tipo T se for encontrado, 
    /// ou nulo se não for encontrado.
    public interface IGetById <T>
    {
        public T? GetById(Guid id);
    }
}