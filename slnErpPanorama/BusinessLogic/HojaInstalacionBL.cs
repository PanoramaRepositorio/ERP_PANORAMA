using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class HojaInstalacionBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<HojaInstalacionBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
				return HojaInstalacion.ListaTodosActivo(IdEmpresa, FechaDesde,FechaHasta);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public HojaInstalacionBE Selecciona(int IdHojaInstalacion)
		{
			try
			{
				HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
				return HojaInstalacion.Selecciona(IdHojaInstalacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public HojaInstalacionBE SeleccionaFechaTurno(int IdTurno, DateTime Fecha)
        {
            try
            {
                HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
                return HojaInstalacion.SeleccionaFechaTurno(IdTurno, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(HojaInstalacionBE pItem, List<HojaInstalacionDetalleBE> pListaHojaInstalacionDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
                    HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();

                    int IdHojaInstalacion = 0;
                    IdHojaInstalacion = HojaInstalacion.Inserta(pItem);

                    foreach (HojaInstalacionDetalleBE item in pListaHojaInstalacionDetalle)
                    {
                        //Insertamos el detalle
                        item.IdHojaInstalacion = IdHojaInstalacion;
                        HojaInstalacionDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }

		}

		public void Actualiza(HojaInstalacionBE pItem, List<HojaInstalacionDetalleBE> pListaHojaInstalacionDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
                    HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();

                    foreach (HojaInstalacionDetalleBE item in pListaHojaInstalacionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle
                            item.IdHojaInstalacion = pItem.IdHojaInstalacion;
                            HojaInstalacionDetalle.Inserta(item);
                        }
                        else
                        {
                            HojaInstalacionDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos la HojaInstalacion
                    HojaInstalacion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

		public void Elimina(HojaInstalacionBE pItem)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HojaInstalacionDL HojaInstalacion = new HojaInstalacionDL();
                    HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();

                    List<HojaInstalacionDetalleBE> lstHojaInstalacionDetalle = null;
                    lstHojaInstalacionDetalle = HojaInstalacionDetalle.ListaTodosActivo(pItem.IdHojaInstalacion);

                    foreach (HojaInstalacionDetalleBE item in lstHojaInstalacionDetalle)
                    {
                        HojaInstalacionDetalle.Elimina(item);
                    }

                    //Eliminamos Principal
                    HojaInstalacion.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

	}
}
