using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório para acessar dados referentes aos cortes de cabelo
    /// 
    /// <para>Tais como horarios, cliente e se disponivel da entidade <see cref="HaircuteEntity"/> </para>
    /// </summary>
    public class HaircuteRepository : BaseRepository<HaircuteEntity>
    {
        public HaircuteRepository() : base("HaircuteTime")
        {

        }

        public void AddPrice(HaircutePriceEntity haircutepriceEntity)
        {
            var saloonItem = new HaircutePriceEntity()
            {
                Id = haircutepriceEntity.Id,
                Hair = haircutepriceEntity.Hair,
                Beard = haircutepriceEntity.Beard,
                Mustache = haircutepriceEntity.Mustache,

            };
            haircutepriceEntity.Create();
        }
    }

  
}