namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração da imagem.
    /// </summary>
    public sealed class ImageEntity : BaseEntity
    {
        /// <summary>
        /// Id do salão.
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Imagem.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Data de upload da imagem
        /// </summary>
        public DateOnly UploadDate { get; set; }

        /// <summary>
        /// Tipo da imagem
        /// </summary>
        public string Type { get; set; }

        public ImageEntity(Guid userID, byte[] image, DateOnly uploadDate, string type)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Image = image;
            UploadDate = uploadDate;
            Type = type;
        }

        public ImageEntity()
        {

        }
    }
}