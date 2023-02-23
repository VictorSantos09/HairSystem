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
        public Guid HaircutId { get; set; }
        public string HaircutTime { get; set; }
        public ClientEntity Client { get; set; }

        public ViewHaircutTimeDto(Guid haircutId, string haircutTime, ClientEntity client)
        {
            HaircutId = haircutId;
            HaircutTime = haircutTime;
            Client = client;
        }
    }
}
