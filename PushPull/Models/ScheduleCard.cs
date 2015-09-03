using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PushPull.Models
{
    public class ScheduleCard
    {
        [Key]
        public long ScheduleId { get; set; }
        [ForeignKey("RecurredScheduleId")]
        public long? RecurredScheduleId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Card Card { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}