using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.DataLogic
{
    public class IngresoEgresoDL
    {
        public List<IngresoEgresoBE> Listar(string Buscartipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Cab_RegIngresoEgreso_Listar");
            db.AddInParameter(dbCommand, "pBuscar", DbType.String, Buscartipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<IngresoEgresoBE> Tablalist = new List<IngresoEgresoBE>();
            IngresoEgresoBE Tabla;
            while (reader.Read())
            {
                Tabla = new IngresoEgresoBE();
                Tabla.IdIngresoEgreso = Int32.Parse(reader["IdIngresoEgreso"].ToString());
                Tabla.NumIngresoEgreso = reader["NumIngresoEgreso"].ToString();
                Tabla.FecIngresoEgreso =DateTime.Parse(reader["FechaIngresoEgreso"].ToString());
                Tabla.IdTablaTipoGestion = Int32.Parse(reader["IdTablaTipoGestion"].ToString());
                Tabla.IdTablaElementoTipoGestion = Int32.Parse(reader["IdTablaElementoTipoGestion"].ToString());
                Tabla.TipoGestion = reader["TipoGestion"].ToString();
                Tabla.IdTipificacion = Int32.Parse(reader["IdTipificacion"].ToString());
                Tabla.DescTipificacion = reader["DescTipificacion"].ToString();
                Tabla.Moneda = reader["Moneda"].ToString();
                Tabla.Total = Decimal.Parse(reader["Total"].ToString());
                Tabla.Local = reader["Local"].ToString();
                Tabla.Area = reader["Area"].ToString();
                Tabla.DescBanco = reader["DescBanco"].ToString();
                Tabla.DescEstado = reader["Estado"].ToString();

                Tabla.Proveedor = reader["Proveedor"].ToString();
                Tabla.TipoDocumento = reader["TipoDocumento"].ToString();
                Tabla.NumDocumento = reader["NumDocumento"].ToString();



                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public void Inserta(IngresoEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Cab_IngresoEgreso_Insertar");

            db.AddInParameter(dbCommand, "pFecIngresoEgreso", DbType.Date, pItem.FecIngresoEgreso);
            db.AddInParameter(dbCommand, "ptCambio", DbType.Decimal, pItem.tCambio);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);

            db.AddInParameter(dbCommand, "pIdTablaTipoGestion", DbType.Int32, pItem.IdTablaTipoGestion);
            db.AddInParameter(dbCommand, "pIdTablaElementoTipoGestion", DbType.Int32, pItem.IdTablaElementoTipoGestion);
            db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pItem.IdTipificacion);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);

            db.AddInParameter(dbCommand, "pIdTablaTipoDocumento", DbType.Int32, pItem.IdTablaTipoDocumento);
            db.AddInParameter(dbCommand, "pIdTablaElementoTipoDocumento", DbType.Int32, pItem.IdTablaElementoTipoDocumento);
            db.AddInParameter(dbCommand, "pNumDocumento", DbType.String, pItem.NumDocumento);
            db.AddInParameter(dbCommand, "pIdTablaLocal", DbType.Int32, pItem.IdTablaLocal);
            db.AddInParameter(dbCommand, "pIdTablaElementoLocal", DbType.Int32, pItem.IdTablaElementoLocal);

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdTablaTipoCuenta", DbType.Int32, pItem.IdTablaTipoCuenta);
            db.AddInParameter(dbCommand, "pIdTablaElementoTipoCuenta", DbType.Int32, pItem.IdTablaElementoTipoCuenta);

            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pDetraccion", DbType.Decimal, pItem.Detraccion);

            db.AddInParameter(dbCommand, "pEstado", DbType.Boolean, pItem.Estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(IngresoEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pItem.IdTipificacion);
            db.AddInParameter(dbCommand, "pIdSubTipificacion", DbType.Int32, pItem.IdSubTipificacion);
            db.AddInParameter(dbCommand, "pDescSubTipificacion", DbType.String, pItem.DescSubTipificacion);
            //db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
