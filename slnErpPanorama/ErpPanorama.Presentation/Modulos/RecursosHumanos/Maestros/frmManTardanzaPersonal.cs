using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;


namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManTardanzaPersonal : DevExpress.XtraEditors.XtraForm
    {
        #region 'Propiedades'

        private int TipoReporte = 1;
        private List<CheckinoutBE> mLista = new List<CheckinoutBE>();

        public frmManTardanzaPersonal()
        {
            InitializeComponent();
        }

        #endregion

        #region 'Eventos'

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void frmManTardanzaPersonal_Load(object sender, EventArgs e)
        {
            optResumen.Checked = true;
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {

            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTardanza";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcMarcacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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

        private void gvMarcacion_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }
        #endregion

        #region 'Metodos'

        private void CargarResumen()
        {
            gridColumn12.Visible = false;
            gridColumn3.Visible = false;
            gridColumn6.Visible = false;

            //txtDescuento.Location = new Point(559, 566);
            //txtTotalMinutos.Location = new Point(437, 566);
            //labelControl27.Location = new Point(396, 569);

            int IdPersona = Parametros.intPersonaId;

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                IdPersona = 0;

            mLista = new CheckinoutBL().ListaTardanza("0", IdPersona, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),1);
            gcMarcacion.DataSource = mLista;

            CalcularTotalDocumentos();
            //lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
        }

        private void CargarDetalle()
        {
            gridColumn3.VisibleIndex = 2;
            gridColumn6.VisibleIndex = 3;
            gridColumn12.Visible = true;
            gridColumn3.Visible = true;
            gridColumn6.Visible = true;

            //txtDescuento.Location = new Point(810, 566);
            //txtTotalMinutos.Location = new Point(700, 566);
            //labelControl27.Location = new Point(659, 569);

            int IdPersona = Parametros.intPersonaId;

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                IdPersona = 0;

            mLista = new CheckinoutBL().ListaTardanza("0", IdPersona, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);
            gcMarcacion.DataSource = mLista;

            CalcularTotalDocumentos();
            //lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
        }

        private void Cargar()
        {
            if (optDetalle.Checked == true)
            {
                CargarDetalle();
            }
            else
            {
                CargarResumen();
            }
        }

        private void CargarBusqueda()
        {
            gcMarcacion.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.Dni.ToUpper().Contains(txtDescripcion.Text.ToUpper()) /*||
                                                   obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.DescArea.ToUpper().Contains(txtDescripcion.Text.ToUpper())*/).ToList();
            //CalcularTotalDocumentos();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                if (gvMarcacion.RowCount > 0)
                {
                    decimal decMinutos = 0;
                    decimal decDescuento = 0;
                    for (int i = 0; i < gvMarcacion.RowCount; i++)
                    {
                        decMinutos = decMinutos + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Tardanza"])));
                        decDescuento = decDescuento + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Descuento"])));
                    }
                    txtTotalMinutos.EditValue = decMinutos;
                    txtDescuento.EditValue = decDescuento;

                    lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion


    }
}
