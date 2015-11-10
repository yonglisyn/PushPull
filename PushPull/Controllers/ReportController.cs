using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PushPull.DataAccessLayer;
using PushPull.ViewModels;

namespace PushPull.Controllers
{
    public class ReportController : Controller
    {
        private static readonly DateTime _StartDateTime = new DateTime(1900, 1, 1);
        private IReportRepository _ReportRepository;

        public IReportRepository ReportRepository
        {
            get { return _ReportRepository ?? (_ReportRepository = new ReportRepository()); }
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var lastWeekIndex = GetWeekIndex(DateTime.Now)-1;
            var weeklyTaskData = await ReportRepository.GetWeeklyTaskReportAsync(userId, lastWeekIndex);
            var dailyTaskData = await ReportRepository.GetDailyTaskReportAsync(userId);
            var reportViewModel = new DailyReportViewModel(weeklyTaskData,dailyTaskData);
            return View("Index", reportViewModel);
        }

        public int GetWeekIndex(DateTime dateTime)
        {
            return (dateTime - _StartDateTime).Days/7;
        }
    }
}