using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class VehiculoDL
	{
		public VehiculoDL() { }

		public Int32 Inserta(VehiculoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_Inserta");

			db.AddOutParameter(dbCommand, "pIdVehiculo", DbType.Int32, pItem.IdVehiculo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPlaca", DbType.String, pItem.Placa);
			db.AddInParameter(dbCommand, "pNumeroSerie", DbType.String, pItem.NumeroSerie);
			db.AddInParameter(dbCommand, "pNumeroMotor", DbType.String, pItem.NumeroMotor);
			db.AddInParameter(dbCommand, "pColor", DbType.String, pItem.Color);
			db.AddInParameter(dbCommand, "pMarca", DbType.String, pItem.Marca);
			db.AddInParameter(dbCommand, "pModelo", DbType.String, pItem.Modelo);
			db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdConductor", DbType.Int32, pItem.IdConductor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdVehiculo");

			return Id;
		}

		public void Actualiza(VehiculoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_Actualiza");

			db.AddInParameter(dbCommand, "pIdVehiculo", DbType.Int32, pItem.IdVehiculo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPlaca", DbType.String, pItem.Placa);
			db.AddInParameter(dbCommand, "pNumeroSerie", DbType.String, pItem.NumeroSerie);
			db.AddInParameter(dbCommand, "pNumeroMotor", DbType.String, pItem.NumeroMotor);
			db.AddInParameter(dbCommand, "pColor", DbType.String, pItem.Color);
			db.AddInParameter(dbCommand, "pMarca", DbType.String, pItem.Marca);
			db.AddInParameter(dbCommand, "pModelo", DbType.String, pItem.Modelo);
			db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdConductor", DbType.Int32, pItem.IdConductor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(VehiculoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_Elimina");

			db.AddInParameter(dbCommand, "pIdVehiculo", DbType.Int32, pItem.IdVehiculo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<VehiculoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<VehiculoBE> Vehiculolist = new List<VehiculoBE>();
			VehiculoBE Vehiculo;
			while (reader.Read())
			{
				Vehiculo = new VehiculoBE();
				Vehiculo.IdVehiculo = Int32.Parse(reader["IdVehiculo"].ToString());
				Vehiculo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Vehiculo.RazonSocial = reader["RazonSocial"].ToString();
                Vehiculo.Placa = reader["Placa"].ToString();
				Vehiculo.NumeroSerie = reader["NumeroSerie"].ToString();
				Vehiculo.NumeroMotor = reader["NumeroMotor"].ToString();
				Vehiculo.Color = reader["Color"].ToString();
				Vehiculo.Marca = reader["Marca"].ToString();
				Vehiculo.Modelo = reader["Modelo"].ToString();
				Vehiculo.Codigo = reader["Codigo"].ToString();
				Vehiculo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Vehiculo.IdConductor = reader.IsDBNull(reader.GetOrdinal("IdConductor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdConductor"));
                Vehiculo.DescConductor = reader["DescConductor"].ToString();
                Vehiculo.Observacion = reader["Observacion"].ToString();
                Vehiculo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				Vehiculolist.Add(Vehiculo);
			}
			reader.Close();
			reader.Dispose();
			return Vehiculolist;
		}

		public VehiculoBE Selecciona(int IdVehiculo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_Selecciona");
			db.AddInParameter(dbCommand, "pIdVehiculo", DbType.Int32, IdVehiculo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			VehiculoBE Vehiculo = null;
			while (reader.Read())
			{
				Vehiculo = new VehiculoBE();
                Vehiculo.IdVehiculo = Int32.Parse(reader["IdVehiculo"].ToString());
                Vehiculo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Vehiculo.Placa = reader["Placa"].ToString();
                Vehiculo.NumeroSerie = reader["NumeroSerie"].ToString();
                Vehiculo.NumeroMotor = reader["NumeroMotor"].ToString();
                Vehiculo.Color = reader["Color"].ToString();
                Vehiculo.Marca = reader["Marca"].ToString();
                Vehiculo.Modelo = reader["Modelo"].ToString();
                Vehiculo.Codigo = reader["Codigo"].ToString();
                Vehiculo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Vehiculo.IdConductor = reader.IsDBNull(reader.GetOrdinal("IdConductor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdConductor"));
                Vehiculo.DescConductor = reader["DescConductor"].ToString();
                Vehiculo.Observacion = reader["Observacion"].ToString();
                Vehiculo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return Vehiculo;
		}

		public VehiculoBE SeleccionaMarca(int IdVehiculo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Vehiculo_SeleccionaMarca");
			db.AddInParameter(dbCommand, "pIdVehiculo", DbType.Int32, IdVehiculo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			VehiculoBE Vehiculo = null;
			while (reader.Read())
			{
				Vehiculo = new VehiculoBE();
				Vehiculo.Marca = reader["Marca"].ToString();
			}
			reader.Close();
			reader.Dispose();
			return Vehiculo;
		}


	}
}
