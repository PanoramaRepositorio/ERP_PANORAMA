using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegCheque : DevExpress.XtraEditors.XtraForm
    {
        public frmRegCheque()
        {
            InitializeComponent();
        }

        #region "Propiedades"

        private List<ChequeBE> mLista = new List<ChequeBE>();
        public ChequeBE pCheque { get; set; }
        #endregion

        #region "Eventos"

        private void frmRegCheque_Load(object sender, EventArgs e)
        {
            //tlbMenu.Ensamblado = this.Tag.ToString(); // NECESARIO PARA QUE FUNCIONE TBLMENU
            BSUtils.LoaderLook(cboEmpresa, CargarEmpresa(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            deFechaEmision.EditValue = DateTime.Now.AddMonths(-1);
            deFechaFin.EditValue = DateTime.Now;
            Cargar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvCheque_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void tlbMenu_NewClick()
        {

        }

        private void tlbMenu_EditClick()
        {
          
        }

        private void tlbMenu_DeleteClick()
        {

        }

        private void tlbMenu_RefreshClick()
        {
           
        }

        private void tlbMenu_PrintClick()
        {
            // PENDIENTE
        }

        private void tlbMenu_ExportClick()
        {

        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ChequeBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToDateTime(deFechaEmision.EditValue), Convert.ToDateTime(deFechaFin.EditValue));
            gcCheque.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCheque.RowCount > 0)
            {
                ChequeBE objCheque = new ChequeBE();
                objCheque.IdCheque = int.Parse(gvCheque.GetFocusedRowCellValue("IdCheque").ToString());
                frmRegChequeEdit frm = new frmRegChequeEdit();
                frm.pOperacion = frmRegChequeEdit.Operacion.Modificar;
                frm.IdCheque = objCheque.IdCheque;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                XtraMessageBox.Show("No hay registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvCheque.GetFocusedRowCellValue("IdCheque").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Cheque", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private DataTable CargarEmpresa()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdEmpresa", Type.GetType("System.Int32"));
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            DataRow dr;

            dr = dt.NewRow();
            dr["IdEmpresa"] = 13;
            dr["RazonSocial"] = "PANORAMA DISTRIBUIDORES S.A.";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["IdEmpresa"] = 27;
            dr["RazonSocial"] = "DECORATEX E.I.R.L.";
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegChequeEdit frm = new frmRegChequeEdit();
                frm.pOperacion = frmRegChequeEdit.Operacion.Nuevo;
                frm.IdCheque = 0;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean vdato = Convert.ToBoolean(gvCheque.GetFocusedRowCellValue("FlagEstado"));

                if (!vdato)
                {
                    XtraMessageBox.Show("El registro se encuentra anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ChequeBE pCheque = null;
                pCheque = new ChequeBL().Consulta(int.Parse(gvCheque.GetFocusedRowCellValue("IdCheque").ToString()));

               if (pCheque.IdSituacion==1)
              //  if (pCheque.FechaEmision != Convert.ToDateTime(DateTime.Now.Date))
                {
                    XtraMessageBox.Show("Ya no puede anular el registro debido a que se genero el correlativo del cheque.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ChequeBE objE_Cheque = new ChequeBE();
                        objE_Cheque.IdCheque = int.Parse(gvCheque.GetFocusedRowCellValue("IdCheque").ToString());
                        objE_Cheque.Usuario = Parametros.strUsuarioLogin;
                        objE_Cheque.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cheque.IdEmpresa = Parametros.intEmpresaId;

                        objE_Cheque.IdBanco = int.Parse(gvCheque.GetFocusedRowCellValue("IdBanco").ToString());
                        objE_Cheque.IdMoneda = int.Parse(gvCheque.GetFocusedRowCellValue("IdMoneda").ToString());

                        ChequeBL objBL_Cheque = new ChequeBL();
                        objBL_Cheque.Elimina(objE_Cheque);
                        XtraMessageBox.Show("El registro se eliminó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Cargar();
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCheque";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCheque.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean vdato = Convert.ToBoolean(gvCheque.GetFocusedRowCellValue("FlagEstado"));

                if (!vdato)
                {
                    XtraMessageBox.Show("El registro se encuentra anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de anular el CHEQUE?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ChequeBE objE_Cheque = new ChequeBE();
                        objE_Cheque.IdCheque = int.Parse(gvCheque.GetFocusedRowCellValue("IdCheque").ToString());
                        objE_Cheque.Usuario = Parametros.strUsuarioLogin;
                        objE_Cheque.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cheque.IdEmpresa = Parametros.intEmpresaId;

                        objE_Cheque.IdBanco = int.Parse(gvCheque.GetFocusedRowCellValue("IdBanco").ToString());
                        objE_Cheque.IdMoneda = int.Parse(gvCheque.GetFocusedRowCellValue("IdMoneda").ToString());

                        ChequeBL objBL_Cheque = new ChequeBL();
                        objBL_Cheque.AnulaCheque(objE_Cheque);
                        XtraMessageBox.Show("El cheque fue anulado satisfactoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void gvCheque_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvCheque.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DesSituacion"]);
                    if (objDocRetiro != null)
                    {
                        string IdSituacion = (objDocRetiro.ToString());
                        if (IdSituacion == "ANULADO REG.")
                        {
                            e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular | FontStyle.Strikeout);
                            //e.Appearance.ForeColor = Color.Gray;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else if (IdSituacion == "ANULADO CHEQ.")
                        {
                            //  e.Appearance.ForeColor = Color.Red;
                            //  e.Appearance.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular | FontStyle.Strikeout);
                            e.Appearance.ForeColor = Color.Black;
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else if (IdSituacion == "EN PROCESO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                        else if (IdSituacion == "CANCELADO")
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}