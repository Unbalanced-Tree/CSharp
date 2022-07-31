using FastReport;
using FastReport.Export.Pdf;
using FastReportPdf.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastReportPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(nameof(GetData))]
        public ResponseDataModel GetData()
        {
            return ResponseData();
        }

        private static ResponseDataModel ResponseData()
        {
            var response = new ResponseDataModel
            {
                Header = "FasterReprt Header",
                Content = "FastReprt Column",
                Footer = "FastReport Footer",
            };
            List<OneMoreDataModel> collection = new();
            for (int i = 0; i < 20; i++)
            {
                collection.Add(new OneMoreDataModel { Number = i + 1 });
            }
            response.Collection = collection;
            return response;
        }

        [HttpGet(nameof(GenerateReportPdf))]
        public JsonResult GenerateReportPdf()
        {
            string filePath = string.Concat(Environment.CurrentDirectory, @"\Controllers\AFastReport.frx");
            Report report = Report.FromFile(filePath);
            var data = new List<ResponseDataModel> { ResponseData() };
            report.RegisterData(data, "ResponseData");
            report.Prepare();
            PDFExport export = new();
            MemoryStream stream = new ();
            report.Export(export, stream);
            string reportName = "Reportpdf.pdf";
            System.IO.File.WriteAllBytes(reportName, stream.ToArray());
            return new JsonResult(new { ReportName = reportName });
        }
    }
}
