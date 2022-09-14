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
    public class FileController : ApiController
    {
        DocumentContext context;
        public FileController()
        {
            context = new DocumentContext();
        }

        public IHttpActionResult GetAll()
        {
            var alldoc = context.Files.ToList();
            return Ok(alldoc);
        }
        public IHttpActionResult GetById(int id)
        {
            var doc = context.Files.Find(id);
            if (doc is null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        public IHttpActionResult PostFile(File NewItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            context.Files.Add(NewItem);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if (FileExist(NewItem.Id))
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
        public IHttpActionResult PutFile([FromUri] int id, [FromBody] File NewItem)
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
                if (!FileExist(id))
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
        public IHttpActionResult DeleteFile(int id)
        {
            var result = context.Files.Find(id);
            if (result == null)
                return NotFound();
            context.Files.Remove(result);
            context.SaveChanges();
            return Ok();
        }
        //fn to insure Doc is exist in db
        public bool FileExist(int id)
        {
            return context.Files.Count(x => x.Id == id) > 0;
        }
    }
}
