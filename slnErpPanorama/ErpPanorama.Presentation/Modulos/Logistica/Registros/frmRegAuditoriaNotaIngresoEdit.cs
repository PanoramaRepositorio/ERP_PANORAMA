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
    public partial class frmRegAuditoriaNotaIngresoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CMovimientoAlmacenDetalle> mListaMovimientoAlmacenDetalleOrigen = new List<CMovimientoAlmacenDetalle>();

        int _IdMovimientoAlmacen = 0;

        public int IdMovimientoAlmacen
        {
            get { return _IdMovimientoAlmacen; }
            set { _IdMovimientoAlmacen = value; }
        }


        private int IdCliente = 0;
        private bool bModificaChequeo = false;

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
        public int TipoMovimiento = 0;

        private bool Chequeado = false;
        private bool Preparado = false;

        #endregion

        #region "Eventos"

        public frmRegAuditoriaNotaIngresoEdit()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaNotaIngresoEdit_Load(object sender, EventArgs e)
        {
            //deFecha.EditValue = DateTime.Now;
            deFechaChequeo.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboPersonaChequeo, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaChequeo.EditValue = Parametros.intUsuarioId;
            BSUtils.LoaderLook(cboPersonaPicking, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboPersonaEmbalaje, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

            //---N/I
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0 /*Parametros.intTiendaId*/), "DescAlmacen", "IdAlmacen", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaAlmacenIngreso(Parametros.intEmpresaId), "DescTablaElemento", "IdTablaElemento", true);
            //BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModLogistica), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intPanoraramaDistribuidores), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            cboAlmacenDestino.EditValue = Parametros.intAlmTiendaUcayali;
            //----------

            if (pOperacion == Operacion.Nuevo)
            {
                    this.Text = "Auditoria MovimientoAlmacen - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                if (TipoMovimiento == 1)
                {
                    this.Text = "Auditoria MovimientoAlmacen - Nota de Salida";
                }
                else
                {
                    this.Text = "Auditoria MovimientoAlmacen - Nota de Ingreso";
                }


                //Carga Personal - Todos - Cesados
                //BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId ,IdMovimientoAlmacen);

                if (objE_MovimientoAlmacen != null)
                {
                    IdMovimientoAlmacen = objE_MovimientoAlmacen.IdMovimientoAlmacen;
                    cboAlmacen.EditValue = objE_MovimientoAlmacen.IdAlmacenOrigen;
                    txtNumero.Text = objE_MovimientoAlmacen.Numero;
                    deFecha.EditValue = objE_MovimientoAlmacen.Fecha;
                    cboDocumento.EditValue = objE_MovimientoAlmacen.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_MovimientoAlmacen.NumeroDocumento;
                    cboMotivo.EditValue = objE_MovimientoAlmacen.IdMotivo;
                    cboAlmacenDestino.EditValue = objE_MovimientoAlmacen.IdAlmacenDestino;
                    txtObservaciones.Text = objE_MovimientoAlmacen.Observaciones;
                    if(objE_MovimientoAlmacen.FechaChequeo!= null)
                        deFechaChequeo.EditValue = objE_MovimientoAlmacen.FechaChequeo;
                    else
                        deFechaChequeo.EditValue = DateTime.Now;

                    //deFechaChequeo.EditValue = objE_MovimientoAlmacen.FechaChequeo;
                    cboPersonaPicking.EditValue = objE_MovimientoAlmacen.IdAuxiliar;
                    cboPersonaChequeo.EditValue = objE_MovimientoAlmacen.IdChequeador;
                    cboPersonaEmbalaje.EditValue = objE_MovimientoAlmacen.IdEmbalador;
                    txtNumeroBultos.EditValue = objE_MovimientoAlmacen.CantidadBulto;
                    Preparado = objE_MovimientoAlmacen.Preparado;

                    if (objE_MovimientoAlmacen.FlagChequeoFinalizado)
                    {
                        btnFinalizar.Enabled = false;
                    }
                }

                CargaMovimientoAlmacenDetalle();

                if (Convert.ToInt32(txtTotalDiferencia.EditValue) == 0)
                {
                    btnGrabar.Enabled = false;
                }

                return;

            }

            CargaMovimientoAlmacenDetalle();
        }

        private void btnLectorBarras_Click(object sender, EventArgs e)
        {
            //CargarLector();
            CargarLector111();
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    ///Int32 Numero = 0;

                    MovimientoAlmacenDetalleBL objBL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL();
                    MovimientoAlmacenDetalleBE objMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();


                    //MovimientoAlmacen Detalle
                    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

                    foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
                    {
                        MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                        objE_MovimientoAlmacenDetalle.CantidadChequeo = item.CantidadChequeo;
                        lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
                    }

                    objBL_MovimientoAlmacenDetalle.ActualizaChequeo(lstMovimientoAlmacenDetalle);


                    ////Chequeador
                    //MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    //MovimientoAlmacenBE objE_MovimientoAlmacen = new MovimientoAlmacenBE();

                    //objE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    //objE_MovimientoAlmacen.IdChequeador = Convert.ToInt32(cboPersonaChequeo.EditValue);
                    //objE_MovimientoAlmacen.FlagChequeoFinalizado = false;

                    //objBL_MovimientoAlmacen.ActualizaChequeador(objE_MovimientoAlmacen);


                    ////Embalador
                    //GrabarEmbalador();

                    Cursor = Cursors.Default;

                    this.DialogResult = DialogResult.OK;
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
            if (keyData == Keys.F5) txtCodigo.Select();
            if (keyData == Keys.F12) CargarLector();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ////MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
            ////objBL_MovimientoAlmacen.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdMovimientoAlmacen, Parametros.intEnChequeo, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

            //btnLectorBarras.Visible = true;
            //btnIniciar.Visible = false;




            if (cboPersonaPicking.Text == "")
            {
                XtraMessageBox.Show("No se puede CHEQUEAR sin antes pasar por PICKING\nFavor de registrar utilizando el módulo de picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Preparado)
            {
                XtraMessageBox.Show("El pedido aún no finaliza PICKING!.\nPor favor consultar con el personal de Picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (!frmAutoriza.Edita)
            {
                Cursor = Cursors.Default;
                return;
            }
            if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                return;
            }
            cboPersonaChequeo.EditValue = frmAutoriza.IdPersona;
            cboPersonaChequeo.Properties.ReadOnly = true;


            if (cboPersonaChequeo.Text == "")
            {
                XtraMessageBox.Show("Seleccionar el nombre del CHEQUEADOR!.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Actualizar cierre de chequeado
            MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
            MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
            objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
            objBE_MovimientoAlmacen.IdChequeador = Convert.ToInt32(cboPersonaChequeo.EditValue);
            objBE_MovimientoAlmacen.FlagChequeo = true;
            objBE_MovimientoAlmacen.FlagCierre = false;
            objBL_MovimientoAlmacen.ActualizaCierreChequeo(objBE_MovimientoAlmacen);


            btnLectorBarras.Visible = true;
            btnIniciar.Visible = false;

            if (Convert.ToInt32(txtTotalChequeo.EditValue) == 0)
            {
                this.Text = this.Text + " - Inicio de Picking " + DateTime.Now.ToString();
            }


        }

        private void txtNumeroBultos_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNumeroBultos.Text.Trim().Count() > 0)
            {
                btnGrabar.Enabled = true;
            }
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda()
        {
            gcMovimientoAlmacenDetalle.DataSource = mListaMovimientoAlmacenDetalleOrigen.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private void ObtenerCorrelativo()
        {
            //try
            //{
            //    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            //    string sNumero = "";
            //    string sSerie = "";
            //    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocMovimientoAlmacenVenta, Parametros.intPeriodo);
            //    if (mListaNumero.Count > 0)
            //    {
            //        sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            //        sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
            //    }
            //    txtNumero.Text = sNumero;
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaMovimientoAlmacenDetalle()
        {
            mListaMovimientoAlmacenDetalleOrigen = new List<CMovimientoAlmacenDetalle>();

            List<MovimientoAlmacenDetalleBE> lstTmpMovimientoAlmacenDetalle = null;
            lstTmpMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaTodosActivoChequeo(IdMovimientoAlmacen);

            foreach (MovimientoAlmacenDetalleBE item in lstTmpMovimientoAlmacenDetalle)
            {
                CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();

                objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = item.IdMovimientoAlmacen;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                objE_MovimientoAlmacenDetalle.Item = item.Item;
                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CantidadChequeo = item.CantidadChequeo;
                objE_MovimientoAlmacenDetalle.CantidadDiferencia = item.Cantidad - item.CantidadChequeo;
                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                if ((item.Cantidad - item.CantidadChequeo) < 0)
                {
                    gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowEdit = true;
                    gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowFocus = true;
                }
            }

            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();


            //CalcularCantidad();
            txtTotalRegistros.EditValue = mListaMovimientoAlmacenDetalleOrigen.Count;

            CalcularTotalDocumentos();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboPersonaChequeo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar Personal de Chequeo.\n";
                flag = true;
            }

            if (mListaMovimientoAlmacenDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar, mientra no haya productos.\n";
                flag = true;
            }


            if (Convert.ToInt32(txtTotalChequeo.EditValue) == 0)
            {
                strMensaje = strMensaje + "- La diferencia debe ser mayor a cero.\n";
                flag = true;
            }

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
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Location = new Point(100, 100);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int decCantidadChequeo = 0;
                int decCantidadDiferencia = 0;
                int cantidadLectura = 0;
                int IdProducto = 0;
                bool FlagExiste = false;
                cantidadLectura = frm.oBE.Cantidad;
                IdProducto = frm.oBE.IdProducto;


                int PosicionX = 0;
                foreach (CMovimientoAlmacenDetalle item in mListaMovimientoAlmacenDetalleOrigen)
                {
                    if (IdProducto == item.IdProducto)
                    {
                        FlagExiste = true;
                        bModificaChequeo = true;

                        //gcMovimientoAlmacenDetalle.DataSource = mListaMovimientoAlmacenDetalleOrigen.Where(obj => obj.IdProducto.ToString().Contains(IdProducto.ToString())).ToList();

                        decCantidad = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(PosicionX, (gvMovimientoAlmacenDetalle.Columns["Cantidad"])));
                        decCantidadChequeo = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(PosicionX, (gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"])));
                        decCantidadDiferencia = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(PosicionX, (gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"])));

                        if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < -1)
                        {
                            XtraMessageBox.Show("Cantidad ingresada del Código: " + frm.oBE.CodigoProveedor + " es mayor a lo solicitado, Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            gvMovimientoAlmacenDetalle.SetRowCellValue(PosicionX, gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"], decCantidadChequeo + cantidadLectura);
                            //gvMovimientoAlmacenDetalle.SetRowCellValue(PosicionX, gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"], decCantidad - (decCantidadChequeo + cantidadLectura));
                            gvMovimientoAlmacenDetalle.SetRowCellValue(PosicionX, gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"], decCantidadDiferencia);
                        }

                        CalcularTotalDocumentos();// add

                        if (decCantidadDiferencia == 0)
                            lblMensaje.Text = "COMPLETO";
                        else
                            lblMensaje.Text = "FALTAN " + (decCantidadDiferencia).ToString();

                    }
                    PosicionX = PosicionX + 1;
                }


                if (!FlagExiste)
                {
                    XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Consultar con el Personal de Picking!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarLector();
                //CalcularTotalDocumentos();
            }



        }

        private void CargarLector111()
        {
            frmRegAuditoriaPedidoDetalleEdit frm = new frmRegAuditoriaPedidoDetalleEdit();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Location = new Point(100, 100);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int decCantidadChequeo = 0;
                int decCantidadDiferencia = 0;
                int cantidadLectura = 0;
                int IdProducto = 0;
                string CodigoProveedor = "";
                string NombreProducto = "";
                string Abreviatura = "";

                bool FlagExiste = false;
                cantidadLectura = frm.oBE.Cantidad;
                IdProducto = frm.oBE.IdProducto;
                CodigoProveedor = frm.oBE.CodigoProveedor;
                NombreProducto = frm.oBE.NombreProducto;
                Abreviatura = frm.oBE.Abreviatura;


                for (int i = 0; i < gvMovimientoAlmacenDetalle.RowCount; i++) //Existe
                {
                    int IdProductoLista = 0;
                    int row = gvMovimientoAlmacenDetalle.GetRowHandle(i);

                    IdProductoLista = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["IdProducto"])));

                    if (IdProducto == IdProductoLista)
                    {
                        FlagExiste = true;
                        decCantidad = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["Cantidad"])));
                        decCantidadChequeo = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"])));
                        decCantidadDiferencia = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"])));


                        if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < -1)
                        {
                            XtraMessageBox.Show("Cantidad ingresada del Código: " + frm.oBE.CodigoProveedor + " es mayor a lo solicitado, Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            gvMovimientoAlmacenDetalle.SetRowCellValue(row, gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"], decCantidadChequeo + cantidadLectura);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(row, gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"], decCantidad - (decCantidadChequeo + cantidadLectura));
                            lblMensaje.Text = (decCantidad + cantidadLectura).ToString();
                            lblMensaje2.Text = CodigoProveedor;
                            //CargarLector111();
                            //return;                   
                        }

                        CalcularTotalDocumentos();
                        if (decCantidadDiferencia == 0)
                            lblMensaje.Text = "COMPLETO";
                        else
                            lblMensaje.Text = "FALTAN " + (decCantidadDiferencia).ToString();

                    }
                }

                if (!FlagExiste)
                {
                    XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Consultar con el Personal de Picking!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ////gvMovimientoAlmacenDetalle.AddNewRow();
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Item", (mListaMovimientoAlmacenDetalleOrigen.Count - 1) + 1);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdProducto", IdProducto);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CodigoProveedor", CodigoProveedor);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "NombreProducto", NombreProducto);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Abreviatura", Abreviatura);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Cantidad", cantidadLectura);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CostoUnitario", 0);
                    ////gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "MontoTotal", 0);


                    ////if (pOperacion == Operacion.Modificar)
                    ////    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    ////else
                    ////    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    ////gvMovimientoAlmacenDetalle.FocusedColumn = gvMovimientoAlmacenDetalle.GetVisibleColumn(1);
                    ////gvMovimientoAlmacenDetalle.ShowEditor();

                    lblMensaje.Text = cantidadLectura.ToString();
                    lblMensaje2.Text = CodigoProveedor;
                }

                CargarLector111();
                //CalcularTotalDocumentos();
            }
        }


        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalChequeo = 0;
                decimal decTotalDiferencia = 0;

                for (int i = 0; i < gvMovimientoAlmacenDetalle.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(i, (gvMovimientoAlmacenDetalle.Columns["Cantidad"])));
                    decTotalChequeo = decTotalChequeo + Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(i, (gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"])));
                    decTotalDiferencia = decTotalDiferencia + Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(i, (gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"])));
                }

                txtTotalCantidad.EditValue = decTotal;
                txtTotalChequeo.EditValue = decTotalChequeo;
                txtTotalDiferencia.EditValue = decTotalDiferencia;

                //Botones y Etiquetas
                if (decTotalDiferencia == 0)
                {
                    lblMensaje.Text = "CHEQUEO COMPLETO";
                    lblMensaje.ForeColor = Color.Red;
                    txtTotalDiferencia.ForeColor = Color.Blue;
                    txtTotalDiferencia.BackColor = Color.LawnGreen;
                    btnIniciar.Visible = false;
                }

                if (decTotalChequeo > 0 && decTotalDiferencia > 0)
                {
                    lblMensaje.Text = "";
                    btnIniciar.Visible = false;
                    btnLectorBarras.Visible = true;
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularCantidad()
        {
            try
            {
                decimal decTotalDiferencia = 0;
                decimal decCantidad = 0;

                //if (e.Column.Caption == "CantidadChequeo")
                //{
                //if (decimal.Parse(e.Value.ToString()) > 0)
                //{
                //decCantidad = decimal.Parse(e.Value.ToString());
                //Calcular Total
                decCantidad = Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, (gvMovimientoAlmacenDetalle.Columns["decCantidad"])));
                decTotalDiferencia = decCantidad - Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, (gvMovimientoAlmacenDetalle.Columns["CantidadChequeo"])));
                gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, gvMovimientoAlmacenDetalle.Columns["CantidadDiferencia"], decTotalDiferencia);

                //}
                //}
                ////--calculamos el total general ------------
                //for (int i = 0; i < gvMovimientoAlmacenDetalle.RowCount; i++)
                //{
                //    decTotalGeneral = decTotalGeneral + Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(i, (gvMovimientoAlmacenDetalle.Columns["Total"])));
                //}
                //txtTotal.EditValue = decTotalGeneral;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrabarEmbalador()
        {
            try
            {
                if (Convert.ToInt32(txtNumeroBultos.EditValue) > 0)
                {
                    if (txtNumeroBultos.Text.Trim().Length == 0)
                    {
                        XtraMessageBox.Show("Ingresar cantidad de Bultos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroBultos.Focus();
                        return;
                    }

                    //MovimientoMovimientoAlmacenBE objBE_MovimientoMovimientoAlmacenPicking = null;
                    MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                    //Cargar con valores
                    objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objBE_MovimientoAlmacen.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
                    objBE_MovimientoAlmacen.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                    objBL_MovimientoAlmacen.ActualizaEmbalador(objBE_MovimientoAlmacen);

                    //XtraMessageBox.Show("Se guardó N° Bulto Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcMovmientoAlmacenDetalle_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        private void gvMovimientoAlmacenDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacenDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["CantidadDiferencia"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == 0)
                        {
                            e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public class CMovimientoAlmacenDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdMovimientoAlmacen { get; set; }
            public Int32 IdMovimientoAlmacenDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadChequeo { get; set; }
            public Int32 CantidadDiferencia { get; set; }
            public Decimal CostoUnitario { get; set; }
            public Decimal MontoTotal { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CMovimientoAlmacenDetalle()
            {

            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de finalizar y actualizar cantidad en el chequeo",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL():
                //objBL_MovimientoAlmacen.ActualizaChequeo();

                try
                {
                    Cursor = Cursors.WaitCursor;

                    if (!ValidarIngreso())
                    {

                        ////string Usuario = Parametros.strUsuarioLogin;
                        //frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        //frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        //frmAutoriza.ShowDialog();

                        //if (!frmAutoriza.Edita)
                        //{
                        //    return;
                        //}

                        //if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                        //{
                        //    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                        //    return;
                        //}

                        //Usuario = frmAutoriza.Usuario;
                        MovimientoAlmacenDetalleBL objBL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL();
                        MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                        MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                        objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                        objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(cboAlmacen.EditValue);
                        objMovimientoAlmacen.IdAlmacenDestino = cboAlmacenDestino.Text.Trim() == "" ? (int?)null : Convert.ToInt32(cboAlmacenDestino.EditValue);
                        objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                        objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;

                        //Registro de Compra Detalle
                        List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

                        foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
                        {
                            MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                            objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = IdMovimientoAlmacen;
                            objE_MovimientoAlmacenDetalle.Item = item.Item;
                            objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                            objE_MovimientoAlmacenDetalle.Cantidad = item.CantidadChequeo;
                            objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                            objE_MovimientoAlmacenDetalle.CantidadChequeo = item.CantidadChequeo; //add 1508
                            objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                            objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                            objE_MovimientoAlmacenDetalle.IdKardex = 0;
                            objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                            objE_MovimientoAlmacenDetalle.FlagEstado = true;
                            objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                            lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
                        }

                        //objBL_MovimientoAlmacen.Actualiza(lstMovimientoAlmacenDetalle);
                        objBL_MovimientoAlmacenDetalle.ActualizaChequeo(lstMovimientoAlmacenDetalle);
                        objBL_MovimientoAlmacen.ActualizaChequeo(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);

                        //Actualizar cierre de chequeado
                        objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                        objMovimientoAlmacen.FlagChequeo = true;
                        objMovimientoAlmacen.FlagCierre = true;
                        objBL_MovimientoAlmacen.ActualizaCierreChequeo(objMovimientoAlmacen);



                        ////Chequeador
                        //objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                        //objMovimientoAlmacen.IdChequeador = Convert.ToInt32(cboPersonaChequeo.EditValue);
                        //objMovimientoAlmacen.FlagChequeoFinalizado = true;
                        //objBL_MovimientoAlmacen.ActualizaChequeador(objMovimientoAlmacen);

                        ////Embalador
                        //GrabarEmbalador();


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


            //if (XtraMessageBox.Show("Desea finalizar el chequeo? Esta acción eliminará los códigos que no existan y actualizará la <cantidad chequeada> a la cantidad solicitada.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
            //    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //    objBE_MovimientoPedido.IdPedido = IdPedido;
            //    objBE_MovimientoPedido.Chequeado = true;
            //    objBL_MovimientoPedido.ActualizaCierreChequeado(objBE_MovimientoPedido);
            //    btnLectorBarras.Visible = false;
            //    btnIniciar.Visible = false;
            //    btnFinalizar.Visible = false;
            //    XtraMessageBox.Show("El chequeo se finalizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            //if (Convert.ToInt32(txtTotalDiferencia.EditValue) != 0)
            //{
            //    XtraMessageBox.Show("No se puede Finalizar el chequeo, Verificar que todos los códigos existan.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            ////MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
            ////MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            ////objBE_MovimientoPedido.IdPedido = IdPedido;
            ////objBE_MovimientoPedido.Chequeado = true;
            ////objBL_MovimientoPedido.ActualizaCierreChequeado(objBE_MovimientoPedido);
            ////btnLectorBarras.Visible = false;
            ////btnIniciar.Visible = false;
            ////btnFinalizar.Visible = false;
            ////XtraMessageBox.Show("El chequeo se finalizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            ////btnGrabar_Click(sender, e);
        }

        //private bool ValidarSalida()
        //{
        //    bool flag = false;
        //    string strMensaje = "No se pudo registrar:\n";

        //    if (Convert.ToInt32(txtTotalDiferencia.EditValue)==0)
        //    {
        //        strMensaje = strMensaje + "- La diferencia debe ser mayor a cero.\n";
        //        flag = true;
        //    }

        //    if (flag)
        //    {
        //        XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        Cursor = Cursors.Default;
        //    }
        //    return flag;
        //}
    }
}