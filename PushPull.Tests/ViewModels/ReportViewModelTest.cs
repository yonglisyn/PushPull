using System.Collections.Generic;
using NUnit.Framework;
using PushPull.Enums;
using PushPull.Models;
using PushPull.ViewModels;

namespace PushPull.Tests.ViewModels
{
    [TestFixture]
    public class ReportViewModelTest
    {
        private readonly WeeklyTaskReport _IuWeeklyTaskReport = new WeeklyTaskReport
        {
            EisenHowerType = EisenHowerType.ImportantAndUrgent,
            CompletedCount = 100,
            FailedCount = 20,
            TotalCount = 120
        };

        [Test]
        public void GetIuPieViewModel_ShouldBeCorrect()
        {
            var reports = new List<WeeklyTaskReport>{_IuWeeklyTaskReport};
            var model = new DailyReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.ImportantAndUrgent);

            Assert.AreEqual(2,result.Count);
            Assert.AreEqual(20,result[0].Value);
            Assert.AreEqual(100,result[1].Value);
        }
        [Test]
        public void GetNiuPieViewModel_ShouldBeCorrect()
        {
            var reports = new List<WeeklyTaskReport>{new WeeklyTaskReport
            {
                EisenHowerType = EisenHowerType.NotImportantAndUrgent,
                CompletedCount = 100,
                FailedCount = 20,
                TotalCount = 120
            }};
            var model = new DailyReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.NotImportantAndUrgent);

            Assert.AreEqual(2,result.Count);
            Assert.AreEqual(20,result[0].Value);
            Assert.AreEqual(100,result[1].Value);
        }

        [Test]
        public void GetPieViewModel_ShouldBeNull_WhenCannotFindReport()
        {
            var reports = new List<WeeklyTaskReport>{_IuWeeklyTaskReport};
            var model = new DailyReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.NotImportantAndUrgent);

            Assert.AreEqual(null, result);
        }
    }
}
