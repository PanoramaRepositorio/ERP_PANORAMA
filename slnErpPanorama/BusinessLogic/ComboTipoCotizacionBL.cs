﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{
    public class ComboTipoCotizacionBL
    {
        public List<ComboTipoCotizacionBE> ObtenerComboTipoCotizacion()
        {
            ComboTipoCotizacionDL comboTipoCotizacionDL = new ComboTipoCotizacionDL();
            return comboTipoCotizacionDL.ObtenerComboTipoCotizacion();
        }

        public List<ComboTipoCotizacionBE> ObtenerComboMateriales()
        {
            ComboTipoCotizacionDL comboMaterial = new ComboTipoCotizacionDL();
            return comboMaterial.ObtenerComboMateriales();
        }

        public List<ComboTipoCotizacionBE> ObtenerComboInsumo()
        {
            ComboTipoCotizacionDL comboinsumo = new ComboTipoCotizacionDL();
            return comboinsumo.ObtenerComboInsumos();
        }

        public List<ComboTipoCotizacionBE> ObtenerAccesorios()
        {
            ComboTipoCotizacionDL comboaccesorio = new ComboTipoCotizacionDL();
            return comboaccesorio.ObtenerlistaAccesorios();


        }

        public List<ComboTipoCotizacionBE> ObtenerManoObra()
        {
            ComboTipoCotizacionDL comboMano = new ComboTipoCotizacionDL();
            return comboMano.ObtenerListaManoObra();
        }

        public List<ComboTipoCotizacionBE> ObtenerMovilidadyViaticos()
        {
            ComboTipoCotizacionDL comboMovi = new ComboTipoCotizacionDL();
            return comboMovi.ObtenerListaMovilidadyViaticos();
        }
    }
}
