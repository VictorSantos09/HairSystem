using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IGetByUserId<T> : IBaseRepository<T>
    {
        T? GetByUserId(UserEntity user);
    }
}