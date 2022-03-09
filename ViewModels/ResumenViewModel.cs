using Incidencias.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Incidencias.ViewModels
{
    class ResumenViewModel:ViewModelBase
    {
        public string DNI { set; get; }
        public DateTime Fecha1 { set; get; }
        public DateTime Fecha2 { set; get; }
        public ICommand ConsultarCommand { set; get; }

        public bool checkFiltro { set; get; }
        public UpdateViewCommand updateViewCommand { set; get; }
        public ResumenViewModel(UpdateViewCommand updateViewCommand)
        {
            ConsultarCommand = new ConsultarCommand(this);
            this.updateViewCommand = updateViewCommand;
            Fecha1 = DateTime.Today;
            Fecha2 = DateTime.Today;
            checkFiltro = false;
        }
    }
}
