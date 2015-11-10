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
        private ReportRepository _ReportRepository;

        public ReportRepository ReportRepository
        {
            get { return _ReportRepository ?? (_ReportRepository = new ReportRepository()); }
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var lastWeekIndex = GetWeekIndex(DateTime.Now)-1;
            var weeklyTaskData =await _ReportRepository.GetOneWeekTaskReportAsync(userId, lastWeekIndex);
            var reportViewModel = new ReportViewModel(weeklyTaskData);
            return View("Index", reportViewModel);
        }

        public int GetWeekIndex(DateTime dateTime)
        {
            return (dateTime - _StartDateTime).Days/7;
        }
    }
}