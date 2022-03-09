using Incidencias.Services.DataSet;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void GenerarInformeIndicenciasDNI(string dni)
        {
            rds.Name = "InformeIncidencias";
            rds.Value = DataSetHandler.GetDataByDNI(dni);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = "../../Reports/InformeIncidenciasDNI.rdlc";
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }

        public bool GenerarInformeIndicenciasDNIFechas(string dni, DateTime fecha1, DateTime fecha2)
        {
            rds.Name = "InformeIncidencias";
            DataTable dt = DataSetHandler.GetDataByDNIFechas(dni, fecha1, fecha2);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeIncidenciasDNI.rdlc";
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            return false;
            
        }

        public bool GenerarInformeIndicenciasFecha(DateTime fecha)
        {
            rds.Name = "InformeIncidencias";
            DataTable dt = DataSetHandler.GetDataByFecha(fecha);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeIncidenciasFechas.rdlc";
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            return false;

        }

        public bool GenerarInformeIndicenciasFechas(DateTime fecha1, DateTime fecha2)
        {
            rds.Name = "InformeIncidencias";
            DataTable dt = DataSetHandler.GetDataByFechas(fecha1, fecha2);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeIncidenciasFechas.rdlc";
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            return false;

        }

    }
}
