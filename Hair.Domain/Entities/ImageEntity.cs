using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;  

namespace Hair.Domain.Entities
{
    public class ImageEntity : BaseEntity
    {
       public Guid SaloonId { get; set; }
       public string Source { get; set; }
       public object Img { get; set; }

       public ImageEntity(Guid saloonId, string source, object img)
       {
           SaloonId = saloonId;
           Source = source;
           Img = img;
       }
    }
}
