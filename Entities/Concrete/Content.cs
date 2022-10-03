using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Content : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       // public int SubjectId { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Photos { get; set; }

        //Title = Kısmi İntegrasyon
        //matematikolmasanati.ml/contents/kısmi_integrasyon
        //Slug = kısmi_integrasyon
        //Photos = "e.png:pi.jpg" 
    }
}
