﻿using BlogApi.Model;
using BlogApi.Model.Entities;
using BlogApi.Model.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : Controller
    {
        public AuthorController(BlogContext context, ILog logger): base(context, logger){   }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return UseDatabaseWithValidModel(() =>
                {
                   return new ActionResult<IEnumerable<Author>>(db.Authors.ToList());
                }
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            return UseDatabaseWithValidModel(() =>
                new ActionResult<Author>(db.Authors.Find(id))
            );
        }

        // POST apivalues
        [HttpPost("create")]
        public ActionResult Create([FromBody] Author value)
        {
            return UseDatabaseWithValidModel(() => {
                db.Authors.Add(value);
                db.SaveChanges();
                return Ok();
            }); 
        }

        // PUT api/values/5
        [HttpPut("put/{id}")]
        public ActionResult Put(int id, [FromBody] Author value)
        {
            return UseDatabaseWithValidModel(() =>
            {
                Author a = db.Authors.Find(id);
                db.Entry(a).CurrentValues.SetValues(value);
                db.SaveChanges();
                return Ok();
            });
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return UseDatabaseWithValidModel(()=> {
                Author a = db.Authors.Find(id);
                db.Authors.Remove(a);
                db.SaveChanges();
                return Ok();
            });
        }
    }
}
