namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para remover uma entidade do repositório por seu Id. Qualquer classe que o implemente
    /// deve fornecer um método Remove que recebe um Id do tipo Guid como parâmetro e remove a entidade com esse Id do repositório.
    public interface IRemove
    {
        public void Remove(Guid id);
    }
}