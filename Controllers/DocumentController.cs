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
    public class DocumentController : ApiController
    {
        DocumentContext context;
        public DocumentController()
        {
            context = new DocumentContext();
        }

        public IHttpActionResult GetAllDocuments()
        {
            var alldoc = context.Documents.ToList();
            return Ok(alldoc) ;
        }
        public IHttpActionResult GetById(int id)
        {
            var doc =context.Documents.Find(id);
            if(doc is null)
            {
                return NotFound();
            }
            return Ok(doc); 
        }
        public IHttpActionResult PostDocument(Document doc)
        {
            if (!ModelState.IsValid)
            {
             return BadRequest();            
            }
            context.Documents.Add(doc);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if(DocExist(doc.Id))
                {
                    return Conflict();
                }
                else
                {
                    return InternalServerError();
                }
            }
            //return Ok();
            return CreatedAtRoute("DefaultApi", new { id = doc.Id }, doc);
        }
        public IHttpActionResult PutDocument([FromUri] int id, [FromBody] Document doc)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id !=doc.Id)
            {
                return BadRequest("id is Wrong !!!!!!!!");
            }
            context.Entry(doc).State=System.Data.Entity.EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if (!DocExist(id))
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
        public IHttpActionResult DeleteDocument(int id)
        {
            var doc = context.Documents.Find(id);
            if(doc == null)
                return NotFound();
            context.Documents.Remove(doc);
            context.SaveChanges();
            return Ok();
        }
        //fn to insure Doc is exist in db
        public bool DocExist(int id)
        {
            return context.Documents.Count(x => x.Id == id) > 0 ;
        }
    }
}
