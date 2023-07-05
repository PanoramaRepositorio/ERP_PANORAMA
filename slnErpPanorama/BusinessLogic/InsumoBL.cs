using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class InsumoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<InsumoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				InsumoDL Insumo = new InsumoDL();
				return Insumo.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<InsumoBE> ListaTodosInActivo(int IdEmpresa)
        {
            try
            {
                InsumoDL Insumo = new InsumoDL();
                return Insumo.ListaTodosInActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InsumoBE Selecciona(int IdInsumo)
		{
			try
			{
				InsumoDL Insumo = new InsumoDL();
				return Insumo.Selecciona(IdInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(InsumoBE pItem)
		{
			try
			{
				InsumoDL Insumo = new InsumoDL();
				Insumo.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(InsumoBE pItem)
		{
			try
			{
				InsumoDL Insumo = new InsumoDL();
				Insumo.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(InsumoBE pItem)
		{
			try
			{
				InsumoDL Insumo = new InsumoDL();
				Insumo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
