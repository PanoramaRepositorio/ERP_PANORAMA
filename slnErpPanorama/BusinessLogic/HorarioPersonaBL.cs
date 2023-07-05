using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class HorarioPersonaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}
        public List<HorarioPersonaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                return HorarioPersona.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        //public List<HorarioPersonaBE> ListaTodosActivo(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        //      {
        //	try
        //	{
        //		HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
        //		return HorarioPersona.ListaTodosActivo(IdPersona, FechaDesde, FechaHasta);
        //	}
        //	catch (Exception ex)
        //	{ throw ex; }
        //}

        public List<HorarioPersonaBE> ListaHorasFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                return HorarioPersona.ListaHorasFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<HorarioPersonaBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                return HorarioPersona.ListaFecha(IdEmpresa, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }




        public HorarioPersonaBE Selecciona(int IdHorarioPersona)
		{
			try
			{
				HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
				return HorarioPersona.Selecciona(IdHorarioPersona);
			}
			catch (Exception ex)
			{ throw ex; }
		}





		public void Inserta(HorarioPersonaBE pItem)
		{
			try
			{
				HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
				HorarioPersona.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void Inserta(List<HorarioPersonaBE> pListaHorarioPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();

                    foreach (HorarioPersonaBE item in pListaHorarioPersona)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        //item.IdPromocionTemporal = IdPromocionTemporal;
                        HorarioPersona.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaFecha(int IdEmpresa, int IdPersona, int IdTurno, DateTime FechaDesde, DateTime FechaHasta, int IdPerReg, string Usuario, string Maquina)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                HorarioPersona.InsertaFecha(IdEmpresa, IdPersona, IdTurno, FechaDesde, FechaHasta, IdPerReg, Usuario, Maquina);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(HorarioPersonaBE pItem)
		{
			try
			{
				HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
				HorarioPersona.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}


        public void Actualiza(List<HorarioPersonaBE> pListaHorarioPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();

                    foreach (HorarioPersonaBE item in pListaHorarioPersona)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            //item.IdPromocionTemporal = pItem.IdPromocionTemporal;
                            HorarioPersona.Inserta(item);
                        }
                        else if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            HorarioPersona.Actualiza(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(HorarioPersonaBE pItem)
		{
			try
			{
				HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
				HorarioPersona.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void ActualizaIncidencia(HorarioPersonaBE pItem)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                HorarioPersona.ActualizaIncidencia(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaCerrado(int IdEmpresa, int IdPersona, bool FlagCerrado, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HorarioPersonaDL HorarioPersona = new HorarioPersonaDL();
                HorarioPersona.ActualizaCerrado(IdEmpresa, IdPersona, FlagCerrado, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }



    }
}
