using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoCajaChicaDL
    {
        public MovimientoCajaChicaDL() { }

        public Int32 Inserta(MovimientoCajaChicaBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_Inserta");

            db.AddOutParameter(dbCommand, "pIdMovimientoCajaChica", DbType.Int32, pItem.IdMovimientoCajaChica);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoAnexo", DbType.Int32, pItem.IdTipoAnexo);
            db.AddInParameter(dbCommand, "pIdAnexo", DbType.Int32, pItem.IdAnexo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAutoriza", DbType.Int32, pItem.IdPersonaAutoriza);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pUsuarioModifica", DbType.String, pItem.UsuarioModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pIdOrigen", DbType.Int32, pItem.IdOrigen);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdMovimientoCajaChica");

            return Id;
        }

        public void Actualiza(MovimientoCajaChicaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoCajaChica", DbType.Int32, pItem.IdMovimientoCajaChica);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoAnexo", DbType.Int32, pItem.IdTipoAnexo);
            db.AddInParameter(dbCommand, "pIdAnexo", DbType.Int32, pItem.IdAnexo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAutoriza", DbType.Int32, pItem.IdPersonaAutoriza);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pUsuarioModifica", DbType.String, pItem.UsuarioModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pIdOrigen", DbType.Int32, pItem.IdOrigen);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MovimientoCajaChicaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoCajaChica", DbType.Int32, pItem.IdMovimientoCajaChica);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MovimientoCajaChicaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaChicaBE> MovimientoCajaChicalist = new List<MovimientoCajaChicaBE>();
            MovimientoCajaChicaBE MovimientoCajaChica;
            while (reader.Read())
            {
                MovimientoCajaChica = new MovimientoCajaChicaBE();
                MovimientoCajaChica.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());
                MovimientoCajaChica.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoCajaChica.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MovimientoCajaChica.IdTipoAnexo = Int32.Parse(reader["IdTipoAnexo"].ToString());
                MovimientoCajaChica.IdAnexo = Int32.Parse(reader["IdAnexo"].ToString());
                MovimientoCajaChica.DescAnexo = reader["DescAnexo"].ToString();
                MovimientoCajaChica.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCajaChica.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                MovimientoCajaChica.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoCajaChica.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoCajaChica.Concepto = reader["Concepto"].ToString();
                MovimientoCajaChica.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCajaChica.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCajaChica.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                MovimientoCajaChica.Importe = Decimal.Parse(reader["Importe"].ToString());
                MovimientoCajaChica.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCajaChica.Observacion = reader["Observacion"].ToString();
                MovimientoCajaChica.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCajaChica.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCajaChica.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                MovimientoCajaChica.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCajaChica.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
                MovimientoCajaChica.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                MovimientoCajaChica.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                MovimientoCajaChicalist.Add(MovimientoCajaChica);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajaChicalist;
        }

        public List<MovimientoCajaChicaBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.DateTime, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaChicaBE> MovimientoCajaChicalist = new List<MovimientoCajaChicaBE>();
            MovimientoCajaChicaBE MovimientoCajaChica;
            while (reader.Read())
            {
                MovimientoCajaChica = new MovimientoCajaChicaBE();
                MovimientoCajaChica.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());
                MovimientoCajaChica.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoCajaChica.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MovimientoCajaChica.IdTipoAnexo = Int32.Parse(reader["IdTipoAnexo"].ToString());
                MovimientoCajaChica.IdAnexo = Int32.Parse(reader["IdAnexo"].ToString());
                MovimientoCajaChica.DescAnexo = reader["DescAnexo"].ToString();
                MovimientoCajaChica.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCajaChica.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                MovimientoCajaChica.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoCajaChica.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoCajaChica.Concepto = reader["Concepto"].ToString();
                MovimientoCajaChica.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCajaChica.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCajaChica.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                MovimientoCajaChica.Importe = Decimal.Parse(reader["Importe"].ToString());
                MovimientoCajaChica.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCajaChica.Observacion = reader["Observacion"].ToString();
                MovimientoCajaChica.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCajaChica.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCajaChica.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                MovimientoCajaChica.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCajaChica.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
                MovimientoCajaChica.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                MovimientoCajaChica.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                MovimientoCajaChicalist.Add(MovimientoCajaChica);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajaChicalist;
        }

        public MovimientoCajaChicaBE Selecciona(int IdMovimientoCajaChica)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCajaChica_Selecciona");
            db.AddInParameter(dbCommand, "pIdMovimientoCajaChica", DbType.Int32, IdMovimientoCajaChica);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoCajaChicaBE MovimientoCajaChica = null;
            while (reader.Read())
            {
                MovimientoCajaChica = new MovimientoCajaChicaBE();
                MovimientoCajaChica.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());
                MovimientoCajaChica.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MovimientoCajaChica.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MovimientoCajaChica.IdTipoAnexo = Int32.Parse(reader["IdTipoAnexo"].ToString());
                MovimientoCajaChica.IdAnexo = Int32.Parse(reader["IdAnexo"].ToString());
                MovimientoCajaChica.DescAnexo = reader["DescAnexo"].ToString();
                MovimientoCajaChica.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCajaChica.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                MovimientoCajaChica.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoCajaChica.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoCajaChica.Concepto = reader["Concepto"].ToString();
                MovimientoCajaChica.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCajaChica.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCajaChica.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                MovimientoCajaChica.Importe = Decimal.Parse(reader["Importe"].ToString());
                MovimientoCajaChica.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCajaChica.Observacion = reader["Observacion"].ToString();
                MovimientoCajaChica.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCajaChica.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCajaChica.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                MovimientoCajaChica.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCajaChica.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
                MovimientoCajaChica.IdOrigen = Int32.Parse(reader["IdOrigen"].ToString());
                MovimientoCajaChica.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajaChica;
        }

    }
}
