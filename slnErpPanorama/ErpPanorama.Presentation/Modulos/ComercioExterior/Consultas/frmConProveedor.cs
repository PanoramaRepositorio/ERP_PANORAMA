using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmConProveedor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<ProveedorBE> mLista = new List<ProveedorBE>();
        public ProveedorBE _Be { get; set; }

        #endregion

        #region "Eventos"

        public frmConProveedor()
        {
            InitializeComponent();
        }

        private void frmConProveedor_Load(object sender, EventArgs e)
        {
            Carga();
            txtProveedor.Select();
        }

       private void gvProveedor_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void gvProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aceptar();
        }

        private void txtProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCriterio();
            //if (e.KeyCode == Keys.Enter)
            //{
                
            //}

            if (e.KeyCode == Keys.Down)
            {
                gcProveedor.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new ProveedorBL().ListaTodosActivoNacional(Parametros.intEmpresaId);
            gcProveedor.DataSource = mLista;
        }

        private void Aceptar()
        {
            _Be = (ProveedorBE)gvProveedor.GetRow(gvProveedor.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarCriterio()
        {
            gcProveedor.DataSource = mLista.Where(obj =>
                                                   obj.DescProveedor.ToUpper().Contains(txtProveedor.Text.ToUpper())
                                                   || obj.NumeroDocumento.ToString().Contains(txtProveedor.Text.ToUpper()) 
                                                   ).ToList();
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCriterio();
        }
    }
}