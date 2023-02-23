using Hair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Dto
{
    public class ViewHaircutTimeDto
    {
        public Guid UserID { get; set; }

        public ViewHaircutTimeDto(Guid userID)
        {
            UserID = userID;
        }
    }
}
