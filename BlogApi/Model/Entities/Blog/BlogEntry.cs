using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Model.Entities
{
    public class BlogEntry
    {
        public BlogEntry()
        {
            Comments = new List<Comment>();
        }

        public int Id { set; get; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public DateTime InsertDate { get; set; }
        [Required]
        [MinLength(5), MaxLength(512)]
        public string Subject { get; set; }
        public string Entry { get; set; }
        public string Categories { get; set; }

        public virtual Author Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
