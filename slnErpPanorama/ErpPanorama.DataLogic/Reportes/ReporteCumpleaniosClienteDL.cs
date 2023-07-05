using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class ReporteCumpleaniosClienteDL
    {
        public List<ReporteCumpleaniosClienteBE> Listado(int IdTienda, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_rptVentaCumpleanosCliente");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCumpleaniosClienteBE> CumpleaniosClientelist = new List<ReporteCumpleaniosClienteBE>();
            ReporteCumpleaniosClienteBE CumpleaniosCliente;
            while (reader.Read())
            {
                CumpleaniosCliente = new ReporteCumpleaniosClienteBE();
                CumpleaniosCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                CumpleaniosCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                CumpleaniosCliente.DescCliente = reader["DescCliente"].ToString();
                CumpleaniosCliente.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                CumpleaniosCliente.Dia = Int32.Parse(reader["Dia"].ToString());
                CumpleaniosCliente.Telefono = reader["Telefono"].ToString();
                CumpleaniosCliente.Celular = reader["Celular"].ToString();
                CumpleaniosCliente.OtroTelefono = reader["OtroTelefono"].ToString();

                CumpleaniosCliente.Email = reader["Email"].ToString();
                CumpleaniosCliente.Tickets = Int32.Parse(reader["Tickets"].ToString());
                CumpleaniosCliente.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                CumpleaniosCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                CumpleaniosCliente.TicketMes = Int32.Parse(reader["TicketMes"].ToString());
                CumpleaniosCliente.TotalMes = Decimal.Parse(reader["TotalMes"].ToString());
                CumpleaniosCliente.NomDpto = reader["NomDpto"].ToString();
                CumpleaniosCliente.NomProv = reader["NomProv"].ToString();
                CumpleaniosCliente.NomDist = reader["NomDist"].ToString();
                CumpleaniosCliente.Direccion = reader["Direccion"].ToString();
                CumpleaniosCliente.TipoCliente = reader["TipoCliente"].ToString();
                CumpleaniosCliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                CumpleaniosCliente.NroCorreo = Int32.Parse(reader["NroCorreo"].ToString());
                CumpleaniosClientelist.Add(CumpleaniosCliente);
            }
            reader.Close();
            reader.Dispose();
            return CumpleaniosClientelist;
        }

        public List<ReporteCumpleaniosClienteBE> ListadoClientesNuevos(int IdTienda, int Mes, int Anio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_rptVentaClientesNuevos");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pAnio", DbType.Int32, Anio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCumpleaniosClienteBE> CumpleaniosClientelist = new List<ReporteCumpleaniosClienteBE>();
            ReporteCumpleaniosClienteBE CumpleaniosCliente;
            while (reader.Read())
            {
                CumpleaniosCliente = new ReporteCumpleaniosClienteBE();

                CumpleaniosCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                CumpleaniosCliente.TipoCliente = reader["TipoCliente"].ToString();

                CumpleaniosCliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                CumpleaniosCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                CumpleaniosCliente.DescCliente = reader["Cliente"].ToString();
                CumpleaniosCliente.Direccion = reader["Direccion"].ToString();
                CumpleaniosCliente.NomDist = reader["Distrito"].ToString();
                CumpleaniosCliente.Telefono = reader["Telefono"].ToString();
                CumpleaniosCliente.Celular = reader["Celular"].ToString();
                CumpleaniosCliente.OtroTelefono = reader["OtroTelefono"].ToString();
                CumpleaniosCliente.Email = reader["Email"].ToString();
                CumpleaniosCliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                CumpleaniosCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                CumpleaniosClientelist.Add(CumpleaniosCliente);
            }
            reader.Close();
            reader.Dispose();
            return CumpleaniosClientelist;
        }


        public void Inserta(CorreoClienteCumpleanosBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CorreoClienteCumpleanos_Inserta");
            db.AddInParameter(dbCommand, "pIdCorreoClienteCumpleanos", DbType.Int32, pItem.IdCorreoClienteCumpleanos);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFecha", DbType.Date, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
