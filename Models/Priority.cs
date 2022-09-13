using Storing_Documents.Data.Enams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storing_Documents.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfPriority priorities { get; set; }

        //relation
        public virtual Document document { get; set; }


    }
}