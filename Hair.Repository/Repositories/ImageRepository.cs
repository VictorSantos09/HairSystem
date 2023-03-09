﻿using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;


namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : IBaseRepository<ImageEntity>
    {
        private readonly static string TableName = "IMAGES";

        public void Create(ImageEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<ImageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImageEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}