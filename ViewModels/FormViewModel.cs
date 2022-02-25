using Incidencias.Commands;
using Incidencias.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Incidencias.ViewModels
{
    class FormViewModel:ViewModelBase
    {
        public ICommand UpdateDptoCommand { set; get; }
        public ICommand InsertIncidenciaCommand { set; get; }
        private IncidenciaModel incidencia;
        public IncidenciaModel Incidencia
        {
            get { return incidencia; }
            set
            {
                incidencia = value;
                OnPropertyChanged(nameof(Incidencia));
            }
        }

        private ObservableCollection<DptoModel> listaDepartamentos;
        public ObservableCollection<DptoModel> ListaDepartamentos
        {
            get
            {
                return listaDepartamentos;
            }
            set
            {
                listaDepartamentos = value;
                OnPropertyChanged(nameof(ListaDepartamentos));
            }
        }

        public FormViewModel()
        {
            UpdateDptoCommand = new UpdateDptoCommand(this);
            InsertIncidenciaCommand = new InsertIncidenciaCommand(this);
            Incidencia = new IncidenciaModel();
        }

    }
}
