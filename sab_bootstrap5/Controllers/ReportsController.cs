using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.Controllers
{
    public class UploadReportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(DateTime? startDate, DateTime? endDate)
        {
            return View(ReportInitializer.InitializeUploadReport(startDate, endDate));
        }
    }

    public class UsageReportController : Controller
    {
        public ActionResult Report(DateTime? startDate, DateTime? endDate)
        {
            return View(ReportInitializer.InitializeUsageReport(startDate, endDate));
        }
    }
}
