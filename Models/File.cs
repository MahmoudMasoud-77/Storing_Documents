using System.ComponentModel.DataAnnotations.Schema;
namespace Storing_Documents.Models
{
    public class File
    {
        public int Id { get; set; }
        public string File_path { get; set; }

        //relation
        [ForeignKey("Document")]
        public int Document_ID { get; set; }
        public virtual Document Document { get; set; }




    }
}