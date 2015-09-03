using System;
using System.ComponentModel.DataAnnotations.Schema;
using PushPull.Enums;

namespace PushPull.Models
{
    public class Punishment
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public DateTime DeadLine { get; set; }
        public PunishmentStatus Status { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}