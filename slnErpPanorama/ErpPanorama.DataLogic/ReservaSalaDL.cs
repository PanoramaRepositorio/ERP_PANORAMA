using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReservaSalaDL
    {
        public ReservaSalaDL() { }

        public void Inserta(ReservaSalaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservaSala_Inserta");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pAgenda", DbType.String, pItem.Agenda);

            db.AddInParameter(dbCommand, "pFecReserva", DbType.DateTime, pItem.FecReserva);
            db.AddInParameter(dbCommand, "pHoraInicio", DbType.DateTime, pItem.HoraInicio);
            db.AddInParameter(dbCommand, "pHoraFin", DbType.DateTime, pItem.HoraFin);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Actualiza(CajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_Actualiza");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescCaja", DbType.String, pItem.DescCaja);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_Elimina");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaBE> Cajalist = new List<CajaBE>();
            CajaBE Caja;
            while (reader.Read())
            {
                Caja = new CajaBE();
                Caja.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Caja.RazonSocial = reader["RazonSocial"].ToString();
                Caja.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Caja.DescTienda = reader["DescTienda"].ToString();
                Caja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Caja.DescCaja = reader["descCaja"].ToString();
                Caja.Mac = reader["Mac"].ToString();
                Caja.FlagVenta = Boolean.Parse(reader["FlagVenta"].ToString());
                Caja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cajalist.Add(Caja);
            }
            reader.Close();
            reader.Dispose();
            return Cajalist;
        }

        public List<ReservaSalaBE> ListaFecha(DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservaSala_Listado");
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReservaSalaBE> PrestamoBancolist = new List<ReservaSalaBE>();
            ReservaSalaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new ReservaSalaBE();

                SolicitudEgreso.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudEgreso.IdReserva = Int32.Parse(reader["Item"].ToString());
                SolicitudEgreso.FecReserva = DateTime.Parse(reader["FecReserva"].ToString());
                SolicitudEgreso.IdHora = Int32.Parse(reader["IdHora"].ToString());
                SolicitudEgreso.Hora = reader["Hora"].ToString();
                SolicitudEgreso.Agenda = reader["Agenda"].ToString();

                SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEgreso.Reservo = reader["Reservo"].ToString();
                SolicitudEgreso.IdDuracion = Int32.Parse(reader["IdDuracion"].ToString());

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public ReservaSalaBE ValidaHoraInicio(DateTime pHoraInicio, DateTime pFecReserva)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservaSala_ListarSalaOcupada");
            db.AddInParameter(dbCommand, "pHoraInicio", DbType.DateTime, pHoraInicio);
            db.AddInParameter(dbCommand, "pFecReserva", DbType.DateTime, pFecReserva);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ReservaSalaBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new ReservaSalaBE();
                Pedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
            }

            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public ReservaSalaBE ValidaHoraFin(DateTime pHoraFin, DateTime pFecReserva)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReservaSala_ListarSalaOcupadaHoraFin");
            db.AddInParameter(dbCommand, "pHoraFin", DbType.DateTime, pHoraFin);
            db.AddInParameter(dbCommand, "pFecReserva", DbType.DateTime, pFecReserva);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ReservaSalaBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new ReservaSalaBE();
                Pedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
            }

            reader.Close();
            reader.Dispose();
            return Pedido;
        }

    }
}
