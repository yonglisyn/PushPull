using System;
using PushPull.Enums;

namespace PushPull.Models
{
    public class DailyTaskReport
    {
        public int UserId { get; set; }
        public EisenHowerType EisenHowerType { get; set; }
        public DateTime Date { get; set; }
        public int FailedCount { get; set; }
        public int CompletedCount { get; set; }
        public int TotalCount { get; set; }
    }
}