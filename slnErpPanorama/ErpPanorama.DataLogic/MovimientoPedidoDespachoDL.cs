using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoPedidoDespachoDL
    {

        public void Inserta(MovimientoPedidoDespachoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_Inserta");

            db.AddInParameter(dbCommand, "pIdMovimientoPedidoDespacho", DbType.Int32, pItem.IdMovimientoPedidoDespacho);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdDestino", DbType.Int32, pItem.IdDestino);
            db.AddInParameter(dbCommand, "pIdPagoFlete", DbType.Int32, pItem.IdPagoFlete);
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MovimientoPedidoDespachoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoPedidoDespacho", DbType.Int32, pItem.IdMovimientoPedidoDespacho);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdDestino", DbType.Int32, pItem.IdDestino);
            db.AddInParameter(dbCommand, "pIdPagoFlete", DbType.Int32, pItem.IdPagoFlete);
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MovimientoPedidoDespachoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoPedidoDespacho", DbType.Int32, pItem.IdMovimientoPedidoDespacho);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }



        public List<MovimientoPedidoDespachoBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoDespachoBE> MovimientoPedidoDespacholist = new List<MovimientoPedidoDespachoBE>();
            MovimientoPedidoDespachoBE MovimientoPedidoDespacho;
            while (reader.Read())
            {
                MovimientoPedidoDespacho = new MovimientoPedidoDespachoBE();
                MovimientoPedidoDespacho.IdMovimientoPedidoDespacho = Int32.Parse(reader["IdMovimientoPedidoDespacho"].ToString());
                MovimientoPedidoDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedidoDespacho.Numero = reader["Numero"].ToString();
                MovimientoPedidoDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedidoDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                MovimientoPedidoDespacho.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoPedidoDespacho.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedidoDespacho.DescMoneda = reader["DescMoneda"].ToString();
                MovimientoPedidoDespacho.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedidoDespacho.DescSituacion = reader["DescSituacion"].ToString();
                MovimientoPedidoDespacho.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                MovimientoPedidoDespacho.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedidoDespacho.Direccion = reader["Direccion"].ToString();
                MovimientoPedidoDespacho.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedidoDespacho.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                MovimientoPedidoDespacho.DescPrioridad = reader["DescPrioridad"].ToString();
                MovimientoPedidoDespacho.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                MovimientoPedidoDespacho.DescDestino = reader["DescDestino"].ToString();
                MovimientoPedidoDespacho.IdPagoFlete = Int32.Parse(reader["IdPagoFlete"].ToString());
                MovimientoPedidoDespacho.DescPagoFlete = reader["DescPagoFlete"].ToString();
                MovimientoPedidoDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                MovimientoPedidoDespacho.DescDespachador = reader["DescDespachador"].ToString();
                MovimientoPedidoDespacho.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoPedidoDespacho.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoPedidoDespacho.Observacion = reader["Observacion"].ToString();
                MovimientoPedidoDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                MovimientoPedidoDespacholist.Add(MovimientoPedidoDespacho);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidoDespacholist;
        }

        public List<MovimientoPedidoDespachoBE> ListaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_ListaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoDespachoBE> MovimientoPedidoDespacholist = new List<MovimientoPedidoDespachoBE>();
            MovimientoPedidoDespachoBE MovimientoPedidoDespacho;
            while (reader.Read())
            {
                MovimientoPedidoDespacho = new MovimientoPedidoDespachoBE();
                MovimientoPedidoDespacho.IdMovimientoPedidoDespacho = Int32.Parse(reader["IdMovimientoPedidoDespacho"].ToString());
                MovimientoPedidoDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedidoDespacho.Numero = reader["Numero"].ToString();
                MovimientoPedidoDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedidoDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                MovimientoPedidoDespacho.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoPedidoDespacho.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedidoDespacho.DescMoneda = reader["DescMoneda"].ToString();
                MovimientoPedidoDespacho.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedidoDespacho.DescSituacion = reader["DescSituacion"].ToString();
                MovimientoPedidoDespacho.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                MovimientoPedidoDespacho.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedidoDespacho.Direccion = reader["Direccion"].ToString();
                MovimientoPedidoDespacho.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedidoDespacho.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                MovimientoPedidoDespacho.DescPrioridad = reader["DescPrioridad"].ToString();
                MovimientoPedidoDespacho.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                MovimientoPedidoDespacho.DescDestino = reader["DescDestino"].ToString();
                MovimientoPedidoDespacho.IdPagoFlete = Int32.Parse(reader["IdPagoFlete"].ToString());
                MovimientoPedidoDespacho.DescPagoFlete = reader["DescPagoFlete"].ToString();
                MovimientoPedidoDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                MovimientoPedidoDespacho.DescDespachador = reader["DescDespachador"].ToString();
                MovimientoPedidoDespacho.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoPedidoDespacho.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoPedidoDespacho.Observacion = reader["Observacion"].ToString();
                MovimientoPedidoDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                MovimientoPedidoDespacholist.Add(MovimientoPedidoDespacho);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidoDespacholist;
        }

        public MovimientoPedidoDespachoBE Selecciona(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_Selecciona");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoPedidoDespachoBE MovimientoPedidoDespacho = null;
            while (reader.Read())
            {
                MovimientoPedidoDespacho = new MovimientoPedidoDespachoBE();
                MovimientoPedidoDespacho.IdMovimientoPedidoDespacho = Int32.Parse(reader["IdMovimientoPedidoDespacho"].ToString());
                MovimientoPedidoDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedidoDespacho.Numero = reader["Numero"].ToString();
                MovimientoPedidoDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedidoDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                MovimientoPedidoDespacho.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoPedidoDespacho.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedidoDespacho.DescMoneda = reader["DescMoneda"].ToString();
                MovimientoPedidoDespacho.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedidoDespacho.DescSituacion = reader["DescSituacion"].ToString();
                MovimientoPedidoDespacho.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                MovimientoPedidoDespacho.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedidoDespacho.Direccion = reader["Direccion"].ToString();
                MovimientoPedidoDespacho.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedidoDespacho.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                MovimientoPedidoDespacho.DescPrioridad = reader["DescPrioridad"].ToString();
                MovimientoPedidoDespacho.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                MovimientoPedidoDespacho.DescDestino = reader["DescDestino"].ToString();
                MovimientoPedidoDespacho.IdPagoFlete = Int32.Parse(reader["IdPagoFlete"].ToString());
                MovimientoPedidoDespacho.DescPagoFlete = reader["DescPagoFlete"].ToString();
                MovimientoPedidoDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                MovimientoPedidoDespacho.DescDespachador = reader["DescDespachador"].ToString();
                MovimientoPedidoDespacho.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoPedidoDespacho.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoPedidoDespacho.Observacion = reader["Observacion"].ToString();
                MovimientoPedidoDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidoDespacho;
        }

        public void ActualizaEmbalador(MovimientoPedidoDespachoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_ActualizaEmbalador");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDespachador(MovimientoPedidoDespachoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedidoDespacho_ActualizaDespachador");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);


            db.ExecuteNonQuery(dbCommand);
        }

    }
}
