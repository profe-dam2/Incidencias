using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Models
{
    class DptoModel
    {
        public int idDpto { set; get; }
        public string nombreDpto { set; get; }

        public override string ToString()
        {
            return "id: " + idDpto + ". " + nombreDpto;
        }
    }
}
