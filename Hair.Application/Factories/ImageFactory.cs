using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class ImageFactory
    {
        public ImageEntity Create() => new ImageEntity();
        public ImageEntity Create(Guid userID, byte[] image, DateOnly uploadDate, string type)
        {
            return new ImageEntity(userID, image, uploadDate, type);
        }
    }
}