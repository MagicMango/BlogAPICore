using System;
using System.Collections.Generic;

namespace BlogApi.Model.Entities
{
    public class Author
    {
        public Author()
        {
            Blogentrys = new List<BlogEntry>();
        }

        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EMail { get; set; }
        public DateTime Birth { get; set; }

        public List<BlogEntry> Blogentrys { set; get; }
    }
}