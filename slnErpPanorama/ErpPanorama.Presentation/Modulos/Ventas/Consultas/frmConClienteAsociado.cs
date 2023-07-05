using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConClienteAsociado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<ClienteBE> mLista = new List<ClienteBE>();

        int IdCliente = 0;

        #endregion

        #region "Eventos"

        public frmConClienteAsociado()
        {
            InitializeComponent();
        }

        private void frmConClienteAsociado_Load(object sender, EventArgs e)
        {
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusClienteOAsociado frm = new frmBusClienteOAsociado();

                //frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    Cargar();
                    CargarAsociado(IdCliente);
                    gvClientePrincipal.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvClientePrincipal_Click(object sender, EventArgs e)
        {
            CargarAsociado(IdCliente);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBusClienteOAsociado frm = new frmBusClienteOAsociado();

                frm.pFlagMultiSelect = false;
                frm.pNumeroDocumento = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    Cargar();
                    CargarAsociado(IdCliente);
                    gvClientePrincipal.Focus();
                }
                else
                {
                    //XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtCPrincipal = new DataTable();
            mLista = new ClienteBL().SeleccionaLista(Parametros.intEmpresaId,IdCliente);
            dtCPrincipal = FuncionBase.ToDataTable(mLista);
            gcClientePrincipal.DataSource = dtCPrincipal;
        }

        private void CargarAsociado(int IdCliente)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new ClienteAsociadoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente));
                gcClienteAsociado.DataSource = dtDetalle;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion


    }
}