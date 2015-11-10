using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PushPull.Constants;
using PushPull.Enums;
using PushPull.Models;
using PushPull.Resources;

namespace PushPull.ViewModels
{
    public class DailyReportViewModel
    {
        private readonly List<WeeklyTaskReport> _WeeklyTaskReports;
        private readonly List<DailyTaskReport> _DailyTaskReports;

        private readonly PieChartViewModel _FailedTaskPie = new PieChartViewModel
        {
            Color = StringConst.RedHighlight,
            Highlight = StringConst.Red,
            Label = Resource.FailedTask
        };
        private readonly PieChartViewModel _CompletedTaskPie = new PieChartViewModel
        {
            Color = StringConst.GreenHighlight,
            Highlight = StringConst.Green,
            Label = Resource.CompletedTask
        };



        public string TotalPieJson
        {
            get
            {
                return JsonConvert.SerializeObject(TotalPie, AccountConstSettings.SerializerSetting);
            }
        }

        public List<PieChartViewModel> TotalPie {
            get { return GetPieChartViewModels(); }
        }
        public List<PieChartViewModel> IuPie {
            get { return GetPieChartViewModels(EisenHowerType.ImportantAndUrgent); }
        }
        public List<PieChartViewModel> InuPie {
            get { return GetPieChartViewModels(EisenHowerType.ImportantAndNotUrgent); }
        }
        public List<PieChartViewModel> NiuPie {
            get { return GetPieChartViewModels(EisenHowerType.NotImportantAndUrgent); }
        }
        public List<PieChartViewModel> NinuPie {
            get { return GetPieChartViewModels(EisenHowerType.NotImportantAndNotUrgent); }
        }


        public DailyReportViewModel(List<WeeklyTaskReport> weeklyTaskData, List<DailyTaskReport> dailyTaskData)
        {
            _WeeklyTaskReports = weeklyTaskData;
            _DailyTaskReports = dailyTaskData;
        }

        public List<PieChartViewModel> GetPieChartViewModels()
        {
            var pies = new List<PieChartViewModel>();
            var failedCount = _DailyTaskReports.Sum(x => x.FailedCount);
            var completedCount = _DailyTaskReports.Sum(x => x.CompletedCount);
            _FailedTaskPie.Value = (failedCount*100 / (failedCount + completedCount));
            _CompletedTaskPie.Value = (completedCount * 100 / (failedCount + completedCount));
            pies.Add(_FailedTaskPie);
            pies.Add(_CompletedTaskPie);
            return pies;
        }

        public List<PieChartViewModel> GetPieChartViewModels(EisenHowerType eisenHowerType)
        {
            var pies = new List<PieChartViewModel>();
            var taskReport = _DailyTaskReports.FirstOrDefault(x => x.EisenHowerType == eisenHowerType);
            if (taskReport == null)
            {
                return null;
            }
            _FailedTaskPie.Value = (taskReport.FailedCount * 100 / taskReport.TotalCount);
            _CompletedTaskPie.Value = (taskReport.CompletedCount * 100 / taskReport.TotalCount);
            pies.Add(_FailedTaskPie);
            pies.Add(_CompletedTaskPie);
            return pies;
        }
    }
}