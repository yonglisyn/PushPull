using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PushPull.Enums;

namespace PushPull.Models
{
    public class RecurredSchedule
    {
        [Key]
        public long RecurredScheduleId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public DateTime FirstOccurrenceDate { get; set; }
        public int ReccurrenceCount { get; set; }
        public bool IsFinished { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<ScheduleCard> ScheduleCards { get; set; }
    }
}