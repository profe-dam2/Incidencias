using Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Execute(object parameter)
        {
            resumenViewModel.updateViewCommand.reportViewModel.GenerarInformeIndicencias();
            resumenViewModel.updateViewCommand.Execute("report");
        }

        public ResumenViewModel resumenViewModel { set; get; }
        public ConsultarCommand(ResumenViewModel resumenViewModel)
        {
            this.resumenViewModel = resumenViewModel;
        }
    }
}
