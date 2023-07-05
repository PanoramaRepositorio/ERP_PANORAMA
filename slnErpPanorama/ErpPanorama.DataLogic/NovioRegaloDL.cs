using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class NovioRegaloDL
	{
		public NovioRegaloDL() { }

		public Int32 Inserta(NovioRegaloBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_Inserta");

			db.AddOutParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdNovio", DbType.Int32, pItem.IdNovio);
			db.AddInParameter(dbCommand, "pIdNovia", DbType.Int32, pItem.IdNovia);
			db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
			db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pCelular2", DbType.String, pItem.Celular2);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
			db.AddInParameter(dbCommand, "pEmail2", DbType.String, pItem.Email2);
			db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
			db.AddInParameter(dbCommand, "pFechaBoda", DbType.DateTime, pItem.FechaBoda);
			db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdNovioRegalo");

			return Id;
		}

		public void Actualiza(NovioRegaloBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_Actualiza");

			db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdNovio", DbType.Int32, pItem.IdNovio);
			db.AddInParameter(dbCommand, "pIdNovia", DbType.Int32, pItem.IdNovia);
			db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
			db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pCelular2", DbType.String, pItem.Celular2);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
			db.AddInParameter(dbCommand, "pEmail2", DbType.String, pItem.Email2);
			db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
			db.AddInParameter(dbCommand, "pFechaBoda", DbType.DateTime, pItem.FechaBoda);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(NovioRegaloBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_Elimina");

			db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<NovioRegaloBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<NovioRegaloBE> NovioRegalolist = new List<NovioRegaloBE>();
			NovioRegaloBE NovioRegalo;
			while (reader.Read())
			{
				NovioRegalo = new NovioRegaloBE();
				NovioRegalo.IdNovioRegalo = Int32.Parse(reader["IdNovioRegalo"].ToString());
				NovioRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				NovioRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                NovioRegalo.DescTienda = reader["DescTienda"].ToString();
                NovioRegalo.Numero = reader["Numero"].ToString();
                NovioRegalo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                NovioRegalo.IdNovio = Int32.Parse(reader["IdNovio"].ToString());
                NovioRegalo.DescNovio = reader["DescNovio"].ToString();
                NovioRegalo.IdNovia = Int32.Parse(reader["IdNovia"].ToString());
                NovioRegalo.DescNovia = reader["DescNovia"].ToString();
                NovioRegalo.Telefono = reader["Telefono"].ToString();
				NovioRegalo.Celular = reader["Celular"].ToString();
                NovioRegalo.Celular2 = reader["Celular2"].ToString();
                NovioRegalo.Email = reader["Email"].ToString();
				NovioRegalo.Email2 = reader["Email2"].ToString();
				NovioRegalo.Direccion = reader["Direccion"].ToString();
                NovioRegalo.FechaBoda = reader.IsDBNull(reader.GetOrdinal("FechaBoda")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaBoda"));
                NovioRegalo.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                NovioRegalo.DescVendedor = reader["DescVendedor"].ToString();
                NovioRegalo.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                NovioRegalo.DescAsesor = reader["DescAsesor"].ToString();
                NovioRegalo.Observacion = reader["Observacion"].ToString();
                NovioRegalo.TotalInvitados = Decimal.Parse(reader["TotalInvitados"].ToString());
                NovioRegalo.TotalNovios = Decimal.Parse(reader["TotalNovios"].ToString());

                NovioRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				
				NovioRegalolist.Add(NovioRegalo);
			}
			reader.Close();
			reader.Dispose();
			return NovioRegalolist;
		}

		public NovioRegaloBE Selecciona(int IdNovioRegalo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_Selecciona");
			db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, IdNovioRegalo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			NovioRegaloBE NovioRegalo = null;
			while (reader.Read())
			{
				NovioRegalo = new NovioRegaloBE();
                NovioRegalo.IdNovioRegalo = Int32.Parse(reader["IdNovioRegalo"].ToString());
                NovioRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                NovioRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                NovioRegalo.DescTienda = reader["DescTienda"].ToString();
                NovioRegalo.Numero = reader["Numero"].ToString();
                NovioRegalo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                NovioRegalo.IdNovio = Int32.Parse(reader["IdNovio"].ToString());
                NovioRegalo.DniNovio = reader["DniNovio"].ToString();
                NovioRegalo.DescNovio = reader["DescNovio"].ToString();
                NovioRegalo.IdNovia = Int32.Parse(reader["IdNovia"].ToString());
                NovioRegalo.DniNovia = reader["DniNovia"].ToString();
                NovioRegalo.DescNovia = reader["DescNovia"].ToString();
                NovioRegalo.Telefono = reader["Telefono"].ToString();
                NovioRegalo.Celular = reader["Celular"].ToString();
                NovioRegalo.Celular2 = reader["Celular2"].ToString();
                NovioRegalo.Email = reader["Email"].ToString();
                NovioRegalo.Email2 = reader["Email2"].ToString();
                NovioRegalo.Direccion = reader["Direccion"].ToString();
                NovioRegalo.FechaBoda = reader.IsDBNull(reader.GetOrdinal("FechaBoda")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaBoda"));
                NovioRegalo.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                NovioRegalo.DescVendedor = reader["DescVendedor"].ToString();
                NovioRegalo.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                NovioRegalo.DescAsesor = reader["DescAsesor"].ToString();
                NovioRegalo.Observacion = reader["Observacion"].ToString();
                NovioRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return NovioRegalo;
		}

        public NovioRegaloBE SeleccionaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegalo_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.String, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NovioRegaloBE NovioRegalo = null;
            while (reader.Read())
            {
                NovioRegalo = new NovioRegaloBE();
                NovioRegalo.IdNovioRegalo = Int32.Parse(reader["IdNovioRegalo"].ToString());
                NovioRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                NovioRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                NovioRegalo.DescTienda = reader["DescTienda"].ToString();
                NovioRegalo.Numero = reader["Numero"].ToString();
                NovioRegalo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                NovioRegalo.IdNovio = Int32.Parse(reader["IdNovio"].ToString());
                NovioRegalo.DniNovio = reader["DniNovio"].ToString();
                NovioRegalo.DescNovio = reader["DescNovio"].ToString();
                NovioRegalo.IdNovia = Int32.Parse(reader["IdNovia"].ToString());
                NovioRegalo.DniNovia = reader["DniNovia"].ToString();
                NovioRegalo.DescNovia = reader["DescNovia"].ToString();
                NovioRegalo.Telefono = reader["Telefono"].ToString();
                NovioRegalo.Celular = reader["Celular"].ToString();
                NovioRegalo.Celular2 = reader["Celular2"].ToString();
                NovioRegalo.Email = reader["Email"].ToString();
                NovioRegalo.Email2 = reader["Email2"].ToString();
                NovioRegalo.Direccion = reader["Direccion"].ToString();
                NovioRegalo.FechaBoda = reader.IsDBNull(reader.GetOrdinal("FechaBoda")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaBoda"));
                NovioRegalo.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                NovioRegalo.DescVendedor = reader["DescVendedor"].ToString();
                NovioRegalo.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                NovioRegalo.DescAsesor = reader["DescAsesor"].ToString();
                NovioRegalo.Observacion = reader["Observacion"].ToString();
                NovioRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return NovioRegalo;
        }

    }
}
