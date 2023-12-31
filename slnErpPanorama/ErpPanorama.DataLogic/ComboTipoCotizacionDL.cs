﻿using System;
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

        public List<ComboTipoCotizacionBE> ObtenerComboInsumos()
        {
            List<ComboTipoCotizacionBE> listacomboInsumo = new List<ComboTipoCotizacionBE>();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaInsumos");

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE comboTipoInsumo = new ComboTipoCotizacionBE();

                    comboTipoInsumo.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    comboTipoInsumo.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    comboTipoInsumo.Abreviatura = reader["Abreviatura"].ToString();
                    comboTipoInsumo.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    comboTipoInsumo.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    comboTipoInsumo.Valor = reader["valor"] != DBNull.Value ? Convert.ToDecimal(reader["valor"]) : (decimal?)null;
                    comboTipoInsumo.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listacomboInsumo.Add(comboTipoInsumo);
                }
            }
            return listacomboInsumo;
        }

        public List<ComboTipoCotizacionBE> ObtenerlistaAccesorios()
        {
            List<ComboTipoCotizacionBE> listaaccesorios = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaAccesorios");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE comboaccesorios = new ComboTipoCotizacionBE();
                    comboaccesorios.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    comboaccesorios.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    comboaccesorios.Abreviatura = reader["Abreviatura"].ToString();
                    comboaccesorios.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    comboaccesorios.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    comboaccesorios.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    comboaccesorios.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listaaccesorios.Add(comboaccesorios);
                }
            }

            return listaaccesorios;
        }

        public List<ComboTipoCotizacionBE> ObtenerListaManoObra()
        {
            List<ComboTipoCotizacionBE> listamanoobra = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaManoObra");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE combomanoobra = new ComboTipoCotizacionBE();
                    combomanoobra.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    combomanoobra.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    combomanoobra.Abreviatura = reader["Abreviatura"].ToString();
                    combomanoobra.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    combomanoobra.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    combomanoobra.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    combomanoobra.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listamanoobra.Add(combomanoobra);
                }
            }

            return listamanoobra;
        }

        public List<ComboTipoCotizacionBE> ObtenerListaMovilidadyViaticos()
        {
            List<ComboTipoCotizacionBE> listamovilidad = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaMovilidadyViaticos");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE combomovilidad = new ComboTipoCotizacionBE();
                    combomovilidad.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    combomovilidad.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    combomovilidad.Abreviatura = reader["Abreviatura"].ToString();
                    combomovilidad.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    combomovilidad.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    combomovilidad.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    combomovilidad.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listamovilidad.Add(combomovilidad);
                }
            }

            return listamovilidad;
        }

        public List<ComboTipoCotizacionBE> ObtenerListaMonedas()
        {
            List<ComboTipoCotizacionBE> listamovilidad = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaTipoMoneda");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE combomovilidad = new ComboTipoCotizacionBE();
                    combomovilidad.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    combomovilidad.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    combomovilidad.Abreviatura = reader["Abreviatura"].ToString();
                    combomovilidad.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    combomovilidad.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    combomovilidad.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    combomovilidad.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listamovilidad.Add(combomovilidad);
                }
            }

            return listamovilidad;
        }

        public List<ComboTipoCotizacionBE> ObtenerListaEquipoHerramienta()
        {
            List<ComboTipoCotizacionBE> listamovilidad = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaEquiposHerramientas");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE combomovilidad = new ComboTipoCotizacionBE();
                    combomovilidad.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    combomovilidad.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    combomovilidad.Abreviatura = reader["Abreviatura"].ToString();
                    combomovilidad.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    combomovilidad.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    combomovilidad.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    combomovilidad.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listamovilidad.Add(combomovilidad);
                }
            }

            return listamovilidad;
        }


        public List<CotizacionKiraBE> ObtenerListadoCotizaciones()
        {
            List<CotizacionKiraBE> listaCotizaciones = new List<CotizacionKiraBE>();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_ListarCotizaciones");

            using (IDataReader reader = db.ExecuteReader(cmd))
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

                    listaCotizaciones.Add(cotizacion);
                }
            }

            return listaCotizaciones;
        }

        public List<CotizacionKiraProductoTerminadoBE> ObtenerListadoCotizacionesproductos()
        {
            List<CotizacionKiraProductoTerminadoBE> listaCotizaciones = new List<CotizacionKiraProductoTerminadoBE>();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_ListarCotizacionesproductos");

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    CotizacionKiraProductoTerminadoBE cotizacion = new CotizacionKiraProductoTerminadoBE();

                    cotizacion.IdCotizacion = Convert.ToInt32(reader["IdCotizacion"]);
                    cotizacion.CodigoProducto = reader["CodigoProducto"].ToString();
                    cotizacion.Descripcion = reader["Descripcion"].ToString();
                    cotizacion.CostoProductos = reader["CostoProductos"] != DBNull.Value ? Convert.ToDecimal(reader["CostoProductos"]) : 0;
                    cotizacion.TotalGastos = reader["TotalGastos"] != DBNull.Value ? Convert.ToDecimal(reader["TotalGastos"]) : 0;
                    cotizacion.PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : 0;
                    cotizacion.Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue;
                    // Agregamos la columna DescTablaElemento a la entidad CotizacionKiraBE
                    cotizacion.DescTablaElemento = reader["DescTablaElemento"].ToString();

                    listaCotizaciones.Add(cotizacion);
                }
            }

            return listaCotizaciones;
        }

        public List<ComboTipoCotizacionBE> ObtenerListaProductoTerminados()
        {
            List<ComboTipoCotizacionBE> listaProductoterminado = new List<ComboTipoCotizacionBE>();
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand cmd = db.GetStoredProcCommand("usp_Combo_ListaProductoTerminado");
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ComboTipoCotizacionBE comboProductoTerminado = new ComboTipoCotizacionBE();
                    comboProductoTerminado.IdTablaElemento = Convert.ToInt32(reader["IdTablaElemento"]);
                    comboProductoTerminado.IdTabla = reader["IdTabla"] != DBNull.Value ? Convert.ToInt32(reader["IdTabla"]) : (int?)null;
                    comboProductoTerminado.Abreviatura = reader["Abreviatura"].ToString();
                    comboProductoTerminado.DescTablaElemento = reader["DescTablaElemento"].ToString();
                    comboProductoTerminado.IdTablaExterna = reader["IdTablaExterna"] != DBNull.Value ? Convert.ToInt32(reader["IdTablaExterna"]) : (int?)null;
                    comboProductoTerminado.Valor = reader["Valor"] != DBNull.Value ? Convert.ToDecimal(reader["Valor"]) : (decimal?)null;
                    comboProductoTerminado.FlagEstado = reader["FlagEstado"] != DBNull.Value ? Convert.ToBoolean(reader["FlagEstado"]) : (bool?)null;
                    listaProductoterminado.Add(comboProductoTerminado);
                }
            }

            return listaProductoterminado;
        }




    }


}
