using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração da imagem
    /// </summary>
    public class ImageEntity : IImage
    {
        public Guid Id { get; set; }
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