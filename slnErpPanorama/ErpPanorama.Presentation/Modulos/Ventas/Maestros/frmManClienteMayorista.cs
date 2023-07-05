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
using ErpPanorama.Presentation.Modulos.Ventas.Reportes;
using ErpPanorama.Presentation.Modulos.Ventas.Consultas;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteMayorista : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        private List<ClienteBE> mLista = new List<ClienteBE>();
        private List<ReporteClienteCumpleanosBE> mListaClienteCumpleanos = new List<ReporteClienteCumpleanosBE>();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        private int Segundos = 0;
        private int intTipoBusqueda = 0;

        #endregion

        #region "Eventos"

        public frmManClienteMayorista()
        {
            InitializeComponent();
        }

        private void frmManClienteMayorista_Load(object sender, EventArgs e)
        {


            tlbMenu.Ensamblado = this.Tag.ToString();
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();
            PermisosCRM();
            //CargarCumpleanos();

        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManClienteMayoristaEdit objManClientel = new frmManClienteMayoristaEdit();
                objManClientel.lstCliente = mLista;
                objManClientel.pOperacion = frmManClienteMayoristaEdit.Operacion.Nuevo;
                objManClientel.IdCliente = 0;
                objManClientel.StartPosition = FormStartPosition.CenterParent;
                objManClientel.ShowDialog();
                CargarBusqueda();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ClienteBE objE_Clientel = new ClienteBE();
                        objE_Clientel.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());
                        objE_Clientel.Usuario = Parametros.strUsuarioLogin;
                        objE_Clientel.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Clientel.IdEmpresa = Parametros.intEmpresaId;

                        ClienteBL objBL_Cliente = new ClienteBL();
                        objBL_Cliente.Elimina(objE_Clientel);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarBusqueda();
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

        private void tlbMenu_RefreshClick()
        {
            CargarBusqueda();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvCliente.RowCount > 0)
                {
                    List<ReporteClienteListaGeneralBE> lstReporte = null;
                    lstReporte = new ReporteClienteListaGeneralBL().ListadoGeneral(Parametros.intEmpresaId);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoAlmacen = new RptVistaReportes();
                            objRptMovimientoAlmacen.VerRptClienteGeneral(lstReporte);
                            objRptMovimientoAlmacen.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCliente_EditValueChanged(object sender, EventArgs e)
        {
            if (Parametros.bBusquedaTimer)
            {
                timer1.Enabled = true;
                Segundos = 0;
            }
            else
            {
                if (txtCliente.Text.ToString().Length > 4)
                {
                    if (char.IsNumber(Convert.ToChar(txtCliente.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
                        intTipoBusqueda = 1;
                    else
                        intTipoBusqueda = 2;

                    CargarBusqueda();
                }
            }


            //CargarBusqueda();
        }

        private void informeporvendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepClienteMayoristaVendedor objReporte = new frmRepClienteMayoristaVendedor();
            objReporte.Show();
        }

        private void vercumpleanostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConClienteCumpleanos objReporte = new frmConClienteCumpleanos();
            objReporte.StartPosition = FormStartPosition.CenterScreen;
            objReporte.Show();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        private void agendatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvCliente.RowCount > 0)
            {
                ClienteBE objCliente = new ClienteBE();
                objCliente.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMayoristaAgendaEdit objManClienteEdit = new frmManClienteMayoristaAgendaEdit();
                objManClienteEdit.pOperacion = frmManClienteMayoristaAgendaEdit.Operacion.Modificar;
                objManClienteEdit.IdCliente = objCliente.IdCliente;
                objManClienteEdit.StartPosition = FormStartPosition.CenterParent;
                objManClienteEdit.ShowDialog();

                CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void seguimientoclientetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvCliente.RowCount > 0)
            {
                //ClienteBE objCliente = new ClienteBE();
                //objCliente.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());

                frmConSeguimientoCliente objManClienteEdit = new frmConSeguimientoCliente();
                //objManClienteEdit.pOperacion = frmManClienteMayoristaAgendaEdit.Operacion.Modificar;
                //objManClienteEdit.IdCliente = objCliente.IdCliente;
                objManClienteEdit.StartPosition = FormStartPosition.CenterParent;
                objManClienteEdit.Show();

                //CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void frmManClienteMayorista_Shown(object sender, EventArgs e)
        {
            CargarCumpleanos();
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            gcCliente.DataSource = new ClienteBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text, pagina, registros,0);
        }

        private void CargarBusqueda()
        {
            gcCliente.DataSource = new ClienteBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text, intPaginaPrimero, intRegistrosPorPagina,0);
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void CargarCumpleanos()
        {
            int Cumpleanio = 0;
            mListaClienteCumpleanos = new ReporteClienteCumpleanosBL().Listado(DateTime.Now, DateTime.Now, 87);
            if (mListaClienteCumpleanos != null)
            {
                Cumpleanio = mListaClienteCumpleanos.Count();
                //if (Cumpleanio==1)
                //    XtraMessageBox.Show("HOY TENEMOS " + Cumpleanio + " CUMPLEAÑO", "**CUMPLEAÑO**", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //else
                //    XtraMessageBox.Show("HOY TENEMOS " + Cumpleanio + " CUMPLEAÑOS", "**CUMPLEAÑO**", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (Cumpleanio > 0)
                {
                    frmConClienteCumpleanos objReporte = new frmConClienteCumpleanos();
                    objReporte.StartPosition = FormStartPosition.CenterScreen;
                    objReporte.Show();
                }
                

            }
            
            //gcClienteCumpleanos.DataSource = mListaClienteCumpleanos;
        }

        public void InicializarModificar()
        {
            if (gvCliente.RowCount > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                if (Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "dhuaman")
                {
                    objManClientelEdit.cboRuta.Enabled = true;
                    objManClientelEdit.cboVendedor.Enabled = true;
                    objManClientelEdit.btnGrabar.Enabled = true;
                }
                else
                {
                    objManClientelEdit.cboRuta.Enabled = false;
                    objManClientelEdit.cboVendedor.Enabled = false;
                    objManClientelEdit.btnGrabar.Enabled = true;
                }
               
                objManClientelEdit.ShowDialog();

                CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        public void InicializarConsultar()
        {
            if (gvCliente.RowCount > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.btnGrabar.Enabled = false;
                objManClientelEdit.ShowDialog();

                CargarBusqueda();
            }
            
        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new ClienteBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text,0);
            return intRowCount;
        }


        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarConsultar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvCliente.GetFocusedRowCellValue("IdCliente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void exportarcelulartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCelulares_Mayorista_" + DateTime.Today.ToString("dd-MM-yy");
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;

                #region "Generar Archivo"

                // New files
                FileInfo newFile = new FileInfo(f.SelectedPath + @"\" + _fileName + ".xlsx");//
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(f.SelectedPath + @"\" + _fileName + ".xlsx");
                }

                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Periodo" + Parametros.intPeriodo);

                    ////Add the headers Empresa
                    worksheet.Cells["A1:B1"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["A1"].Value = "Panorama Distribuidores S.A.";

                    ////Add the headers
                    worksheet.Cells["A2:B2"].Merge = true;
                    worksheet.Cells["A2"].Style.Font.Bold = true;
                    worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.Cells["A2"].Style.Font.Size = 18;

                    worksheet.Cells["A2"].Value = "Reporte de Celulares - " + Parametros.intPeriodo;
                    worksheet.Cells["A2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A2:B2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Dashed;

                    ////Add the headers Columns
                    worksheet.Cells["A3"].Value = "Cliente";
                    worksheet.Cells["B3"].Value = "Celular";
                    worksheet.Cells["A3:B3"].Style.Font.Bold = true;
                    //worksheet.Cells["A4:B3"].AutoFilter = true;


                    List<ClienteBE> mlistadoReporte = new List<ClienteBE>();
                    mlistadoReporte = new ClienteBL().ListaCelulares(Parametros.intTipClienteMayorista);

                    int Row = 4;
                    int TotRow = 4;
                    TotRow = TotRow - Row + 1;
                    prgFactura.Visible = true;//add
                    prgFactura.Properties.Step = 1;
                    prgFactura.Properties.Maximum = TotRow;
                    prgFactura.Properties.Minimum = 0;

                    foreach (var item in mlistadoReporte)
                    {
                        //Formato
                        //worksheet.Cells["A" + Row].Style.Numberformat.Format = "dd-mmm-yy";
                        //worksheet.Cells["B" + Row + ":G" + Row].Style.Numberformat.Format = "###,###.##";

                        //worksheet.Cells["A" + Row].Value = item.DescCliente.Replace("\n","").Replace("\r","");
                        //worksheet.Cells["A" + Row].Value = item.DescCliente
                        worksheet.Cells["A" + Row].Value = item.DescCliente;
                        worksheet.Cells["B" + Row].Value = item.Telefonos;

                        prgFactura.PerformStep();
                        prgFactura.Update();

                        Row++;
                    }

                    //worksheet.Cells["B4:I4"].AutoFitColumns();
                    //worksheet.Cells["A5"].AutoFitColumns();

                    // set some document properties
                    package.Workbook.Properties.Title = "Reportes";
                    package.Workbook.Properties.Author = "Eder Rojas";
                    package.Workbook.Properties.Comments = "Realizado en Panorama Distribuidores";

                    // set some extended property values
                    package.Workbook.Properties.Company = "Panorama Distribuidores S.A.";

                    // set some custom property values
                    package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Eder Rojas");
                    package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "Ederman");
                    // save our new workbook and we are done!
                    package.Save();

                }
                #endregion

                //gvCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

            
        }

        private void PermisosCRM()
        {
            if (Parametros.intPerfilId != Parametros.intPerAdministrador)
            {
                exportarcelulartoolStripMenuItem.Visible = false;
                //mnuContextual.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Segundos = Segundos + 1;

            if (Segundos > 5)
            {
                if (txtCliente.Text.ToString().Length > 4)
                {
                    if (char.IsNumber(Convert.ToChar(txtCliente.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
                        intTipoBusqueda = 1;
                    else
                        intTipoBusqueda = 2;

                    CargarBusqueda();

                    timer1.Enabled = false;
                }
            }

            if (Segundos > 10)
                timer1.Enabled = false;
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}