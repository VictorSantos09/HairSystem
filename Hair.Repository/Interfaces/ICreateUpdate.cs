namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para um repositório básico, especificando que qualquer classe que o implemente deve
    /// fornecer métodos para criar, remover, recuperar e atualizar entidades do tipo T.
    /// O tipo genérico T é usado para especificar o tipo de entidades que o repositório irá gerenciar.
    public interface ICreateUpdate<T> : ICreate<T>, IUpdate<T>
    {
    }
}