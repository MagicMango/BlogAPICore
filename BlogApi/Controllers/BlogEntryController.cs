using BlogApi.Model;
using BlogApi.Model.Entities;
using BlogApi.Model.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/blogentrys")]
    [ApiController]
    public class BlogEntryController : Controller
    {
        public BlogEntryController(BlogContext context, ILog logger) :base(context, logger){}
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BlogEntry>> Get()
        {
            return UseDatabaseWithValidModel<IEnumerable<BlogEntry>>(() =>
            {
                return db.BlogEntrys.ToList();
            });
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BlogEntry> Get(int id)
        {
            return UseDatabaseWithValidModel(() =>
                 new ActionResult<BlogEntry>(db.BlogEntrys.Find(id))
            );
        }
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BlogEntry value)
        {
            return UseDatabaseWithValidModel(() =>
            {
                db.BlogEntrys.Add(value);
                db.SaveChanges();
                return Ok();
            });
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BlogEntry value)
        {
            return UseDatabaseWithValidModel(() =>
            {
                BlogEntry a = db.BlogEntrys.Find(id);
                a.Categories = value.Categories;
                a.Entry = value.Entry;
                a.Subject = value.Subject;
                db.SaveChanges();
                return Ok();
            });
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return UseDatabaseWithValidModel(() =>
            {
                BlogEntry a = db.BlogEntrys.Find(id);
                db.BlogEntrys.Remove(a);
                db.SaveChanges();
                return Ok();
            });
        }
        [HttpPut("{blogId}/{id}")]
        public ActionResult Put(int blogId, int id, [FromBody] Comment value)
        {
            return UseDatabaseWithValidModel(() =>
            {
                BlogEntry blogEntry = db.BlogEntrys.Find(blogId);
                if (blogEntry != null)
                {
                    Comment c = blogEntry.Comments.Find(x => x.Id == id);
                    if (c != null)
                    {
                        c.Subject = value.Subject;
                        c.Entry = value.Entry;
                        db.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return new StatusCodeResult(902);
                    }
                }
                else
                {
                    return new StatusCodeResult(901);
                }
            });
        }

        [HttpDelete("{blogId}/{id}")]
        public ActionResult Delete(int blogId, int id)
        {
           return UseDatabaseWithValidModel(() =>
                {
                    BlogEntry blogEntry = db.BlogEntrys.Find(blogId);
                    if (blogEntry != null)
                    {
                        Comment c = blogEntry.Comments.Find(x => x.Id == id);
                        db.Comments.Remove(c);
                        db.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return new StatusCodeResult(901);
                    }
                });
        }
        [HttpPost("{blogId}")]
        public ActionResult Post(int blogId, [FromBody] Comment value)
        {
            return UseDatabaseWithValidModel(() =>
            {
                db.Comments.Add(value);
                db.SaveChanges();
                return Ok();
            });
        }
    }
}
