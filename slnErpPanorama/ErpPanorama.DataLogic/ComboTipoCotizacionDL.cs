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
    public class ComboTipoCotizacionDL
    {

        public List<ComboTipoCotizacionBE> ObtenerComboTipoCotizacion()
        {
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = new List<ComboTipoCotizacionBE>();


            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaTipoCotizacion");

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
        public List<ComboTipoCotizacionBE> ObtenerComboMateriales()
        {
            List<ComboTipoCotizacionBE> listaComboMaterial = new List<ComboTipoCotizacionBE>();


            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaMateriales");

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE comboTipoMaterial = new ComboTipoCotizacionBE();

                    // Asignar los valores del DataReader a las propiedades del objeto ComboTipoCotizacionBE
                    comboTipoMaterial.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    comboTipoMaterial.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    comboTipoMaterial.Abreviatura = reader["Abreviatura"].ToString();
                    comboTipoMaterial.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    comboTipoMaterial.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    comboTipoMaterial.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    comboTipoMaterial.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;

                    // Agregar el objeto ComboTipoCotizacionBE a la lista
                    listaComboMaterial.Add(comboTipoMaterial);
                }
            }

            return listaComboMaterial;
        }


    }


}
