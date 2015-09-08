using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PushPull.Models
{
    public class Tag
    {
        [Key]
        public long TagId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public string Content { get; set; }
    }
}