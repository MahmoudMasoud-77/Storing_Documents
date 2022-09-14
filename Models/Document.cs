using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Storing_Documents.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime Due_date { get; set; }

        //Relation
        [ForeignKey("Priority")]
        public virtual int Priority_Id { get; set; }
        //[JsonIgnore]
        public virtual Priority Priority  { get; set; }
        //[JsonIgnore]
        public virtual ICollection<File> Files { get; } = new HashSet<File>(); 



    }
}