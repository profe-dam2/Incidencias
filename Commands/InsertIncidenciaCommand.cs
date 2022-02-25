using Incidencias.Models;
using Incidencias.Services.DataSet;
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
    class InsertIncidenciaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int idEmpleado = DataSetHandler.GetEmpleadoByDNI(formViewModel.Incidencia.DNI);
            if (idEmpleado == 0)
            {
                MessageBox.Show("El DNI no existe");
            }
            else
            {
                formViewModel.Incidencia.IdEmpleado = idEmpleado;
                bool insertarOk = DataSetHandler.InsertarIncidencia(formViewModel.Incidencia);
                if (!insertarOk)
                {
                    MessageBox.Show("No se pudo insertar. Llama al servicio técnico: 923442313");
                }
                else
                {
                    MessageBox.Show("La incidencia se registró correctamente");
                    formViewModel.Incidencia = new IncidenciaModel();
                }
            }
        }

        public FormViewModel formViewModel { set; get; }
        public InsertIncidenciaCommand(FormViewModel formViewModel)
        {
            this.formViewModel = formViewModel;
        }
    }
}
