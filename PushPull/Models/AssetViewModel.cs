using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PushPull.Constants;
using PushPull.Resources;

namespace PushPull.Models
{
    public class AssetViewModel
    {

        private static Dictionary<int, string> _LabelSource;
        private decimal _MaxPrograssBarPercentage = 0.6m;
        private readonly decimal[] _OneWeekMoneyPullDailyData;
        private readonly decimal[] _OneWeekMoneyPushDailyData;
        private readonly decimal[] _OneWeekTimePullDailyData;
        private readonly decimal[] _OneWeekTimePushDailyData;

        public AssetViewModel(decimal[] oneWeekMoneyPullDailyData, decimal[] oneWeekMoneyPushDailyData, decimal[] oneWeekTimePullDailyData, decimal[] oneWeekTimePushDailyData, DateTime endDate)
        {
            _OneWeekMoneyPullDailyData = oneWeekMoneyPullDailyData;
            _OneWeekMoneyPushDailyData = oneWeekMoneyPushDailyData;
            _OneWeekTimePullDailyData = oneWeekTimePullDailyData;
            _OneWeekTimePushDailyData = oneWeekTimePushDailyData;
            EndDate = endDate;
            MoneyPullAssetTotalValue = _OneWeekMoneyPullDailyData.Sum();
            MoneyPushAssetTotalValue = _OneWeekMoneyPushDailyData.Sum();
            TimePullAssetTotalValue = _OneWeekTimePullDailyData.Sum();
            TimePushAssetTotalValue = _OneWeekTimePushDailyData.Sum();
        }

        public AssetViewModel(DateTime date)
        {
            EndDate = date;
        }

        public DateTime EndDate { get; set; }
        public decimal MoneyPullAssetTotalValue { get; set; }
        public decimal MoneyPushAssetTotalValue { get; set; }
        public decimal TimePullAssetTotalValue { get; set; }
        public decimal TimePushAssetTotalValue { get; set; }
        public string[] Lables
        {
            get
            {
                return GetLables();
            }
        }

        public decimal MoneyPullAssetPercentage
        {
            get
            {
                if ((MoneyPullAssetTotalValue + MoneyPushAssetTotalValue) == 0)
                    return 0;
                return Math.Floor(MoneyPullAssetTotalValue * 100 * _MaxPrograssBarPercentage / (MoneyPullAssetTotalValue + MoneyPushAssetTotalValue));
            }
        }
        public decimal MoneyPushAssetPercentage
        {
            get
            {
                if ((MoneyPullAssetTotalValue + MoneyPushAssetTotalValue) == 0)
                    return 0;
                return Math.Floor(MoneyPushAssetTotalValue * 100 * _MaxPrograssBarPercentage / (MoneyPullAssetTotalValue + MoneyPushAssetTotalValue));
            }
        }
        public decimal TimePullAssetPercentage
        {
            get
            {
                if ((TimePullAssetTotalValue + TimePushAssetTotalValue) == 0)
                    return 0;
                return Math.Floor(TimePullAssetTotalValue * 100 * _MaxPrograssBarPercentage / (TimePullAssetTotalValue + TimePushAssetTotalValue));
            }
        }
        public decimal TimePushAssetPercentage
        {
            get
            {
                if ((TimePullAssetTotalValue + TimePushAssetTotalValue) == 0)
                    return 0;
                return Math.Floor(TimePushAssetTotalValue * 100 * _MaxPrograssBarPercentage / (TimePullAssetTotalValue + TimePushAssetTotalValue));
            }
        }

        
        public string MoneyPullChart
        {
            get
            {
                var source = new LineChartViewModel(StringConst.RgbaGreen, StringConst.Green, _OneWeekMoneyPullDailyData);
                return JsonConvert.SerializeObject(source,AccountConstSettings.SerializerSetting);
            }
        }

        public string MoneyPushChart
        {
            get
            {
                var source = new LineChartViewModel(StringConst.RgbaRed, StringConst.Red,_OneWeekMoneyPushDailyData);
                return JsonConvert.SerializeObject(source, AccountConstSettings.SerializerSetting);
            }
        }

        public string TimePullChart
        {
            get
            {
                var source = new LineChartViewModel(StringConst.RgbaGreen, StringConst.Green, _OneWeekTimePullDailyData);
                return JsonConvert.SerializeObject(source, AccountConstSettings.SerializerSetting);
            }
        }

        public string TimePushChart
        {
            get
            {
                var source = new LineChartViewModel(StringConst.RgbaRed, StringConst.Red, _OneWeekTimePushDailyData);
                return JsonConvert.SerializeObject(source, AccountConstSettings.SerializerSetting);
            }
        }

        public string[] GetLables()
        {
            if (_LabelSource == null)
            {
                InitLabelSource();
            }
            var lables = new string[AccountConstSettings.OneWeekCount];
            var dayOfWeek = (int)EndDate.DayOfWeek;
            var j = AccountConstSettings.OneWeekCount -1;
            for (var i = dayOfWeek; i >=dayOfWeek + 1 - AccountConstSettings.OneWeekCount ; i--, j--)
            {
                var index = i >= 0 ? i : AccountConstSettings.OneWeekCount  + i;
                lables[j] = _LabelSource[index];
            }
            return lables;
        }

        private void InitLabelSource()
        {
            _LabelSource = new Dictionary<int, string>
            {
                {0, Resource.Sun},
                {1, Resource.Mon},
                {2, Resource.Tue},
                {3, Resource.Wed},
                {4, Resource.Thu},
                {5, Resource.Fri},
                {6, Resource.Sat}
            };
        }


    }

    public class LineChartViewModel
    {
        public LineChartViewModel(string rgbaColor,string color,decimal[] data)
        {
            FillColor = rgbaColor;
            StrokeColor = color;
            PointColor = color;
            PointStrokeColor = "#fff";
            PointHighlightFill = "#fff";
            PointHighlightStroke = color;
            DailyData = data;
            IntegratedData = new decimal[7];
            var sum = 0m;
            for(var i=0;i<7;i++)
            {
                sum += data[i];
                IntegratedData[i] = sum;
            }
        }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public string PointStrokeColor { get; set; }
        public string PointHighlightFill { get; set; }
        public string PointHighlightStroke { get; set; }
        public decimal[] DailyData{ get; set; }
        public decimal[] IntegratedData{ get; set; }
        public string PointColor { get; set; }
    }
}