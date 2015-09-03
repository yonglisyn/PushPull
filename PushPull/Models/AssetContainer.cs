using System;
using PushPull.Enums;

namespace PushPull.Models
{
    public class AssetContainer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AssetType AssetType { get; set; }
        public decimal AssetValue { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}