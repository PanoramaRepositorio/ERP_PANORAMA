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

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConPlanContable : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<ConPlanContableBE> mLista = new List<ConPlanContableBE>();
        public ConPlanContableBE _Be { get; set; }

        #endregion

        #region "Eventos"

        public frmConPlanContable()
        {
            InitializeComponent();
        }

        private void frmConPlanContable_Load(object sender, EventArgs e)
        {
            Carga();
            txtConPlanContable.Select();
        }

        private void gvConPlanContable_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void gvConPlanContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aceptar();
        }

        private void txtConPlanContable_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCriterio();
            //if (e.KeyCode == Keys.Enter)
            //{
                
            //}

            if (e.KeyCode == Keys.Down)
            {
                gcConPlanContable.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new ConPlanContableBL().ListaTodosActivo();
            gcConPlanContable.DataSource = mLista;
        }

        private void Aceptar()
        {
            _Be = (ConPlanContableBE)gvConPlanContable.GetRow(gvConPlanContable.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarCriterio()
        {
            gcConPlanContable.DataSource = mLista.Where(obj =>
                                                   obj.Descripcion.ToUpper().Contains(txtConPlanContable.Text.ToUpper())
                                                   || obj.IdConPlanContable.ToString().Contains(txtConPlanContable.Text.ToUpper()) 
                                                   ).ToList();
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCriterio();
        }
    }
}