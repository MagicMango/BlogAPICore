using System;

namespace BlogApi.Model.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId  { get; set; }

        public DateTime InsertDate { get; set; }
        public string Subject { get; set; }
        public string Entry { get; set; }

        public virtual BlogEntry Blog { get; set; }
    }
}