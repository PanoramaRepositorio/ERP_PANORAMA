using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.Presentation.Utils;
using System.Threading.Tasks;
using ErpPanorama.Presentation.Funciones;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.BusinessLogic;
using System.Security.Principal;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromo_Descuento_Por_VolumenEdit : DevExpress.XtraEditors.XtraForm
    {
       

        public List<CPromocionVolumenDetalle> mListaPromocionVolumenDetalleOrigen = new List<CPromocionVolumenDetalle>();
        private List<PreventaDetalleBE> lst_PromocionVolumenDetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPromocionVolumen = 0;

        public int IdPromocionVolumen
        {
            get { return _IdPromocionVolumen; }
            set { _IdPromocionVolumen = value; }
        }
        public PromocionVolumenBE pPromocionVolumenBE { get; set; }

        public Operacion pOperacion;
        public frmManPromo_Descuento_Por_VolumenEdit()
        {
            InitializeComponent();
            gvPromocionVolumenDetalle.CellValueChanged += gvPromocionVolumenDetalle_CellValueChanged;

            txtunidades1amas.TextChanged += txtunidades1amas_TextChanged;
            txtunidades1.TextChanged += txtunidades1_TextChanged;
            //txtunidades1amas.Click += txtunidades1amas_Click;
            //txtunidades1.Click += txtunidades1_Click;


        }


        public void validarpermisos()
        {

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "PromocionVolumen - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "PromocionVolumen  - Modificar";

                //cboEmpresa.EditValue = pPromocionVolumenBE.IdEmpresa;
                IdPromocionVolumen = pPromocionVolumenBE.IdPromocionVolumen;
                txtDescPromocionVolumen.Text = pPromocionVolumenBE.DescPromocionVolumen;
                //cboTipoCliente.EditValue = pPromocionVolumenBE.IdTipoCliente;
                //cboFormaPago.EditValue = pPromocionVolumenBE.IdFormaPago;
                //cboTienda.EditValue = pPromocionVolumenBE.IdTienda;
                deDesde.EditValue = pPromocionVolumenBE.FechaInicio;
                deHasta.EditValue = pPromocionVolumenBE.FechaFin;
                chkContado.Checked = pPromocionVolumenBE.FlagContado;
                chkCfabricacion.Checked = pPromocionVolumenBE.FlagCFrabricacion;
                chkFlagAplicaCombinacion.Checked = pPromocionVolumenBE.FlagAplicaCombinacion;
                chkFlagAplicaxCodigo.Checked = pPromocionVolumenBE.FlagAplicaxCodigo;
                chkContraentrega.Checked = pPromocionVolumenBE.FlagContraentrega;
                //chkCopagan.Checked = pPromocionVolumenBE.FlagCopagan;
                //chkObsequio.Checked = pPromocionVolumenBE.FlagObsequio;
                //chkAsaf.Checked = pPromocionVolumenBE.FlagAsaf;
                chkMayorista.Checked = pPromocionVolumenBE.FlagClienteMayorista;
                chkMinorista.Checked = pPromocionVolumenBE.FlagClienteFinal;
                //chkWeb.Checked = pPromocionVolumenBE.FlagWeb;
                chkUcayali.Checked = pPromocionVolumenBE.FlagUcayali;
                chkAndahuaylas.Checked = pPromocionVolumenBE.FlagAndahuaylas;
                chkPrescott.Checked = pPromocionVolumenBE.FlagPrescott;
                //chkAviacion.Checked = pPromocionVolumenBE.FlagAviacion;
                //chkMegaplaza.Checked = pPromocionVolumenBE.FlagMegaplaza;
                deDesdeImpresion.EditValue = pPromocionVolumenBE.FechaInicioImpresion;
                deHastaImpresion.EditValue = pPromocionVolumenBE.FechaFinImpresion;
                //cboTipoVenta.EditValue = pPromocionVolumenBE.IdTipoVenta;
                chkAviacion2.Checked = pPromocionVolumenBE.FlagAviacion2;
                chkSanMiguel.Checked = pPromocionVolumenBE.FlagSanMiguel;
            }

            if (Parametros.intPerfilId == Parametros.intPerAdministrador
                  || Parametros.intPerfilId == Parametros.intPerAsistenteCompras
                  || Parametros.intPerfilId == Parametros.intPerAnalistaProducto)
            {
                //    || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral                     || Parametros.intPerfilId == Parametros.intPerAuxiliarVisual 
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
                elminartodotoolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
                importartoolStripMenuItem.Visible = false;
                nuevoToolStripMenuItem.Visible = false;
                modificarprecioToolStripMenuItem.Visible = false;
            }
        }

        public void recuperarcontroles()
        {
            object descuentoValue = gvPromocionVolumenDetalle.GetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Descuento");
            if (descuentoValue != null )
            {
                txtDscto.Text = descuentoValue.ToString();
            }
            else
            {
                txtDscto.Text = "";
            }

            object MontoUniXamas = gvPromocionVolumenDetalle.GetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "MontoUniXamas");

            if (MontoUniXamas == null || (MontoUniXamas is decimal && (decimal)MontoUniXamas == 0))
            {
                txtunidades1amas.Text = "";
                
            }
            else
            {
                txtunidades1amas.Text = MontoUniXamas.ToString();
            }

            object MontoSoloXUni = gvPromocionVolumenDetalle.GetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "MontoSoloXUni");

            if (MontoSoloXUni == null || (MontoSoloXUni is decimal && (decimal)MontoSoloXUni == 0))
            {
                
                txtunidades1.Text = "";
            }
            else
            {
                txtunidades1.Text = MontoSoloXUni.ToString();
            }
        }

        private void frmManPromo_Descuento_Por_VolumenEdit_Load(object sender, EventArgs e)
        {
            validarpermisos();
            BloquearAccesoPorPerfil();
            CargaPromocionTemporalDetalle();
            gvPromocionVolumenDetalle.CellValueChanged += gvPromocionVolumenDetalle_CellValueChanged;
            recuperarcontroles();


        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescPromocionVolumen.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del Promocion Volumen.\n";
                flag = true;
            }

            if (mListaPromocionVolumenDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Promocion Volumen '" + txtDescPromocionVolumen.Text.Trim().ToString() + "', mientra no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PromocionVolumenBL objBL_PromocionVolumen = new PromocionVolumenBL();
                    PromocionVolumenBE objPromocionVolumen = new PromocionVolumenBE();
                    objPromocionVolumen.IdPromocionVolumen = IdPromocionVolumen;
                    objPromocionVolumen.DescPromocionVolumen = txtDescPromocionVolumen.Text;
                    objPromocionVolumen.IdTipoCliente = 86;
                    objPromocionVolumen.IdFormaPago = 61;
                    objPromocionVolumen.IdTienda = 1;
                    objPromocionVolumen.IdTipoVenta = 0;
                    objPromocionVolumen.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objPromocionVolumen.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    objPromocionVolumen.FlagContado = chkContado.Checked;
                    objPromocionVolumen.FlagCFrabricacion = chkCfabricacion.Checked;
                    objPromocionVolumen.FlagAplicaCombinacion = chkFlagAplicaCombinacion.Checked;
                    objPromocionVolumen.FlagAplicaxCodigo = chkFlagAplicaxCodigo.Checked;
                    objPromocionVolumen.FlagContraentrega = chkContraentrega.Checked;
                    //objPromocionTemporal.FlagCopagan = chkCopagan.Checked;
                    //objPromocionTemporal.FlagObsequio = chkObsequio.Checked;
                    //objPromocionTemporal.FlagAsaf = chkAsaf.Checked;
                    objPromocionVolumen.FlagClienteMayorista = chkMayorista.Checked;
                    objPromocionVolumen.FlagClienteFinal = chkMinorista.Checked;
                    //objPromocionTemporal.FlagWeb = chkWeb.Checked;
                    objPromocionVolumen.FlagUcayali = chkUcayali.Checked;
                    objPromocionVolumen.FlagAndahuaylas = chkAndahuaylas.Checked;
                    objPromocionVolumen.FlagPrescott = chkPrescott.Checked;
                    //objPromocionTemporal.FlagAviacion = chkAviacion.Checked;
                    //objPromocionTemporal.FlagMegaplaza = chkMegaplaza.Checked;
                    objPromocionVolumen.FlagAviacion2 = chkAviacion2.Checked;
                    objPromocionVolumen.FlagSanMiguel = chkSanMiguel.Checked;
                    objPromocionVolumen.FechaInicioImpresion = Convert.ToDateTime(deDesdeImpresion.DateTime);
                    objPromocionVolumen.FechaFinImpresion = Convert.ToDateTime(deHastaImpresion.DateTime);
                    objPromocionVolumen.FlagEstado = true;
                    objPromocionVolumen.Usuario = Parametros.strUsuarioLogin;
                    objPromocionVolumen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocionVolumen.IdEmpresa = Parametros.intEmpresaId;//Convert.ToInt32(cboEmpresa.EditValue);

                    //PromocionTemporal Detalle
                    List<PromocionVolumenDetalleBE> lstPromocionTemporalDetalle = new List<PromocionVolumenDetalleBE>();

                    


                    foreach (var item in mListaPromocionVolumenDetalleOrigen)
                    {
                        PromocionVolumenDetalleBE objE_PromocionTemporalDetalle = new PromocionVolumenDetalleBE();
                        objE_PromocionTemporalDetalle.IdPromocionVolumen = item.IdPromocionVolumen;
                        objE_PromocionTemporalDetalle.IdPromocionVolumenDetalle = item.IdPromocionVolumenDetalle;
                        objE_PromocionTemporalDetalle.IdProducto = item.IdProducto;
                        objE_PromocionTemporalDetalle.Descuento = item.Descuento;
                        objE_PromocionTemporalDetalle.MontoUniXamas = item.MontoUniXamas;
                        objE_PromocionTemporalDetalle.MontoSoloXUni = item.MontoSoloXUni;
                        //objE_PromocionTemporalDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_PromocionTemporalDetalle.NombreProducto = item.NombreProducto;
                        //objE_PromocionTemporalDetalle.Abreviatura = item.Abreviatura;
                        //objE_PromocionTemporalDetalle.Cantidad = item.Cantidad;
                        //objE_PromocionTemporalDetalle.Precio = item.Precio;
                        objE_PromocionTemporalDetalle.FlagEstado = true;
                        objE_PromocionTemporalDetalle.TipoOper = item.TipoOper;
                        objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstPromocionTemporalDetalle.Add(objE_PromocionTemporalDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_PromocionVolumen.Inserta(objPromocionVolumen, lstPromocionTemporalDetalle);
                    }
                    else
                    {
                        objBL_PromocionVolumen.Actualiza(objPromocionVolumen, lstPromocionTemporalDetalle);
                    }

                    Cursor = Cursors.Default;

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearAccesoPorPerfil()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerAsistenteCompras || Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.intPerfilId == Parametros.intPerAuxiliarVisual || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral)
            {
                mnuContextual.Visible = true;
                btnGrabar.Visible = true;
            }
            else
            {
                mnuContextual.Visible = false;
                btnGrabar.Visible = false;
            }


        }

        public class CPromocionVolumenDetalle
        {
            public Int32 IdPromocionVolumen { get; set; }
            public Int32 IdPromocionVolumenDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal MontoSoloXUni { get; set; }
            public Decimal MontoUniXamas { get; set; }
            public Decimal DescuentoActual { get; set; }
            //public Int32 Cantidad { get; set; }
            //public Int32 CantidadVenta { get; set; }
            //public Int32 Diferencia { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Precio2 { get; set; }

            public Int32 CantidadCompra { get; set; }
            public Int32 AlmacenCentral { get; set; }
            public Int32 AlmacenTienda { get; set; }
            public Int32 AlmacenAndahuaylas { get; set; }
            public Int32 AlmacenPrescott { get; set; }
            public Int32 AlmacenAviacion { get; set; }
            public Int32 AlmacenAviacion2 { get; set; }
            public Int32 AlmacenSanMiguel { get; set; }
            public Int32 AlmacenMegaPlaza { get; set; }
            public Int32 StockTotal { get; set; }

            public String DescLineaProducto { get; set; }
            public String DescSubLineaProducto { get; set; }
            public Boolean FlagNacional { get; set; }

            public Int32 TipoOper { get; set; }

            public CPromocionVolumenDetalle()
            {

            }
        }

        private void CargaPromocionTemporalDetalle()
        {
            List<PromocionVolumenDetalleBE> lstTmpPromocionTemporalDetalle = null;
            lstTmpPromocionTemporalDetalle = new PromocionVolumenBL().ListaTodosActivo(IdPromocionVolumen);

            foreach (PromocionVolumenDetalleBE item in lstTmpPromocionTemporalDetalle)
            {
                CPromocionVolumenDetalle objE_PromocionTemporalDetalle = new CPromocionVolumenDetalle();
                objE_PromocionTemporalDetalle.IdPromocionVolumen = item.IdPromocionVolumen;
                objE_PromocionTemporalDetalle.IdPromocionVolumenDetalle = item.IdPromocionVolumenDetalle;
                objE_PromocionTemporalDetalle.IdProducto = item.IdProducto;
                objE_PromocionTemporalDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PromocionTemporalDetalle.NombreProducto = item.NombreProducto;
                //objE_PromocionTemporalDetalle.Abreviatura = item.Abreviatura;
                objE_PromocionTemporalDetalle.Descuento = item.Descuento;
                objE_PromocionTemporalDetalle.MontoUniXamas = item.MontoUniXamas;
                objE_PromocionTemporalDetalle.MontoSoloXUni = item.MontoSoloXUni;
                objE_PromocionTemporalDetalle.Descuento = item.Descuento;
                objE_PromocionTemporalDetalle.DescuentoActual = item.DescuentoActual;
                //objE_PromocionTemporalDetalle.Fecha = item.Fecha;
                objE_PromocionTemporalDetalle.CantidadCompra = item.CantidadCompra;
                objE_PromocionTemporalDetalle.AlmacenCentral = item.AlmacenCentral;
                objE_PromocionTemporalDetalle.AlmacenTienda = item.AlmacenTienda;
                objE_PromocionTemporalDetalle.AlmacenAndahuaylas = item.AlmacenAndahuaylas;
                objE_PromocionTemporalDetalle.AlmacenPrescott = item.AlmacenPrescott;
                objE_PromocionTemporalDetalle.AlmacenAviacion = item.AlmacenAviacion;
                objE_PromocionTemporalDetalle.AlmacenAviacion2 = item.AlmacenAviacion2;
                objE_PromocionTemporalDetalle.AlmacenMegaPlaza = item.AlmacenMegaPlaza;
                objE_PromocionTemporalDetalle.AlmacenSanMiguel = item.AlmacenSanMiguel;
                objE_PromocionTemporalDetalle.StockTotal = item.AlmacenCentral + item.AlmacenTienda + item.AlmacenAndahuaylas + item.AlmacenPrescott + item.AlmacenAviacion + item.AlmacenMegaPlaza + item.AlmacenAviacion2 + item.AlmacenSanMiguel;
                objE_PromocionTemporalDetalle.DescLineaProducto = item.DescLineaProducto;
                objE_PromocionTemporalDetalle.DescSubLineaProducto = item.DescSubLineaProducto;
                objE_PromocionTemporalDetalle.FlagNacional = item.FlagNacional;
                //objE_PromocionTemporalDetalle.Usuario = item.Usuario;
                //objE_PromocionTemporalDetalle.Maquina = item.Maquina;
                //objE_PromocionTemporalDetalle.FechaRegistro = item.FechaRegistro;
                //objE_PromocionTemporalDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                objE_PromocionTemporalDetalle.Precio = item.Precio;
                objE_PromocionTemporalDetalle.Precio2 = item.Precio2;
                objE_PromocionTemporalDetalle.TipoOper = item.TipoOper;
                mListaPromocionVolumenDetalleOrigen.Add(objE_PromocionTemporalDetalle);
            }

            bsListado.DataSource = mListaPromocionVolumenDetalleOrigen;
            gcPromocionVolumenDetalle.DataSource = bsListado;
            gcPromocionVolumenDetalle.RefreshDataSource();


            //lblTotalRegistros.Text = mListaPromocionTemporalDetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescPromocionVolumen.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del Promocionl temporal promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPromocionVolumenDetalleOrigen.Count == 0)
                        {
                            gvPromocionVolumenDetalle.AddNewRow();
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdPromocionTemporal", movDetalle.oBE.IdPromocion);//IdPromocionTemporal);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionTemporalDetalle);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionVolumenDetalle.UpdateCurrentRow();

                            //CalculaTotales();

                            return;

                        }
                        if (mListaPromocionVolumenDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPromocionVolumenDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPromocionVolumenDetalle.AddNewRow();
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdPromocionTemporal", movDetalle.oBE.IdPromocion);//IdPromocionTemporal);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionTemporalDetalle);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionVolumenDetalle.UpdateCurrentRow();

                            //CalculaTotales();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ImportarExcelHangTag(string filename)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int TotalAgregado = 0;
            int TotalActualizado = 0;

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


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    decimal Descuento = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocionVolumenDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            PromocionVolumenBL objBL_PromocionVolumenDetalle = new PromocionVolumenBL();
                            PromocionVolumenDetalleBE objE_PromocionVolumenDetalle = new PromocionVolumenDetalleBE();

                            objE_PromocionVolumenDetalle.IdPromocionVolumen = IdPromocionVolumen;
                            objE_PromocionVolumenDetalle.IdProducto = objE_Producto.IdProducto;
                            objE_PromocionVolumenDetalle.Descuento = Descuento;
                            objE_PromocionVolumenDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_PromocionVolumenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PromocionVolumenDetalle.FlagEstado = true;
                            objBL_PromocionVolumenDetalle.Actualizadt(objE_PromocionVolumenDetalle);

                            TotalActualizado = TotalActualizado + 1;
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            if (pOperacion == Operacion.Nuevo)
                            {
                                gvPromocionVolumenDetalle.AddNewRow();
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", 0);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "Descuento", Descuento);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Observacion", Observacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                                gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "FlagEstado", true);
                                if (pOperacion == Operacion.Modificar)
                                    gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                else
                                    gvPromocionVolumenDetalle.SetRowCellValue(gvPromocionVolumenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                                TotalAgregado = TotalAgregado + 1;

                            }
                            else
                            {
                                PromocionVolumenBL objBL_PromocionVolumenDetalle = new PromocionVolumenBL();
                                PromocionVolumenDetalleBE objE_PromocionVolumenlDetalle = new PromocionVolumenDetalleBE();

                                objE_PromocionVolumenlDetalle.IdPromocionVolumen = IdPromocionVolumen;
                                objE_PromocionVolumenlDetalle.IdProducto = objE_Producto.IdProducto;
                                objE_PromocionVolumenlDetalle.Descuento = Descuento;
                                objE_PromocionVolumenlDetalle.Usuario = Parametros.strUsuarioLogin;
                                objE_PromocionVolumenlDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_PromocionVolumenlDetalle.FlagEstado = true;
                                objBL_PromocionVolumenDetalle.Insertadt(objE_PromocionVolumenlDetalle);

                                TotalAgregado = TotalAgregado + 1;
                            }


                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PromocionTemporalDetalle = new PreventaDetalleBE();
                        ObjE_PromocionTemporalDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_PromocionTemporalDetalle.Cantidad = Cantidad;
                        lst_PromocionVolumenDetalleMsg.Add(ObjE_PromocionTemporalDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                //lblTotalRegistros.Text = gvPromocionTemporalDetalle.RowCount.ToString() + " Registros";
                //CalculaTotales();

                if (lst_PromocionVolumenDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PromocionVolumenDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                XtraMessageBox.Show("La Importacion se realizó correctamente\n" + TotalActualizado + " registros actualizados.\n" + TotalAgregado + " registros Insertados.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                if (pOperacion == Operacion.Modificar)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPromocionVolumenDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPromocionVolumenDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPromocionVolumenlDetalle = 0;
                        if (gvPromocionVolumenDetalle.GetFocusedRowCellValue("IdPromocionVolumenDetalle") != null)
                            IdPromocionVolumenlDetalle = int.Parse(gvPromocionVolumenDetalle.GetFocusedRowCellValue("IdPromocionVolumenDetalle").ToString());
                        int Item = 0;
                        if (gvPromocionVolumenDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPromocionVolumenDetalle.GetFocusedRowCellValue("Item").ToString());
                        PromocionVolumenDetalleBE objBE_PromocionVolumenDetalle = new PromocionVolumenDetalleBE();
                        objBE_PromocionVolumenDetalle.IdPromocionVolumenDetalle = IdPromocionVolumenlDetalle;
                        objBE_PromocionVolumenDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PromocionVolumenDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PromocionVolumenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PromocionVolumenBL objBL_PromocionTemporalDetalle = new PromocionVolumenBL();
                        objBL_PromocionTemporalDetalle.Eliminadt(objBE_PromocionVolumenDetalle);
                        gvPromocionVolumenDetalle.DeleteRow(gvPromocionVolumenDetalle.FocusedRowHandle);
                        gvPromocionVolumenDetalle.RefreshData();

                    }
                    else
                    {
                        gvPromocionVolumenDetalle.DeleteRow(gvPromocionVolumenDetalle.FocusedRowHandle);
                        gvPromocionVolumenDetalle.RefreshData();
                    }

                    //CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void elminartodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de eliminar todo los registros?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PromocionVolumenDetalleBE ojbE_PromocionDetalle = new PromocionVolumenDetalleBE();
                ojbE_PromocionDetalle.IdPromocionVolumen = IdPromocionVolumen;
                ojbE_PromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                ojbE_PromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                ojbE_PromocionDetalle.IdEmpresa = Parametros.intEmpresaId;


                PromocionVolumenBL ojbBL_PromocionDetalle = new PromocionVolumenBL();
                ojbBL_PromocionDetalle.EliminaTodo(ojbE_PromocionDetalle);

                mListaPromocionVolumenDetalleOrigen = new List<CPromocionVolumenDetalle>();
                CargaPromocionTemporalDetalle();
                gvPromocionVolumenDetalle.RefreshData();

                XtraMessageBox.Show("Registros eliminados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void gvPromocionVolumenDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Descuento")
            {

                if (pOperacion == Operacion.Modificar)
                {
                    if (Convert.ToDecimal(gvPromocionVolumenDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                        gvPromocionVolumenDetalle.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    else
                        gvPromocionVolumenDetalle.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                }

            }
            if (e.Column.FieldName == "Descuento")
            {
                // Obtén el valor de la celda en la columna "Descuento" de la fila actual
                object descuentoValue = gvPromocionVolumenDetalle.GetRowCellValue(e.RowHandle, "Descuento");
                // Verifica si el valor obtenido no es nulo
                if (descuentoValue != null)
                {
                    // Convierte el valor a string y asigna a txtDscto.Text
                    txtDscto.Text = descuentoValue.ToString();
                }
                else
                {
                    // Si el valor es nulo, puedes asignar un valor predeterminado o dejar el txtDscto.Text vacío
                    txtDscto.Text = "";
                }
            }
            if (e.Column.FieldName == "MontoUniXamas")
            {
                // Obtén el valor de la celda en la columna "Descuento" de la fila actual
                object MontoUniXamas = gvPromocionVolumenDetalle.GetRowCellValue(e.RowHandle, "MontoUniXamas");
                // Verifica si el valor obtenido no es nulo
                if (MontoUniXamas != null)
                {
                    // Convierte el valor a string y asigna a txtunidades1amas.Text
                    if (Convert.ToDecimal(MontoUniXamas) == 0)
                    {
                        txtunidades1amas.Text = ""; // Establece el valor en blanco si es 0
                    }
                    else
                    {
                        txtunidades1amas.Text = MontoUniXamas.ToString();
                    }
                }
                else
                {
                    // Si el valor es nulo, puedes asignar un valor predeterminado o dejar el txtDscto.Text vacío
                    txtunidades1amas.Text = "";
                }
            }

            if (e.Column.FieldName == "MontoSoloXUni")
            {
                // Obtén el valor de la celda en la columna "Descuento" de la fila actual
                object MontoSoloXUni = gvPromocionVolumenDetalle.GetRowCellValue(e.RowHandle, "MontoSoloXUni");
                // Verifica si el valor obtenido no es nulo
                if (MontoSoloXUni != null)
                {
                    // Convierte el valor a string y asigna a txtunidades1.Text
                    if (Convert.ToDecimal(MontoSoloXUni) == 0)
                    {
                        txtunidades1.Text = ""; // Establece el valor en blanco si es 0
                    }
                    else
                    {
                        txtunidades1.Text = MontoSoloXUni.ToString();
                    }
                }
                else
                {
                    // Si el valor es nulo, puedes asignar un valor predeterminado o dejar el txtDscto.Text vacío
                    txtunidades1.Text = "";
                }
            }
        }

        private void txtDscto_TextChanged(object sender, EventArgs e)
        {
            // Obtiene el nuevo valor del txtDscto.Text
            string nuevoValor = txtDscto.Text;
            // Guarda el RowHandle de la fila actual antes de la iteración
            int filaActual = gvPromocionVolumenDetalle.FocusedRowHandle;

            // Itera a través de todas las filas en la cuadrícula y actualiza la columna "Descuento"
            for (int i = 0; i < gvPromocionVolumenDetalle.RowCount; i++)
            {
                gvPromocionVolumenDetalle.SetRowCellValue(i, "Descuento", nuevoValor);
            }

            if (pOperacion == Operacion.Modificar)
            {
                if (Convert.ToDecimal(gvPromocionVolumenDetalle.GetRowCellValue(filaActual, "TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                    gvPromocionVolumenDetalle.SetRowCellValue(filaActual, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                else
                    gvPromocionVolumenDetalle.SetRowCellValue(filaActual, "TipoOper", Convert.ToInt32(Operacion.Modificar));
            }
        }


        private void txtunidades1amas_TextChanged(object sender, EventArgs e)
        {

            string nuevoValor2 = txtunidades1.Text;
            if (txtunidades1amas.Enabled = string.IsNullOrEmpty(nuevoValor2))
            {
                txtunidades1.Enabled = false;

                if (txtunidades1amas.Text == "")
                {
                    txtunidades1.Enabled = true;
                    txtunidades1amas.Enabled = false;
                }
            }
            string nuevoValor1 = txtunidades1amas.Text;

            // Itera a través de todas las filas en la cuadrícula y actualiza la columna "MontoSoloXUni"
            for (int i = 0; i < gvPromocionVolumenDetalle.RowCount; i++)
            {
                gvPromocionVolumenDetalle.SetRowCellValue(i, "MontoUniXamas", nuevoValor1);
            }
        }

        private void txtunidades1_TextChanged(object sender, EventArgs e)
        {

            string nuevoValor1 = txtunidades1amas.Text;
            // Habilitar el control txtunidades1 solo si txtunidades1amas está vacío
            if (txtunidades1.Enabled = string.IsNullOrEmpty(nuevoValor1))
            {
                txtunidades1amas.Enabled = false;
                if (txtunidades1.Text == "")
                {
                    txtunidades1amas.Enabled = true;
                    txtunidades1.Enabled = false;
                }
            }
            string nuevoValor2 = txtunidades1.Text;
            // Itera a través de todas las filas en la cuadrícula y actualiza la columna "MontoUniXamas"
            for (int i = 0; i < gvPromocionVolumenDetalle.RowCount; i++)
            {
                gvPromocionVolumenDetalle.SetRowCellValue(i, "MontoSoloXUni", nuevoValor2);
            }
        }
    }

}
