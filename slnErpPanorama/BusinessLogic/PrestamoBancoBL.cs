using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PrestamoBancoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PrestamoBancoBE> ListaTodosActivo(int IdEmpresa, int IdSituacion)
		{
			try
			{
				PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
				return PrestamoBanco.ListaTodosActivo(IdEmpresa, IdSituacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PrestamoBancoBE> ListaTodosActivoAñoMes(int IdEmpresa,int Moneda)
        {
            try
            {
                PrestamoBancoDL PrestamoBancoAñoMes = new PrestamoBancoDL();
                return PrestamoBancoAñoMes.ListaTodosActivoAñoMes(IdEmpresa,Moneda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PrestamoBancoBE> ListaTodosActivoPagos(int Moneda)
        {
            try
            {
                PrestamoBancoDL PrestamoBancoPagos = new PrestamoBancoDL();
                return PrestamoBancoPagos.ListaTodosActivoPagos(Moneda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PrestamoBancoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
                return PrestamoBanco.ListaFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PrestamoBancoBE Selecciona(int IdPrestamoBanco)
		{
			try
			{
				PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
				return PrestamoBanco.Selecciona(IdPrestamoBanco);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PrestamoBancoBE pItem, List<PrestamoBancoDetalleBE> pListaPrestamoBancoDetalle)
		{
			try
			{
                using (TransactionScope ts = new TransactionScope())
                {
                    PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
                    PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();

                    //Insertar en el PrestamoBanco
                    int IdPrestamoBanco = 0;
                    IdPrestamoBanco = PrestamoBanco.Inserta(pItem);

                    foreach (PrestamoBancoDetalleBE item in pListaPrestamoBancoDetalle)
                    {
                        //Insertamos el detalle del PrestamoBanco
                        item.IdPrestamoBanco = IdPrestamoBanco;
                        PrestamoBancoDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PrestamoBancoBE pItem, List<PrestamoBancoDetalleBE> pListaPrestamoBancoDetalle)
		{
			try
			{
                using (TransactionScope ts = new TransactionScope())
                {
                    PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
                    PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();

                    foreach (PrestamoBancoDetalleBE item in pListaPrestamoBancoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del PrestamoBanco
                            item.IdPrestamoBanco = pItem.IdPrestamoBanco;
                            PrestamoBancoDetalle.Inserta(item);
                        }
                        else
                        {
                            PrestamoBancoDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el PrestamoBanco
                    PrestamoBanco.Actualiza(pItem);

                    ts.Complete();
                }
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PrestamoBancoBE pItem)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PrestamoBancoDL PrestamoBanco = new PrestamoBancoDL();
                    PrestamoBancoDetalleDL PrestamoBancoDetalle = new PrestamoBancoDetalleDL();

                    List<PrestamoBancoDetalleBE> ListaSolicitudDetalle = null;
                    ListaSolicitudDetalle = new PrestamoBancoDetalleDL().ListaTodosActivo(pItem.IdPrestamoBanco,0);

                    foreach (PrestamoBancoDetalleBE item in ListaSolicitudDetalle)
                    {
                        PrestamoBancoDetalle.Elimina(item);
                    }

                    PrestamoBanco.Elimina(pItem);

                    ts.Complete();
                }


            }
            catch (Exception ex)
            { throw ex; }


		}

	}
}
