using Hair.Application.Common;
using Hair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Interfaces
{
    public interface IStorageService
    {
        public BaseDto ManageStorage(int itemCount, Guid itemId, double itemPrice, bool addItem, bool removeItem, bool confirmed);
    }
}
