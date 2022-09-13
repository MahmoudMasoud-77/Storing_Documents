using Storing_Documents.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Storing_Documents.Data
{
    public class DocumentContext : DbContext
    {
        
        public DocumentContext()
            : base("name=DocumentContext")
        {
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}