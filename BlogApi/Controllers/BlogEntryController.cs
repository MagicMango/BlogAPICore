using BlogApi.Model;
using BlogApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/blogentrys")]
    [ApiController]
    public class BlogEntryController : ControllerBase
    {
        private BlogContext db;

        public BlogEntryController(BlogContext context)
        {
            db = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BlogEntry>> Get()
        {
            using (db)
            {
                return db.BlogEntrys.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BlogEntry> Get(int id)
        {
            using (db)
            {
                return db.BlogEntrys.Find(id);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] BlogEntry value)
        {
            using (db)
            {
                db.BlogEntrys.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlogEntry value)
        {
            using (db)
            {
                BlogEntry a = db.BlogEntrys.Find(id);
                a.Categories = value.Categories;
                a.Entry = value.Entry;
                a.Subject = value.Subject;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (db)
            {
                BlogEntry a = db.BlogEntrys.Find(id);
                db.BlogEntrys.Remove(a);
                db.SaveChanges();
            }
        }

        [HttpPut("/{blogId}/{id}")]
        public void Put(int blogId, int id, [FromBody] Comment value)
        {
            using (db)
            {
                BlogEntry a = db.BlogEntrys.Find(blogId);
                Comment c = a.Comments.Find(x=>x.Id == id);
                c.Subject = value.Subject;
                c.Entry = value.Entry;
                db.SaveChanges();
            }
        }

        [HttpDelete("/{blogId}/{id}")]
        public void Delete(int blogId, int id)
        {
            using (db)
            {
                BlogEntry a = db.BlogEntrys.Find(blogId);
                Comment c = a.Comments.Find(x => x.Id == id);
                db.Comments.Remove(c);
                db.SaveChanges();
            }
        }

        [HttpPost("/{blogId}")]
        public void Post(int blogId, [FromBody] Comment value)
        {
            using (db)
            {
                db.Comments.Add(value);
                db.SaveChanges();
            }
        }

        
    }
}
