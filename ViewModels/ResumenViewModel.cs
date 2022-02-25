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
        public ICommand ConsultarCommand { set; get; }

        public UpdateViewCommand updateViewCommand { set; get; }
        public ResumenViewModel(UpdateViewCommand updateViewCommand)
        {
            ConsultarCommand = new ConsultarCommand(this);
            this.updateViewCommand = updateViewCommand;
        }
    }
}
