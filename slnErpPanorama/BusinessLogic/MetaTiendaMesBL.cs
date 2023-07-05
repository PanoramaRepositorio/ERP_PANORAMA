using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class MetaTiendaMesBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<MetaTiendaMesBE> ListaTodosActivo(int IdEmpresa, int Periodo)
		{
			try
			{
				MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
				return MetaTiendaMes.ListaTodosActivo(IdEmpresa, Periodo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<MetaTiendaMesBE> ListaTodosActivoHorizontal(int IdEmpresa, int Periodo)
        {
            try
            {
                MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
                return MetaTiendaMes.ListaTodosActivoHorizontal(IdEmpresa, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetaTiendaMesBE Selecciona(int IdMetaTiendaMes)
		{
			try
			{
				MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
				return MetaTiendaMes.Selecciona(IdMetaTiendaMes);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public MetaTiendaMesBE SeleccionaTiendaTipoCliente(int IdTienda, int IdTipoCliente, int Periodo, int Mes)
        {
            try
            {
                MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
                return MetaTiendaMes.SeleccionaTiendaTipoCliente(IdTienda, IdTipoCliente, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MetaTiendaMesBE pItem)
		{
			try
			{
				MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
				MetaTiendaMes.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(MetaTiendaMesBE pItem)
		{
			try
			{
				MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
				MetaTiendaMes.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(MetaTiendaMesBE pItem)
		{
			try
			{
				MetaTiendaMesDL MetaTiendaMes = new MetaTiendaMesDL();
				MetaTiendaMes.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
