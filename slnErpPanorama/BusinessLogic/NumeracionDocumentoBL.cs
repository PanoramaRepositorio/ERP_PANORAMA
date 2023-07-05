using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class NumeracionDocumentoBL
    {
        public List<NumeracionDocumentoBE> ListaTodosActivo()
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                return NumeracionDocumento.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public NumeracionDocumentoBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, int Periodo, String Serie)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                return NumeracionDocumento.SeleccionaNumero(IdEmpresa, IdTipoDocumento, Periodo, Serie);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<NumeracionDocumentoBE> ObtenerCorrelativoPeriodo(int IdEmpresa, int IdTipoDocumento, int Periodo)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                return NumeracionDocumento.ObtenerCorrelativoPeriodo(IdEmpresa, IdTipoDocumento, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<NumeracionDocumentoBE> ObtenerCorrelativoPeriodo(int IdEmpresa, int IdTienda, int IdTipoDocumento, bool FlagFacturacion, int Periodo)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                return NumeracionDocumento.ObtenerCorrelativoPeriodo(IdEmpresa, IdTienda, IdTipoDocumento, FlagFacturacion, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<NumeracionDocumentoBE> ObtenerCorrelativoSerie(int IdEmpresa, int IdTipoDocumento, string Serie)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                return NumeracionDocumento.ObtenerCorrelativoSerie(IdEmpresa, IdTipoDocumento, Serie);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(NumeracionDocumentoBE pItem)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                NumeracionDocumento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(NumeracionDocumentoBE pItem)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                NumeracionDocumento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(NumeracionDocumentoBE pItem)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                NumeracionDocumento.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCorrelativoPeriodo(int IdEmpresa, int IdTipoDocumento, int Periodo)
        {
            try
            {
                NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                NumeracionDocumento.ActualizaCorrelativoPeriodo(IdEmpresa, IdTipoDocumento, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
