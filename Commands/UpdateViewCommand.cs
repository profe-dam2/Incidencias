using Incidencias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Incidencias.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string viewName = (string)parameter;

                if (viewName.Equals("home"))
                {
                    mainViewModel.SelectedViewModel = new HomeViewModel();
                }else if (viewName.Equals("resumen"))
                {
                    mainViewModel.SelectedViewModel = new ResumenViewModel(this);
                }else if (viewName.Equals("form"))
                {
                    mainViewModel.SelectedViewModel = new FormViewModel();
                }else if (viewName.Equals("report"))
                {
                    mainViewModel.SelectedViewModel = reportViewModel;
                }
            }
        }

        public MainViewModel mainViewModel { get; set; }
        public ReportViewModel reportViewModel { set; get; }
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.mainViewModel.SelectedViewModel = new ResumenViewModel(this);
            reportViewModel = new ReportViewModel();
        }
    }
}
