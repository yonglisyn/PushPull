using System;
using NUnit.Framework;
using PushPull.Models;

namespace PushPull.Tests.ViewModels
{
    [TestFixture]
    public class AssetViewModelTest
    {
        [Test]
        public void GetDayOfWeekArray_Sunday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays( -(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Monday",result[0]);
            Assert.AreEqual("Tuesday",result[1]);
            Assert.AreEqual("Wednesday",result[2]);
            Assert.AreEqual("Thursday",result[3]);
            Assert.AreEqual("Friday",result[4]);
            Assert.AreEqual("Saturday",result[5]);
            Assert.AreEqual("Sunday",result[6]);
        }

        [Test]
        public void GetDayOfWeekArray_Saturday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(6-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Sunday", result[0]);
            Assert.AreEqual("Monday", result[1]);
            Assert.AreEqual("Tuesday",result[2]);
            Assert.AreEqual("Wednesday",result[3]);
            Assert.AreEqual("Thursday",result[4]);
            Assert.AreEqual("Friday",result[5]);
            Assert.AreEqual("Saturday",result[6]);
        }
        
        [Test]
        public void GetDayOfWeekArray_Friday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(5-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Saturday", result[0]);
            Assert.AreEqual("Sunday", result[1]);
            Assert.AreEqual("Monday", result[2]);
            Assert.AreEqual("Tuesday",result[3]);
            Assert.AreEqual("Wednesday",result[4]);
            Assert.AreEqual("Thursday",result[5]);
            Assert.AreEqual("Friday",result[6]);
        }
        [Test]
        public void GetDayOfWeekArray_Thursday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(4-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Friday", result[0]);
            Assert.AreEqual("Saturday", result[1]);
            Assert.AreEqual("Sunday", result[2]);
            Assert.AreEqual("Monday", result[3]);
            Assert.AreEqual("Tuesday",result[4]);
            Assert.AreEqual("Wednesday",result[5]);
            Assert.AreEqual("Thursday",result[6]);
        }

        [Test]
        public void GetDayOfWeekArray_Wednesday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(3-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Thursday", result[0]);
            Assert.AreEqual("Friday", result[1]);
            Assert.AreEqual("Saturday", result[2]);
            Assert.AreEqual("Sunday", result[3]);
            Assert.AreEqual("Monday", result[4]);
            Assert.AreEqual("Tuesday",result[5]);
            Assert.AreEqual("Wednesday",result[6]);
        }
        [Test]
        public void GetDayOfWeekArray_Tuesday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(2-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Wednesday", result[0]);
            Assert.AreEqual("Thursday", result[1]);
            Assert.AreEqual("Friday", result[2]);
            Assert.AreEqual("Saturday", result[3]);
            Assert.AreEqual("Sunday", result[4]);
            Assert.AreEqual("Monday", result[5]);
            Assert.AreEqual("Tuesday",result[6]);
        }

        [Test]
        public void GetDayOfWeekArray_Monday_ShouldBeCorrect()
        {
            var sunday =DateTime.Today.AddDays(1-(int) DateTime.Today.DayOfWeek);
            var model = new AssetViewModel(sunday);
            var result = model.GetLables();
            Assert.AreEqual("Tuesday", result[0]);
            Assert.AreEqual("Wednesday", result[1]);
            Assert.AreEqual("Thursday", result[2]);
            Assert.AreEqual("Friday", result[3]);
            Assert.AreEqual("Saturday", result[4]);
            Assert.AreEqual("Sunday", result[5]);
            Assert.AreEqual("Monday", result[6]);
        }

    }
}
