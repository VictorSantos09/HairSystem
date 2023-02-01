namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface que realiza a remoção de entidades pelo Id.
    /// </summary>
    public interface IRemove
    {
        public void Remove(Guid id);
    }
}