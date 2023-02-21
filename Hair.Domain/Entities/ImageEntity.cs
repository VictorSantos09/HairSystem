using Hair.Domain.Common;

namespace Hair.Domain.Entities
{
    public class ImageEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public byte[] Img { get; set; }

        public ImageEntity(Guid saloonId, byte[] img)
        {
            Id = Guid.NewGuid();
            SaloonId = saloonId;
            Img = img;
        }

        public ImageEntity()
        {

        }
    }
}