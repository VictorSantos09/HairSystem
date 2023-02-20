using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Dto
{
    public class VisualizeEmployeeDataDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public VisualizeEmployeeDataDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}

