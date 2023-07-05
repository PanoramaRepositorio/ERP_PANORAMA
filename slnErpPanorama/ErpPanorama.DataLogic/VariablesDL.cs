using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class VariablesDL
    {
        public VariablesDL() { }

        public void Inserta(VariablesBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_Variables_Inserta");

            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pCompra", DbType.Decimal, pItem.Compra);
            //db.AddInParameter(dbCommand, "pVenta", DbType.Decimal, pItem.Venta);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            //db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(VariablesBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_Variables_Actualiza");

            //db.AddInParameter(dbCommand, "pIdVariables", DbType.Int32, pItem.IdVariables);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            //db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            //db.AddInParameter(dbCommand, "pCompra", DbType.Decimal, pItem.Compra);
            //db.AddInParameter(dbCommand, "pVenta", DbType.Decimal, pItem.Venta);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            //db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(VariablesBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_Variables_Elimina");

            //db.AddInParameter(dbCommand, "pIdVariables", DbType.Int32, pItem.IdVariables);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            //db.ExecuteNonQuery(dbCommand);
        }

        public VariablesBE Selecciona(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Variables_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            VariablesBE Variables = null;
            while (reader.Read())
            {
                Variables = new VariablesBE();
                Variables.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Variables.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                Variables.TipoCambioMayorista = Decimal.Parse(reader["TipoCambioMayorista"].ToString());
                Variables.TipoCambioMinoristaNacional = Decimal.Parse(reader["TipoCambioMinoristaNacional"].ToString());
                Variables.SueldoBaseAsesorJunior = Decimal.Parse(reader["SueldoBaseAsesorJunior"].ToString());
                Variables.SueldoBaseAsesorSenior = Decimal.Parse(reader["SueldoBaseAsesorSenior"].ToString());
                Variables.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Variables;
        }

        //public List<VariablesBE> ListaTodosActivo(int IdEmpresa, int IdMoneda)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Variables_ListaTodosActivo");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<VariablesBE> Variableslist = new List<VariablesBE>();
        //    VariablesBE Variables;
        //    while (reader.Read())
        //    {
        //        Variables = new VariablesBE();
        //        Variables.IdVariables = Int32.Parse(reader["idVariables"].ToString());
        //        Variables.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
        //        Variables.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
        //        Variables.Moneda = reader["Moneda"].ToString();
        //        Variables.Fecha = DateTime.Parse(reader["Fecha"].ToString());
        //        Variables.Compra = Decimal.Parse(reader["Compra"].ToString());
        //        Variables.Venta = Decimal.Parse(reader["Venta"].ToString());
        //        Variables.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
        //        Variableslist.Add(Variables);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return Variableslist;
        //}
    }
}
