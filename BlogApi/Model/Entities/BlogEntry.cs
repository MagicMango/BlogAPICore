using System;
using System.Collections.Generic;

namespace BlogApi.Model.Entities
{
    public class BlogEntry
    {
        public BlogEntry()
        {
            Comments = new List<Comment>();
        }

        public int Id { set; get; }
        public int AuthorId { get; set; }
        public DateTime InsertDate { get; set; }
        public string Subject { get; set; }
        public string Entry { get; set; }
        public string Categories { get; set; }

        public virtual Author Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
