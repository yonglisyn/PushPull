using System;
using PushPull.Enums;

namespace PushPull.Models
{
    public class Asset
    {
        public int UserId { get; set; }
        public AssetPurpose AssetPurpose { get; set; }
        public AssetType AssetType { get; set; }
        public DateTime Date { get; set; }
        public decimal AssetValue { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}