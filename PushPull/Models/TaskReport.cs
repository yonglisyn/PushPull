using PushPull.Enums;

namespace PushPull.Models
{
    public class TaskReport
    {
        public int UserId { get; set; }
        public EisenHowerType EisenHowerType { get; set; }
        public int WeekIndex { get; set; }
        public int PendingCount { get; set; }
        public int FailedCount { get; set; }
        public int CompletedCount { get; set; }
        public int TotalCount { get; set; }
    }
}