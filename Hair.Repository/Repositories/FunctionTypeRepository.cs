﻿using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Repository.Repositories
{
    public sealed class FunctionTypeRepository : IFunctionTypeRepository
    {
        public void Create(FunctionTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<FunctionTypeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public FunctionTypeEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public FunctionTypeEntity? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(FunctionTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
