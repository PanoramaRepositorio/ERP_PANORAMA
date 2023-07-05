﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmBuscaEgresos: DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public CajaEgresoDetalleBE oBE = new CajaEgresoDetalleBE();

        public List<ProveedorBE> pListaCliente { get; set; }
        public ProveedorBE pProveedorBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public String pNumeroDescCliente { get; set; }
        public int intTipoBusqueda = 0;

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        public int Segundos = 0;

        private List<CajaEgresoDetalleBE> mLista = new List<CajaEgresoDetalleBE>();

        public int IdCajaEgreso = 0;
        public int IdCajaEgresoDetalle = 0;
        #endregion

        #region "Eventos"


        public frmBuscaEgresos()
        {
            InitializeComponent();
        }

        private void frmBuscaEgresos_Load(object sender, EventArgs e)
        {
            mLista = new CajaEgresoDetalleBL().ListaTodosEgresos(oBE.IdCajaEgreso, oBE.IdCajaEgresoDetalle);
            gcListaEgresos.DataSource = mLista;
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            //if (Parametros.bBusquedaTimer)
            //{
            //    timer1.Enabled = true;
            //    Segundos = 0;
            //}
            //else
            //{
            //    if (txtDescripcion.Text.ToString().Length > 4)
            //    {
            //        if (char.IsNumber(Convert.ToChar(txtDescripcion.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
            //            intTipoBusqueda = 1;
            //        else
            //            intTipoBusqueda = 2;

            //        CargarBusqueda();
            //    }
            //}


        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtDescripcion.Text.Length > 4) {
            //        SeleccionarRegistro();
            //    }
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    gcProveedor.Focus();
            //}
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            oBE.IdCajaEgreso  = int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgreso").ToString());
            oBE.IdCajaEgresoDetalle = int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
            oBE.NumRecibo   = gvListaEgresos.GetFocusedRowCellValue("NumRecibo").ToString();
            oBE.Fecha = Convert.ToDateTime(gvListaEgresos.GetFocusedRowCellValue("Fecha").ToString());
            oBE.Importe = Convert.ToDecimal(gvListaEgresos.GetFocusedRowCellValue("Importe").ToString());

            this.DialogResult = DialogResult.OK;
		}

        private void gvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //intPagina = intPaginaPrimero;
            ////cboPagina.EditValue = intPagina;
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);
            ////cboPagina.EditValue = intPagina;

            //CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //intPagina = intPagina - 1;
            ////cboPagina.EditValue = intPagina;
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);

            //CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //intPagina = intPagina + 1;
            ////cboPagina.EditValue = intPagina;
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);

            //CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //intPagina = intPaginaUltima;
            ////cboPagina.EditValue = intPagina;
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);

            //CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtCantidadRegistros.Text.Length > 0)
            //{
            //    intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            //    CalcularPaginas();
            //    CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            //}
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            //intPagina = int.Parse(cboPagina.EditValue.ToString());
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);
            //if (intPaginaPrimero == intPaginaUltima)
            //    HabilitarBotones(false, false, false, false);
            //CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            //if (txtDescripcion.Text.Trim().Length > 2)
            //{
                //gcProveedor.DataSource = new ProveedorBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, txtDescripcion.Text, pagina, registros, intTipoBusqueda);
            //}
        }

        private void CargarBusqueda()
        {
            //gcProveedor.DataSource = new ProveedorBL().SeleccionaBusquedaEgresosCaja(IdCajaEgreso, IdCajaEgresoDetalle);
            //CalcularPaginas();
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);
            //if (intPaginaPrimero == intPaginaUltima)
            //    HabilitarBotones(false, false, false, false);

        }

        private void SeleccionarRegistro()
        {

        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            //btnFirst.Enabled = bolFirst;
            //btnPrevious.Enabled = bolPrevious;
            //btnNext.Enabled = bolNext;
            //btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            //intRowCount = new ClienteBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, 0, txtDescripcion.Text, intTipoBusqueda);
            return intRowCount;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                SeleccionarRegistro();
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Segundos = Segundos + 1;

            //if (Segundos > 5)
            //{
            //    if (txtDescripcion.Text.ToString().Length > 4)
            //    {
            //        if (char.IsNumber(Convert.ToChar(txtDescripcion.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
            //            intTipoBusqueda = 1;
            //        else
            //            intTipoBusqueda = 2;

            //        CargarBusqueda();

            //        timer1.Enabled = false;
            //    }
            //}

            //if (Segundos > 10)
            //    timer1.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}