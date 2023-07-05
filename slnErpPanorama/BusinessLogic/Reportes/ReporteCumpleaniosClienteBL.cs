using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCumpleaniosClienteBL
    {
        public List<ReporteCumpleaniosClienteBE> Listado(int IdTienda, int Mes)
        {
            try
            {
                ReporteCumpleaniosClienteDL reporte = new ReporteCumpleaniosClienteDL();
                return reporte.Listado(IdTienda, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCumpleaniosClienteBE> ListadoClientesNuevos(int IdTienda, int Mes, int Anio)
        {
            try
            {
                ReporteCumpleaniosClienteDL reporte = new ReporteCumpleaniosClienteDL();
                return reporte.ListadoClientesNuevos(IdTienda, Mes, Anio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CorreoClienteCumpleanosBE pItem)
        {
            try
            {
                ReporteCumpleaniosClienteDL CorreoClienteCumpleanos = new ReporteCumpleaniosClienteDL();
                CorreoClienteCumpleanos.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
