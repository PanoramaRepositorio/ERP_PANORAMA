using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Threading.Tasks;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionVolumenBL
    {

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PromocionVolumenBE> ListaFecha(int IdEmpresa, bool FlagEstado, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PromocionVolumenDL PromocionTemporal = new PromocionVolumenDL();
                return PromocionTemporal.ListaFecha(IdEmpresa, FlagEstado, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(PromocionTemporalBE pItem, List<PromocionTemporalDetalleBE> pListaPromocionTemporalDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                    PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();

                    int IdPromocionTemporal = 0;
                    IdPromocionTemporal = PromocionTemporal.Inserta(pItem);

                    foreach (PromocionTemporalDetalleBE item in pListaPromocionTemporalDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocionTemporal = IdPromocionTemporal;
                        PromocionTemporalDetalle.Inserta(item);
                    }

                    if (pItem.FlagWeb)
                    {
                        PromocionTemporal.ActualizaVistaWeb();
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }


        }

    }
}
