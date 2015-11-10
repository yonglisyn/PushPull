using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PushPull.Constants;
using PushPull.Enums;
using PushPull.Models;
using PushPull.Resources;
using PushPull.Constants;

namespace PushPull.ViewModels
{
    public class ReportViewModel
    {
        private readonly List<TaskReport> _WeeklyTaskReports;
        private readonly PieChartViewModel _PendingTaskPie = new PieChartViewModel
        {
            Color = StringConst.Yellow,
            Highlight = StringConst.YellowHighlight,
            Lable = Resource.PendingTask
        };
        private readonly PieChartViewModel _FailedTaskPie = new PieChartViewModel
        {
            Color = StringConst.Red,
            Highlight = StringConst.RedHighlight,
            Lable = Resource.FailedTask
        };
        private readonly PieChartViewModel _CompletedTaskPie = new PieChartViewModel
        {
            Color = StringConst.Green,
            Highlight = StringConst.GreenHighlight,
            Lable = Resource.CompletedTask
        };

        public string TotalPieChart
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


        public ReportViewModel(List<TaskReport> weeklyTaskData)
        {
            _WeeklyTaskReports = weeklyTaskData;
        }

        public List<PieChartViewModel> GetPieChartViewModels()
        {
            var pies = new List<PieChartViewModel>();
            _PendingTaskPie.Value = _WeeklyTaskReports.Sum(x=>x.PendingCount);
            _FailedTaskPie.Value = _WeeklyTaskReports.Sum(x=>x.FailedCount);
            _CompletedTaskPie.Value = _WeeklyTaskReports.Sum(x=>x.CompletedCount);
            pies.Add(_PendingTaskPie);
            pies.Add(_FailedTaskPie);
            pies.Add(_CompletedTaskPie);
            return pies;
        }

        public List<PieChartViewModel> GetPieChartViewModels(EisenHowerType eisenHowerType)
        {
            var pies = new List<PieChartViewModel>();
            var taskReport = _WeeklyTaskReports.FirstOrDefault(x => x.EisenHowerType == eisenHowerType);
            if (taskReport == null)
            {
                return null;
            }
            _PendingTaskPie.Value = taskReport.PendingCount;
            _FailedTaskPie.Value = taskReport.FailedCount;
            _CompletedTaskPie.Value = taskReport.CompletedCount;
            pies.Add(_PendingTaskPie);
            pies.Add(_FailedTaskPie);
            pies.Add(_CompletedTaskPie);
            return pies;
        }
    }
}