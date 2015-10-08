using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PushPull.Constants;
using PushPull.DataAccessLayer.Repositories;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.Controllers
{
    public class AssetController:Controller 
    {
        private readonly AssetRepository _AssetRepository;

        public AssetController()
        {
            _AssetRepository = new AssetRepository();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var endDate = DateTime.Today;
            var assets =await _AssetRepository.GetOneWeekAssetListAsync(userId, endDate);
            var oneWeekMoneyPullAssetData =
             assets.Where(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Pull));
            var oneWeekMoneyPushAssetData =
                assets.Where(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));
            var oneWeekTimePullAssetData =
                assets.Where(x => x.AssetType == AssetType.Time && (x.AssetPurpose == AssetPurpose.Pull));
            var oneWeekTimePushAssetData =
                assets.Where(x => x.AssetType == AssetType.Money && (x.AssetPurpose == AssetPurpose.Push));

            var oneWeekMoneyPullData = GetArrayData(oneWeekMoneyPullAssetData, endDate);
            var oneWeekMoneyPushData = GetArrayData(oneWeekMoneyPushAssetData, endDate);
            var oneWeekTimePullData = GetArrayData(oneWeekTimePullAssetData, endDate);
            var oneWeekTimePushData = GetArrayData(oneWeekTimePushAssetData, endDate);
 
            return View("Index", new AssetViewModel(oneWeekMoneyPullData,oneWeekMoneyPushData,oneWeekTimePullData,oneWeekTimePushData, endDate));
        }

        private decimal[] GetArrayData(IEnumerable<Asset> oneWeekAsset, DateTime endDate)
        {
            var data = new decimal[AccountConstSettings.OneWeekCount];
            var date = endDate;
            for (var i = AccountConstSettings.OneWeekCount-1; i >= 0; i--)
            {
                if (oneWeekAsset.Any(x => x.Date == date))
                {
                    data[i] = oneWeekAsset.First(x => x.Date == date).AssetValue;
                }
                else
                {
                    data[i] = 0m;
                }
                date = date.AddDays(-1);
            }
            return data;
        }


    }
}