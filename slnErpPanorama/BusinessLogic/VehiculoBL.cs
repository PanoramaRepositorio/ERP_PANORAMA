using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class VehiculoBL
	{
		public List<VehiculoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				return Vehiculo.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public VehiculoBE Selecciona(int IdVehiculo)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				return Vehiculo.Selecciona(IdVehiculo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public VehiculoBE SeleccionaMarca(int IdVehiculo)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				return Vehiculo.SeleccionaMarca(IdVehiculo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(VehiculoBE pItem)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				Vehiculo.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(VehiculoBE pItem)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				Vehiculo.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(VehiculoBE pItem)
		{
			try
			{
				VehiculoDL Vehiculo = new VehiculoDL();
				Vehiculo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
