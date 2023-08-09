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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegContratoFabricacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDis_ContratoFabricacionDetalle> mListaDis_ContratoFabricacionDetalleOrigen = new List<CDis_ContratoFabricacionDetalle>();
        private List<Dis_ContratoFabricacionDetalleBE> lst_Dis_ContratoFabricacionDetalleMsg = new List<Dis_ContratoFabricacionDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        private int? IdDis_ProyectoServicio;
        private int IdCliente = 0;

        int _IdDis_ContratoFabricacion = 0;

        public int IdDis_ContratoFabricacion
        {
            get { return _IdDis_ContratoFabricacion; }
            set { _IdDis_ContratoFabricacion = value; }
        }

        public Dis_ContratoFabricacionBE pDis_ContratoFabricacionBE { get; set; }

        public Operacion pOperacion;

        public ParametroBE pParametroBE;

        #endregion

        #region "Eventos"

        public frmRegContratoFabricacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegContratoFabricacionEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboVendedor2, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor2.EditValue = 0;


            if (pOperacion == Operacion.Nuevo)
            {
                ObtenerCorrelativo();

                this.Text = "Contrato de Fabricación - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Contrato de Fabricación - Modificar";

                Dis_ContratoFabricacionBE objE_Contrato = new Dis_ContratoFabricacionBE();
                objE_Contrato = new Dis_ContratoFabricacionBL().Selecciona(IdDis_ContratoFabricacion);

                IdDis_ContratoFabricacion = objE_Contrato.IdDis_ContratoFabricacion;
                txtNumero.EditValue = objE_Contrato.Numero;
                deFecha.EditValue = objE_Contrato.Fecha;
                txtNumeroProyecto.Text = objE_Contrato.NumeroProyecto;
                IdCliente = objE_Contrato.IdCliente;
                txtNumeroDocumento.Text = objE_Contrato.NumeroDocumento;
                txtDescCliente.Text = objE_Contrato.DescCliente;
                txtDireccion.Text = objE_Contrato.Direccion;
                txtReferencia.Text = objE_Contrato.Referencia;
                txtEmail.Text = objE_Contrato.Email;
                cboVendedor.EditValue = objE_Contrato.IdVendedor;
                cboVendedor2.EditValue = objE_Contrato.IdVendedor2;
                deFechaEntrega.EditValue = objE_Contrato.FechaEntrega;
                deFechaProduccion.EditValue = objE_Contrato.FechaProduccion;
                IdDis_ProyectoServicio = objE_Contrato.IdProyecto;
                txtPiso.EditValue = objE_Contrato.Piso;
                txtRutaArchivo.Text = objE_Contrato.RutaArchivo;
                lblFechaAtendido.Text = objE_Contrato.FechaAtencion.ToString();
                lblUsuarioAtendido.Text = objE_Contrato.UsuarioAtencion;

                txtNumeroProyecto.Properties.ReadOnly = true;
                txtRutaArchivo.Properties.ReadOnly = true;
                txtNumeroContrato.Properties.ReadOnly = true;
                BloquearCabecera();

                if(objE_Contrato.FlagCerrado)
                {
                    BloquearTodo();
                }
            }

            deFechaEntrega.Properties.ReadOnly = true;
            if (Parametros.intPerfilId==Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerSupervisorDiseno|| Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno)
            {
                deFechaEntrega.Properties.ReadOnly = false;
            }
            CargarRutaArchivo();
            CargaDis_ContratoFabricacionDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtDescDis_ContratoFabricacion.Text.Trim() == "")
                //{
                //    XtraMessageBox.Show("Ingresar el nombre del Dis_ContratoFabricacion promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                frmRegContratoFabricacionDetalleEdit movDetalle = new frmRegContratoFabricacionDetalleEdit();
                movDetalle.pOperacion = frmRegContratoFabricacionDetalleEdit.Operacion.Nuevo;
                movDetalle.StartPosition = FormStartPosition.CenterParent;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDis_ContratoFabricacionDetalleOrigen.Count == 0)
                        {
                            gvDis_ContratoFabricacionDetalle.AddNewRow();
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacion", movDetalle.oBE.IdDis_ContratoFabricacion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacionDetalle", movDetalle.oBE.IdDis_ContratoFabricacionDetalle);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Modelo", movDetalle.oBE.Modelo);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Material", movDetalle.oBE.Material);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Imagen", movDetalle.oBE.Imagen);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagModificado", movDetalle.oBE.FlagModificado);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "DiasProduccion", movDetalle.oBE.DiasProduccion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
                        {
                            //var Buscar = mListaDis_ContratoFabricacionDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            gvDis_ContratoFabricacionDetalle.AddNewRow();
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacion", movDetalle.oBE.IdDis_ContratoFabricacion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacionDetalle", movDetalle.oBE.IdDis_ContratoFabricacionDetalle);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Modelo", movDetalle.oBE.Modelo);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Material", movDetalle.oBE.Material);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Imagen", movDetalle.oBE.Imagen);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagModificado", movDetalle.oBE.FlagModificado);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "DiasProduccion", movDetalle.oBE.DiasProduccion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

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
            if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegContratoFabricacionDetalleEdit movDetalle = new frmRegContratoFabricacionDetalleEdit();
                movDetalle.pOperacion = frmRegContratoFabricacionDetalleEdit.Operacion.Modificar;
                movDetalle.IdDis_ContratoFabricacion = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdDis_ContratoFabricacion"));
                movDetalle.IdDis_ContratoFabricacionDetalle = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdDis_ContratoFabricacionDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtModelo.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Modelo").ToString();
                movDetalle.txtMedida.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Medida").ToString();
                movDetalle.txtMaterial.Text = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Material").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Precio"));//mod
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Precio"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.bFlagModificado = Convert.ToBoolean(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("FlagModificado"));
                movDetalle.bFlagObsequio = Convert.ToBoolean(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("FlagObsequio"));
                movDetalle.sObservacion = gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.txtDiasProduccion.EditValue = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("DiasProduccion"));
                movDetalle.Imagen = new FuncionBase().Bytes2Image((byte[])gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Imagen"));

                movDetalle.StartPosition = FormStartPosition.CenterParent;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDis_ContratoFabricacionDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "IdDis_ContratoFabricacion", movDetalle.oBE.IdDis_ContratoFabricacion);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "IdDis_ContratoFabricacionDetalle", movDetalle.oBE.IdDis_ContratoFabricacionDetalle);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Modelo", movDetalle.oBE.Modelo);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Medida", movDetalle.oBE.Medida);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Material", movDetalle.oBE.Material);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Imagen", movDetalle.oBE.Imagen);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "FlagObsequio", movDetalle.oBE.FlagObsequio);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "FlagModificado", movDetalle.oBE.FlagModificado);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "DiasProduccion", movDetalle.oBE.DiasProduccion);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvDis_ContratoFabricacionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdDis_ContratoFabricacionDetalle").ToString()) != 0)
                    {
                        int IdDis_ContratoFabricacionDetalle = 0;
                        if (gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdDis_ContratoFabricacionDetalle") != null)
                            IdDis_ContratoFabricacionDetalle = int.Parse(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("IdDis_ContratoFabricacionDetalle").ToString());
                        int Item = 0;
                        if (gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDis_ContratoFabricacionDetalle.GetFocusedRowCellValue("Item").ToString());
                        Dis_ContratoFabricacionDetalleBE objBE_Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBE();
                        objBE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = IdDis_ContratoFabricacionDetalle;
                        objBE_Dis_ContratoFabricacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_Dis_ContratoFabricacionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_Dis_ContratoFabricacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        Dis_ContratoFabricacionDetalleBL objBL_Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL();
                        objBL_Dis_ContratoFabricacionDetalle.Elimina(objBE_Dis_ContratoFabricacionDetalle);
                        gvDis_ContratoFabricacionDetalle.DeleteRow(gvDis_ContratoFabricacionDetalle.FocusedRowHandle);
                        gvDis_ContratoFabricacionDetalle.RefreshData();

                    }
                    else
                    {
                        gvDis_ContratoFabricacionDetalle.DeleteRow(gvDis_ContratoFabricacionDetalle.FocusedRowHandle);
                        gvDis_ContratoFabricacionDetalle.RefreshData();
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
                    Dis_ContratoFabricacionBL objBL_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBL();
                    Dis_ContratoFabricacionBE objDis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                    objDis_ContratoFabricacion.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                    objDis_ContratoFabricacion.Periodo = Parametros.intPeriodo;
                    objDis_ContratoFabricacion.Numero = txtNumero.Text;
                    objDis_ContratoFabricacion.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDis_ContratoFabricacion.IdCliente = IdCliente;
                    objDis_ContratoFabricacion.NumeroDocumento = txtNumeroDocumento.Text;
                    objDis_ContratoFabricacion.DescCliente = txtDescCliente.Text;
                    objDis_ContratoFabricacion.Direccion = txtDireccion.Text;
                    objDis_ContratoFabricacion.Referencia = txtReferencia.Text;
                    objDis_ContratoFabricacion.Email = txtEmail.Text;
                    objDis_ContratoFabricacion.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDis_ContratoFabricacion.IdVendedor2 = Convert.ToInt32(cboVendedor2.EditValue);
                    objDis_ContratoFabricacion.FechaEntrega = deFechaEntrega.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaEntrega.Text);
                    objDis_ContratoFabricacion.FechaProduccion = deFechaProduccion.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaProduccion.Text);
                    objDis_ContratoFabricacion.IdProyecto = IdDis_ProyectoServicio;
                    objDis_ContratoFabricacion.Piso = Convert.ToInt32(txtPiso.EditValue);
                    objDis_ContratoFabricacion.RutaArchivo = txtRutaArchivo.Text;
                    objDis_ContratoFabricacion.PorcentajeAvance = Convert.ToDecimal(lblCotizacion.Text);
                    objDis_ContratoFabricacion.FlagCerrado = false;
                    objDis_ContratoFabricacion.FlagEstado = true;
                    objDis_ContratoFabricacion.Usuario = Parametros.strUsuarioLogin;
                    objDis_ContratoFabricacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_ContratoFabricacion.IdEmpresa = Parametros.intEmpresaId;

                    //Dis_ContratoFabricacion Detalle
                    List<Dis_ContratoFabricacionDetalleBE> lstDis_ContratoFabricacionDetalle = new List<Dis_ContratoFabricacionDetalleBE>();

                    foreach (var item in mListaDis_ContratoFabricacionDetalleOrigen)
                    {
                        Dis_ContratoFabricacionDetalleBE objE_Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBE();
                        objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacion = item.IdDis_ContratoFabricacion;
                        objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = item.IdDis_ContratoFabricacionDetalle;
                        objE_Dis_ContratoFabricacionDetalle.IdProducto = item.IdProducto;
                        objE_Dis_ContratoFabricacionDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_Dis_ContratoFabricacionDetalle.NombreProducto = item.NombreProducto;
                        objE_Dis_ContratoFabricacionDetalle.Abreviatura = item.Abreviatura;
                        objE_Dis_ContratoFabricacionDetalle.Modelo = item.Modelo;
                        objE_Dis_ContratoFabricacionDetalle.Medida = item.Medida;
                        objE_Dis_ContratoFabricacionDetalle.Material = item.Material;
                        objE_Dis_ContratoFabricacionDetalle.Cantidad = item.Cantidad;
                        objE_Dis_ContratoFabricacionDetalle.Precio = item.Precio;
                        objE_Dis_ContratoFabricacionDetalle.ValorVenta = item.ValorVenta;
                        objE_Dis_ContratoFabricacionDetalle.Imagen = item.Imagen;//new FuncionBase().Image2Bytes(item.Imagen);//new FuncionBase().Bytes2Image((byte[])item.Imagen);
                        objE_Dis_ContratoFabricacionDetalle.FlagObsequio = item.FlagObsequio;
                        objE_Dis_ContratoFabricacionDetalle.FlagModificado = item.FlagModificado;
                        objE_Dis_ContratoFabricacionDetalle.FlagAprobado = item.FlagAprobado;
                        objE_Dis_ContratoFabricacionDetalle.DiasProduccion = item.DiasProduccion;
                        objE_Dis_ContratoFabricacionDetalle.FechaEntrega = item.FechaEntrega;
                        objE_Dis_ContratoFabricacionDetalle.Observacion = item.Observacion;
                        objE_Dis_ContratoFabricacionDetalle.FlagEstado = true;
                        objE_Dis_ContratoFabricacionDetalle.TipoOper = item.TipoOper;
                        lstDis_ContratoFabricacionDetalle.Add(objE_Dis_ContratoFabricacionDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Dis_ContratoFabricacion.Inserta(objDis_ContratoFabricacion, lstDis_ContratoFabricacionDetalle);
                    }
                    else
                    {
                        objBL_Dis_ContratoFabricacion.Actualiza(objDis_ContratoFabricacion, lstDis_ContratoFabricacionDetalle);
                    }

                    Cursor = Cursors.Default;

                    XtraMessageBox.Show("El contrato de fabricación se está realizando para el PISO N° "+ txtPiso.Text +"\n"+ txtDireccion.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Dis_ProyectoServicio
                    Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                    objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProyecto.Text.Trim());
                    if (objE_Dis_ProyectoServicio != null)
                    {
                        if(objE_Dis_ProyectoServicio.FlagCerrado)
                        {
                            XtraMessageBox.Show("El proyecto ya finalizó!, por favor verifcar.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        IdDis_ProyectoServicio = objE_Dis_ProyectoServicio.IdDis_ProyectoServicio;
                        txtNumeroProyecto.Text = objE_Dis_ProyectoServicio.Numero;
                        cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                        cboVendedor2.EditValue = objE_Dis_ProyectoServicio.IdVendedor;
                        //cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                        //txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                        IdCliente = objE_Dis_ProyectoServicio.IdCliente;
                        txtNumeroDocumento.Text = objE_Dis_ProyectoServicio.NumeroDocumento;
                        txtDescCliente.Text = objE_Dis_ProyectoServicio.DescCliente;
                        txtRutaArchivo.Text = objE_Dis_ProyectoServicio.RutaArchivo;
                        txtPiso.EditValue = objE_Dis_ProyectoServicio.Piso;

                        //Selecciona TipoCliente
                        ClienteBE objE_Cliente = null;
                        //objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, objE_Dis_ProyectoServicio.NumeroDocumento);
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));
                        if (objE_Cliente != null)
                        {
                            //IdCliente = objE_Cliente.IdCliente;
                            txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente.DescCliente;
                            txtDireccion.Text = objE_Cliente.Direccion;
                            txtEmail.Text = objE_Cliente.Email;
                            txtReferencia.Text = objE_Cliente.Referencia;

                            //IdTipoCliente = objE_Cliente.IdTipoCliente;
                            //IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                            //txtTipoCliente.Text = objE_Cliente.DescTipoCliente;

                            //if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                            //{
                            //    txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                            //    cboMoneda.EditValue = Parametros.intSoles;
                            //    txtCodMonedaPedido.Text = "S/";
                            //}
                            //else
                            //{
                            //    cboMoneda.EditValue = Parametros.intDolares;
                            //    txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                            //    txtCodMonedaPedido.Text = "US$";
                            //}
                        }
                        BloquearCabecera();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de proyecto no existe, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    //IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    //IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    //if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    //{
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                    txtReferencia.Text = frm.pClienteBE.Referencia;
                    txtEmail.Text = frm.pClienteBE.Email;
                    //cboMoneda.EditValue = Parametros.intSoles;

                    //Calcula Cumpleaños
                    DateTime FechaNac = Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                    int PeriodoNac = FechaNac.Year;
                    int Anios = Parametros.intPeriodo - PeriodoNac;

                    txtRutaArchivo.Text = pParametroBE.Valor + "CONT_" + txtNumero.Text + "_" + txtNumeroDocumento.Text.Trim();
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NumDireccion;
                        //IdTipoCliente = objE_Cliente.IdTipoCliente;
                        //IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;

                        //if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                        //{
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                        txtReferencia.Text = objE_Cliente.Referencia;
                        txtEmail.Text = objE_Cliente.Email;
                        //cboMoneda.EditValue = Parametros.intSoles;

                        //Calcula Cumpleaños
                        DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        txtRutaArchivo.Text = pParametroBE.Valor + "CONT_" + txtNumero.Text + "_" + txtNumeroDocumento.Text.Trim();

                    }

                }
                else
                {
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    //IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;

                        //    //Calcula Cumpleaños
                        //    DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        //    int PeriodoNac = FechaNac.Year;
                        //    int Anios = Parametros.intPeriodo - PeriodoNac;

                        //    //Compras del mes
                        //    List<DocumentoVentaBE> lstVenta = null;
                        //    lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                        //    if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        //    {
                        //        lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                        //        bCumpleAnios = true;
                        //    }
                        //    else
                        //    {
                        //        bCumpleAnios = false;
                        //    }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvDis_ContratoFabricacionDetalle_DoubleClick(object sender, EventArgs e)
        {
            modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void gvDis_ContratoFabricacionDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                int decCantidadDias = 0;

                if (e.Column.Caption == "Aprobado")
                {
                    decCantidadDias = Convert.ToInt32(gvDis_ContratoFabricacionDetalle.GetRowCellValue(e.RowHandle, (gvDis_ContratoFabricacionDetalle.Columns["DiasProduccion"])));

                    DateTime FechaEntrega = DateTime.Now.AddDays(decCantidadDias);// deFechaInicio.DateTime.AddDays(-Dias);
                    gvDis_ContratoFabricacionDetalle.SetRowCellValue(e.RowHandle, gvDis_ContratoFabricacionDetalle.Columns["FechaProducccion"], FechaEntrega);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aprobartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de Aprobar el producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < gvDis_ContratoFabricacionDetalle.SelectedRowsCount; i++)
                {
                    int row = gvDis_ContratoFabricacionDetalle.GetSelectedRows()[i];

                    int decCantidadDias = 0;
                    decCantidadDias = int.Parse(gvDis_ContratoFabricacionDetalle.GetRowCellValue(row,"DiasProduccion").ToString());

                    DateTime? FechaEntrega = null;
                    if (decCantidadDias > 0)
                    {
                        FechaEntrega = DateTime.Now.AddDays(decCantidadDias);// deFechaInicio.DateTime.AddDays(-Dias);
                    }

                    gvDis_ContratoFabricacionDetalle.SetRowCellValue(row, "FlagAprobado", true);
                    gvDis_ContratoFabricacionDetalle.SetRowCellValue(row, "FechaEntrega", FechaEntrega);
                    CalcularMaximaFecha();
                    CalculaTotales();
                }
            }
        }

        private void desaprobartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de desaprobar el producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < gvDis_ContratoFabricacionDetalle.SelectedRowsCount; i++)
                {
                    int row = gvDis_ContratoFabricacionDetalle.GetSelectedRows()[i];

                    gvDis_ContratoFabricacionDetalle.SetRowCellValue(row, "FlagAprobado", false);
                    gvDis_ContratoFabricacionDetalle.SetRowCellValue(row, "FechaEntrega", "");
                    CalcularMaximaFecha();
                    CalculaTotales();
                }
            }
        }

        private void CalcularMaximaFecha()
        {
            try
            {
                DateTime FechaMaxima = Convert.ToDateTime("01/01/1990");

                if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDis_ContratoFabricacionDetalleOrigen)
                    {
                        if (item.FechaEntrega.ToString() != "")
                        {
                            //FechaMaxima = Convert.ToDateTime(item.FechaEntrega);
                            if (FechaMaxima < Convert.ToDateTime(item.FechaEntrega))
                            {
                                FechaMaxima = Convert.ToDateTime(item.FechaEntrega);
                            }
                        }
                    }
                }

                if (FechaMaxima > Convert.ToDateTime("01/01/1990"))
                {
                    deFechaProduccion.EditValue = FechaMaxima;
                }
                else
                {
                    deFechaProduccion.EditValue = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCerrarContrato_Click(object sender, EventArgs e)
        {
            if (btnCerrarContrato.Text == "Abrir Contrato")
            {
                if (XtraMessageBox.Show("Está seguro de Abrir el Contrato de fabricación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerCoodinadorComprasDiseno || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                    {
                        Dis_ContratoFabricacionBL Contrato = new Dis_ContratoFabricacionBL();
                        Contrato.ActualizaCerrado(IdDis_ContratoFabricacion, false);
                        btnGrabar_Click(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("El usuario no cuenta con permisos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                if (XtraMessageBox.Show("Está seguro de cerrar el Contrato de fabricación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var item in mListaDis_ContratoFabricacionDetalleOrigen)
                    {
                        if (item.IdProducto == 0)
                        {
                            XtraMessageBox.Show("El Producto " + item.NombreProducto + ", no tiene Código de proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if (item.Precio == 0 && !item.FlagObsequio)
                        {
                            XtraMessageBox.Show("El Producto " + item.NombreProducto + ", no tiene Precio de Venta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                    {
                        Dis_ContratoFabricacionBL Contrato = new Dis_ContratoFabricacionBL();
                        Contrato.ActualizaCerrado(IdDis_ContratoFabricacion, true);
                        btnGrabar_Click(sender, e);
                    }
                    else if (frmAutoriza.IdPersona == Convert.ToInt32(cboVendedor.EditValue))
                    {
                        Dis_ContratoFabricacionBL Contrato = new Dis_ContratoFabricacionBL();
                        Contrato.ActualizaCerrado(IdDis_ContratoFabricacion, true);
                        btnGrabar_Click(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("El contrato no se puede cerrar porque pertenece a otro vendedor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            frmDeliveryTarifa movDetalle = new frmDeliveryTarifa();
            if (movDetalle.ShowDialog() == DialogResult.OK)
            {
                decimal Tarifa = movDetalle.oBE.TarifaEnvio;
                string Distrito = movDetalle.oBE.DescUbigeo;
                int Producto = Parametros.intIdProductoDelivery;
                CargarProductoDelivery(Producto, Tarifa, Distrito);
            }
        }

        private void CargarProductoDelivery(int IdProducto, decimal Precio, string Distrito)
        {
            try
            {
                #region "HangTag"

                //StockBE pProductoBE = null;
                //pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);

                ProductoBE pProductoBE = null;
                pProductoBE = new ProductoBL().SeleccionaIDTodos(IdProducto);
                if (pProductoBE != null)
                {
                    //IdProducto = pProductoBE.IdProducto;
                    //pProductoBE.Cantidad = 1;
                    pProductoBE.NombreProducto = pProductoBE.NombreProducto + " - " + Distrito;
                    int i = 0;
                    int Item = 0;
                    //if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)

                    //    i = mListaDis_ContratoFabricacionDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                    //Item = Convert.ToInt32(i) + 1;

                    ////IdLineaProducto = pProductoBE.IdLineaProducto;
                    ////txtCodigo.Text = pProductoBE.CodigoProveedor;
                    ////txtProducto.Text = pProductoBE.NombreProducto;
                    ////txtUM.Text = pProductoBE.Abreviatura;
                    ////txtCantidad.EditValue = 1;
                    //if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                    //{
                    if (btnCerrarContrato.Enabled == true)//IdTipoCliente == Parametros.intTipClienteMayorista)
                    {
                        var Buscar = mListaDis_ContratoFabricacionDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            if (XtraMessageBox.Show("El servicio de trasporte ya existe, Desea agregar otro servicio de transporte?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }

                        }
                        gvDis_ContratoFabricacionDetalle.AddNewRow();
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacion", IdDis_ContratoFabricacion);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacionDetalle", 0);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Modelo", "");
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Medida", "");
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Material", "");
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", 1);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Precio", Precio);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", Precio);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Imagen", pProductoBE.Imagen);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagModificado", false);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "DiasProduccion", 0);
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                        gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                        CalculaTotales();

                        //btnNuevo.Focus();
                    }
                    //else
                    //{

                    //    var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                    //    if (Buscar.Count > 0)
                    //    {
                    //        XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //    gvDis_ContratoFabricacionDetalle.AddNewRow();
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                    //    //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Item", Item);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CantidadAnt", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitario", Precio);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Descuento", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioVenta", Precio);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", Precio);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdKardex", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagMuestra", false);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagRegalo", false);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Stock", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                    //    gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    //    gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                    //    CalculaTotales();

                    //    btnNuevo.Focus();
                    //}
                    //}
                    #region "Dolares"

                    //else
                    //{
                    //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                    //    {

                    //        var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                    //        if (Buscar.Count > 0)
                    //        {
                    //            XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            return;
                    //        }
                    //        gvDis_ContratoFabricacionDetalle.AddNewRow();
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                    //        //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Item", Item);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CantidadAnt", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitario", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Descuento", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdKardex", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagMuestra", false);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagRegalo", false);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Stock", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    //        gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                    //        CalculaTotales();

                    //        btnNuevo.Focus();
                    //    }
                    //    else
                    //    {
                    //        var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                    //        if (Buscar.Count > 0)
                    //        {
                    //            XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            return;
                    //        }
                    //        gvDis_ContratoFabricacionDetalle.AddNewRow();
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                    //        //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Item", Item);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CantidadAnt", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitario", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Descuento", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "ValorVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdKardex", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagMuestra", false);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagRegalo", false);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Stock", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                    //        gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    //        gvDis_ContratoFabricacionDetalle.UpdateCurrentRow();

                    //        CalculaTotales();

                    //        btnNuevo.Focus();
                    //    }
                    //}
                    #endregion


                }

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarAprobado()
        {
            bool flag = false;

            if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
            {
                int CantidadAprobada = 0;

                foreach (var item in mListaDis_ContratoFabricacionDetalleOrigen)
                {
                    if (item.FlagAprobado)
                    {
                        flag = true;
                        CantidadAprobada = CantidadAprobada + 1;
                    }
                }


            }

            if (flag)
            {
                XtraMessageBox.Show("No se puede cerrar el contrato", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }

            return flag;
        }

        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRutaArchivo.Text.Trim() == "")
                {
                    XtraMessageBox.Show("No se puede abrir, Ingrese una ruta válida", "Abrir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Directory.Exists(pParametroBE.Valor))
                {
                    Directory.CreateDirectory(txtRutaArchivo.Text.Trim());
                    Directory.CreateDirectory(txtRutaArchivo.Text.Trim() + @"\FOTOS ANTES");
                    Directory.CreateDirectory(txtRutaArchivo.Text.Trim() + @"\FOTOS DESPUES");
                    Directory.CreateDirectory(txtRutaArchivo.Text.Trim() + @"\PLANOS");

                    FileStream FS = new FileStream(txtRutaArchivo.Text.Trim() + "\\" + cboVendedor.Text + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //string texto = "Diseño de tal Cliente .\n\nMás Detalles";
                    //char[] txtcar = new char[texto.Length];
                    //txtcar = texto.ToCharArray();

                    //foreach (char c in txtcar)
                    //{
                    //    FS.WriteByte((byte)c);
                    //}

                    FS.Close();

                    System.Diagnostics.Process.Start("explorer.exe", @"" + txtRutaArchivo.Text.Trim());
                }
                else
                {
                    XtraMessageBox.Show("No se puede Crear Carpeta, Verique que tenga Acceso a la ruta: \n" + pParametroBE.Valor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarRutaArchivo()
        {
            pParametroBE = new ParametroBL().Selecciona("ContratoFabricacionUbicacion");
            //txtRutaArchivo.Text = pParametroBE.Valor;
        }

        //private Image CargarFoto(int IdProducto)
        //{
        //    Image Foto;
        //    if (IdProducto > 0)
        //    {
        //        ProductoBE objE_Producto = null;
        //        objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

        //        if (objE_Producto.Imagen != null)
        //        {
        //            Foto = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
        //        }
        //        else
        //        { Foto = ErpPanorama.Presentation.Properties.Resources.noImage; }
        //    }

        //    return Foto;
        //}

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            try
            {

                //decimal deValorVenta = 0;
                decimal TotalCotizado = 0;

                decimal deTotal = 0;
                decimal CantidadTotal = 0;
                decimal CantidadAprobado = 0;
                decimal deTotalAprobado = 0;
                decimal TotalRegistros = 0;

                if (mListaDis_ContratoFabricacionDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDis_ContratoFabricacionDetalleOrigen)
                    {
                        //deValorVenta = item.Precio;
                        //deTotal = deTotal + deValorVenta;

                        CantidadTotal = CantidadTotal + item.Cantidad;
                        deTotal = deTotal + item.ValorVenta;

                        if (item.FlagAprobado)
                        {
                            if(!item.FlagObsequio)
                            {
                                CantidadAprobado = CantidadAprobado + item.Cantidad;
                                deTotalAprobado = deTotalAprobado + item.ValorVenta;
                            }
                        }
                        if (item.ValorVenta > 0)
                        {
                            TotalCotizado = TotalCotizado + 1;
                        }

                    }

                    //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
                    txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
                    txtTotalVenta.EditValue = Math.Round(deTotal, 2);

                    txtCantidadAprobada.EditValue = Math.Round(CantidadAprobado, 2);
                    txtTotalAprobado.EditValue = Math.Round(deTotalAprobado, 2);

                    //Porcentaje de Avance
                    TotalRegistros = mListaDis_ContratoFabricacionDetalleOrigen.Count;
                    lblCotizacion.Text =  Convert.ToString(Math.Round( (TotalCotizado / TotalRegistros)*100,0));

                }
                else
                {
                    lblCotizacion.Text = "0";
                    txtTotalCantidad.EditValue = 0;
                    txtTotalVenta.EditValue = 0;
                    txtCantidadAprobada.EditValue = 0;
                    txtTotalAprobado.EditValue = 0;
                }

                lblTotalRegistros.Text = mListaDis_ContratoFabricacionDetalleOrigen.Count.ToString() + " Registros encontrados";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaDis_ContratoFabricacionDetalle()
        {
            List<Dis_ContratoFabricacionDetalleBE> lstTmpDis_ContratoFabricacionDetalle = null;
            lstTmpDis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL().ListaTodosActivo(IdDis_ContratoFabricacion);

            foreach (Dis_ContratoFabricacionDetalleBE item in lstTmpDis_ContratoFabricacionDetalle)
            {
                CDis_ContratoFabricacionDetalle objE_Dis_ContratoFabricacionDetalle = new CDis_ContratoFabricacionDetalle();
                objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacion = item.IdDis_ContratoFabricacion;
                objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = item.IdDis_ContratoFabricacionDetalle;
                objE_Dis_ContratoFabricacionDetalle.IdProducto = item.IdProducto;
                objE_Dis_ContratoFabricacionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_Dis_ContratoFabricacionDetalle.NombreProducto = item.NombreProducto;
                objE_Dis_ContratoFabricacionDetalle.Abreviatura = item.Abreviatura;
                objE_Dis_ContratoFabricacionDetalle.Modelo = item.Modelo;
                objE_Dis_ContratoFabricacionDetalle.Medida = item.Medida;
                objE_Dis_ContratoFabricacionDetalle.Material = item.Material;
                objE_Dis_ContratoFabricacionDetalle.Cantidad = item.Cantidad;
                objE_Dis_ContratoFabricacionDetalle.Precio = item.Precio;
                objE_Dis_ContratoFabricacionDetalle.ValorVenta = item.ValorVenta;
                objE_Dis_ContratoFabricacionDetalle.Imagen = item.Imagen;//new FuncionBase().Bytes2Image((byte[])item.Imagen);
                objE_Dis_ContratoFabricacionDetalle.FlagObsequio = item.FlagObsequio;
                objE_Dis_ContratoFabricacionDetalle.FlagModificado = item.FlagModificado;
                objE_Dis_ContratoFabricacionDetalle.FlagAprobado = item.FlagAprobado;
                objE_Dis_ContratoFabricacionDetalle.DiasProduccion = item.DiasProduccion;
                objE_Dis_ContratoFabricacionDetalle.FechaEntrega = item.FechaEntrega;
                objE_Dis_ContratoFabricacionDetalle.Observacion = item.Observacion;
                objE_Dis_ContratoFabricacionDetalle.TipoOper = item.TipoOper;
                mListaDis_ContratoFabricacionDetalleOrigen.Add(objE_Dis_ContratoFabricacionDetalle);
            }

            bsListado.DataSource = mListaDis_ContratoFabricacionDetalleOrigen;
            gcDis_ContratoFabricacionDetalle.DataSource = bsListado;
            gcDis_ContratoFabricacionDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingresar la descripción del Dis_ContratoFabricacion.\n";
                flag = true;
            }

            if (txtDescCliente.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar el nombre del cliente.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtPiso.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingresar el Número de Piso.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboVendedor.EditValue) == Convert.ToInt32(cboVendedor2.EditValue))
            {
                cboVendedor2.EditValue = 0;
            }

            if (mListaDis_ContratoFabricacionDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Contrato de Fabricación, mientras no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoContratoDetalle_" + txtNumero.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_ContratoFabricacionDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void ImportarExcel(string filename)
        {
            //if (filename.Trim() == "")
            //    return;

            //Excel._Application xlApp;
            //Excel._Workbook xlLibro;
            //Excel._Worksheet xlHoja;
            //Excel.Sheets xlHojas;
            //xlApp = new Excel.Application();
            //xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //xlHojas = xlLibro.Sheets;
            //xlHoja = (Excel._Worksheet)xlHojas[1];

            //int Row = 2;
            //int TotRow = 2;

            //try
            //{
            //    //Contador de Registros
            //    while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
            //    {
            //        if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
            //            TotRow++;
            //    }
            //    TotRow = TotRow - Row + 1;
            //    prgFactura.Properties.Step = 1;
            //    prgFactura.Properties.Maximum = TotRow;
            //    prgFactura.Properties.Minimum = 0;


            //    //Recorremos los códigos de Dis_ContratoFabricacion
            //    while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
            //    {
            //        string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
            //        int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
            //        string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
            //        string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

            //        ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
            //        if (objE_Producto != null)
            //        {
            //            //Verifica existencia
            //            var Buscar = mListaDis_ContratoFabricacionDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
            //            if (Buscar.Count > 0)
            //            {
            //                XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }


            //            gvDis_ContratoFabricacionDetalle.AddNewRow();
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdDis_ContratoFabricacionDetalle", 0);
            //            //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
            //            //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Cantidad", Cantidad);
            //            //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
            //            //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Observacion", Observacion);
            //            //gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
            //            gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "FlagEstado", true);
            //            if (pOperacion == Operacion.Modificar)
            //                gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //            else
            //                gvDis_ContratoFabricacionDetalle.SetRowCellValue(gvDis_ContratoFabricacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

            //        }
            //        else
            //        {

            //            //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
            //            Dis_ContratoFabricacionDetalleBE ObjE_Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBE();
            //            ObjE_Dis_ContratoFabricacionDetalle.CodigoProveedor = CodigoProveedor;
            //            ObjE_Dis_ContratoFabricacionDetalle.Cantidad = Cantidad;
            //            lst_Dis_ContratoFabricacionDetalleMsg.Add(ObjE_Dis_ContratoFabricacionDetalle);
            //        }


            //        prgFactura.PerformStep();
            //        prgFactura.Update();

            //        Row++;
            //    }


            //    lblTotalRegistros.Text = gvDis_ContratoFabricacionDetalle.RowCount.ToString() + " Registros";
            //    CalculaTotales();

            //    if (lst_Dis_ContratoFabricacionDetalleMsg.Count > 0)
            //    {
            //        frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
            //        frm.mLista = lst_Dis_ContratoFabricacionDetalleMsg;
            //        frm.ShowDialog();
            //    }

            //    //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


            //    xlLibro.Close(false, Missing.Value, Missing.Value);
            //    xlApp.Quit();
            //    //this.Close();
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    xlLibro.Close(false, Missing.Value, Missing.Value);
            //    xlApp.Quit();
            //    XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocContratoFabricacion, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearCabecera()
        {
            cboVendedor.Properties.ReadOnly = false;
            txtNumeroDocumento.Properties.ReadOnly = true;
            txtDescCliente.Properties.ReadOnly = true;
            btnNuevoCliente.Enabled = false;
            btnBuscar.Enabled = false;
            deFecha.Properties.ReadOnly = true;
        }


        private void BloquearTodo()
        {
            cboVendedor.Properties.ReadOnly = false;
            txtNumeroDocumento.Properties.ReadOnly = true;
            txtDescCliente.Properties.ReadOnly = true;
            btnNuevoCliente.Enabled = false;
            btnBuscar.Enabled = false;
            deFecha.Properties.ReadOnly = true;
            //btnCerrarContrato.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            mnuContextual.Enabled = false;
            btnCerrarContrato.Text = "Abrir Contrato";
        }




        #endregion

        public class CDis_ContratoFabricacionDetalle

        {
            public Int32 IdDis_ContratoFabricacion { get; set; }
            public Int32 IdDis_ContratoFabricacionDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 IdUnidadMedida { get; set; }
            public String Modelo { get; set; }
            public String Medida { get; set; }
            public String Material { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Decimal ValorVenta { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagObsequio { get; set; }
            public Boolean FlagModificado { get; set; }
            public Boolean FlagAprobado { get; set; }
            public byte[] Imagen { get; set; }
            public Int32 DiasProduccion { get; set; }
            public DateTime? FechaEntrega { get; set; }
            public Int32 TipoOper { get; set; }

            public CDis_ContratoFabricacionDetalle()
            {

            }
        }

        private void btnEliminarVendedor2_Click(object sender, EventArgs e)
        {
            cboVendedor2.EditValue = 0;
        }

        private void txtNumeroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            Dis_ContratoFabricacionBE objE_Contrato = null;
            objE_Contrato = new Dis_ContratoFabricacionBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroContrato.Text.Trim());

            if (objE_Contrato != null)
            {
                //IdDis_ContratoFabricacion = 0;
                //txtNumero.EditValue = objE_Contrato.Numero;
                deFecha.EditValue = objE_Contrato.Fecha;
                txtNumeroProyecto.Text = objE_Contrato.NumeroProyecto;
                IdCliente = objE_Contrato.IdCliente;
                txtNumeroDocumento.Text = objE_Contrato.NumeroDocumento;
                txtDescCliente.Text = objE_Contrato.DescCliente;
                txtDireccion.Text = objE_Contrato.Direccion;
                txtReferencia.Text = objE_Contrato.Referencia;
                txtEmail.Text = objE_Contrato.Email;
                cboVendedor.EditValue = objE_Contrato.IdVendedor;
                cboVendedor2.EditValue = objE_Contrato.IdVendedor2;
                deFechaEntrega.EditValue = objE_Contrato.FechaEntrega;
                IdDis_ProyectoServicio = objE_Contrato.IdProyecto;
                txtPiso.EditValue = objE_Contrato.Piso;
                txtRutaArchivo.Text = objE_Contrato.RutaArchivo;
                txtNumeroProyecto.Properties.ReadOnly = true;
                txtRutaArchivo.Properties.ReadOnly = true;
                //txtNumeroContrato.Properties.ReadOnly = true;
                //BloquearCabecera();

                //if (objE_Contrato.FlagCerrado)
                //{
                //    BloquearTodo();
                //}

                List<Dis_ContratoFabricacionDetalleBE> lstTmpDis_ContratoFabricacionDetalle = null;
                lstTmpDis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL().ListaTodosActivo(objE_Contrato.IdDis_ContratoFabricacion);

                foreach (Dis_ContratoFabricacionDetalleBE item in lstTmpDis_ContratoFabricacionDetalle)
                {
                    CDis_ContratoFabricacionDetalle objE_Dis_ContratoFabricacionDetalle = new CDis_ContratoFabricacionDetalle();
                    objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacion = 0;
                    objE_Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = 0;
                    objE_Dis_ContratoFabricacionDetalle.IdProducto = item.IdProducto;
                    objE_Dis_ContratoFabricacionDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_Dis_ContratoFabricacionDetalle.NombreProducto = item.NombreProducto;
                    objE_Dis_ContratoFabricacionDetalle.Abreviatura = item.Abreviatura;
                    objE_Dis_ContratoFabricacionDetalle.Modelo = item.Modelo;
                    objE_Dis_ContratoFabricacionDetalle.Medida = item.Medida;
                    objE_Dis_ContratoFabricacionDetalle.Material = item.Material;
                    objE_Dis_ContratoFabricacionDetalle.Cantidad = item.Cantidad;
                    objE_Dis_ContratoFabricacionDetalle.Precio = item.Precio;
                    objE_Dis_ContratoFabricacionDetalle.ValorVenta = item.ValorVenta;
                    objE_Dis_ContratoFabricacionDetalle.Imagen = item.Imagen;//new FuncionBase().Bytes2Image((byte[])item.Imagen);
                    objE_Dis_ContratoFabricacionDetalle.FlagModificado = item.FlagModificado;
                    objE_Dis_ContratoFabricacionDetalle.FlagAprobado = item.FlagAprobado;
                    objE_Dis_ContratoFabricacionDetalle.DiasProduccion = item.DiasProduccion;
                    objE_Dis_ContratoFabricacionDetalle.FechaEntrega = item.FechaEntrega;
                    objE_Dis_ContratoFabricacionDetalle.Observacion = item.Observacion;
                    objE_Dis_ContratoFabricacionDetalle.TipoOper = 1;
                    mListaDis_ContratoFabricacionDetalleOrigen.Add(objE_Dis_ContratoFabricacionDetalle);
                }

                bsListado.DataSource = mListaDis_ContratoFabricacionDetalleOrigen;
                gcDis_ContratoFabricacionDetalle.DataSource = bsListado;
                gcDis_ContratoFabricacionDetalle.RefreshDataSource();

                CalculaTotales();


            }

        }

        private void deFechaEntrega_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void deFechaProduccion_EditValueChanged(object sender, EventArgs e)
        {
            if (deFechaProduccion.Text != "")
                deFechaEntrega.EditValue = deFechaProduccion.DateTime.AddDays(2);
            else
                deFechaEntrega.Text = "";
        }

        private void btnActualizarFechaProd_Click(object sender, EventArgs e)
        {
            CalcularMaximaFecha();
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void opcionesavanzadastoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}