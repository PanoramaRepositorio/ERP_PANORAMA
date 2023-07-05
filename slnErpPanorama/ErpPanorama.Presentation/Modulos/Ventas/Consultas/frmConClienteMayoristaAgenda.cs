using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConClienteMayoristaAgenda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<ClienteAgendaBE> mLista = new List<ClienteAgendaBE>();

        #endregion

        #region "Eventos"

        public frmConClienteMayoristaAgenda()
        {
            InitializeComponent();
        }

        private void frmConClienteMayoristaAgenda_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaCargo(Parametros.intEmpresaId, Parametros.intGestorCartera), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTrackingCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSITPendiente;

            //Cargar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteAgenda";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvClienteAgenda.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int IdVendedor = 0;
            if (cboVendedor.Text !="")
                IdVendedor = Convert.ToInt32(cboVendedor.EditValue);

            mLista = new ClienteAgendaBL().ListaVendedorSituacion(IdVendedor, Convert.ToInt32(cboSituacion.EditValue));
            gcClienteAgenda.DataSource = mLista;
            lblTotalRegistros.Text = gvClienteAgenda.RowCount.ToString() + " Registros";
        }



        #endregion

    }
}