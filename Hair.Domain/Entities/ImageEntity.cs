﻿namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração da imagem.
    /// 
    /// </summary>
    public class ImageEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Id do salão.
        /// 
        /// </summary>
        public Guid SaloonId { get; set; }
        /// <summary>
        /// 
        /// Imagem.
        /// 
        /// </summary>
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