using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class DiscussionDetailForListDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ForumName { get; set; }
        public string ForumSlug { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public List<Tag> Tags { get; set; }
        public int Views { get; set; }
        public int Messages { get; set; }
        public int Vote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }





    }
}
