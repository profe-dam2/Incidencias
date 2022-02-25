using Incidencias.Services.DataSet;
using Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Incidencias.Commands
{
    class UpdateDptoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            formViewModel.ListaDepartamentos = DataSetHandler.getDptos();
        }
        public FormViewModel formViewModel { set; get; }
        public UpdateDptoCommand(FormViewModel formViewModel)
        {
            this.formViewModel = formViewModel;
        }
    }
}
