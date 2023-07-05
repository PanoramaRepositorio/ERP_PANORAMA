using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class TurnoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<TurnoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				TurnoDL Turno = new TurnoDL();
				return Turno.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public TurnoBE Selecciona(int IdTurno)
		{
			try
			{
				TurnoDL Turno = new TurnoDL();
				return Turno.Selecciona(IdTurno);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(TurnoBE pItem, List<TurnoDetalleBE> pListaTurnoDetalle)
		{
			try
			{
				using (TransactionScope ts = new TransactionScope())
				{
					TurnoDL Turno = new TurnoDL();
					TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();

					int IdTurno = 0;
					IdTurno = Turno.Inserta(pItem);

					foreach (TurnoDetalleBE item in pListaTurnoDetalle)
					{
						//Insertamos el detalle de la solicitud de producto
						item.IdTurno = IdTurno;
						TurnoDetalle.Inserta(item);
					}

					ts.Complete();
				}
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(TurnoBE pItem, List<TurnoDetalleBE> pListaTurnoDetalle)
		{
			try
			{
				using (TransactionScope ts = new TransactionScope())
				{
					TurnoDL Turno = new TurnoDL();
					TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();

					foreach (TurnoDetalleBE item in pListaTurnoDetalle)
					{
						if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
						{
							//Insertamos el detalle 
							item.IdTurno = pItem.IdTurno;
							TurnoDetalle.Inserta(item);
						}
						else
						{
							//Actualizamos el detalle
							TurnoDetalle.Actualiza(item);
						}
					}
					Turno.Actualiza(pItem);
					ts.Complete();
				}
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(TurnoBE pItem)
		{
			try
			{
				TurnoDL Turno = new TurnoDL();
				Turno.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
