using System;
using NUnit.Framework;
using PushPull.Controllers;

namespace PushPull.Tests.Controllers
{
    [TestFixture]
    public class ReportControllerTest
    {
        [TestCase(2015, 10, 10, 6040)]
        [TestCase(2015, 10, 11, 6040)]
        [TestCase(2015, 10, 12, 6041)]
        public void GetWeekIndex_ShouldBeCorrect(int year,int month, int day,int expectedWeekIndex)
        {
            var controller = new ReportController();
            var result = controller.GetWeekIndex(new DateTime(year,month,day));
            Assert.AreEqual(expectedWeekIndex,result);
        }
    }
}
