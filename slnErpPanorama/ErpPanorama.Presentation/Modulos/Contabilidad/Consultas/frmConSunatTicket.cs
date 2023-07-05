using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConSunatTicket : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SunatConsultaTicketBE> mLista = new List<SunatConsultaTicketBE>();

        #endregion

        #region "Eventos"
        public frmConSunatTicket()
        {
            InitializeComponent();
        }

        private void frmConSunatTicket_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoConsultaTicketSunat";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumentoVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new SunatConsultaTicketBL().ListaFecha(Parametros.intEmpresaId, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcDocumentoVenta.DataSource = mLista;
        }

        #endregion
    }
}