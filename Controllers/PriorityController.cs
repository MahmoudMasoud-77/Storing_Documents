using Storing_Documents.Data;
using Storing_Documents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storing_Documents.Controllers
{
    public class PriorityController : ApiController
    {
        DocumentContext context;
        public PriorityController()
        {
            context = new DocumentContext();
        }

        public IHttpActionResult GetAll()
        {
            var all = context.Priorities.ToList();
            return Ok(all);
        }
        public IHttpActionResult GetById(int id)
        {
            var doc = context.Priorities.Find(id);
            if (doc is null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        public IHttpActionResult PostPriority(Priority NewItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            context.Priorities.Add(NewItem);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if (PriorityExist(NewItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    return InternalServerError();
                }
            }
            //return Ok();
            return CreatedAtRoute("DefaultApi", new { id = NewItem.Id }, NewItem);
        }
        public IHttpActionResult PutPriority([FromUri] int id, [FromBody] Priority NewItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != NewItem.Id)
            {
                return BadRequest("id is Wrong !!!!!!!!");
            }
            context.Entry(NewItem).State = System.Data.Entity.EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if (!PriorityExist(id))
                {
                    return Conflict();
                }
                else
                {
                    return InternalServerError();
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult DeletePriority(int id)
        {
            var result = context.Priorities.Find(id);
            if (result == null)
                return NotFound();
            context.Priorities.Remove(result);
            context.SaveChanges();
            return Ok();
        }
        //fn to insure Doc is exist in db
        public bool PriorityExist(int id)
        {
            return context.Priorities.Count(x => x.Id == id) > 0;
        }
    }
}
