using System.Collections.Generic;
using System.Linq;
using PushPull.Enums;

namespace PushPull.Models
{
    public class AssetViewModel
    {
        public IEnumerable<Asset> MoneyPullAssets { get; set; }
        public IEnumerable<Asset> MoneyPushAssets { get; set; }
        public IEnumerable<Asset> TimePullAssets { get; set; }
        public IEnumerable<Asset> TimePushAssets { get; set; } 
        public AssetViewModel(List<Asset> assets)
        {
            MoneyPullAssets = assets.Where(x =>x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Pull));
            MoneyPushAssets = assets.Where(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));
            TimePullAssets = assets.Where(x => x.AssetType == AssetType.Time && (x.AssetPurpose == AssetPurpose.Pull));
            TimePushAssets = assets.Where(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));
        }
    }
}