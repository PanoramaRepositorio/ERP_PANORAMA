using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class ProformaDisenioDetalleBL
    {
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<ProformaDisenioDetalleBE> ListaTodosActivo(int IdSolicitudInsumo)
		{
			try
			{
                ProformaDisenioDetalleDL SolicitudInsumoDetalle = new ProformaDisenioDetalleDL();
				return SolicitudInsumoDetalle.ListaTodosActivo(IdSolicitudInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<ProformaDisenioDetalleBE> ListaSolicitudEgresoDetalle(int pIdSolicitudEgreso)
        {
            try
            {
                ProformaDisenioDetalleDL SolicitudEgresoDetalle = new ProformaDisenioDetalleDL();
                return SolicitudEgresoDetalle.ListaSolicitudEgresoDetalle(pIdSolicitudEgreso);
            }
            catch (Exception ex)
            { throw ex; }
        }



        //public SolicitudEgresoDetalleBE Selecciona(int IdSolicitudInsumoDetalle)
        //{
        //	try
        //	{
        //              SolicitudEgresoDetalleDL SolicitudInsumoDetalle = new SolicitudEgresoDetalleDL();
        //		return SolicitudInsumoDetalle.Selecciona(IdSolicitudInsumoDetalle);
        //	}
        //	catch (Exception ex)
        //	{ throw ex; }
        //}

        //public void Inserta(SolicitudInsumoDetalleBE pItem)
        //{
        //	try
        //	{
        //              SolicitudEgresoDetalleDL SolicitudInsumoDetalle = new SolicitudEgresoDetalleDL();
        //		SolicitudInsumoDetalle.Inserta(pItem);
        //	}
        //	catch (Exception ex)
        //	{ throw ex; }
        //}

        public void Actualiza(ProformaDisenioDetalleBE pItem)
		{
			try
			{
                ProformaDisenioDetalleDL SolicitudInsumoDetalle = new ProformaDisenioDetalleDL();
				SolicitudInsumoDetalle.Actualiza_E(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(ProformaDisenioDetalleBE pItem)
		{
			try
			{
                ProformaDisenioDetalleDL SolicitudInsumoDetalle = new ProformaDisenioDetalleDL();
				SolicitudInsumoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
