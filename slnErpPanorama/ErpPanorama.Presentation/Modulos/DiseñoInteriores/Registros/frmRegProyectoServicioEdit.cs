using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegProyectoServicioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public List<CPedidoDetalle> mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();
        //public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();
        //public List<DescuentoClienteFechaCompraBE> mListaDescuentoClienteFechaCompra = new List<DescuentoClienteFechaCompraBE>();

        public List<CDis_DisenoFuncional> mListaDis_DisenoFuncionalOrigen = new List<CDis_DisenoFuncional>();
        public List<CDis_DisenoEstetico> mListaDis_DisenoEsteticoOrigen = new List<CDis_DisenoEstetico>();
        
        public List<CDis_VisitasEfectuadas> mListaDis_VisitasEfectuadasOrigen = new List<CDis_VisitasEfectuadas>();

        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
       private int IdClienteAsociado = 0;
      //  public int IdDis_ProyectoServicio = 0;
        private int IdSituacion = 0;

        int _IdDis_ProyectoServicio = 0;

        public int IdDis_ProyectoServicio
        {
            get { return _IdDis_ProyectoServicio; }
            set { _IdDis_ProyectoServicio = value; }
        }


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

        public frmRegProyectoServicioEdit()
        {
            InitializeComponent();
        }

        private void frmRegProyectoServicioEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            deFechaVencimiento.EditValue = DateTime.Now.AddDays(30);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboAsesor, new PersonaBL().SeleccionaAsesor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboTipoCasa, CargarTipoCasa(), "Descripcion", "Id", true);
            BSUtils.LoaderLook(cboForma, new Dis_FormaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Forma", "IdDis_Forma", true);
            BSUtils.LoaderLook(cboEstilo, new Dis_EstiloBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Estilo", "IdDis_Estilo", true);
            BSUtils.LoaderLook(cboVendedor2, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor2.EditValue = 0;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 92), "DescTablaElemento", "IdTablaElemento", true);  //Motivo VISITA
            cboMotivo.EditValue = 553;

            if (pOperacion == Operacion.Nuevo)
            {
                ObtenerCorrelativo();

                this.Text = "Proyecto de Servicio - Nuevo";
                //Especificamos los datos del cliente general
                IdCliente = Parametros.intIdClienteGeneral;
                IdTipoCliente = Parametros.intTipClienteFinal;
                txtNumeroDocumento.Text = Parametros.strNumeroCliente;
                txtDescCliente.Text = Parametros.strDescCliente;
                IdClasificacionCliente = Parametros.intClasico;
                txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
                txtDireccion.Text = Parametros.strDireccion;
                txtTipoCambio.EditValue = Parametros.dmlTCMinorista;
                IdSituacion = Parametros.intSITProyectoServicioEvaluacion;
                txtPago.EditValue = String.Format("{0:#,##0.00}", 342.84);
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Proyecto de Servicio - Modificar";

                Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().Selecciona(IdDis_ProyectoServicio);

                if (objE_Dis_ProyectoServicio != null)
                {
                    txtNumero.Text = objE_Dis_ProyectoServicio.Numero;
                    deFecha.EditValue = objE_Dis_ProyectoServicio.Fecha;
                    deFechaVencimiento.EditValue = objE_Dis_ProyectoServicio.FechaVencimiento;
                    IdCliente = objE_Dis_ProyectoServicio.IdCliente;
                    txtNumeroDocumento.EditValue = objE_Dis_ProyectoServicio.NumeroDocumento;
                    txtDescCliente.EditValue = objE_Dis_ProyectoServicio.DescCliente;
                    txtDireccion.EditValue = objE_Dis_ProyectoServicio.Direccion;
                    cboAsesor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                    cboVendedor2.EditValue = objE_Dis_ProyectoServicio.IdVendedor;
                    cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                    txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                    txtRutaArchivo.EditValue = objE_Dis_ProyectoServicio.RutaArchivo;
                    txtObservaciones.EditValue = objE_Dis_ProyectoServicio.Observacion;
                    cboTipoCasa.Text = objE_Dis_ProyectoServicio.DescTipoCasa;  //-------------------
                    txtAmbiente.Text = objE_Dis_ProyectoServicio.DescAmbiente;
                    txtPiso.EditValue = objE_Dis_ProyectoServicio.Piso;
                    txtObjetivos.Text = objE_Dis_ProyectoServicio.Objetivos;
                    txtIluminacion.Text = objE_Dis_ProyectoServicio.Iluminacion;
                    txtAcustica.Text = objE_Dis_ProyectoServicio.Acustica;
                    txtArea.Text = objE_Dis_ProyectoServicio.Area;
                    cboForma.EditValue = objE_Dis_ProyectoServicio.IdDis_Forma;
                    cboEstilo.EditValue = objE_Dis_ProyectoServicio.IdDis_Estilo;//-----------------
                    IdSituacion = objE_Dis_ProyectoServicio.IdSituacion;
                    deFechaVisita.EditValue = objE_Dis_ProyectoServicio.FechaVisita;
                    txtPago.EditValue = objE_Dis_ProyectoServicio.PagoAsesoria;
                    cboMotivo.EditValue = objE_Dis_ProyectoServicio.IdMotivo;

                    BloquearCabera();
                }
            }
            CargarRutaArchivo();
            CargaDis_DisenoFuncional();
            CargaDis_DisenoEstetico();
            CargaDis_VisitasEfectuadas();
        }

        private void frmRegProyectoServicioEdit_Shown(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;
                    }
                    else
                    {
                        cboMoneda.EditValue = Parametros.intDolares;
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    }

                    //agregado para mostrar tipo cambio
                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                    {
                        txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMayorista).ToString();
                    }
                    else
                    {
                        txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMinorista).ToString();
                    }


                    //Direccion de Carpeta
                    txtRutaArchivo.Text = pParametroBE.Valor + "PROY_"+ txtNumero.Text + "_" + txtNumeroDocumento.Text.Trim() ;


                    //Cliente Asociado
                    //CargarClienteAsociado(); 
                    //cboTipoCasa.Select();
                    
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_ProyectoServicioBL objBL_Dis_ProyectoServicio = new Dis_ProyectoServicioBL();
                    Dis_ProyectoServicioBE objDis_ProyectoServicio = new Dis_ProyectoServicioBE();
                    objDis_ProyectoServicio.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                    objDis_ProyectoServicio.Periodo = Parametros.intPeriodo;
                    objDis_ProyectoServicio.Numero = txtNumero.Text;
                    objDis_ProyectoServicio.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString()); 
                    objDis_ProyectoServicio.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objDis_ProyectoServicio.IdCliente = IdCliente;
                    objDis_ProyectoServicio.NumeroDocumento = txtNumeroDocumento.Text;
                    objDis_ProyectoServicio.DescCliente = txtDescCliente.Text;
                    objDis_ProyectoServicio.Direccion = txtDireccion.Text;
                    objDis_ProyectoServicio.IdAsesor = Convert.ToInt32(cboAsesor.EditValue);
                    objDis_ProyectoServicio.IdVendedor = Convert.ToInt32(cboVendedor2.EditValue);
                    objDis_ProyectoServicio.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDis_ProyectoServicio.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDis_ProyectoServicio.Importe = 0;
                    objDis_ProyectoServicio.RutaArchivo = txtRutaArchivo.Text.Trim();
                    objDis_ProyectoServicio.Observacion = txtObservaciones.Text.Trim();
                    objDis_ProyectoServicio.IdSituacion = IdSituacion;
                    objDis_ProyectoServicio.DescTipoCasa = cboTipoCasa.Text; //-------------------
                    objDis_ProyectoServicio.DescAmbiente = txtAmbiente.Text.Trim();
                    objDis_ProyectoServicio.Piso = Convert.ToInt32(txtPiso.EditValue);
                    objDis_ProyectoServicio.Objetivos = txtObjetivos.Text.Trim();
                    objDis_ProyectoServicio.Iluminacion = txtIluminacion.Text.Trim();
                    objDis_ProyectoServicio.Acustica = txtAcustica.Text.Trim();
                    objDis_ProyectoServicio.Area = txtArea.Text.Trim();
                    objDis_ProyectoServicio.IdDis_Forma = Convert.ToInt32(cboForma.EditValue);
                    objDis_ProyectoServicio.IdDis_Estilo = Convert.ToInt32(cboEstilo.EditValue);//-----------------
                    objDis_ProyectoServicio.FechaVisita = deFechaVisita.EditValue == null? (DateTime?)null :Convert.ToDateTime(deFechaVisita.Text);
                    objDis_ProyectoServicio.PagoAsesoria = Convert.ToDecimal(txtPago.EditValue);
                    objDis_ProyectoServicio.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);

                    //objDis_ProyectoServicio.FechaVisita = deFechaVisita.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaVisita.DateTime.ToShortDateString());
                    //if(deFechaVisita.Text == "")
                    //    objDis_ProyectoServicio.FechaVisita  = null;
                    //else
                    //    objDis_ProyectoServicio.FechaVisita = Convert.ToDateTime(deFechaVisita.DateTime.ToShortDateString());

                    objDis_ProyectoServicio.FlagEstado = true;
                    objDis_ProyectoServicio.Usuario = Parametros.strUsuarioLogin;
                    objDis_ProyectoServicio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_ProyectoServicio.IdEmpresa = Parametros.intEmpresaId;
                    

                    //Diseño Funcional Detalle
                    List<Dis_DisenoFuncionalBE> lstDis_DisenoFuncional = new List<Dis_DisenoFuncionalBE>();

                    foreach (var item in mListaDis_DisenoFuncionalOrigen)
                    {
                        Dis_DisenoFuncionalBE objE_Dis_DisenoFuncional = new Dis_DisenoFuncionalBE();
                        objE_Dis_DisenoFuncional.IdDis_ProyectoServicio = item.IdDis_ProyectoServicio;
                        objE_Dis_DisenoFuncional.IdDis_DisenoFuncional = item.IdDis_DisenoFuncional;
                        objE_Dis_DisenoFuncional.IdDis_Ambiente = item.IdDis_Ambiente;
                        objE_Dis_DisenoFuncional.DescActividad = item.DescActividad;
                        objE_Dis_DisenoFuncional.IdDis_Pieza = item.IdDis_Pieza;
                        objE_Dis_DisenoFuncional.Cantidad = item.Cantidad;
                        objE_Dis_DisenoFuncional.IdMaterial = item.IdMaterial;
                        objE_Dis_DisenoFuncional.IdDis_Estilo = item.IdDis_Estilo;
                        objE_Dis_DisenoFuncional.IdDis_Forma = item.IdDis_Forma;
                        objE_Dis_DisenoFuncional.DescVolumen = item.DescVolumen;
                        objE_Dis_DisenoFuncional.DescTextura = item.DescTextura;
                        objE_Dis_DisenoFuncional.Observacion = item.Observacion;
                        objE_Dis_DisenoFuncional.FlagEstado = true;
                        objE_Dis_DisenoFuncional.TipoOper = item.TipoOper;
                        lstDis_DisenoFuncional.Add(objE_Dis_DisenoFuncional);
                    }

                    //Diseño Estetico Detalle
                    List<Dis_DisenoEsteticoBE> lstDis_DisenoEstetico = new List<Dis_DisenoEsteticoBE>();

                    foreach (var item in mListaDis_DisenoEsteticoOrigen)
                    {
                        Dis_DisenoEsteticoBE objE_Dis_DisenoEstetico = new Dis_DisenoEsteticoBE();
                        objE_Dis_DisenoEstetico.IdDis_ProyectoServicio = item.IdDis_ProyectoServicio;
                        objE_Dis_DisenoEstetico.IdDis_DisenoEstetico = item.IdDis_DisenoEstetico;
                        objE_Dis_DisenoEstetico.Objetivos = item.Objetivos;
                        objE_Dis_DisenoEstetico.IdDis_Estilo = item.IdDis_Estilo;
                        objE_Dis_DisenoEstetico.IdDis_Forma = item.IdDis_Forma;
                        objE_Dis_DisenoEstetico.DescVolumen = item.DescVolumen;
                        objE_Dis_DisenoEstetico.DescTextura = item.DescTextura;
                        objE_Dis_DisenoEstetico.IdMaterial = item.IdMaterial;
                        objE_Dis_DisenoEstetico.IdDis_TipoColor = item.IdDis_TipoColor;
                        objE_Dis_DisenoEstetico.FlagEstado = true;
                        objE_Dis_DisenoEstetico.TipoOper = item.TipoOper;
                        lstDis_DisenoEstetico.Add(objE_Dis_DisenoEstetico);
                    }

                    int wIdDis_ProyectoServicio = 0;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        wIdDis_ProyectoServicio = objBL_Dis_ProyectoServicio.Inserta(objDis_ProyectoServicio, lstDis_DisenoFuncional, lstDis_DisenoEstetico);
                    }
                    else
                    {
                        objBL_Dis_ProyectoServicio.Actualiza(objDis_ProyectoServicio, lstDis_DisenoFuncional, lstDis_DisenoEstetico);
                    }

                    //Visitas realizadas
                    List<Dis_DisenoVisitasRealizadasBE> lstDisVisitasRealizadas = new List<Dis_DisenoVisitasRealizadasBE>();
                    foreach (var item in mListaDis_VisitasEfectuadasOrigen)
                    {
                        Dis_DisenoVisitasRealizadasBE objE_VisitasRealizadas = new Dis_DisenoVisitasRealizadasBE();
                        objE_VisitasRealizadas.IdDis_ProyectoServicio = pOperacion == Operacion.Nuevo ? wIdDis_ProyectoServicio : IdDis_ProyectoServicio;       // IdDis_ProyectoServicio;  // IdDis_ProyectoServicio;
                        objE_VisitasRealizadas.IdAgendaVisita = item.IdAgendaVisita;
                        objE_VisitasRealizadas.TipoOper = item.TipoOper == 0 ? 1 : item.TipoOper;

                        lstDisVisitasRealizadas.Add(objE_VisitasRealizadas);
                    }

                    Dis_DisenoVisitasRealizadasBL objBL_VisitaRealizadas = new Dis_DisenoVisitasRealizadasBL();
                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_VisitaRealizadas.Inserta  . .InsertaCuentaBancoProveedor(lstDisVisitasRealizadas);
                    }
                    else
                        //objBL_VisitaRealizadas.InsertaCuentaBancoProveedor(lstCuentaBcoProveedor);


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

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = txtRutaArchivo.Text;
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                txtRutaArchivo.Text = f.SelectedPath + @"\";
                Cursor = Cursors.Default;
            }
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


                    FileStream FS = new FileStream(txtRutaArchivo.Text.Trim() + "\\" + cboAsesor.Text + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
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

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    IdCliente = objE_Cliente.IdCliente;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                    txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NumDireccion;
                    IdTipoCliente = objE_Cliente.IdTipoCliente;
                    IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;
                    }
                    else
                    {
                        cboMoneda.EditValue = Parametros.intDolares;
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                    }

                    //Direccion de Carpeta
                    txtRutaArchivo.Text = pParametroBE.Valor + "PROY_" + txtNumero.Text + "_" + txtNumeroDocumento.Text.Trim();

                }
                else
                {
                    XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnNuevoFuncional_Click(object sender, EventArgs e)
        {
            this.nuevoFuncionalToolStripMenuItem_Click(sender, e);
        }

        private void btnEditarFuncional_Click(object sender, EventArgs e)
        {
            this.modificarFuncionalToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminarFuncional_Click(object sender, EventArgs e)
        {
            this.eliminarFuncionalToolStripMenuItem_Click(sender, e);
        }

        private void nuevoFuncionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegProyectoServicioFuncionalEdit movDetalle = new frmRegProyectoServicioFuncionalEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDis_DisenoFuncionalOrigen.Count == 0)
                        {
                            gvDis_DisenoFuncional.AddNewRow();
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_ProyectoServicio", movDetalle.oBE.IdDis_ProyectoServicio);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_DisenoFuncional", movDetalle.oBE.IdDis_DisenoFuncional);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Ambiente", movDetalle.oBE.IdDis_Ambiente);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Ambiente", movDetalle.oBE.DescDis_Ambiente);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescActividad", movDetalle.oBE.DescActividad);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Pieza", movDetalle.oBE.IdDis_Pieza);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Pieza", movDetalle.oBE.DescDis_Pieza);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Estilo", movDetalle.oBE.IdDis_Estilo);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Estilo", movDetalle.oBE.DescDis_Estilo);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Forma", movDetalle.oBE.IdDis_Forma);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Forma", movDetalle.oBE.DescDis_Forma);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescVolumen", movDetalle.oBE.DescVolumen);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescTextura", movDetalle.oBE.DescTextura);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_DisenoFuncional.UpdateCurrentRow();

                            return;

                        }
                        if (mListaDis_DisenoFuncionalOrigen.Count > 0)
                        {
                            //var Buscar = mListaDis_DisenoFuncionalOrigen.Where(oB => oB.IdDis_Ambiente == movDetalle.oBE.IdDis_Ambiente).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El Ambiente ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            gvDis_DisenoFuncional.AddNewRow();
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_ProyectoServicio", movDetalle.oBE.IdDis_ProyectoServicio);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_DisenoFuncional", movDetalle.oBE.IdDis_DisenoFuncional);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Ambiente", movDetalle.oBE.IdDis_Ambiente);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Ambiente", movDetalle.oBE.DescDis_Ambiente);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescActividad", movDetalle.oBE.DescActividad);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Pieza", movDetalle.oBE.IdDis_Pieza);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Pieza", movDetalle.oBE.DescDis_Pieza);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Estilo", movDetalle.oBE.IdDis_Estilo);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Estilo", movDetalle.oBE.DescDis_Estilo);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "IdDis_Forma", movDetalle.oBE.IdDis_Forma);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescDis_Forma", movDetalle.oBE.DescDis_Forma);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescVolumen", movDetalle.oBE.DescVolumen);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "DescTextura", movDetalle.oBE.DescTextura);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvDis_DisenoFuncional.SetRowCellValue(gvDis_DisenoFuncional.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_DisenoFuncional.UpdateCurrentRow();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarFuncionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaDis_DisenoFuncionalOrigen.Count > 0)
            {
                int xposition = 0;

                Dis_DisenoFuncionalBE objDis_Ambiente = new Dis_DisenoFuncionalBE();
                objDis_Ambiente.IdDis_ProyectoServicio = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString());
                objDis_Ambiente.IdDis_DisenoFuncional = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_DisenoFuncional").ToString());
                objDis_Ambiente.IdDis_Ambiente = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_Ambiente").ToString());
                objDis_Ambiente.DescActividad = gvDis_DisenoFuncional.GetFocusedRowCellValue("DescActividad").ToString();
                objDis_Ambiente.IdDis_Pieza = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_Pieza").ToString());
                objDis_Ambiente.Cantidad = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("Cantidad").ToString());
                objDis_Ambiente.IdMaterial = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdMaterial").ToString());
                objDis_Ambiente.IdDis_Estilo = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_Estilo").ToString());
                objDis_Ambiente.IdDis_Forma = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_Forma").ToString());
                objDis_Ambiente.DescVolumen = gvDis_DisenoFuncional.GetFocusedRowCellValue("DescVolumen").ToString();
                objDis_Ambiente.DescTextura = gvDis_DisenoFuncional.GetFocusedRowCellValue("DescTextura").ToString();
                objDis_Ambiente.Observacion = gvDis_DisenoFuncional.GetFocusedRowCellValue("Observacion").ToString();


                //objDis_Ambiente.FlagEstado = Convert.ToBoolean(gvDis_DisenoFuncional.GetFocusedRowCellValue("FlagEstado").ToString());

                frmRegProyectoServicioFuncionalEdit objManDis_AmbienteEdit = new frmRegProyectoServicioFuncionalEdit();
                objManDis_AmbienteEdit.pOperacion = frmRegProyectoServicioFuncionalEdit.Operacion.Modificar;
                objManDis_AmbienteEdit.IdDis_ProyectoServicio = objDis_Ambiente.IdDis_ProyectoServicio;
                objManDis_AmbienteEdit.IdDis_DisenoFuncional = objDis_Ambiente.IdDis_DisenoFuncional;
                objManDis_AmbienteEdit.oBE = objDis_Ambiente;
                objManDis_AmbienteEdit.StartPosition = FormStartPosition.CenterParent;
                //objManDis_AmbienteEdit.ShowDialog();


                if (objManDis_AmbienteEdit.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDis_DisenoFuncional.FocusedRowHandle;

                    if (objManDis_AmbienteEdit.oBE != null)
                    {
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_ProyectoServicio", objManDis_AmbienteEdit.oBE.IdDis_ProyectoServicio);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_DisenoFuncional", objManDis_AmbienteEdit.oBE.IdDis_DisenoFuncional);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_Ambiente", objManDis_AmbienteEdit.oBE.IdDis_Ambiente);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescDis_Ambiente", objManDis_AmbienteEdit.oBE.DescDis_Ambiente);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescActividad", objManDis_AmbienteEdit.oBE.DescActividad);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_Pieza", objManDis_AmbienteEdit.oBE.IdDis_Pieza);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescDis_Pieza", objManDis_AmbienteEdit.oBE.DescDis_Pieza);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "Cantidad", objManDis_AmbienteEdit.oBE.Cantidad);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdMaterial", objManDis_AmbienteEdit.oBE.IdMaterial);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescMaterial", objManDis_AmbienteEdit.oBE.DescMaterial);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_Estilo", objManDis_AmbienteEdit.oBE.IdDis_Estilo);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescDis_Estilo", objManDis_AmbienteEdit.oBE.DescDis_Estilo);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "IdDis_Forma", objManDis_AmbienteEdit.oBE.IdDis_Forma);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescDis_Forma", objManDis_AmbienteEdit.oBE.DescDis_Forma);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescVolumen", objManDis_AmbienteEdit.oBE.DescVolumen);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "DescTextura", objManDis_AmbienteEdit.oBE.DescTextura);
                        gvDis_DisenoFuncional.SetRowCellValue(xposition, "Observacion", objManDis_AmbienteEdit.oBE.Observacion);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvDis_DisenoFuncional.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvDis_DisenoFuncional.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvDis_DisenoFuncional.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDis_DisenoFuncional.UpdateCurrentRow();

                        //CalculaTotales();

                    }
                }
            }
        }

        private void eliminarFuncionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDis_DisenoFuncionalOrigen.Count > 0)
                {
                    if (int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()) != 0)
                    {
                        int IdDis_DisenoFuncional = 0;
                        if (gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_DisenoFuncional") != null)
                            IdDis_DisenoFuncional = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("IdDis_DisenoFuncional").ToString());
                        int Item = 0;
                        if (gvDis_DisenoFuncional.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDis_DisenoFuncional.GetFocusedRowCellValue("Item").ToString());
                        Dis_DisenoFuncionalBE objBE_Dis_DisenoFuncional = new Dis_DisenoFuncionalBE();
                        objBE_Dis_DisenoFuncional.IdDis_DisenoFuncional = IdDis_DisenoFuncional;
                        objBE_Dis_DisenoFuncional.IdEmpresa = Parametros.intEmpresaId;
                        objBE_Dis_DisenoFuncional.Usuario = Parametros.strUsuarioLogin;
                        objBE_Dis_DisenoFuncional.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        Dis_DisenoFuncionalBL objBL_Dis_DisenoFuncional = new Dis_DisenoFuncionalBL();
                        objBL_Dis_DisenoFuncional.Elimina(objBE_Dis_DisenoFuncional);
                        gvDis_DisenoFuncional.DeleteRow(gvDis_DisenoFuncional.FocusedRowHandle);
                        gvDis_DisenoFuncional.RefreshData();

                    }
                    else
                    {
                        gvDis_DisenoFuncional.DeleteRow(gvDis_DisenoFuncional.FocusedRowHandle);
                        gvDis_DisenoFuncional.RefreshData();
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void nuevoEsteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegProyectoServicioEsteticoEdit movDetalle = new frmRegProyectoServicioEsteticoEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDis_DisenoEsteticoOrigen.Count == 0)
                        {
                            gvDis_DisenoEstetico.AddNewRow();
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_ProyectoServicio", movDetalle.oBE.IdDis_ProyectoServicio);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_DisenoEstetico", movDetalle.oBE.IdDis_DisenoEstetico);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "Objetivos", movDetalle.oBE.Objetivos);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_Estilo", movDetalle.oBE.IdDis_Estilo);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_Estilo", movDetalle.oBE.DescDis_Estilo);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_Forma", movDetalle.oBE.IdDis_Forma);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_Forma", movDetalle.oBE.DescDis_Forma);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescVolumen", movDetalle.oBE.DescVolumen);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescTextura", movDetalle.oBE.DescTextura);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_TipoColor", movDetalle.oBE.IdDis_TipoColor);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_TipoColor", movDetalle.oBE.DescDis_TipoColor);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_DisenoEstetico.UpdateCurrentRow();

                            return;

                        }
                        if (mListaDis_DisenoEsteticoOrigen.Count > 0)
                        {
                            //var Buscar = mListaDis_DisenoEsteticoOrigen.Where(oB => oB.IdDis_Ambiente == movDetalle.oBE.IdDis_Ambiente).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El Ambiente ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            gvDis_DisenoEstetico.AddNewRow();
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_ProyectoServicio", movDetalle.oBE.IdDis_ProyectoServicio);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_DisenoEstetico", movDetalle.oBE.IdDis_DisenoEstetico);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "Objetivos", movDetalle.oBE.Objetivos);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_Estilo", movDetalle.oBE.IdDis_Estilo);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_Estilo", movDetalle.oBE.DescDis_Estilo);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_Forma", movDetalle.oBE.IdDis_Forma);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_Forma", movDetalle.oBE.DescDis_Forma);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescVolumen", movDetalle.oBE.DescVolumen);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescTextura", movDetalle.oBE.DescTextura);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdMaterial", movDetalle.oBE.IdMaterial);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescMaterial", movDetalle.oBE.DescMaterial);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "IdDis_TipoColor", movDetalle.oBE.IdDis_TipoColor);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "DescDis_TipoColor", movDetalle.oBE.DescDis_TipoColor);
                            gvDis_DisenoEstetico.SetRowCellValue(gvDis_DisenoEstetico.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDis_DisenoEstetico.UpdateCurrentRow();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarEsteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaDis_DisenoEsteticoOrigen.Count > 0)
            {
                int xposition = 0;

                Dis_DisenoEsteticoBE objDis_Ambiente = new Dis_DisenoEsteticoBE();
                objDis_Ambiente.IdDis_ProyectoServicio = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString());
                objDis_Ambiente.IdDis_DisenoEstetico = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_DisenoEstetico").ToString());
                objDis_Ambiente.Objetivos = gvDis_DisenoEstetico.GetFocusedRowCellValue("Objetivos").ToString();
                objDis_Ambiente.IdDis_Estilo = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_Estilo").ToString());
                objDis_Ambiente.IdDis_Forma = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_Forma").ToString());
                objDis_Ambiente.DescVolumen = gvDis_DisenoEstetico.GetFocusedRowCellValue("DescVolumen").ToString();
                objDis_Ambiente.DescTextura = gvDis_DisenoEstetico.GetFocusedRowCellValue("DescTextura").ToString();
                objDis_Ambiente.IdMaterial = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdMaterial").ToString());
                objDis_Ambiente.IdDis_TipoColor = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_TipoColor").ToString());

                //objDis_Ambiente.FlagEstado = Convert.ToBoolean(gvDis_DisenoEstetico.GetFocusedRowCellValue("FlagEstado").ToString());

                frmRegProyectoServicioEsteticoEdit objManDis_AmbienteEdit = new frmRegProyectoServicioEsteticoEdit();
                objManDis_AmbienteEdit.pOperacion = frmRegProyectoServicioEsteticoEdit.Operacion.Modificar;
                objManDis_AmbienteEdit.IdDis_ProyectoServicio = objDis_Ambiente.IdDis_ProyectoServicio;
                objManDis_AmbienteEdit.IdDis_DisenoEstetico = objDis_Ambiente.IdDis_DisenoEstetico;
                objManDis_AmbienteEdit.oBE = objDis_Ambiente;
                objManDis_AmbienteEdit.StartPosition = FormStartPosition.CenterParent;
                //objManDis_AmbienteEdit.ShowDialog();


                if (objManDis_AmbienteEdit.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDis_DisenoEstetico.FocusedRowHandle;

                    if (objManDis_AmbienteEdit.oBE != null)
                    {

                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdDis_ProyectoServicio", objManDis_AmbienteEdit.oBE.IdDis_ProyectoServicio);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdDis_DisenoEstetico", objManDis_AmbienteEdit.oBE.IdDis_DisenoEstetico);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "Objetivos", objManDis_AmbienteEdit.oBE.Objetivos);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdDis_Estilo", objManDis_AmbienteEdit.oBE.IdDis_Estilo);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescDis_Estilo", objManDis_AmbienteEdit.oBE.DescDis_Estilo);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdDis_Forma", objManDis_AmbienteEdit.oBE.IdDis_Forma);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescDis_Forma", objManDis_AmbienteEdit.oBE.DescDis_Forma);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescVolumen", objManDis_AmbienteEdit.oBE.DescVolumen);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescTextura", objManDis_AmbienteEdit.oBE.DescTextura);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdMaterial", objManDis_AmbienteEdit.oBE.IdMaterial);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescMaterial", objManDis_AmbienteEdit.oBE.DescMaterial);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "IdDis_TipoColor", objManDis_AmbienteEdit.oBE.IdDis_TipoColor);
                        gvDis_DisenoEstetico.SetRowCellValue(xposition, "DescDis_TipoColor", objManDis_AmbienteEdit.oBE.DescDis_TipoColor);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvDis_DisenoEstetico.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvDis_DisenoEstetico.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvDis_DisenoEstetico.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDis_DisenoEstetico.UpdateCurrentRow();

                        //CalculaTotales();

                    }
                }
            }
        }

        private void eliminarEsteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDis_DisenoEsteticoOrigen.Count > 0)
                {
                    if (int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()) != 0)
                    {
                        int IdDis_DisenoEstetico = 0;
                        if (gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_DisenoEstetico") != null)
                            IdDis_DisenoEstetico = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("IdDis_DisenoEstetico").ToString());
                        int Item = 0;
                        if (gvDis_DisenoEstetico.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDis_DisenoEstetico.GetFocusedRowCellValue("Item").ToString());
                        Dis_DisenoEsteticoBE objBE_Dis_DisenoEstetico = new Dis_DisenoEsteticoBE();
                        objBE_Dis_DisenoEstetico.IdDis_DisenoEstetico = IdDis_DisenoEstetico;
                        objBE_Dis_DisenoEstetico.IdEmpresa = Parametros.intEmpresaId;
                        objBE_Dis_DisenoEstetico.Usuario = Parametros.strUsuarioLogin;
                        objBE_Dis_DisenoEstetico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        Dis_DisenoEsteticoBL objBL_Dis_DisenoEstetico = new Dis_DisenoEsteticoBL();
                        objBL_Dis_DisenoEstetico.Elimina(objBE_Dis_DisenoEstetico);
                        gvDis_DisenoEstetico.DeleteRow(gvDis_DisenoEstetico.FocusedRowHandle);
                        gvDis_DisenoEstetico.RefreshData();

                    }
                    else
                    {
                        gvDis_DisenoEstetico.DeleteRow(gvDis_DisenoEstetico.FocusedRowHandle);
                        gvDis_DisenoEstetico.RefreshData();
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoEstetico_Click(object sender, EventArgs e)
        {
            this.nuevoEsteticoToolStripMenuItem_Click(sender, e);
        }

        private void btnEditarEstetico_Click(object sender, EventArgs e)
        {
            this.modificarEsteticoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminarEstetico_Click(object sender, EventArgs e)
        {
            this.eliminarEsteticoToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region "Metodos"

        private DataTable CargarTipoCasa()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "CASA";
            dr["Descripcion"] = "CASA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "DUPLEX";
            dr["Descripcion"] = "DUPLEX";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "DEPARTAMENTO";
            dr["Descripcion"] = "DEPARTAMENTO";
            dt.Rows.Add(dr);
            return dt;
        }

        private void CargarRutaArchivo()
        {
            pParametroBE = new ParametroBL().Selecciona("ProyectoServicioUbicacion");
            //txtRutaArchivo.Text = pParametroBE.Valor;
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocProyectoServicio, Parametros.intPeriodo);
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

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescCliente.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar el nombre de cliente.\n";
                flag = true;
            }

            if (deFechaVisita.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la Fecha de Visita.\n";
                flag = true;
            }

            if (txtPiso.Text == "0")
            {
                strMensaje = strMensaje + "- Ingresar el N° de Piso.\n";
                flag = true;
            }

            //if (mListaDis_DisenoFuncionalOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- No se puede generar mientras no haya Diseño Funcional.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaDis_DisenoFuncional()
        {
            List<Dis_DisenoFuncionalBE> lstTmpDis_DisenoFuncional = null;
            lstTmpDis_DisenoFuncional = new Dis_DisenoFuncionalBL().ListaTodosActivo(IdDis_ProyectoServicio);

            foreach (Dis_DisenoFuncionalBE item in lstTmpDis_DisenoFuncional)
            {
                CDis_DisenoFuncional objE_Dis_DisenoFuncional = new CDis_DisenoFuncional();
                objE_Dis_DisenoFuncional.IdDis_DisenoFuncional = item.IdDis_DisenoFuncional;
                objE_Dis_DisenoFuncional.IdDis_ProyectoServicio = item.IdDis_ProyectoServicio;
                objE_Dis_DisenoFuncional.IdDis_Ambiente = item.IdDis_Ambiente;
                objE_Dis_DisenoFuncional.DescDis_Ambiente = item.DescDis_Ambiente;
                objE_Dis_DisenoFuncional.DescActividad = item.DescActividad;
                objE_Dis_DisenoFuncional.IdDis_Pieza = item.IdDis_Pieza;
                objE_Dis_DisenoFuncional.DescDis_Pieza = item.DescDis_Pieza;
                objE_Dis_DisenoFuncional.Cantidad = item.Cantidad;
                objE_Dis_DisenoFuncional.IdMaterial = item.IdMaterial;
                objE_Dis_DisenoFuncional.DescMaterial = item.DescMaterial;
                objE_Dis_DisenoFuncional.IdDis_Estilo = item.IdDis_Estilo;
                objE_Dis_DisenoFuncional.DescDis_Estilo = item.DescDis_Estilo;
                objE_Dis_DisenoFuncional.IdDis_Forma = item.IdDis_Forma;
                objE_Dis_DisenoFuncional.DescDis_Forma = item.DescDis_Forma;
                objE_Dis_DisenoFuncional.DescVolumen = item.DescVolumen;
                objE_Dis_DisenoFuncional.DescTextura = item.DescTextura;
                objE_Dis_DisenoFuncional.Observacion = item.Observacion;
                objE_Dis_DisenoFuncional.TipoOper = item.TipoOper;
                mListaDis_DisenoFuncionalOrigen.Add(objE_Dis_DisenoFuncional);
            }

            bsListadoFuncional.DataSource = mListaDis_DisenoFuncionalOrigen;
            gcDis_DisenoFuncional.DataSource = bsListadoFuncional;
            gcDis_DisenoFuncional.RefreshDataSource();

            //CalculaTotales();
        }

        private void CargaDis_DisenoEstetico()
        {
            List<Dis_DisenoEsteticoBE> lstTmpDis_DisenoEstetico = null;
            lstTmpDis_DisenoEstetico = new Dis_DisenoEsteticoBL().ListaTodosActivo(IdDis_ProyectoServicio);

            foreach (Dis_DisenoEsteticoBE item in lstTmpDis_DisenoEstetico)
            {
                CDis_DisenoEstetico objE_Dis_DisenoEstetico = new CDis_DisenoEstetico();
                objE_Dis_DisenoEstetico.IdDis_DisenoEstetico = item.IdDis_DisenoEstetico;
                objE_Dis_DisenoEstetico.IdDis_ProyectoServicio = item.IdDis_ProyectoServicio;
                objE_Dis_DisenoEstetico.Objetivos = item.Objetivos;
                objE_Dis_DisenoEstetico.IdDis_Estilo = item.IdDis_Estilo;
                objE_Dis_DisenoEstetico.DescDis_Estilo = item.DescDis_Estilo;
                objE_Dis_DisenoEstetico.IdDis_Forma = item.IdDis_Forma;
                objE_Dis_DisenoEstetico.DescDis_Forma = item.DescDis_Forma;
                objE_Dis_DisenoEstetico.DescVolumen = item.DescVolumen;
                objE_Dis_DisenoEstetico.DescTextura = item.DescTextura; 
                objE_Dis_DisenoEstetico.IdMaterial = item.IdMaterial;
                objE_Dis_DisenoEstetico.DescMaterial = item.DescMaterial;
                objE_Dis_DisenoEstetico.IdDis_TipoColor = item.IdDis_TipoColor;
                objE_Dis_DisenoEstetico.DescDis_TipoColor = item.DescDis_TipoColor;
                objE_Dis_DisenoEstetico.TipoOper = item.TipoOper;
                mListaDis_DisenoEsteticoOrigen.Add(objE_Dis_DisenoEstetico);
            }

            bsListadoEstetico.DataSource = mListaDis_DisenoEsteticoOrigen;
            gcDis_DisenoEstetico.DataSource = bsListadoEstetico;
            gcDis_DisenoEstetico.RefreshDataSource();

            //CalculaTotales();
        }

        private void CargaDis_VisitasEfectuadas()
        {
            List<Dis_DisenoVisitasRealizadasBE> lstTmpDis_DisenoVE = null;
            lstTmpDis_DisenoVE = new Dis_DisenoVisitasRealizadasBL().ListaTodosActivo(IdDis_ProyectoServicio);

            foreach (Dis_DisenoVisitasRealizadasBE item in lstTmpDis_DisenoVE)
            {
                CDis_VisitasEfectuadas objE_Dis_DisenoVisitasEfectuadas = new CDis_VisitasEfectuadas();

                objE_Dis_DisenoVisitasEfectuadas.IdDis_ProyectoServicio = item.IdDis_ProyectoServicio;
                objE_Dis_DisenoVisitasEfectuadas.IdAgendaVisita = item.IdAgendaVisita;
                objE_Dis_DisenoVisitasEfectuadas.NumAgendaVisita = item.NumAgendaVisita;
                objE_Dis_DisenoVisitasEfectuadas.FechaAgenda = item.FechaAgenda;
                objE_Dis_DisenoVisitasEfectuadas.HoraInicio = item.HoraInicio;
                objE_Dis_DisenoVisitasEfectuadas.HoraFin = item.HoraFin;

                objE_Dis_DisenoVisitasEfectuadas.Disenador = item.Disenador;
                objE_Dis_DisenoVisitasEfectuadas.Agenda = item.Agenda;
                objE_Dis_DisenoVisitasEfectuadas.MotivoVisita = item.MotivoVisita;
                objE_Dis_DisenoVisitasEfectuadas.PrecioVisita = item.PrecioVisita;
                objE_Dis_DisenoVisitasEfectuadas.Situacion = item.Situacion;
                objE_Dis_DisenoVisitasEfectuadas.TipoOper = item.TipoOper;

                mListaDis_VisitasEfectuadasOrigen.Add(objE_Dis_DisenoVisitasEfectuadas);
            }

            bsListadoVisitasEfectuadas.DataSource = mListaDis_VisitasEfectuadasOrigen;
            gcVisitasEfectuadas.DataSource = bsListadoVisitasEfectuadas;
            gcVisitasEfectuadas.RefreshDataSource();
        }

        #endregion


        public class CDis_DisenoFuncional
        {
            public Int32 IdDis_ProyectoServicio { get; set; }
            public Int32 IdDis_DisenoFuncional { get; set; }
            public Int32 IdDis_Ambiente { get; set; }
            public String DescDis_Ambiente { get; set; }
            public String DescActividad { get; set; }
            public Int32 IdDis_Pieza { get; set; }
            public String DescDis_Pieza { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 IdMaterial { get; set; }
            public String DescMaterial { get; set; }
            public Int32 IdDis_Estilo { get; set; }
            public String DescDis_Estilo { get; set; }
            public Int32 IdDis_Forma { get; set; }
            public String DescDis_Forma { get; set; }
            public String DescVolumen { get; set; }
            public String DescTextura { get; set; }
            public String Observacion { get; set; }
            public Int32 TipoOper { get; set; }


            public CDis_DisenoFuncional()
            {

            }
        }

        public class CDis_DisenoEstetico
        {
            public Int32 IdDis_ProyectoServicio { get; set; }
            public Int32 IdDis_DisenoEstetico { get; set; }
            public String Objetivos { get; set; }
            public Int32 IdDis_Estilo { get; set; }
            public String DescDis_Estilo { get; set; }
            public Int32 IdDis_Forma { get; set; }
            public String DescDis_Forma { get; set; }
            public String DescVolumen { get; set; }
            public String DescTextura { get; set; }
            public Int32 IdMaterial { get; set; }
            public String DescMaterial { get; set; }
            public Int32 IdDis_TipoColor { get; set; }
            public String DescDis_TipoColor { get; set; }
            public Int32 TipoOper { get; set; }


            public CDis_DisenoEstetico()
            {

            }
        }

        public class CDis_VisitasEfectuadas
        {
            public Int32 IdDis_ProyectoServicio { get; set; }
            public Int32 IdAgendaVisita { get; set; }
            public String NumAgendaVisita { get; set; }
            public DateTime FechaAgenda { get; set; }

            public String HoraInicio { get; set; }
            public String HoraFin { get; set; }

            public String Disenador { get; set; }
            public String Agenda { get; set; }
            public String MotivoVisita { get; set; }

            public decimal PrecioVisita { get; set; }
            public String Situacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CDis_VisitasEfectuadas()
            {

            }
        }

        public void BloquearCabera()
        {
            if (Parametros.intPerfilId != Parametros.intPerAdministrador)
            {
                deFecha.Properties.ReadOnly = true;
                cboAsesor.Properties.ReadOnly = true;
                txtNumeroDocumento.Properties.ReadOnly = true;
                txtDescCliente.Properties.ReadOnly = true;
                txtDireccion.Properties.ReadOnly = true;
                txtRutaArchivo.Properties.ReadOnly = true;
                btnBuscar.Enabled = false;            
            }
        }

        private void btnEliminarVendedor2_Click(object sender, EventArgs e)
        {
            cboVendedor2.EditValue = 0;
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegProyectoServicioVisitasRealizadas movDetalle = new frmRegProyectoServicioVisitasRealizadas();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDis_VisitasEfectuadasOrigen.Count == 0)                         
                        {
                            gvVisitasEfectuadas.AddNewRow();
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "IdDis_ProyectoServicio", 0);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "IdAgendaVisita", movDetalle.oBE.IdAgendaVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "NumAgendaVisita", movDetalle.oBE.NumAgendaVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "FechaAgenda", movDetalle.oBE.FechaAgenda);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "HoraInicio", movDetalle.oBE.HoraInicio);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "HoraFin", movDetalle.oBE.HoraFin);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Disenador", movDetalle.oBE.Disenador);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Agenda", movDetalle.oBE.Agenda);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "MotivoVisita", movDetalle.oBE.MotivoVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "PrecioVisita", movDetalle.oBE.PrecioVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Situacion", movDetalle.oBE.Situacion);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            
                            gvVisitasEfectuadas.UpdateCurrentRow();

                            return;

                        }
                        if (mListaDis_VisitasEfectuadasOrigen.Count > 0)
                        {
                            gvVisitasEfectuadas.AddNewRow();
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "IdDis_ProyectoServicio", 0);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "IdAgendaVisita", movDetalle.oBE.IdAgendaVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "NumAgendaVisita", movDetalle.oBE.NumAgendaVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "FechaAgenda", movDetalle.oBE.FechaAgenda);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "HoraInicio", movDetalle.oBE.HoraInicio);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "HoraFin", movDetalle.oBE.HoraFin);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Disenador", movDetalle.oBE.Disenador);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Agenda", movDetalle.oBE.Agenda);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "MotivoVisita", movDetalle.oBE.MotivoVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "PrecioVisita", movDetalle.oBE.PrecioVisita);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "Situacion", movDetalle.oBE.Situacion);
                            gvVisitasEfectuadas.SetRowCellValue(gvVisitasEfectuadas.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvVisitasEfectuadas.UpdateCurrentRow();                  

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcVisitasEfectuadas_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDis_VisitasEfectuadasOrigen.Count > 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (int.Parse(gvVisitasEfectuadas.GetFocusedRowCellValue("IdAgendaVisita").ToString()) != 0)
                        {
                            int vIdAgendaVisita = 0;
                            if (gvVisitasEfectuadas.GetFocusedRowCellValue("IdAgendaVisita") != null)
                                vIdAgendaVisita = int.Parse(gvVisitasEfectuadas.GetFocusedRowCellValue("IdAgendaVisita").ToString());

                            int Item = 0;
                            if (gvVisitasEfectuadas.GetFocusedRowCellValue("Item") != null)
                                Item = int.Parse(gvVisitasEfectuadas.GetFocusedRowCellValue("Item").ToString());

                            Dis_DisenoVisitasRealizadasBE objBE_Dis_DisenoVisitasRea = new Dis_DisenoVisitasRealizadasBE();
                            //objBE_Dis_DisenoVisitasRea.IdDis_ProyectoServicio = IdDis_DisenoFuncional;
                            objBE_Dis_DisenoVisitasRea.IdAgendaVisita = vIdAgendaVisita;
                            //objBE_Dis_DisenoVisitasRea.Usuario = Parametros.strUsuarioLogin;
                            //objBE_Dis_DisenoVisitasRea.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            Dis_DisenoVisitasRealizadasBL objBL_Dis_DisenoVR = new Dis_DisenoVisitasRealizadasBL();
                            objBL_Dis_DisenoVR.Elimina(objBE_Dis_DisenoVisitasRea);
                            gvVisitasEfectuadas.DeleteRow(gvVisitasEfectuadas.FocusedRowHandle);
                            gvVisitasEfectuadas.RefreshData();
                        }
                        else
                        {
                            gvVisitasEfectuadas.DeleteRow(gvVisitasEfectuadas.FocusedRowHandle);
                            gvVisitasEfectuadas.RefreshData();
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