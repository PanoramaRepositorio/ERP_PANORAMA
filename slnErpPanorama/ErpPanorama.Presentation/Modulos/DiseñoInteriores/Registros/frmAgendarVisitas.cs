using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmAgendarVisitas: DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        int _IdAsesor = 0;

        public int IdAsesor
        {
            get { return _IdAsesor; }
            set { _IdAsesor = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public AsesoriaBE pAsesoriaBE { get; set; }

        #endregion

        #region "Eventos"

        public frmAgendarVisitas()
        {
            InitializeComponent();
        }

        private void frmAgendarVisitas_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAsesor, new PersonaBL().SeleccionaAsesor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;   // .strUsuarioLogin;
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Modificar";
                //deFechaContrato.EditValue = pAsesoriaBE.FechaContrato;
                //deFechaVenta.EditValue = pAsesoriaBE.FechaVenta;
                //deFechaVisita.EditValue = pAsesoriaBE.FechaVisita;
                //deFechaEntrega.EditValue = pAsesoriaBE.FechaEntrega;
                txtObservaciones.EditValue = pAsesoriaBE.Observacion;
                txtNumero.EditValue = pAsesoriaBE.Numero;
                IdPedido = Convert.ToInt32(pAsesoriaBE.IdPedido);
                IdCliente = pAsesoriaBE.IdCliente;
                cboAsesor.EditValue = pAsesoriaBE.IdAsesor;
                //btnBuscar.Enabled = false;
            }
            deFecha.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //if (!ValidarIngreso())
                //{
                    AgendaVisitaBE objAgenda = new AgendaVisitaBE();
                    AgendaVisitaBL objBL_Agenda = new AgendaVisitaBL();

                objAgenda.FechaAgendaVisita = Convert.ToDateTime(deFecha.EditValue); //  Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objAgenda.IdTienda = Convert.ToInt32(cboTienda.EditValue); 
                    objAgenda.IdPersona = Convert.ToInt32(cboAsesor.EditValue);
                    objAgenda.Observacion = txtObservaciones.Text;
                    objAgenda.IdSituacion = Parametros.intPVGenerado;
                    objAgenda.Usuario = Parametros.strUsuarioLogin;

                    //if (pOperacion == Operacion.Nuevo)
                        objBL_Agenda.Inserta(objAgenda);
                    //else
                        //objBL_Asesoria.Actualiza(objAsesoria);
                   //     objBL_Agenda.ActualizaFecha(objAgenda);

                    this.Close();
                //}
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deFechaContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaVisita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmBusCliente frm = new frmBusCliente();
            //    frm.pFlagMultiSelect = false;
            //    frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
            //    frm.ShowDialog();
            //    if (frm.pClienteBE != null)
            //    {
            //        IdCliente = frm.pClienteBE.IdCliente;
            //        txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
            //        txtDescCliente.Text = frm.pClienteBE.DescCliente;
            //        deFechaVenta.Focus();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingrese el Cliente.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        private void cboAsesor_EditValueChanged(object sender, EventArgs e)
        {


        }
    }
}