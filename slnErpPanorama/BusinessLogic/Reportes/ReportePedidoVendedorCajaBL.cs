﻿using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorCajaBL
    {
        public List<ReportePedidoVendedorCajaBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorCajaDL reporte = new ReportePedidoVendedorCajaDL();
                return reporte.Listado(IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
