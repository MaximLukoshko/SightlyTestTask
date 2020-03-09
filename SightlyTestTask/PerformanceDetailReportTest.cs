
namespace SightlyTestTask
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    using Excel = Microsoft.Office.Interop.Excel;

    [TestFixture]
    public class PerformanceDetailReportTest
    {
        private string reportPath;

        private Excel.Application excelApplication;
        private Excel.Workbook excelWorkBook;
        private Excel.Worksheet excelWorkSheet;

        [OneTimeSetUp]
        public void SetupTest()
        {    
            this.reportPath = SightlyClient.DownloadPerformanceDetailReport();

            this.excelApplication = new Excel.Application();
            this.excelWorkBook = this.excelApplication.Workbooks.Open(this.reportPath);
            this.excelWorkSheet = (Excel.Worksheet)this.excelWorkBook.Sheets[1];
        }

        [TestCase(1, "Start Date")]
        [TestCase(2, "End Date")]
        [TestCase(3, "CID")]
        [TestCase(4, "Campaign Name")]
        [TestCase(5, "Placement Name")]
        [TestCase(6, "Placement ID")]
        [TestCase(7, "Impressions")]
        [TestCase(8, "Views")]
        [TestCase(9, "View Rate")]
        [TestCase(10, "Clicks")]
        [TestCase(11, "CTR")]
        [TestCase(12, "CPV")]
        [TestCase(13, "CPM")]
        [TestCase(14, "Cost")]
        [TestCase(15, "Video Played To 25%")]
        [TestCase(16, "Video Played To 50%")]
        [TestCase(17, "Video Played To 75%")]
        [TestCase(18, "Video Played To 100%")]
        [TestCase(19, null)]
        public void CheckColumnNames(int column, string expectedTitle)
        {
            var titleRow = 5;

            var columnName = (string)(this.excelWorkSheet.Cells[titleRow, column] as Excel.Range).Value;

            Assert.AreEqual(expectedTitle, columnName);
        }
        
        [OneTimeTearDown]
        public void TearDownTest()
        {
            this.excelWorkBook.Close();
            this.excelApplication.Quit();
            File.Delete(this.reportPath);
        }
    }
}
