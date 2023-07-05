using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class NovioRegaloBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<NovioRegaloBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				NovioRegaloDL NovioRegalo = new NovioRegaloDL();
				return NovioRegalo.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public NovioRegaloBE Selecciona(int IdNovioRegalo)
		{
			try
			{
				NovioRegaloDL NovioRegalo = new NovioRegaloDL();
				return NovioRegalo.Selecciona(IdNovioRegalo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public NovioRegaloBE SeleccionaNumero(int Periodo, string Numero)
        {
            try
            {
                NovioRegaloDL NovioRegalo = new NovioRegaloDL();
                return NovioRegalo.SeleccionaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(NovioRegaloBE pItem, List<NovioRegaloDetalleBE> pListaNovioRegaloDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    NovioRegaloDL NovioRegalo = new NovioRegaloDL();
                    NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();

                    //Insertar en el NovioRegalo
                    int IdNovioRegalo = 0;
                    IdNovioRegalo = NovioRegalo.Inserta(pItem);

                    foreach (NovioRegaloDetalleBE item in pListaNovioRegaloDetalle)
                    {
                        //Insertamos el detalle del NovioRegalo
                        item.IdNovioRegalo = IdNovioRegalo;
                        NovioRegaloDetalle.Inserta(item);
                    }

                    //Actualizamos el correlativo del NovioRegalo
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Periodo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

		public void Actualiza(NovioRegaloBE pItem, List<NovioRegaloDetalleBE> pListaNovioRegaloDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    NovioRegaloDL NovioRegalo = new NovioRegaloDL();
                    NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();

                    foreach (NovioRegaloDetalleBE item in pListaNovioRegaloDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del NovioRegalo
                            item.IdNovioRegalo = pItem.IdNovioRegalo;
                            NovioRegaloDetalle.Inserta(item);
                        }
                        else
                        {
                            NovioRegaloDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el NovioRegalo
                    NovioRegalo.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

		public void Elimina(NovioRegaloBE pItem)
		{
			try
			{
				NovioRegaloDL NovioRegalo = new NovioRegaloDL();
				NovioRegalo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
