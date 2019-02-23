using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Model.Entities
{
    public class Author
    {
        public Author()
        {
            Blogentrys = new List<BlogEntry>();
        }

        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(255)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(2), MaxLength(255)]
        public string Lastname { get; set; }
        [Required]
        [MinLength(3), MaxLength(512)]
        public string EMail { get; set; }
        [Required]
        public DateTime? Birth { get; set; }

        public List<BlogEntry> Blogentrys { set; get; }
    }
}