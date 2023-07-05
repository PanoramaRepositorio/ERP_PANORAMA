using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AlmacenMotivoMovimientoDL
    {
        public List<AlmacenMotivoMovimientoBE> ListaTodosActivo(int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenMotivoMovimiento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenMotivoMovimientoBE> AlmacenMotivoMovimientolist = new List<AlmacenMotivoMovimientoBE>();
            AlmacenMotivoMovimientoBE AlmacenMotivoMovimiento;
            while (reader.Read())
            {
                AlmacenMotivoMovimiento = new AlmacenMotivoMovimientoBE();
                AlmacenMotivoMovimiento.IdTablaElemento = Int32.Parse(reader["IdTablaElemento"].ToString());
                AlmacenMotivoMovimiento.DescTablaElemento = reader["DescTablaElemento"].ToString();
                AlmacenMotivoMovimientolist.Add(AlmacenMotivoMovimiento);
            }
            reader.Close();
            reader.Dispose();
            return AlmacenMotivoMovimientolist;
        }
    }
}
