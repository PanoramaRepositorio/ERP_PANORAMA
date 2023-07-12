using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ErpPanorama.DataLogic
{
    class ComboTipoCotizacionDL
    {
       
            public List<ComboTipoCotizacionBE> ObtenerComboTipoCotizacion()
            {
                List<ComboTipoCotizacionBE> listaComboTipoCotizacion = new List<ComboTipoCotizacionBE>();

                // Obtener una instancia de la base de datos
                Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");

                // Crear el comando para ejecutar el procedimiento almacenado
                DbCommand cmd = db.GetStoredProcCommand("NombreDelProcedimientoAlmacenado");

                // Agregar parámetros al comando si es necesario
                // db.AddInParameter(cmd, "NombreParametro", DbType.TipoDato, valorParametro);

                // Ejecutar el comando y obtener el resultado en un DataReader
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ComboTipoCotizacionBE comboTipoCotizacion = new ComboTipoCotizacionBE();

                        // Asignar los valores del DataReader a las propiedades del objeto ComboTipoCotizacionBE
                        comboTipoCotizacion.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                        comboTipoCotizacion.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                        comboTipoCotizacion.Abreviatura = reader["Abreviatura"].ToString();
                        comboTipoCotizacion.DescTablaElemento = reader["DescTablaElemento"].ToString();
                        comboTipoCotizacion.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                        comboTipoCotizacion.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                        comboTipoCotizacion.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;

                        // Agregar el objeto ComboTipoCotizacionBE a la lista
                        listaComboTipoCotizacion.Add(comboTipoCotizacion);
                    }
                }

                return listaComboTipoCotizacion;
            }
        

    }
}
