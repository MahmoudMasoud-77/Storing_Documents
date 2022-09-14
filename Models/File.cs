using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Storing_Documents.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string File_path { get; set; }

        //relation
        public int DocumentID { get; set; }
        [ForeignKey(nameof(DocumentID))]
        //[JsonIgnore]
        public virtual Document document { get; set; }




    }
}