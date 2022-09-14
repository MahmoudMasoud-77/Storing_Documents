using Newtonsoft.Json;
using Storing_Documents.Data.Enams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storing_Documents.Models
{
    public class Priority
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfPriority prioritiy { get; set; }

        //relation
        //[JsonIgnore]
        public virtual Document document { get; set; }


    }
}