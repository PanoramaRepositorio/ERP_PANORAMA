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
    public class RegIngresoEgresoDL
    {
        public List<RegIngresoEgresoBE> ListaTodosActivo(int IdTipoRegistro, int IdTipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_ListarPorTipificacion");
            db.AddInParameter(dbCommand, "pIdTipoRegistro", DbType.Int32, IdTipoRegistro);
            db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, IdTipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RegIngresoEgresoBE> DocumentoVentaDetallelist = new List<RegIngresoEgresoBE>();
            RegIngresoEgresoBE DetalleIO;
            while (reader.Read())
            {
                DetalleIO = new RegIngresoEgresoBE();

                DetalleIO.IdSubTipificacion = Int32.Parse(reader["IdSubTipificacion"].ToString());
                DetalleIO.DescSubTipificacion =reader["DescSubTipificacion"].ToString();
                DetalleIO.UnidadMedida = reader["UnidadMedida"].ToString();
                DetalleIO.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                DetalleIO.Monto = Decimal.Parse(reader["Monto"].ToString());
                DetalleIO.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                DocumentoVentaDetallelist.Add(DetalleIO);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<RegIngresoEgresoBE> Listar(string Buscartipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_Listar");
            db.AddInParameter(dbCommand, "pBuscar", DbType.String, Buscartipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RegIngresoEgresoBE> Tablalist = new List<RegIngresoEgresoBE>();
            RegIngresoEgresoBE Tabla;
            while (reader.Read())
            {
                Tabla = new RegIngresoEgresoBE();
                //Tabla.IdTipificacion = Int32.Parse(reader["IdTipificacion"].ToString());
                //Tabla.CodTipificacion = reader["CodTipificacion"].ToString();
                //Tabla.DescTipificacion = reader["DescTipificacion"].ToString();
                Tabla.IdSubTipificacion = Int32.Parse(reader["IdSubTipificacion"].ToString());
                Tabla.DescSubTipificacion = reader["DescSubTipificacion"].ToString();
                //Tabla.DescTipoGestion = reader["DescTipoGestion"].ToString();

                //Tabla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                //Tabla.DescArea = reader["DescArea"].ToString();
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public List<RegIngresoEgresoBE> ListarPorTificacion(int pIdTipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_Listar");
            db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pIdTipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RegIngresoEgresoBE> Tablalist = new List<RegIngresoEgresoBE>();
            RegIngresoEgresoBE Tabla;
            while (reader.Read())
            {
                Tabla = new RegIngresoEgresoBE();
                //Tabla.IdTipificacion = Int32.Parse(reader["IdTipificacion"].ToString());
                //Tabla.CodTipificacion = reader["CodTipificacion"].ToString();
                //Tabla.DescTipificacion = reader["DescTipificacion"].ToString();
                //Tabla.IdSubTipificacion = Int32.Parse(reader["IdSubTipificacion"].ToString());
                //Tabla.DescSubTipificacion = reader["DescSubTipificacion"].ToString();
                //Tabla.DescTipoGestion = reader["DescTipoGestion"].ToString();

                //Tabla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                //Tabla.DescArea = reader["DescArea"].ToString();
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }


        public void Inserta(RegIngresoEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_Insertar");

            //db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pItem.IdTipificacion);
            db.AddInParameter(dbCommand, "pDescSubTipificacion", DbType.String, pItem.DescSubTipificacion);
            //db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(RegIngresoEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_SubTipificaciones_Actualiza");

            //db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pItem.IdTipificacion);
            db.AddInParameter(dbCommand, "pIdSubTipificacion", DbType.Int32, pItem.IdSubTipificacion);
            db.AddInParameter(dbCommand, "pDescSubTipificacion", DbType.String, pItem.DescSubTipificacion);
            //db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
