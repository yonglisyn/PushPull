using System;
using PushPull.Enums;
using PushPull.ViewModels;

namespace PushPull.Models
{
    public class TaskCard
    {
        public TaskCard(TaskCardViewModel form)
        {
            TaskId = form.TaskId;
            DeadLine = form.Deadline;
            EisenHowerType = form.EisenHowerType;
            Card = new Card
            {
                Content = form.Content,
                AssetType = AssetType.Time,
                PullValue = form.AssetValue,
                PushValue = form.FailValue,
                ValueUnit = form.ValueUnit,
                Status = CardStatus.NotStarted,
                Tag = form.Tag
            };
        }

        public TaskCard()
        {
        }

        public long TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime? DeadLine { get; set; }
        public EisenHowerType EisenHowerType { get; set; }
        public Card Card { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        public bool IsPull()
        {
            return (Card.Status == CardStatus.Completed);
        }
    }
}