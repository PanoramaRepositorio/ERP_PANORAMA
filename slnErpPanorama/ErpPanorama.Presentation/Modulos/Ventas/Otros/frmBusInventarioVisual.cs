using System;
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

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusInventarioVisual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioVisualBE> mLista = new List<InventarioVisualBE>();
        public Int32 IdProducto { get; set; }

        #endregion

        #region "Eventos"

        public frmBusInventarioVisual()
        {
            InitializeComponent();
        }

        private void frmBusInventarioVisual_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            mLista = new InventarioVisualBL().ListaBuscaProducto(IdProducto);
            gcProducto.DataSource = mLista;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"
            
        #endregion

    }
}