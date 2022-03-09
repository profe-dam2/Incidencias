using Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Incidencias.Commands
{
    class ConsultarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void ConsultarDNIFechas()
        {
            bool okConsulta = resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicenciasDNIFechas(resumenViewModel.DNI,
                    resumenViewModel.Fecha1, resumenViewModel.Fecha2);
            if (okConsulta)
            {
                resumenViewModel.updateViewCommand.Execute("report");

            }
            else
            {
                MessageBox.Show("No se encontró ningún registro para las fechas indicadas", "Infome", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void Execute(object parameter)
        {
            string tipoInforme = (string)parameter;
            if (tipoInforme.Equals("todos"))
            {
                resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicencias();
                resumenViewModel.updateViewCommand.Execute("report");
            }else if (tipoInforme.Equals("dni"))
            {
                resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicenciasDNI(resumenViewModel.DNI);
                resumenViewModel.updateViewCommand.Execute("report");
            }
            else if (tipoInforme.Equals("dniFechas"))
            {

                if (resumenViewModel.checkFiltro)
                {
                    ConsultarDNIFechas();
                }
                else
                {
                    resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicenciasDNI(resumenViewModel.DNI);
                    resumenViewModel.updateViewCommand.Execute("report");
                }
                
            }
            else if (tipoInforme.Equals("fecha"))
            {
                bool okConsulta = resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicenciasFecha(resumenViewModel.Fecha1);
                if (okConsulta)
                {
                    resumenViewModel.updateViewCommand.Execute("report");

                }
                else
                {
                    MessageBox.Show("No se encontró ningún registro para las fechas indicadas", "Infome", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (tipoInforme.Equals("fechas"))
            {
                bool okConsulta = resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicenciasFechas(resumenViewModel.Fecha1, resumenViewModel.Fecha2);
                if (okConsulta)
                {
                    resumenViewModel.updateViewCommand.Execute("report");

                }
                else
                {
                    MessageBox.Show("No se encontró ningún registro para las fechas indicadas", "Infome", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        public ResumenViewModel resumenViewModel { set; get; }
        public ConsultarCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
