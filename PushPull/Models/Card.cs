using PushPull.Enums;

namespace PushPull.Models
{
    public class Card
    {
        public string Content { get; set; }
        public CardStatus Status { get; set; }
        public decimal AssetValue { get; set; }
        public decimal FailValue { get; set; }
        public AssetType AssetType{ get; set; }
        public string ValueUnit { get; set; }
        public string Tag { get; set; }
    }
}