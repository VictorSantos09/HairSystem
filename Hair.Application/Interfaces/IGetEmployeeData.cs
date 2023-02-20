using Hair.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Interfaces
{
    public interface IGetEmployeeData
    {
        public BaseDto GetEmployeeData(string password);
    }
}
