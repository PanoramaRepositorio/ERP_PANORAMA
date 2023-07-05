using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class SolicitudEgresoDetalleBL
    {
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<SolicitudEgresoDetalleBE> ListaTodosActivo(int IdSolicitudInsumo)
		{
			try
			{
                SolicitudEgresoDetalleDL SolicitudInsumoDetalle = new SolicitudEgresoDetalleDL();
				return SolicitudInsumoDetalle.ListaTodosActivo(IdSolicitudInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<SolicitudEgresoDetalleBE> ListaSolicitudEgresoDetalle(int pIdSolicitudEgreso)
        {
            try
            {
                SolicitudEgresoDetalleDL SolicitudEgresoDetalle = new SolicitudEgresoDetalleDL();
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

        public void Actualiza(SolicitudEgresoDetalleBE pItem)
		{
			try
			{
                SolicitudEgresoDetalleDL SolicitudInsumoDetalle = new SolicitudEgresoDetalleDL();
				SolicitudInsumoDetalle.Actualiza_E(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(SolicitudEgresoDetalleBE pItem)
		{
			try
			{
                SolicitudEgresoDetalleDL SolicitudInsumoDetalle = new SolicitudEgresoDetalleDL();
				SolicitudInsumoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
