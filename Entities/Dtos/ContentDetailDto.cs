using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;

namespace Entities.Dtos
{
    public class ContentDetailDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserOperationClaimName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Photos { get; set; }
    }
}
