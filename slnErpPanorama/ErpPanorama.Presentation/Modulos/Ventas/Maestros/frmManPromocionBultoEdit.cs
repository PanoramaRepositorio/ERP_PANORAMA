using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromocionBultoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPromocionBultoDetalle> mListaPromocionBultoDetalleOrigen = new List<CPromocionBultoDetalle>();
        private List<PreventaDetalleBE> lst_PromocionBultoDetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPromocionBulto = 0;

        public int IdPromocionBulto
        {
            get { return _IdPromocionBulto; }
            set { _IdPromocionBulto = value; }
        }

        public PromocionBultoBE pPromocionBultoBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManPromocionBultoEdit()
        {
            InitializeComponent();
        }

        private void frmManPromocionBultoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "PromocionBulto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "PromocionBulto - Modificar";

                cboEmpresa.EditValue = pPromocionBultoBE.IdEmpresa;
                IdPromocionBulto = pPromocionBultoBE.IdPromocionBulto;
                txtDescPromocionBulto.Text = pPromocionBultoBE.DescPromocionBulto;
                cboTipoCliente.EditValue = pPromocionBultoBE.IdTipoCliente;
                cboFormaPago.EditValue = pPromocionBultoBE.IdFormaPago;
                deDesde.EditValue = pPromocionBultoBE.FechaInicio;
                deHasta.EditValue = pPromocionBultoBE.FechaFin;

                if (Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    btnGrabar.Enabled = true;
                }
                else
                {
                    btnGrabar.Enabled = false;
                }
            }

            CargaPromocionBultoDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescPromocionBulto.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del PromocionBulto promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPromocionBultoDetalleOrigen.Count == 0)
                        {
                            gvPromocionBultoDetalle.AddNewRow();
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBulto", movDetalle.oBE.IdPromocion);//IdPromocionBulto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBultoDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionBultoDetalle);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionBultoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaPromocionBultoDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPromocionBultoDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPromocionBultoDetalle.AddNewRow();
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBulto", movDetalle.oBE.IdPromocion);//IdPromocionBulto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBultoDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionBultoDetalle);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionBultoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaPromocionBultoDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdPromocionBulto"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdPromocionBultoDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvPromocionBultoDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPromocionBultoDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPromocionBultoDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPromocionBultoDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPromocionBultoDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPromocionBultoDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "IdPromocionBulto", movDetalle.oBE.IdPromocion);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "IdPromocionBultoDetalle", movDetalle.oBE.IdPromocionDetalle);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPromocionBultoDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvPromocionBultoDetalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvPromocionBultoDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPromocionBultoDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPromocionBultoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPromocionBultoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPromocionBultoDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPromocionBultoDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPromocionBultoDetalle = 0;
                        if (gvPromocionBultoDetalle.GetFocusedRowCellValue("IdPromocionBultoDetalle") != null)
                            IdPromocionBultoDetalle = int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdPromocionBultoDetalle").ToString());
                        int Item = 0;
                        if (gvPromocionBultoDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("Item").ToString());
                        PromocionBultoDetalleBE objBE_PromocionBultoDetalle = new PromocionBultoDetalleBE();
                        objBE_PromocionBultoDetalle.IdPromocionBultoDetalle = IdPromocionBultoDetalle;
                        objBE_PromocionBultoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PromocionBultoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PromocionBultoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PromocionBultoDetalleBL objBL_PromocionBultoDetalle = new PromocionBultoDetalleBL();
                        objBL_PromocionBultoDetalle.Elimina(objBE_PromocionBultoDetalle);
                        gvPromocionBultoDetalle.DeleteRow(gvPromocionBultoDetalle.FocusedRowHandle);
                        gvPromocionBultoDetalle.RefreshData();

                    }
                    else
                    {
                        gvPromocionBultoDetalle.DeleteRow(gvPromocionBultoDetalle.FocusedRowHandle);
                        gvPromocionBultoDetalle.RefreshData();
                    }

                    CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PromocionBultoBL objBL_PromocionBulto = new PromocionBultoBL();
                    PromocionBultoBE objPromocionBulto = new PromocionBultoBE();
                    objPromocionBulto.IdPromocionBulto = IdPromocionBulto;
                    objPromocionBulto.DescPromocionBulto = txtDescPromocionBulto.Text;
                    objPromocionBulto.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocionBulto.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocionBulto.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objPromocionBulto.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    //objPromocionBulto.Total = Convert.ToDecimal(txtTotal.EditValue);
                    //objPromocionBulto.Observacion = txtObservacion.Text.Trim();
                    objPromocionBulto.FlagEstado = true;
                    objPromocionBulto.Usuario = Parametros.strUsuarioLogin;
                    objPromocionBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocionBulto.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    //PromocionBulto Detalle
                    List<PromocionBultoDetalleBE> lstPromocionBultoDetalle = new List<PromocionBultoDetalleBE>();

                    foreach (var item in mListaPromocionBultoDetalleOrigen)
                    {
                        PromocionBultoDetalleBE objE_PromocionBultoDetalle = new PromocionBultoDetalleBE();
                        objE_PromocionBultoDetalle.IdPromocionBulto = item.IdPromocionBulto;
                        objE_PromocionBultoDetalle.IdPromocionBultoDetalle = item.IdPromocionBultoDetalle;
                        objE_PromocionBultoDetalle.IdProducto = item.IdProducto;
                        objE_PromocionBultoDetalle.Descuento = item.Descuento;
                        //objE_PromocionBultoDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_PromocionBultoDetalle.NombreProducto = item.NombreProducto;
                        //objE_PromocionBultoDetalle.Abreviatura = item.Abreviatura;
                        //objE_PromocionBultoDetalle.Cantidad = item.Cantidad;
                        //objE_PromocionBultoDetalle.Precio = item.Precio;
                        objE_PromocionBultoDetalle.FlagEstado = true;
                        objE_PromocionBultoDetalle.TipoOper = item.TipoOper;
                        objE_PromocionBultoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionBultoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstPromocionBultoDetalle.Add(objE_PromocionBultoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_PromocionBulto.Inserta(objPromocionBulto, lstPromocionBultoDetalle);
                    }
                    else
                    {
                        objBL_PromocionBulto.Actualiza(objPromocionBulto, lstPromocionBultoDetalle);
                    }

                    Cursor = Cursors.Default;

                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            //try
            //{

            //    //decimal deValorVenta = 0;
            //    //decimal deTotal = 0;

            //    decimal CantidadTotal = 0;
            //    decimal CantidadVentaTotal = 0;

            //    if (mListaPromocionBultoDetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaPromocionBultoDetalleOrigen)
            //        {
            //            //deValorVenta = item.Precio;
            //            //deTotal = deTotal + deValorVenta;

            //            CantidadTotal = CantidadTotal + item.Cantidad;
            //            CantidadVentaTotal += item.CantidadVenta;

            //        }

            //        //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
            //        txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
            //        txtTotalVenta.EditValue = Math.Round(CantidadVentaTotal, 2);

            //    }
            //    else
            //    {
            //        txtTotalCantidad.EditValue = 0;
            //        txtTotalVenta.EditValue = 0;
            //    }

            //    lblTotalRegistros.Text = mListaPromocionBultoDetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaPromocionBultoDetalle()
        {
            List<PromocionBultoDetalleBE> lstTmpPromocionBultoDetalle = null;
            lstTmpPromocionBultoDetalle = new PromocionBultoDetalleBL().ListaTodosActivo(IdPromocionBulto);

            foreach (PromocionBultoDetalleBE item in lstTmpPromocionBultoDetalle)
            {
                CPromocionBultoDetalle objE_PromocionBultoDetalle = new CPromocionBultoDetalle();
                objE_PromocionBultoDetalle.IdPromocionBulto = item.IdPromocionBulto;
                objE_PromocionBultoDetalle.IdPromocionBultoDetalle = item.IdPromocionBultoDetalle;
                objE_PromocionBultoDetalle.IdProducto = item.IdProducto;
                objE_PromocionBultoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PromocionBultoDetalle.NombreProducto = item.NombreProducto;
                objE_PromocionBultoDetalle.Abreviatura = item.Abreviatura;
                objE_PromocionBultoDetalle.Descuento = item.Descuento;
                objE_PromocionBultoDetalle.Fecha = item.Fecha;
                //objE_PromocionBultoDetalle.Usuario = item.Usuario;
                //objE_PromocionBultoDetalle.Maquina = item.Maquina;
                //objE_PromocionBultoDetalle.FechaRegistro = item.FechaRegistro;
                //objE_PromocionBultoDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                //objE_PromocionBultoDetalle.Precio = item.Precio;
                objE_PromocionBultoDetalle.TipoOper = item.TipoOper;
                mListaPromocionBultoDetalleOrigen.Add(objE_PromocionBultoDetalle);
            }

            bsListado.DataSource = mListaPromocionBultoDetalleOrigen;
            gcPromocionBultoDetalle.DataSource = bsListado;
            gcPromocionBultoDetalle.RefreshDataSource();

            lblTotalRegistros.Text = mListaPromocionBultoDetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescPromocionBulto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del PromocionBulto.\n";
                flag = true;
            }

            if (mListaPromocionBultoDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el PromocionBulto, mientra no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        public class CPromocionBultoDetalle
        {
            public Int32 IdPromocionBulto { get; set; }
            public Int32 IdPromocionBultoDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Decimal Descuento { get; set; }
            //public Int32 Cantidad { get; set; }
            //public Int32 CantidadVenta { get; set; }
            //public Int32 Diferencia { get; set; }
            //public Decimal Precio { get; set; }
            public Int32 TipoOper { get; set; }

            public CPromocionBultoDetalle()
            {

            }
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string _file_excel = "";
            //OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            //objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            //if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    _file_excel = objOpenFileDialog.FileName;
            //    ImportarExcel(_file_excel);
            //    //Cargar();
            //}
        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPromocionBultoDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionBultoDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void ImportarExcel(string filename)
        {
            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de PromocionBulto
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    decimal Descuento = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocionBultoDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvPromocionBultoDetalle.AddNewRow();
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBultoDetalle", 0);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Descuento", Descuento);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                        }



                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PromocionBultoDetalle = new PreventaDetalleBE();
                        ObjE_PromocionBultoDetalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_PromocionBultoDetalle.Cantidad = Cantidad;
                        lst_PromocionBultoDetalleMsg.Add(ObjE_PromocionBultoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocionBultoDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_PromocionBultoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PromocionBultoDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ImportarExcelHangTag(string filename)
        {
            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de PromocionBulto
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    decimal Descuento = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocionBultoDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvPromocionBultoDetalle.AddNewRow();
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdPromocionBultoDetalle", 0);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Descuento", Descuento);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvPromocionBultoDetalle.SetRowCellValue(gvPromocionBultoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PromocionBultoDetalle = new PreventaDetalleBE();
                        ObjE_PromocionBultoDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_PromocionBultoDetalle.Cantidad = Cantidad;
                        lst_PromocionBultoDetalleMsg.Add(ObjE_PromocionBultoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocionBultoDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_PromocionBultoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PromocionBultoDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importarporcodigotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }

        private void importarporhangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcelHangTag(_file_excel);
                //Cargar();
            }
        }

        private void gvPromocionBultoDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvPromocionBultoDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvPromocionBultoDetalle.GetDataRow(e.FocusedRowHandle);
                int IdProducto = 0;
                IdProducto = int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                //IdProducto = int.Parse(dr["IdProducto"].ToString());

                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }

        private void gvPromocionBultoDetalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvPromocionBultoDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvPromocionBultoDetalle.GetDataRow(e.RowHandle);
                int IdProducto = 0;

                IdProducto = int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                //IdProducto = int.Parse(dr["IdProducto"].ToString());


                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }

        private void CargarIdProducto()
        {

            //dt = FuncionBase.ToDataTable(mListaPromocionBultoDetalleOrigen);//new PromocionBultoDetalleBL().ListaTodosActivo(IdPromocionBulto));
            //gcPromocionBultoDetalle.DataSource = dt;

            //if (gvPromocionBultoDetalle.RowCount > 0)
            //{
            //    ProductoBE objE_Producto = null;
            //    int IdProducto = 0;
            //    IdProducto = int.Parse(gvPromocionBultoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

            //    objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

            //    if (objE_Producto.Imagen != null)
            //    {
            //        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
            //    }
            //    else
            //    { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

            //    //txtProducto.SelectAll();
            //    //txtProducto.Focus();
            //}
        }


    }
}