using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoClientePromocionDL
    {
        public DescuentoClientePromocionDL() { }

        public Int32 Inserta(DescuentoClientePromocionBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_Inserta");

            db.AddOutParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdDescuentoClientePromocion");

            return intIdCliente;
        }


        public void Actualiza(DescuentoClientePromocionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoClientePromocionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_Elimina");

            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClientePromocionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClientePromocionBE> DescuentoClientePromocionlist = new List<DescuentoClientePromocionBE>();
            DescuentoClientePromocionBE DescuentoClientePromocion;
            while (reader.Read())
            {
                DescuentoClientePromocion = new DescuentoClientePromocionBE();
                DescuentoClientePromocion.IdDescuentoClientePromocion = Int32.Parse(reader["idDescuentoClientePromocion"].ToString());
                DescuentoClientePromocion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoClientePromocion.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DescuentoClientePromocion.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DescuentoClientePromocion.Descripcion = reader["Descripcion"].ToString();
                DescuentoClientePromocion.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoClientePromocion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoClientePromocion.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClientePromocion.Observacion = reader["Observacion"].ToString();
                DescuentoClientePromocion.Items = Int32.Parse(reader["Items"].ToString());
                DescuentoClientePromocion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClientePromocionlist.Add(DescuentoClientePromocion);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClientePromocionlist;
        }

        public List<DescuentoClientePromocionBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClientePromocionBE> DescuentoClientePromocionlist = new List<DescuentoClientePromocionBE>();
            DescuentoClientePromocionBE DescuentoClientePromocion;
            while (reader.Read())
            {
                DescuentoClientePromocion = new DescuentoClientePromocionBE();
                DescuentoClientePromocion.IdDescuentoClientePromocion = Int32.Parse(reader["idDescuentoClientePromocion"].ToString());
                //DescuentoClientePromocion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                //DescuentoClientePromocion.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DescuentoClientePromocion.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DescuentoClientePromocion.Descripcion = reader["Descripcion"].ToString();
                //DescuentoClientePromocion.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoClientePromocion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoClientePromocion.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClientePromocion.Observacion = reader["Observacion"].ToString();
                DescuentoClientePromocion.Items = Int32.Parse(reader["Items"].ToString());
                //DescuentoClientePromocion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClientePromocionlist.Add(DescuentoClientePromocion);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClientePromocionlist;
        }

        public DescuentoClientePromocionBE Selecciona(int IdEmpresa, int IdDescuentoClientePromocion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocion_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, IdDescuentoClientePromocion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DescuentoClientePromocionBE DescuentoClientePromocion = null;
            while (reader.Read())
            {
                DescuentoClientePromocion = new DescuentoClientePromocionBE();
                DescuentoClientePromocion.IdDescuentoClientePromocion = Int32.Parse(reader["IdDescuentoClientePromocion"].ToString());
                DescuentoClientePromocion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoClientePromocion.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DescuentoClientePromocion.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DescuentoClientePromocion.Descripcion = reader["Descripcion"].ToString();
                DescuentoClientePromocion.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoClientePromocion.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoClientePromocion.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClientePromocion.Observacion = reader["Observacion"].ToString();
                DescuentoClientePromocion.Items = Int32.Parse(reader["Items"].ToString());
                DescuentoClientePromocion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClientePromocion;
        }
    }
}
