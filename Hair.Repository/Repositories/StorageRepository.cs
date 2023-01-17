using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso dos itens do salão
    /// <para>Como quantidades de navalhas, maquinas entre outros da entidade <see cref="SaloonItemEntity"/></para>
    /// </summary>
    public class StorageRepository : BaseRepository<SaloonItemEntity>
    {
        public StorageRepository() : base("StorageItens")
        {

        }

        public void AddUser(SaloonItemEntity saloonitemEntity)
        {
            var saloonItem = new SaloonItemEntity()
            {
                Id = saloonitemEntity.Id,
                Name = saloonitemEntity.Name,   
                Price = saloonitemEntity.Price,
                QuantityAvaible = saloonitemEntity.QuantityAvaible,
            };
            saloonItem.Create();
        }
    }
}
