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
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;


namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegAuditoriaBultoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public List<CBultoDetalle> mListaBultoDetalleOrigen = new List<CBultoDetalle>();

        int _IdBulto = 0;

        public int IdBulto
        {
            get { return _IdBulto; }
            set { _IdBulto = value; }
        }


        private int IdCliente = 0;
        private bool bModificaChequeo = false;
        private int IdProducto = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public bool bNuevo = true;
        public bool bConsulta = false;
        private int EBotonGrabar = 0;

        decimal dmlTipoCambio = 0;


        public ParametroBE pParametroBE;

        #endregion

        #region "Eventos"

        public frmRegAuditoriaBultoEdit()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaBultoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            deFechaChequeo.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboPersonaChequeo, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaChequeo.EditValue = Parametros.intUsuarioId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Auditoria Bulto - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Auditoria Bulto - Modificar";

                //Carga Personal - Todos - Cesados
                BSUtils.LoaderLook(cboPersonaChequeo, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                BultoBE objE_Bulto = null;
                objE_Bulto = new BultoBL().SeleccionaChequeo(Parametros.intEmpresaId, IdBulto);

                if (objE_Bulto != null)
                {
                    IdBulto = objE_Bulto.IdBulto;
                    txtNumero.Text = objE_Bulto.NumeroBulto;
                    deFecha.EditValue = objE_Bulto.FechaIngreso;
                    txtCantidad.EditValue = objE_Bulto.Cantidad;
                    txtCantidadChequeo.EditValue = objE_Bulto.CantidadChequeo;
                    deFechaChequeo.EditValue = objE_Bulto.FechaChequeo;
                    cboPersonaChequeo.EditValue = objE_Bulto.IdChequeador;
                    IdProducto = objE_Bulto.IdProducto;
                    txtCodigoProveedor.Text = objE_Bulto.CodigoProveedor;
                    txtTotalDiferencia.EditValue = objE_Bulto.Cantidad - objE_Bulto.CantidadChequeo;
                }

                ////Chequeador
                //MovimientoBultoBE objE_MovimientoBulto = null;
                //objE_MovimientoBulto = new MovimientoBultoBL().SeleccionaChequeo(IdBulto);
                //if (objE_MovimientoBulto != null)
                //{
                //    cboPersonaPicking.EditValue = objE_MovimientoBulto.IdAuxiliar;
                //    cboPersonaChequeo.EditValue = objE_MovimientoBulto.IdChequeador;
                //    cboPersonaEmbalaje.EditValue = objE_MovimientoBulto.IdEmbalador;
                //    txtNumeroBultos.EditValue = objE_MovimientoBulto.CantidadBulto;
                //}

                //CargaBultoDetalle();

                if (Convert.ToInt32(txtTotalDiferencia.EditValue) == 0)
                {
                    btnGrabar.Enabled = false;
                }

                return;

            }


            if (Parametros.strUsuarioLogin == "master")
            {
                txtCantidadChequeo.Properties.ReadOnly = false;
            }
            //CargaBultoDetalle();

        }

        private void btnLectorBarras_Click(object sender, EventArgs e)
        {
            CargarLector();
        }

        private void frmRegBultoEdit_Shown(object sender, EventArgs e)
        {
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    BultoBL objBL_Bulto = new BultoBL();
                    BultoBE objE_Bulto = new BultoBE();
                    objE_Bulto.IdBulto = IdBulto;
                    objE_Bulto.CantidadChequeo = Convert.ToInt32(txtCantidadChequeo.EditValue);
                    objE_Bulto.FechaChequeo = Convert.ToDateTime(deFechaChequeo.EditValue);
                    objE_Bulto.IdChequeador = Convert.ToInt32(cboPersonaChequeo.EditValue);

                    objBL_Bulto.ActualizaCantidadChequeo(objE_Bulto);

                    //Embalador
                    //GrabarEmbalador();

                    Cursor = Cursors.Default;

                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == Keys.F5) txtCodigo.Select();
            if (keyData == Keys.F12) CargarLector();

            return base.ProcessCmdKey(ref msg, keyData);
        }


        #endregion

        #region "Metodos"


        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboPersonaChequeo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar Personal de Chequeo.\n";
                flag = true;
            }

            //if (mListaBultoDetalleOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
            //    flag = true;
            //}

            if (bModificaChequeo == true) //
            {
                bModificaChequeo = false;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargarLector()
        {
            frmRegAuditoriaPedidoDetalleEdit frm = new frmRegAuditoriaPedidoDetalleEdit();
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.Location = new Point(0, 0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int decCantidadChequeo = 0;
                int decCantidadDiferencia = 0;
                int cantidadLectura = 0;
                //int IdProducto = 0;
                string CodigoProveedor = "";
                string NombreProducto = "";
                string Abreviatura = "";

                cantidadLectura = frm.oBE.Cantidad;
                //IdProducto = frm.oBE.IdProducto;
                CodigoProveedor = frm.oBE.CodigoProveedor;
                NombreProducto = frm.oBE.NombreProducto;
                Abreviatura = frm.oBE.Abreviatura;

                //txtCantidadChequeo.EditValue = cantidadLectura;


                if (IdProducto == frm.oBE.IdProducto)
                {
                    decCantidad = Convert.ToInt32(txtCantidad.EditValue);
                    decCantidadChequeo = Convert.ToInt32(txtCantidadChequeo.EditValue);
                    decCantidadDiferencia = Convert.ToInt32(txtTotalDiferencia.EditValue);


                    if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < -1)
                    {
                        XtraMessageBox.Show("Cantidad ingresada del Código: " + frm.oBE.CodigoProveedor + " es mayor a la Cantidad del Bulto, Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //\nSe capturó el registro para auditoria
                        return;
                    }
                    else if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < 0)
                    {
                        XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " está completo , Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        decCantidadDiferencia = decCantidad - (decCantidadChequeo + cantidadLectura);
                        txtCantidadChequeo.EditValue = decCantidadChequeo + cantidadLectura;
                        txtTotalDiferencia.EditValue = decCantidad - (decCantidadChequeo + cantidadLectura);
                        lblMensaje.Text = (decCantidad + cantidadLectura).ToString();
                        lblMensaje2.Text = CodigoProveedor;

                        //CargarLector111();
                        //return;                   
                    }

                    //CalcularTotalDocumentos();
                    if (decCantidadDiferencia == 0)
                        lblMensaje.Text = "COMPLETO";
                    else
                        lblMensaje.Text = "FALTAN " + (decCantidadDiferencia).ToString();
               
                }else
                {
                    XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Favor de Verificar el producto!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    lblMensaje.Text = cantidadLectura.ToString();
                    lblMensaje2.Text = CodigoProveedor;
                }

                CargarLector();
                //CalcularTotalDocumentos();
            }
        }




        private void GrabarEmbalador()
        {
            //try
            //{
            //    if (Convert.ToInt32(txtNumeroBultos.EditValue) > 0)
            //    {
            //        if (txtNumeroBultos.Text.Trim().Length == 0)
            //        {
            //            XtraMessageBox.Show("Ingresar cantidad de Bultos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtNumeroBultos.Focus();
            //            return;
            //        }

            //        //MovimientoBultoBE objBE_MovimientoBultoPicking = null;
            //        MovimientoBultoBE objBE_MovimientoBulto = new MovimientoBultoBE();
            //        MovimientoBultoBL objBL_MovimientoBulto = new MovimientoBultoBL();

            //        ////Buscar situación de picking
            //        //objBE_MovimientoBultoPicking = objBL_MovimientoBulto.SeleccionaChequeo(objE_Bulto.IdBulto);
            //        //if (objBE_MovimientoBultoPicking.IdAuxiliar == 0)
            //        //{
            //        //    XtraMessageBox.Show("El Bulto tiene que Pasar por PICKING, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return;
            //        //}

            //        //Cargar con valores
            //        objBE_MovimientoBulto.IdBulto = IdBulto;
            //        objBE_MovimientoBulto.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
            //        objBE_MovimientoBulto.EnPT = true;
            //        objBE_MovimientoBulto.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
            //        objBL_MovimientoBulto.ActualizaCierreEmbalaje(objBE_MovimientoBulto);

            //        //XtraMessageBox.Show("Se guardó N° Bulto Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion




        private void frmRegAuditoriaBultoEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (bModificaChequeo == true)
            //{
            //    if (XtraMessageBox.Show("Está seguro que desea Cerrar el registro de chequeo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }

            //}
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (cboPersonaChequeo.Text == "")
            {
                XtraMessageBox.Show("No se puede realizar el chequeo sin la persona de Chequeo\nRegistrar desde el módulo de picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //BultoBL objBL_Bulto = new BultoBL();
            //objBL_Bulto.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdBulto, Parametros.intEnChequeo, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
            btnLectorBarras.Visible = true;
            btnIniciar.Visible = false;
        }

 





    }
}