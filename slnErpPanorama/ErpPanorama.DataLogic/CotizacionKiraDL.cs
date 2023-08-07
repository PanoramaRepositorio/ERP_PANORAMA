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

        public void RegistrarCotizacionYDetalle(CotizacionKiraBE cotizacion, List<DetalleCotizacionBE> detallesCotizacion, out int idCotizacion)
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
                        db.AddInParameter(cotizacionCommand, "@CostoMateriales", DbType.Decimal, cotizacion.CostoMateriales);
                        db.AddInParameter(cotizacionCommand, "@CostoInsumos", DbType.Decimal, cotizacion.CostoInsumos);
                        db.AddInParameter(cotizacionCommand, "@CostoAccesorios", DbType.Decimal, cotizacion.CostoAccesorios);
                        db.AddInParameter(cotizacionCommand, "@CostoManoObra", DbType.Decimal, cotizacion.CostoManoObra);
                        db.AddInParameter(cotizacionCommand, "@CostoMovilidad", DbType.Decimal, cotizacion.CostoMovilidad);
                        db.AddInParameter(cotizacionCommand, "@CostoEquipos", DbType.Decimal, cotizacion.CostoEquipos);
                        db.AddInParameter(cotizacionCommand, "@TotalGastos", DbType.Decimal, cotizacion.TotalGastos);
                        db.AddInParameter(cotizacionCommand, "@PrecioVenta", DbType.Decimal, cotizacion.PrecioVenta);
                        db.AddInParameter(cotizacionCommand, "@Moneda", DbType.Int32, cotizacion.IdMoneda); // Nuevo parámetro para la moneda
                        db.AddInParameter(cotizacionCommand, "@FlagEstado", DbType.Boolean, cotizacion.FlagEstado); // Nuevo parámetro para el FlagEstado de la Cotización
                        db.AddOutParameter(cotizacionCommand, "@IdCotizacion", DbType.Int32, 4);

                        // Agregar el parámetro @Imagen si se necesita almacenar en la base de datos
                        db.AddInParameter(cotizacionCommand, "@Imagen", DbType.String, cotizacion.Imagen);

                        // Agregar los parámetros de tabla estructurada para los detalles de cotización
                        var tvpParam = new SqlParameter("@DetalleCotizacion", SqlDbType.Structured)
                        {
                            TypeName = "dbo.DetalleCotizacionType",
                            Value = ConvertToDataTable(detallesCotizacion)
                        };
                        cotizacionCommand.Parameters.Add(tvpParam);

                        db.ExecuteNonQuery(cotizacionCommand, transaction);

                        // Obtener el ID de la cotización recién insertada
                        idCotizacion = Convert.ToInt32(db.GetParameterValue(cotizacionCommand, "@IdCotizacion"));

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
            dt.Columns.Add("Costo", typeof(decimal)); // Agregar la columna para el costo

            foreach (var detalle in detallesCotizacion)
            {
                dt.Rows.Add(detalle.IdTablaElemento, detalle.Item, detalle.DescripcionGastos, detalle.FlagAprobacion, detalle.FlagEstado, detalle.Costo);
            }

            return dt;
        }

        public bool ValidarCodigoProducto(string codigoProducto)
        {
            bool existeCodigo = false;

            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_ValidarCodigoProducto"))
                {
                    db.AddInParameter(command, "@CodigoProducto", DbType.String, codigoProducto);
                    db.AddOutParameter(command, "@ExisteCodigo", DbType.Boolean, 1);

                    db.ExecuteNonQuery(command);

                    existeCodigo = Convert.ToBoolean(db.GetParameterValue(command, "@ExisteCodigo"));
                }
            }

            return existeCodigo;
        }

        public void EliminarCotizacionPorCodigoProducto(string codigoProducto)
        {
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_EliminarCotizacion"))
                {
                    db.AddInParameter(command, "@CodigoProducto", DbType.String, codigoProducto);

                    db.ExecuteNonQuery(command);
                }
            }
        }

        public int ObtenerSiguienteNumeroCotizacion()
        {
            int siguienteNumero = 1;

            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_ObtenerSiguienteNumeroCotizacion"))
                {
                    var reader = db.ExecuteReader(command);

                    // Verificamos si hay al menos una fila en el resultado
                    if (reader.Read())
                    {
                        siguienteNumero = Convert.ToInt32(reader["SiguienteNumero"]);
                    }
                }
            }

            return siguienteNumero;
        }


        public int ObtenerSiguienteNumeroCotizacionProductoTerminado()
        {
            int siguienteNumero = 1;

            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_ObtenerSiguienteNumeroCotizacionProducto"))
                {
                    var reader = db.ExecuteReader(command);

                    // Verificamos si hay al menos una fila en el resultado
                    if (reader.Read())
                    {
                        siguienteNumero = Convert.ToInt32(reader["SiguienteNumero"]);
                    }
                }
            }

            return siguienteNumero;
        }

        public void ActualizarCotizacionPorId(int idCotizacion, string nuevoCodigoProducto, string nuevaDescripcion)
        {
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var actualizarCotizacionCommand = db.GetStoredProcCommand("usp_ActualizarCotizacion");
                        db.AddInParameter(actualizarCotizacionCommand, "@IdCotizacion", DbType.Int32, idCotizacion);
                        db.AddInParameter(actualizarCotizacionCommand, "@NuevoCodigoProducto", DbType.String, nuevoCodigoProducto);
                        db.AddInParameter(actualizarCotizacionCommand, "@NuevaDescripcion", DbType.String, nuevaDescripcion);
                        db.ExecuteNonQuery(actualizarCotizacionCommand, transaction);

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

        // Método para verificar si el nuevo CodigoProducto ya existe en la base de datos
        public bool ExisteCodigoProducto(string nuevoCodigoProducto)
        {
            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_ValidarCodigoProducto"))
                {
                    db.AddInParameter(command, "@CodigoProducto", DbType.String, nuevoCodigoProducto);
                    db.AddOutParameter(command, "@ExisteCodigo", DbType.Boolean, 1);

                    db.ExecuteNonQuery(command);

                    return Convert.ToBoolean(db.GetParameterValue(command, "@ExisteCodigo"));
                }
            }
        }

        public List<CotizacionKiraBE> FiltrarCotizacionesPorPeriodoYNumero(int periodo, int numeroCotizacion)
        {
            List<CotizacionKiraBE> cotizaciones = new List<CotizacionKiraBE>();

            using (var connection = db.CreateConnection())
            {
                connection.Open();
                using (var command = db.GetStoredProcCommand("usp_FiltrarCotizacionesPorPeriodoYNumero"))
                {
                    db.AddInParameter(command, "@Periodo", DbType.Int32, periodo);
                    db.AddInParameter(command, "@NumeroCotizacion", DbType.Int32, numeroCotizacion);

                    using (var reader = db.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
                            cotizacion.IdCotizacion = Convert.ToInt32(reader["IdCotizacion"]);
                            cotizacion.CodigoProducto = reader["CodigoProducto"].ToString();
                            cotizacion.Descripcion = reader["Descripcion"].ToString();
                            cotizacion.CostoMateriales = reader["CostoMateriales"] != DBNull.Value ? Convert.ToDecimal(reader["CostoMateriales"]) : 0;
                            cotizacion.CostoInsumos = reader["CostoInsumos"] != DBNull.Value ? Convert.ToDecimal(reader["CostoInsumos"]) : 0;
                            cotizacion.CostoAccesorios = reader["CostoAccesorios"] != DBNull.Value ? Convert.ToDecimal(reader["CostoAccesorios"]) : 0;
                            cotizacion.CostoManoObra = reader["CostoManoObra"] != DBNull.Value ? Convert.ToDecimal(reader["CostoManoObra"]) : 0;
                            cotizacion.CostoMovilidad = reader["CostoMovilidad"] != DBNull.Value ? Convert.ToDecimal(reader["CostoMovilidad"]) : 0;
                            cotizacion.CostoEquipos = reader["CostoEquipos"] != DBNull.Value ? Convert.ToDecimal(reader["CostoEquipos"]) : 0;
                            cotizacion.TotalGastos = reader["TotalGastos"] != DBNull.Value ? Convert.ToDecimal(reader["TotalGastos"]) : 0;
                            cotizacion.PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : 0;
                            cotizacion.Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue;
                            // Agregamos la columna DescTablaElemento a la entidad CotizacionKiraBE
                            cotizacion.DescTablaElemento = reader["DescTablaElemento"].ToString();
                            cotizaciones.Add(cotizacion);
                        }
                    }
                }
            }

            return cotizaciones;
        }




    }
}