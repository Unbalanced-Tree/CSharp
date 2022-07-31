namespace FastReportPdf.Models
{
    public class ResponseDataModel
    {
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Content { get; set; }
        public List<OneMoreDataModel> Collection { get; set; }

    }
}
