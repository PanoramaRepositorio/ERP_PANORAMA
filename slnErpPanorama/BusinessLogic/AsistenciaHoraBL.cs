using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AsistenciaHoraBL
    {
        public List<AsistenciaHoraBE> ListaHoras(int Periodo, int Mes)
        {
            try
            {
                AsistenciaHoraDL Asistencia = new AsistenciaHoraDL();
                return Asistencia.ListaHoras(Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
