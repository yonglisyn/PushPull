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
        [Test]
        public void GetIuPieViewModel_ShouldBeCorrect()
        {
            var reports = new List<TaskReport>{new TaskReport
            {
                EisenHowerType = EisenHowerType.ImportantAndUrgent,
                PendingCount = 10,
                CompletedCount = 100,
                FailedCount = 20,
                TotalCount = 130
            }};
            var model = new ReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.ImportantAndUrgent);

            Assert.AreEqual(3,result.Count);
            Assert.AreEqual(10,result[0].Value);
            Assert.AreEqual(20,result[1].Value);
            Assert.AreEqual(100,result[2].Value);
        }
        [Test]
        public void GetNiuPieViewModel_ShouldBeCorrect()
        {
            var reports = new List<TaskReport>{new TaskReport
            {
                EisenHowerType = EisenHowerType.NotImportantAndUrgent,
                PendingCount = 10,
                CompletedCount = 100,
                FailedCount = 20,
                TotalCount = 130
            }};
            var model = new ReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.NotImportantAndUrgent);

            Assert.AreEqual(3,result.Count);
            Assert.AreEqual(10,result[0].Value);
            Assert.AreEqual(20,result[1].Value);
            Assert.AreEqual(100,result[2].Value);
        }

        [Test]
        public void GetPieViewModel_ShouldBeNull_WhenCannotFindReport()
        {
            var reports = new List<TaskReport>{new TaskReport
            {
                EisenHowerType = EisenHowerType.ImportantAndUrgent,
                PendingCount = 10,
                CompletedCount = 100,
                FailedCount = 20,
                TotalCount = 130
            }};
            var model = new ReportViewModel(reports);
            var result = model.GetPieChartViewModels(EisenHowerType.NotImportantAndUrgent);

            Assert.AreEqual(null, result);
        }
    }
}
