using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegAsistenciaFecha : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CheckinoutBE> mLista = new List<CheckinoutBE>();

        private int IdCheckinout = 0;

        #endregion

        #region "Eventos"

        public frmRegAsistenciaFecha()
        {
            InitializeComponent();
        }

        private void frmRegAsistenciaFecha_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMarcacionPersonal";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMarcacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CheckinoutBL().ListaTodosActivoFecha(0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcMarcacion.DataSource = mLista;
            lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
        }

        #endregion

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvMarcacion.SelectedRowsCount; i++)
                {
                    int row = gvMarcacion.GetSelectedRows()[i];
                    int IdCheckinout = 0;

                    IdCheckinout = int.Parse(gvMarcacion.GetRowCellValue(row, "IdCheckinout").ToString());

                    CheckinoutBE objBE_Checkinout = new CheckinoutBE();
                    objBE_Checkinout.IdCheckinout = IdCheckinout;
                    objBE_Checkinout.IdEmpresa = Parametros.intEmpresaId;
                    objBE_Checkinout.Usuario = Parametros.strUsuarioLogin;
                    objBE_Checkinout.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                    objBL_Checkinout.Elimina(objBE_Checkinout);

                    gvMarcacion.DeleteSelectedRows();
                    gvMarcacion.RefreshData();
                    XtraMessageBox.Show("Registro eliminado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItemCopiar_Click(object sender, EventArgs e)
        {

        }

        private void gvMarcacion_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvMarcacion.RowCount > 0)
            {
                
                IdCheckinout = int.Parse(gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "IdCheckinout").ToString());
                //txtDni.Text = gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "Dni").ToString();
                //deFecha.EditValue = DateTime.Parse(gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "Fecha").ToString());
                //chkTipo.Checked = gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "Tipo"));
                //chkManual.Checked = Boolean.Parse(gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "FlagManual").ToString());
            }
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gvMarcacion_DoubleClick(object sender, EventArgs e)
        {
            if (gvMarcacion.RowCount > 0)
            {
                IdCheckinout = int.Parse(gvMarcacion.GetRowCellValue(gvMarcacion.FocusedRowHandle, "IdCheckinout").ToString());
                CheckinoutBE objE_Checkinout = new CheckinoutBE();
                objE_Checkinout = new CheckinoutBL().Selecciona(IdCheckinout);
                txtDni.Text = objE_Checkinout.Dni;
                deFecha.EditValue = objE_Checkinout.FechaHora;
                chkManual.Checked = objE_Checkinout.flagManual;
                if (objE_Checkinout.Tipo.ToUpper() == "I")
                {
                    optIngreso.Checked = true;
                }
                else
                {
                    optSalida.Checked = true;
                }
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngreso())
            {
                CheckinoutBE objE_Checkinout = new CheckinoutBE();
                CheckinoutBL objBL_Checkinout = new CheckinoutBL();

                objE_Checkinout.IdCheckinout = IdCheckinout;
                objE_Checkinout.IdEmpresa = Parametros.intEmpresaId;
                objE_Checkinout.Dni = txtDni.Text.Trim();
                objE_Checkinout.Fecha = Convert.ToDateTime(deFecha.Text); //Convert.ToDateTime(deFecha.Text);//Convert.ToDateTime(deFecha.EditValue);
                objE_Checkinout.FechaHora = Convert.ToDateTime(deFecha.Text);
                objE_Checkinout.flagManual = true;//chkManual.Checked;
                objE_Checkinout.Usuario = Parametros.strUsuarioLogin;
                objE_Checkinout.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_Checkinout.FlagEstado = true;
                if (optIngreso.Checked == true)
                    objE_Checkinout.Tipo = "I";
                else
                    objE_Checkinout.Tipo = "O";
                objBL_Checkinout.InsertaSimple(objE_Checkinout);

                XtraMessageBox.Show("Registro grabado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (IdCheckinout > 0)
            {
                CheckinoutBE objE_Checkinout = new CheckinoutBE();
                CheckinoutBL objBL_Checkinout = new CheckinoutBL();

                objE_Checkinout.IdCheckinout = IdCheckinout;
                objE_Checkinout.IdEmpresa = Parametros.intEmpresaId;
                objE_Checkinout.Dni = txtDni.Text.Trim();
                objE_Checkinout.Fecha = Convert.ToDateTime(deFecha.Text);//Convert.ToDateTime(deFecha.EditValue);
                objE_Checkinout.FechaHora = Convert.ToDateTime(deFecha.Text);// Convert.ToDateTime(deFecha.EditValue);
                objE_Checkinout.flagManual = chkManual.Checked;
                objE_Checkinout.Usuario = Parametros.strUsuarioLogin;
                objE_Checkinout.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_Checkinout.FlagEstado = true;
                if (optIngreso.Checked == true)
                    objE_Checkinout.Tipo = "I";
                else
                    objE_Checkinout.Tipo = "O";
                objBL_Checkinout.Actualiza(objE_Checkinout);

                XtraMessageBox.Show("Registro grabado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar();
            }

        }

        private void gvMarcacion_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDni.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- El nímero del documento no puede estar vacío.\n";
                flag = true;
            }

            if (deFecha.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la fecha de registro.\n";
                flag = true;
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

    }
}