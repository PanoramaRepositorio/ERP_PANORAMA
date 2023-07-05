using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class MovimientoCajaChicaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<MovimientoCajaChicaBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
				return MovimientoCajaChica.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<MovimientoCajaChicaBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
                return MovimientoCajaChica.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoCajaChicaBE Selecciona(int IdMovimientoCajaChica)
		{
			try
			{
				MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
				return MovimientoCajaChica.Selecciona(IdMovimientoCajaChica);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public Int32 Inserta(MovimientoCajaChicaBE pItem)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
                    int IdMovimientoCajaChica = 0;

                    //Insertamos el Movimiento caja chica
                    IdMovimientoCajaChica = MovimientoCajaChica.Inserta(pItem);

                    ts.Complete();

                    return IdMovimientoCajaChica;
                }
            }
            catch (Exception ex)
            { throw ex; }


        }

		public void Actualiza(MovimientoCajaChicaBE pItem)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
                    MovimientoCajaChica.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

		public void Elimina(MovimientoCajaChicaBE pItem)
		{
			try
			{
				MovimientoCajaChicaDL MovimientoCajaChica = new MovimientoCajaChicaDL();
				MovimientoCajaChica.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
