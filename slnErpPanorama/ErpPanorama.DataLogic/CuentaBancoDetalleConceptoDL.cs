using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class CuentaBancoDetalleConceptoDL
	{
		public CuentaBancoDetalleConceptoDL() { }

		public void Inserta(CuentaBancoDetalleConceptoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleConcepto_Inserta");

			db.AddOutParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, pItem.IdCuentaBancoDetalleConcepto);
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Actualiza(CuentaBancoDetalleConceptoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleConcepto_Actualiza");

			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, pItem.IdCuentaBancoDetalleConcepto);
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(CuentaBancoDetalleConceptoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleConcepto_Elimina");

			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, pItem.IdCuentaBancoDetalleConcepto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public List<CuentaBancoDetalleConceptoBE> ListaTodosActivo(int IdCuentaBancoDetalleCausal)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleConcepto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, IdCuentaBancoDetalleCausal);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<CuentaBancoDetalleConceptoBE> CuentaBancoDetalleConceptolist = new List<CuentaBancoDetalleConceptoBE>();
			CuentaBancoDetalleConceptoBE CuentaBancoDetalleConcepto;
			while (reader.Read())
			{
				CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoBE();
				CuentaBancoDetalleConcepto.IdCuentaBancoDetalleConcepto = Int32.Parse(reader["IdCuentaBancoDetalleConcepto"].ToString());
				CuentaBancoDetalleConcepto.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
				CuentaBancoDetalleConcepto.Descripcion = reader["Descripcion"].ToString();
                CuentaBancoDetalleConcepto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CuentaBancoDetalleConcepto.DescTienda = reader["DescTienda"].ToString();
				CuentaBancoDetalleConcepto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				CuentaBancoDetalleConceptolist.Add(CuentaBancoDetalleConcepto);
			}
			reader.Close();
			reader.Dispose();
			return CuentaBancoDetalleConceptolist;
		}

		public CuentaBancoDetalleConceptoBE Selecciona(int IdCuentaBancoDetalleConcepto)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleConcepto_Selecciona");
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, IdCuentaBancoDetalleConcepto);

			IDataReader reader = db.ExecuteReader(dbCommand);
			CuentaBancoDetalleConceptoBE CuentaBancoDetalleConcepto = null;
			while (reader.Read())
			{
				CuentaBancoDetalleConcepto = new CuentaBancoDetalleConceptoBE();
				CuentaBancoDetalleConcepto.IdCuentaBancoDetalleConcepto = Int32.Parse(reader["IdCuentaBancoDetalleConcepto"].ToString());
				CuentaBancoDetalleConcepto.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
				CuentaBancoDetalleConcepto.Descripcion = reader["Descripcion"].ToString();
                CuentaBancoDetalleConcepto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CuentaBancoDetalleConcepto.DescTienda = reader["DescTienda"].ToString();
				CuentaBancoDetalleConcepto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return CuentaBancoDetalleConcepto;
		}

	}
}
