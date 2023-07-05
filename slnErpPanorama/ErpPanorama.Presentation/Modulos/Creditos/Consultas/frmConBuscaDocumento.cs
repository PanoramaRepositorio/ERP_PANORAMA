using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConBuscaDocumento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        private List<PedidoDetalleBE> mListaPedidoDetalle = new List<PedidoDetalleBE>();

        #endregion

        #region "Eventos"

        public frmConBuscaDocumento()
        {
            InitializeComponent();
        }

        private void frmConBuscaDocumento_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            Cargar();
        }


        private void toolstpImprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaDocumentoEstadoCuentaNumero(Parametros.intPeriodo, txtNumero.Text.Trim()));
                if (dtPedido.Rows.Count > 0)
                {
                    gcDocumento.DataSource = dtPedido;
                }
                else
                {
                    XtraMessageBox.Show("El N° de Documento no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDocumentoEstadoCuenta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaFechaDocumentoEstadoCuenta(Parametros.intEmpresaId ,deDesde.DateTime, deHasta.DateTime));
            gcDocumento.DataSource = dtPedido;

//            txtTotal.Text = dtPedido.Rows.Count.ToString();
        }

        private void txtConcepto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaDocumentoEstadoCuentaConcepto(Parametros.intPeriodo,txtConcepto.Text.Trim()));
                if (dtPedido.Rows.Count > 0)
                {
                    gcDocumento.DataSource = dtPedido;
                }
                else
                {
                    XtraMessageBox.Show("No hay registros que contengan: " + txtConcepto.Text , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion



    }
}