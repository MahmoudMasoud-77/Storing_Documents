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
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime Due_date { get; set; }

        //Relation
        [ForeignKey("Priorities")]
        public int PriorityId { get; set; }
        public virtual Priority Priorities  { get; set; }
        public virtual ICollection<File> Files { get; set; } = new HashSet<File>(); 



    }
}