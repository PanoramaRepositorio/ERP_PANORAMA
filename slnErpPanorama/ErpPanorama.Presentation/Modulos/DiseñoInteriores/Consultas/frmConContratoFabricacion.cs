using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Consultas
{
    public partial class frmConContratoFabricacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<Dis_ContratoFabricacionBE> mLista = new List<Dis_ContratoFabricacionBE>();

        #endregion

        #region "Eventos"

        public frmConContratoFabricacion()
        {
            InitializeComponent();
        }

        private void frmConContratoFabricacion_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
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
                gvContratoFabricacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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
            mLista = new Dis_ContratoFabricacionBL().ListaTracking(Parametros.intEmpresaId ,deDesde.DateTime, deHasta.DateTime) ;
            gcContratoFabricacion.DataSource = mLista;
        }



        #endregion


    }
}