using Incidencias.Services.DataSet;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.ViewModels
{
    class ReportViewModel:ViewModelBase
    {
        public string pdfData { set; get; }
        ReportViewer myReport { set; get; }
        ReportDataSource rds { set; get; }

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }

        public void GenerarInformeIndicencias()
        {
            rds.Name = "InformeIncidencias";
            rds.Value = DataSetHandler.GetInformeIncidencias();
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reports/InformeIncidencias.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }

    }
}
