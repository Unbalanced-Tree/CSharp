using FastReport;
using FastReportPdf.Models;
using Newtonsoft.Json;

namespace FastReportDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // To create an empty report and attach to FastReport designer 
        private void Form1_Load(object sender, EventArgs e)
        {
            Report report = new();
            var responseModel = JsonConvert.DeserializeObject<ResponseDataModel>(File.ReadAllText("data.json"));
            var data = new List<ResponseDataModel> { responseModel };
            report.RegisterData(data, "ResponseData");
            report.Design();
        }
    }
}