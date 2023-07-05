using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PrestamoBancoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PrestamoBancoDetalleBE> ListaTodosActivo(int IdPrestamoBanco, int IdSituacion)
		{
			try
			{
				PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
				return PrestamoBancoDetalle.ListaTodosActivo(IdPrestamoBanco, IdSituacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}


        public PrestamoBancoDetalleBE Selecciona(int IdPrestamoBancoDetalle)
		{
			try
			{
				PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
				return PrestamoBancoDetalle.Selecciona(IdPrestamoBancoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PrestamoBancoDetalleBE pItem)
		{
			try
			{
				PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
				PrestamoBancoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PrestamoBancoDetalleBE pItem)
		{
			try
			{
				PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
				PrestamoBancoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void ActualizaSituacion(PrestamoBancoDetalleBE pItem)
        {
            try
            {
                PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
                PrestamoBancoDetalle.ActualizaSituacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PrestamoBancoDetalleBE pItem)
		{
			try
			{
				PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();
				PrestamoBancoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
