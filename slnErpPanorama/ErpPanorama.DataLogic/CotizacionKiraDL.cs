using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpPanorama.BusinessEntity;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ErpPanorama.DataLogic
{
    public class CotizacionKiraDL
    {
        private Database db;

        public CotizacionKiraDL()
        {
            // Reemplaza "cnErpPanoramaBD" con la cadena de conexión configurada en tu app.config
            db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        }

        public void RegistrarCotizacionYDetalle(CotizacionKiraBE cotizacion, List<DetalleCotizacionBE> detallesCotizacion)
        {
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar la cotización en la tabla "CotizacionKIRA"
                        var cotizacionCommand = db.GetStoredProcCommand("usp_RegistrarCotizacionYDetalle");
                        db.AddInParameter(cotizacionCommand, "@IdTablaElemento", DbType.Int32, cotizacion.IdTablaElemento);
                        db.AddInParameter(cotizacionCommand, "@Fecha", DbType.Date, cotizacion.Fecha);
                        db.AddInParameter(cotizacionCommand, "@CodigoProducto", DbType.String, cotizacion.CodigoProducto);
                        db.AddInParameter(cotizacionCommand, "@Descripcion", DbType.String, cotizacion.Descripcion);
                        db.AddInParameter(cotizacionCommand, "@Caracteristicas", DbType.String, cotizacion.Caracteristicas);
                        db.AddInParameter(cotizacionCommand, "@Imagen", DbType.String, cotizacion.Imagen);
                        db.AddInParameter(cotizacionCommand, "@TotalGastos", DbType.Decimal, cotizacion.TotalGastos);
                        db.AddInParameter(cotizacionCommand, "@PrecioVenta", DbType.Decimal, cotizacion.PrecioVenta);
                        db.AddInParameter(cotizacionCommand, "@Moneda", DbType.Int32, cotizacion.IdMoneda); // Nueva línea para agregar el parámetro Moneda

                        db.AddOutParameter(cotizacionCommand, "@IdCotizacion", DbType.Int32, 4);

                        // Agregar los parámetros de tabla estructurada para los detalles de cotización
                        var tvpParam = new SqlParameter("@DetalleCotizacion", SqlDbType.Structured)
                        {
                            TypeName = "dbo.DetalleCotizacionType",
                            Value = ConvertToDataTable(detallesCotizacion)
                        };
                        cotizacionCommand.Parameters.Add(tvpParam);

                        db.ExecuteNonQuery(cotizacionCommand, transaction);

                        // Obtener el ID de la cotización recién insertada
                        cotizacion.IdCotizacion = Convert.ToInt32(db.GetParameterValue(cotizacionCommand, "@IdCotizacion"));

                        // Confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DataTable ConvertToDataTable(List<DetalleCotizacionBE> detallesCotizacion)
        {
            var dt = new DataTable();
            dt.Columns.Add("IdTablaElemento", typeof(int));
            dt.Columns.Add("Item", typeof(int));
            dt.Columns.Add("DescripcionGastos", typeof(string));
            dt.Columns.Add("FlagAprobacion", typeof(bool));
            dt.Columns.Add("FlagEstado", typeof(bool));

            foreach (var detalle in detallesCotizacion)
            {
                dt.Rows.Add(detalle.IdTablaElemento, detalle.Item, detalle.DescripcionGastos, detalle.FlagAprobacion, detalle.FlagEstado);
            }

            return dt;
        }

    }
}