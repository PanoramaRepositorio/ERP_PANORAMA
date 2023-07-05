using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class CuentaBancoDetalleConceptoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

        public List<CuentaBancoDetalleConceptoBE> ListaTodosActivo(int IdCuentaBancoDetalleCausal)
		{
			try
			{
				CuentaBancoDetalleConceptoDL CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoDL();
                return CuentaBancoDetalleConcepto.ListaTodosActivo(IdCuentaBancoDetalleCausal);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public CuentaBancoDetalleConceptoBE Selecciona(int IdCuentaBancoDetalleConcepto)
		{
			try
			{
				CuentaBancoDetalleConceptoDL CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoDL();
				return CuentaBancoDetalleConcepto.Selecciona(IdCuentaBancoDetalleConcepto);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(CuentaBancoDetalleConceptoBE pItem)
		{
			try
			{
				CuentaBancoDetalleConceptoDL CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoDL();
				CuentaBancoDetalleConcepto.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(CuentaBancoDetalleConceptoBE pItem)
		{
			try
			{
				CuentaBancoDetalleConceptoDL CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoDL();
				CuentaBancoDetalleConcepto.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(CuentaBancoDetalleConceptoBE pItem)
		{
			try
			{
				CuentaBancoDetalleConceptoDL CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoDL();
				CuentaBancoDetalleConcepto.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
