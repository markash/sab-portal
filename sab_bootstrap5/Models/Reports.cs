using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UploadReportItemModel
    {
        public string Email { get; set; }
        public string Country { get; set; }
        public int UploadCount { get; set; }
    }

    public class UsageReportItemModel
    {
        public string Email { get; set; }
        public string Country { get; set; }
        public DateTime? LastEntry { get; set; }
        public int EntryCount { get; set; }
    }

    public class UploadReportModel
    {
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? EndDate { get; set; }
        public IEnumerable<UploadReportItemModel> Items { get; set; }
    }

    public class UsageReportModel
    {
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? EndDate { get; set; }
        public IEnumerable<UsageReportItemModel> Items { get; set; }
    }

    public static class ReportInitializer
    {

        public static UploadReportModel InitializeUploadReport(DateTime? startDate, DateTime? endDate)
        {
            var reportManager = new ReportDataManager();
            return new UploadReportModel
            {
                StartDate = startDate,
                EndDate = endDate,
                Items = reportManager.UploadReport(startDate, endDate)
            };
        }

        public static UsageReportModel InitializeUsageReport(DateTime? startDate, DateTime? endDate)
        {
            var reportManager = new ReportDataManager();
            return new UsageReportModel
            {
                StartDate = startDate,
                EndDate = endDate,
                Items = reportManager.UsageReport(startDate, endDate)
            };
        }
    }
}