using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AsistenciaBL
    {
        public List<AsistenciaBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AsistenciaDL Asistencia = new AsistenciaDL();
                return Asistencia.ListaFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AsistenciaBE> ListaDni(String Dni, DateTime Fecha)
        {
            try
            {
                AsistenciaDL Asistencia = new AsistenciaDL();
                return Asistencia.ListaDni(Dni, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
