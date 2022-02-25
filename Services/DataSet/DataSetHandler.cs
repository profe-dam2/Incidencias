using Incidencias.Models;
using Incidencias.Services.DataSet.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidencias.Services.DataSet
{
    class DataSetHandler
    {
        private static IndicenciasTableAdapter incidenciasAdapter = new IndicenciasTableAdapter();
        private static departamentoTableAdapter dptoAdapter = new departamentoTableAdapter();
        private static empleadoTableAdapter empleadoAdapter = new empleadoTableAdapter();
        private static InformeIncidenciasTableAdapter adapter = new InformeIncidenciasTableAdapter();
        

        public static DataTable GetInformeIncidencias()
        {
            return adapter.GetData();
        }


        public static int GetEmpleadoByDNI(string dni)
        {
            try
            {
                DataTable empleadoDT = empleadoAdapter.GetDataByDNI(dni);
                DataRow empleadoRow = empleadoDT.Rows[0];
                int idEmpleado = (int)empleadoRow["idEmpleado"];
                return idEmpleado;
            }
            catch
            {
                return 0;
            }
           
        }

        public static bool InsertarIncidencia(IncidenciaModel i)
        {
            try
            {
                incidenciasAdapter.Insert(i.Tipo, i.Descripcion, i.Dpto.idDpto, i.Prioridad, i.Fecha, i.IdEmpleado, i.Email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static ObservableCollection<DptoModel> getDptos()
        {
            DataTable dptosDataTable = dptoAdapter.GetData();
            ObservableCollection<DptoModel> listaDptos = new ObservableCollection<DptoModel>();


            foreach (DataRow dpto in dptosDataTable.Rows)
            {
                DptoModel myDpto = new DptoModel();
                myDpto.idDpto = (int)dpto["idDpto"];
                myDpto.nombreDpto = dpto["nombreDpto"].ToString();
                listaDptos.Add(myDpto);
            }
            return listaDptos;
        }
    }
}
