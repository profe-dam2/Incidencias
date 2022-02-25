using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Models
{
    class IncidenciaModel
    {
        public int IdIncidencia { set; get; }
        public string Tipo { set; get; }
        public string Descripcion { set; get; }

        public DptoModel Dpto { set; get; }

        public int IdEmpleado { set; get; }

        public string Prioridad { set; get; }
        public DateTime Fecha { set; get; }
        public string DNI { set; get; }
        public string Email { set; get; }

        public IncidenciaModel()
        {
            Fecha = DateTime.Today;
        }
    }
}
