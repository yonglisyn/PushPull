using System.Collections.Generic;
using System.Linq;
using PushPull.Enums;

namespace PushPull.Models
{
    public class AssetViewModel
    {
        public Asset MoneyPullAssets { get; set; }
        public Asset MoneyPushAssets { get; set; }
        public Asset TimePullAssets { get; set; }
        public Asset TimePushAssets { get; set; } 
        public AssetViewModel(List<Asset> assets)
        {
            MoneyPullAssets = assets.SingleOrDefault(x =>x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Pull));
            MoneyPushAssets = assets.SingleOrDefault(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));
            TimePullAssets = assets.SingleOrDefault(x => x.AssetType == AssetType.Time && (x.AssetPurpose == AssetPurpose.Pull));
            TimePushAssets = assets.SingleOrDefault(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));
        }
    }
}