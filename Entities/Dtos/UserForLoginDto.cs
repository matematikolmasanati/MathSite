using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    //DTO = Data Transformation Object
   public class UserForLoginDto:IDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
  
}
