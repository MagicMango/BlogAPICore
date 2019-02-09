using BlogApi.Model;
using BlogApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private BlogContext db;

        public AuthorController(BlogContext context)
        {
            db = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            using (db)
            {
                return db.Authors.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            using (db)
            {
                return db.Authors.Find(id);
            }
        }

        // POST api/values
        [HttpPost]
        public StatusCodeResult Post([FromBody] Author value)
        {
            using (db)
            {
                db.Authors.Add(value);
                db.SaveChanges();
                return Ok();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Author value)
        {
            using (db)
            {
                Author a = db.Authors.Find(id);
                a.Birth = value.Birth;
                a.EMail = value.EMail;
                a.Firstname = value.Firstname;
                a.Lastname = value.Lastname;
                db.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            using (db)
            {
                Author a = db.Authors.Find(id);
                db.Authors.Remove(a);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
