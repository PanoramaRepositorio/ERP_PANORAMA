using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PagoServicioBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PagoServicioBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PagoServicioDL PagoServicio = new PagoServicioDL();
				return PagoServicio.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PagoServicioBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PagoServicioDL PagoServicio = new PagoServicioDL();
                return PagoServicio.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PagoServicioBE> ListaVencido(int IdEmpresa)
        {
            try
            {
                PagoServicioDL PagoServicio = new PagoServicioDL();
                return PagoServicio.ListaVencido(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PagoServicioBE Selecciona(int IdPagoServicio)
		{
			try
			{
				PagoServicioDL PagoServicio = new PagoServicioDL();
				return PagoServicio.Selecciona(IdPagoServicio);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public PagoServicioBE SeleccionaNumero(int IdPagoServicio, string Numero)
        {
            try
            {
                PagoServicioDL PagoServicio = new PagoServicioDL();
                return PagoServicio.SeleccionaNumero(IdPagoServicio, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PagoServicioBE pItem)
		{
			try
			{
				PagoServicioDL PagoServicio = new PagoServicioDL();
				PagoServicio.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PagoServicioBE pItem)
		{
			try
			{
				PagoServicioDL PagoServicio = new PagoServicioDL();
				PagoServicio.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PagoServicioBE pItem)
		{
			try
			{
				PagoServicioDL PagoServicio = new PagoServicioDL();
				PagoServicio.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
