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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros ;
namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManPersonalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PersonaBE> lstPersonal;
        public List<CDerechoHabiente> mListaDerechoHabienteOrigen = new List<CDerechoHabiente>();
        public List<CEstudioRealizado> mListaEstudioRealizadoOrigen = new List<CEstudioRealizado>();
        public List<CPersonaCuentaBancaria> mListaPersonaCuentaBancariaOrigen = new List<CPersonaCuentaBancaria>();
        public List<CContrato> mListaContratoOrigen = new List<CContrato>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdPersona = 0;

        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }

        public bool bOnp = false;
        #endregion

        #region "Eventos"

        public frmManPersonalEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonalEdit_Load(object sender, EventArgs e)
        {
            CargaPersonal();

            this.TxCombo.Items.Add ("Lunes");
            this.TxCombo.Items.Add("Martes");
            this.TxCombo.Items.Add("Miercoles");
            this.TxCombo.Items.Add("Jueves");
            this.TxCombo.Items.Add("Viernes");
            this.TxCombo.Items.Add("Sabado");  
            this.TxCombo.Items.Add("Domingo");  

            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboSexo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSexo) , "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEstadoCivil, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblEstadoCivil), "DescTablaElemento", "IdTablaElemento", true);
            //BSUtils.LoaderLook(cboCargo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCargos), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescArea", "IdArea", true);
            BSUtils.LoaderLook(cboAfp, new PlaAfpBL().ListaTodosActivo(), "DescPlaAfp", "IdPlaAfp", true);
            BSUtils.LoaderLook(cboTipoDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);

            BSUtils.LoaderLook(cboSituacionEspecial, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 102), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboClasificacionPuesto, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 103), "DescTablaElemento", "IdTablaElemento", true);

            // BSUtils.LoaderLook(cboAfp, new PlaAfpBL().ListaTodosActivo(), "DescPlaAfp", "IdPlaAfp", true)

            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            deFechaNac.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Personal - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Personal - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                PersonaBE objE_Persona = new PersonaBE();

                objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                
                txtDni.EditValue = objE_Persona.Dni;
                cboTipoDocumento.EditValue = objE_Persona.IdTipoDocumento;
                cboSexo.EditValue = objE_Persona.IdSexo;
                cboEstadoCivil.EditValue = objE_Persona.IdEstadoCivil;
                txtApellidos.EditValue = objE_Persona.Apellidos;
                txtNombres.EditValue = objE_Persona.Nombres;
                txtEssalud.EditValue = objE_Persona.Essalud;
                txtBrevete.EditValue = objE_Persona.Brevete;
                deFechaNac.EditValue = objE_Persona.FechaNac;
                chkEPS.Checked = objE_Persona.FlagEps;
                chkSCTR.Checked = objE_Persona.FlagSctr;
                txtCuspp.Text = objE_Persona.Cuspp;
                chkPensionista.Checked = objE_Persona.FlagPensionista;
                cboArea.EditValue = objE_Persona.IdArea;
                cboCargo.EditValue = objE_Persona.IdCargo;
                TxCombo.Text = objE_Persona.Descanso; 
                if (objE_Persona.IdUbigeo.Trim() != "")
                    IdDepartamento = objE_Persona.IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (objE_Persona.IdUbigeo.Trim() != "")
                    IdProvincia = objE_Persona.IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (objE_Persona.IdUbigeo.Trim() != "")
                    IdDistrito = objE_Persona.IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;
              
                txtDireccion.EditValue = objE_Persona.Direccion;
                txtTelefono.EditValue = objE_Persona.Telefono;
                txtCelular.EditValue = objE_Persona.Celular;
                txtOtroTelefono.EditValue = objE_Persona.TelefonoOtro;
                txtEmail.EditValue = objE_Persona.Email;
                deFechaIngreso.EditValue = objE_Persona.FechaIngreso;
                deFechaCese.EditValue = objE_Persona.FechaCese;
                lblCodigoPersona.Text = "Código: " + objE_Persona.IdPersona.ToString();

                //TxCombo.Text= objE_Persona.Descanso;
                if (objE_Persona.Foto != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Persona.Foto);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
                txtObservacion.EditValue = objE_Persona.Observacion;
                cboEmpresa.EditValue = objE_Persona.IdEmpresa;
                cboTienda.EditValue = objE_Persona.IdTienda;
                cboAfp.EditValue = objE_Persona.IdPlaAfp;

                if (objE_Persona.Discapacidad == 1)
                    optDiscapacidadSi.Checked = true;
                else if (objE_Persona.Discapacidad == 0)
                    optDiscapacidadNo.Checked = true;

                cboClasificacionPuesto.EditValue = objE_Persona.ClasificaPuesto;
                cboSituacionEspecial.EditValue = objE_Persona.SituacionEspecial;

                if (objE_Persona.FlagOnp == true)
                    optOnpSi.Checked = true;
                else
                    optOnpNo.Checked = true;

                //Estado
                if (objE_Persona.FlagHoraExtra  == true)
                    this.chkhr.Checked = true;
                else
                    this.chkhr.Checked = false;


                //Estado
                if (objE_Persona.FlagAsignacion  == true)
                    this.chkas.Checked = true;
                else
                    this.chkas.Checked = false;


                //Estado
                if (objE_Persona.FlagEstado == true)
                    optActivo.Checked = true;
                else
                    optInactivo.Checked = true;


                txtRutaArchivo.Text = objE_Persona.RutaCV;
                txtRuc.Text = objE_Persona.Ruc;
                txtUsuarioSol.Text = objE_Persona.UsuarioSol;
                txtClaveSol.Text = objE_Persona.ClaveSol;
                chkApoyo.Checked = objE_Persona.FlagApoyo;
                txtMotivoCese.Text = objE_Persona.MotivoCese;
                chkFlagAsistencia.Checked = objE_Persona.FlagAsistencia;
                txtSueldo.Text = objE_Persona.Sueldo.ToString();
                deFechaRegistro.EditValue =  objE_Persona.FechaRegistro;
                txtUsuarioCreacion.EditValue = objE_Persona.UsuarioRegistro;
            }

            CargaDerechoHabiente();
            CargaEstudioRealizado();
            CargaCuentaBancaria();
            CargaContrato();

            txtDni.Select();
            this.MostrarAsignaciónFamiliar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PersonaBL objBL_Persona = new PersonaBL();
                    PersonaBE objE_Persona = new PersonaBE();
                    int vDiscapacidad = 0;

                    if (optOnpSi.Checked == true)
                    {
                        cboAfp.EditValue = Parametros.intNinguno;
                        bOnp = true;
                    }
                    else {
                        bOnp = false;
                    }

                    if (optDiscapacidadSi.Checked == true)
                    {
                        vDiscapacidad = 1;
                    }
                    else if (optDiscapacidadNo.Checked == true)
                    {
                        vDiscapacidad = 0;
                    }

                    objE_Persona.SituacionEspecial = Convert.ToInt32(cboSituacionEspecial.EditValue);
                    objE_Persona.ClasificaPuesto = Convert.ToInt32(cboClasificacionPuesto.EditValue);
                    objE_Persona.Discapacidad = vDiscapacidad;

                    objE_Persona.IdPersona = IdPersona;
                    objE_Persona.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objE_Persona.IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.EditValue);
                    objE_Persona.Dni = txtDni.Text;
                    objE_Persona.IdSexo = Convert.ToInt32(cboSexo.EditValue);
                    objE_Persona.IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.EditValue);
                    objE_Persona.Nombres = txtNombres.Text.Trim();
                    objE_Persona.Apellidos = txtApellidos.Text.Trim();
                    objE_Persona.ApeNom = txtApellidos.Text.Trim() + " " + txtNombres.Text.Trim();
                    objE_Persona.Essalud = txtEssalud.Text;
                    if (chkEPS.Checked)
                        objE_Persona.FlagEps = true;
                    else
                        objE_Persona.FlagEps = false;

                    if (chkSCTR.Checked)
                        objE_Persona.FlagSctr = true;
                    else
                        objE_Persona.FlagSctr = false;

                    objE_Persona.FlagOnp = bOnp; //add
                    objE_Persona.IdPlaAfp = Convert.ToInt32(cboAfp.EditValue); //add
                    objE_Persona.Cuspp = txtCuspp.Text;
                    objE_Persona.FlagPensionista = chkPensionista.Checked;
                    objE_Persona.Brevete = txtBrevete.Text;
                    objE_Persona.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                    objE_Persona.FechaNac = Convert.ToDateTime(deFechaNac.EditValue);
                    objE_Persona.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_Persona.Direccion = txtDireccion.Text;
                    objE_Persona.Telefono = txtTelefono.Text;
                    objE_Persona.Celular = txtCelular.Text;
                    objE_Persona.TelefonoOtro = txtOtroTelefono.Text;
                    objE_Persona.Email = txtEmail.Text;
                    objE_Persona.Foto = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Persona.Observacion = txtObservacion.Text;
                    objE_Persona.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objE_Persona.RutaCV = txtRutaArchivo.Text;
                    objE_Persona.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToLongDateString());
                    objE_Persona.FechaCese = deFechaCese.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaCese.DateTime.ToShortDateString());
                    objE_Persona.Descanso = this.TxCombo.Text; // fecha de descanso
                    objE_Persona.FlagApoyo = chkApoyo.Checked;
                    objE_Persona.FlagAsistencia = chkFlagAsistencia.Checked;
                    objE_Persona.Sueldo = Convert.ToDecimal(txtSueldo.Text);

                    if (chkhr.Checked)
                    objE_Persona.FlagHoraExtra = true;
                    else
                    objE_Persona.FlagHoraExtra =false;

                    if (chkas.Checked)
                        objE_Persona.FlagAsignacion = true;
                    else
                        objE_Persona.FlagAsignacion = false;

                    objE_Persona.Ruc = txtRuc.Text.Trim();
                    objE_Persona.UsuarioSol = txtUsuarioSol.Text.Trim();
                    objE_Persona.ClaveSol = txtClaveSol.Text.Trim();
                    objE_Persona.MotivoCese = txtMotivoCese.Text.Trim();
                    objE_Persona.FlagEstado = optActivo.Checked; //true;
                    objE_Persona.Usuario = Parametros.strUsuarioLogin;
                    objE_Persona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Persona.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    List<DerechoHabienteBE> lstDerechoHabiente = new List<DerechoHabienteBE>();
                    List<EstudioRealizadoBE> lstEstudioRealizado = new List<EstudioRealizadoBE>();
                    List<PersonaCuentaBancariaBE> lstCuentaBancaria = new List<PersonaCuentaBancariaBE>();
                    List<ContratoBE> lstContrato = new List<ContratoBE>();

                    //Derecho Habiente
                    foreach (var item in mListaDerechoHabienteOrigen)
                    {
                        DerechoHabienteBE objE_DerechoHabiente = new DerechoHabienteBE();
                        objE_DerechoHabiente.IdPersona = item.IdPersona;
                        objE_DerechoHabiente.IdDerechoHabiente = item.IdDerechoHabiente;
                        objE_DerechoHabiente.IdSexo = item.IdSexo;
                        objE_DerechoHabiente.DescSexo = item.DescSexo;
                        objE_DerechoHabiente.IdParentesco = item.IdParentesco;
                        objE_DerechoHabiente.DescParentesco = item.DescParentesco;
                        objE_DerechoHabiente.NumeroDocumento = item.NumeroDocumento;
                        objE_DerechoHabiente.ApeNom = item.ApeNom;
                        objE_DerechoHabiente.FechaNac = item.FechaNac;
                        objE_DerechoHabiente.Ocupacion = item.Ocupacion;
                        objE_DerechoHabiente.FlagEps = item.FlagEps;
                        objE_DerechoHabiente.FlagEstado = true;
                        objE_DerechoHabiente.TipoOper = item.TipoOper;
                        lstDerechoHabiente.Add(objE_DerechoHabiente);
                    }

                    //Estudio Realizado
                    foreach (var item in mListaEstudioRealizadoOrigen)
                    {
                        EstudioRealizadoBE objE_EstudioRealizado = new EstudioRealizadoBE();
                        objE_EstudioRealizado.IdPersona = item.IdPersona;
                        objE_EstudioRealizado.IdEstudioRealizado = item.IdEstudioRealizado;
                        objE_EstudioRealizado.IdNivelEstudio = item.IdNivelEstudio;
                        objE_EstudioRealizado.CentroEstudio = item.CentroEstudio;
                        objE_EstudioRealizado.GradoObtenido = item.GradoObtenido;
                        objE_EstudioRealizado.MesAnioIncio = item.MesAnioIncio;
                        objE_EstudioRealizado.MesAnioFin = item.MesAnioFin;
                        objE_EstudioRealizado.FlagEstado = true;
                        objE_EstudioRealizado.TipoOper = item.TipoOper;
                        lstEstudioRealizado.Add(objE_EstudioRealizado);
                    }

                    //Cuenta Bancaria
                    foreach (var item in mListaPersonaCuentaBancariaOrigen)
                    {
                        PersonaCuentaBancariaBE objE_CuentaBancaria = new PersonaCuentaBancariaBE();
                        objE_CuentaBancaria.IdPersona = item.IdPersona;
                        objE_CuentaBancaria.IdPersonaCuentaBancaria = item.IdPersonaCuentaBancaria;
                        objE_CuentaBancaria.IdBanco = item.IdBanco;
                        objE_CuentaBancaria.IdMoneda = item.IdMoneda;
                        objE_CuentaBancaria.NumeroCuenta = item.NumeroCuenta;
                        objE_CuentaBancaria.IdTipoCuenta = item.IdTipoCuenta;
                        objE_CuentaBancaria.Observacion = item.Observacion;
                        objE_CuentaBancaria.FlagEstado = true;
                        objE_CuentaBancaria.TipoOper = item.TipoOper;
                        lstCuentaBancaria.Add(objE_CuentaBancaria);
                    }

                    foreach (var item in mListaContratoOrigen)
                    {
                        ContratoBE objE_Contrato = new ContratoBE();
                        objE_Contrato.IdContrato = item.IdContrato;
                        objE_Contrato.IdTipoContrato = item.IdTipoContrato;
                        objE_Contrato.IdTipoTrabajador = item.IdTipoTrabajador;
                        objE_Contrato.IdPersona = IdPersona;
                        objE_Contrato.IdTienda = item.IdTienda;
                        objE_Contrato.IdArea = item.IdArea;
                        objE_Contrato.IdCargo = item.IdCargo;
                        objE_Contrato.IdHorario = item.IdHorario;
                        objE_Contrato.FechaIni = item.FechaIni;
                        objE_Contrato.FechaVen = item.FechaVen;
                        objE_Contrato.IdTipoRenta = item.IdTipoRenta;
                        objE_Contrato.Sueldo = item.Sueldo;
                        objE_Contrato.HoraExtra = item.HoraExtra;
                        objE_Contrato.BonSueldo = item.BonSueldo;
                        objE_Contrato.Movilidad = item.Movilidad;
                        objE_Contrato.SueldoNeto = item.SueldoNeto;
                        objE_Contrato.IdClasificacionTrabajador = item.IdClasificacionTrabajador;
                        objE_Contrato.RutaContrato = item.RutaContrato;
                        objE_Contrato.Observacion = item.Observacion;
                        objE_Contrato.FlagHoraExtra = item.FlagHoraExtra;
                        objE_Contrato.Dias = item.Dias;
                        objE_Contrato.Meses = item.Meses;
                        objE_Contrato.FlagEstado = true;
                        objE_Contrato.Usuario = Parametros.strUsuarioLogin;
                        objE_Contrato.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Contrato.IdEmpresa = item.IdEmpresa;//Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;
                        objE_Contrato.TipoOper = item.TipoOper;
                        lstContrato.Add(objE_Contrato);
                    }


                    if (pOperacion == Operacion.Nuevo)
                        objBL_Persona.Inserta(objE_Persona, lstDerechoHabiente, lstEstudioRealizado, lstCuentaBancaria, lstContrato);
                    else
                        objBL_Persona.Actualiza(objE_Persona, lstDerechoHabiente, lstEstudioRealizado, lstCuentaBancaria, lstContrato);

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

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optOnpSi_CheckedChanged(object sender, EventArgs e)
        {
            if (optOnpSi.Checked == true)
            {
                cboAfp.Enabled = false;
                
            }
            else
            {
                cboAfp.Enabled = true;
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManDerechoHabienteEdit movDetalle = new frmManDerechoHabienteEdit();
                movDetalle.pOperacion = frmManDerechoHabienteEdit.Operacion.Nuevo;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDerechoHabienteOrigen.Count == 0)
                        {
                            gvDerechoHabiente.AddNewRow();
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdDerechoHabiente", movDetalle.oBE.IdDerechoHabiente);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdSexo", movDetalle.oBE.IdSexo);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "DescSexo", movDetalle.oBE.DescSexo);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdParentesco", movDetalle.oBE.IdParentesco);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "DescParentesco", movDetalle.oBE.DescParentesco);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "NumeroDocumento", movDetalle.oBE.NumeroDocumento);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "ApeNom", movDetalle.oBE.ApeNom);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "FechaNac", movDetalle.oBE.FechaNac);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "Ocupacion", movDetalle.oBE.Ocupacion);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "FlagEps", movDetalle.oBE.FlagEps);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDerechoHabiente.UpdateCurrentRow();

                            return;

                        }
                        if (mListaDerechoHabienteOrigen.Count > 0)
                        {
                            var Buscar = mListaDerechoHabienteOrigen.Where(oB => oB.NumeroDocumento == movDetalle.oBE.NumeroDocumento && oB.ApeNom == movDetalle.oBE.ApeNom).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("La persona ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDerechoHabiente.AddNewRow();
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdDerechoHabiente", movDetalle.oBE.IdDerechoHabiente);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdSexo", movDetalle.oBE.IdSexo);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "DescSexo", movDetalle.oBE.DescSexo);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "IdParentesco", movDetalle.oBE.IdParentesco);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "DescParentesco", movDetalle.oBE.DescParentesco);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "NumeroDocumento", movDetalle.oBE.NumeroDocumento);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "ApeNom", movDetalle.oBE.ApeNom);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "FechaNac", movDetalle.oBE.FechaNac);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "Ocupacion", movDetalle.oBE.Ocupacion);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "FlagEps", movDetalle.oBE.FlagEps);
                            gvDerechoHabiente.SetRowCellValue(gvDerechoHabiente.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDerechoHabiente.UpdateCurrentRow();

                            
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
            if (mListaDerechoHabienteOrigen.Count > 0)
            {
                int xposition = 0;

                frmManDerechoHabienteEdit movDetalle = new frmManDerechoHabienteEdit();
                movDetalle.pOperacion = frmManDerechoHabienteEdit.Operacion.Modificar;
                movDetalle.IdPersona = Convert.ToInt32(gvDerechoHabiente.GetFocusedRowCellValue("IdPersona"));
                movDetalle.IdDerechoHabiente = Convert.ToInt32(gvDerechoHabiente.GetFocusedRowCellValue("IdDerechoHabiente"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDerechoHabiente.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDerechoHabiente.SetRowCellValue(xposition, "IdPersona", movDetalle.oBE.IdPersona);
                        gvDerechoHabiente.SetRowCellValue(xposition, "IdDerechoHabiente", movDetalle.oBE.IdDerechoHabiente);
                        gvDerechoHabiente.SetRowCellValue(xposition, "IdSexo", movDetalle.oBE.IdSexo);
                        gvDerechoHabiente.SetRowCellValue(xposition, "DescSexo", movDetalle.oBE.DescSexo);
                        gvDerechoHabiente.SetRowCellValue(xposition, "IdParentesco", movDetalle.oBE.IdParentesco);
                        gvDerechoHabiente.SetRowCellValue(xposition, "DescParentesco", movDetalle.oBE.DescParentesco);
                        gvDerechoHabiente.SetRowCellValue(xposition, "NumeroDocumento", movDetalle.oBE.NumeroDocumento);
                        gvDerechoHabiente.SetRowCellValue(xposition, "ApeNom", movDetalle.oBE.ApeNom);
                        gvDerechoHabiente.SetRowCellValue(xposition, "FechaNac", movDetalle.oBE.FechaNac);
                        gvDerechoHabiente.SetRowCellValue(xposition, "Ocupacion", movDetalle.oBE.Ocupacion);
                        gvDerechoHabiente.SetRowCellValue(xposition, "FlagEps", movDetalle.oBE.FlagEps);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvDerechoHabiente.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvDerechoHabiente.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvDerechoHabiente.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDerechoHabiente.UpdateCurrentRow();

                        
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDerechoHabienteOrigen.Count > 0)
                {
                    DerechoHabienteBE objBE_DerechoHabiente = new DerechoHabienteBE();
                    objBE_DerechoHabiente.IdDerechoHabiente = int.Parse(gvDerechoHabiente.GetFocusedRowCellValue("IdDerechoHabiente").ToString());
                    objBE_DerechoHabiente.IdEmpresa = Parametros.intEmpresaId;
                    objBE_DerechoHabiente.Usuario = Parametros.strUsuarioLogin;
                    objBE_DerechoHabiente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    DerechoHabienteBL objBL_DerechoHabiente = new DerechoHabienteBL();
                    objBL_DerechoHabiente.Elimina(objBE_DerechoHabiente);
                    gvDerechoHabiente.DeleteRow(gvDerechoHabiente.FocusedRowHandle);
                    gvDerechoHabiente.RefreshData();

                }
                else
                {
                    gvDerechoHabiente.DeleteRow(gvDerechoHabiente.FocusedRowHandle);
                    gvDerechoHabiente.RefreshData();
                }
                              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoEstudioRealizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManEstudioRealizadoEdit movDetalle = new frmManEstudioRealizadoEdit();
                movDetalle.pOperacion = frmManEstudioRealizadoEdit.Operacion.Nuevo;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaEstudioRealizadoOrigen.Count == 0)
                        {
                            gvEstudioRealizado.AddNewRow();
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdEstudioRealizado", movDetalle.oBE.IdEstudioRealizado);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdNivelEstudio", movDetalle.oBE.IdNivelEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "DescNivelEstudio", movDetalle.oBE.DescNivelEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "CentroEstudio", movDetalle.oBE.CentroEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "GradoObtenido", movDetalle.oBE.GradoObtenido);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "MesAnioIncio", movDetalle.oBE.MesAnioIncio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "MesAnioFin", movDetalle.oBE.MesAnioFin);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvEstudioRealizado.UpdateCurrentRow();

                            return;

                        }
                        if (mListaEstudioRealizadoOrigen.Count > 0)
                        {
                            var Buscar = mListaEstudioRealizadoOrigen.Where(oB => oB.DescNivelEstudio == movDetalle.oBE.DescNivelEstudio && oB.CentroEstudio == movDetalle.oBE.CentroEstudio).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El nivel de estudio ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvEstudioRealizado.AddNewRow();
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdEstudioRealizado", movDetalle.oBE.IdEstudioRealizado);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "IdNivelEstudio", movDetalle.oBE.IdNivelEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "DescNivelEstudio", movDetalle.oBE.DescNivelEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "CentroEstudio", movDetalle.oBE.CentroEstudio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "GradoObtenido", movDetalle.oBE.GradoObtenido);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "MesAnioIncio", movDetalle.oBE.MesAnioIncio);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "MesAnioFin", movDetalle.oBE.MesAnioFin);
                            gvEstudioRealizado.SetRowCellValue(gvEstudioRealizado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvEstudioRealizado.UpdateCurrentRow();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarEstudioRealizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaEstudioRealizadoOrigen.Count > 0)
            {
                int xposition = 0;

                frmManEstudioRealizadoEdit movDetalle = new frmManEstudioRealizadoEdit();
                movDetalle.pOperacion = frmManEstudioRealizadoEdit.Operacion.Modificar;
                movDetalle.IdPersona = Convert.ToInt32(gvEstudioRealizado.GetFocusedRowCellValue("IdPersona"));
                movDetalle.IdEstudioRealizado = Convert.ToInt32(gvEstudioRealizado.GetFocusedRowCellValue("IdEstudioRealizado"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvEstudioRealizado.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvEstudioRealizado.SetRowCellValue(xposition, "IdPersona", movDetalle.oBE.IdPersona);
                        gvEstudioRealizado.SetRowCellValue(xposition, "IdEstudioRealizado", movDetalle.oBE.IdEstudioRealizado);
                        gvEstudioRealizado.SetRowCellValue(xposition, "IdNivelEstudio", movDetalle.oBE.IdNivelEstudio);
                        gvEstudioRealizado.SetRowCellValue(xposition, "DescNivelEstudio", movDetalle.oBE.DescNivelEstudio);
                        gvEstudioRealizado.SetRowCellValue(xposition, "CentroEstudio", movDetalle.oBE.CentroEstudio);
                        gvEstudioRealizado.SetRowCellValue(xposition, "GradoObtenido", movDetalle.oBE.GradoObtenido);
                        gvEstudioRealizado.SetRowCellValue(xposition, "MesAnioIncio", movDetalle.oBE.MesAnioIncio);
                        gvEstudioRealizado.SetRowCellValue(xposition, "MesAnioFin", movDetalle.oBE.MesAnioFin);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvEstudioRealizado.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvEstudioRealizado.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvEstudioRealizado.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvEstudioRealizado.UpdateCurrentRow();


                    }
                }
            }
        }

        private void eliminarEstudioRealizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaEstudioRealizadoOrigen.Count > 0)
                {
                    EstudioRealizadoBE objBE_EstudioRealizado = new EstudioRealizadoBE();
                    objBE_EstudioRealizado.IdEstudioRealizado = int.Parse(gvEstudioRealizado.GetFocusedRowCellValue("IdEstudioRealizado").ToString());
                    objBE_EstudioRealizado.IdEmpresa = Parametros.intEmpresaId;
                    objBE_EstudioRealizado.Usuario = Parametros.strUsuarioLogin;
                    objBE_EstudioRealizado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    EstudioRealizadoBL objBL_EstudioRealizado = new EstudioRealizadoBL();
                    objBL_EstudioRealizado.Elimina(objBE_EstudioRealizado);
                    gvEstudioRealizado.DeleteRow(gvEstudioRealizado.FocusedRowHandle);
                    gvEstudioRealizado.RefreshData();

                }
                else
                {
                    gvEstudioRealizado.DeleteRow(gvEstudioRealizado.FocusedRowHandle);
                    gvEstudioRealizado.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "Word Documents|*.doc|Word Documents |*.docx|All Files (*.*)|*.*";
            if (Dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                txtRutaArchivo.Text = Dialog1.FileName;
                Cursor = Cursors.Default;
            }
            
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (txtRutaArchivo.Text != string.Empty)
            {
                System.Diagnostics.Process.Start(txtRutaArchivo.Text);
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDni.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Dni.\n";
                flag = true;
            }

            if (txtNombres.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese los nombres.\n";
                flag = true;
            }

            if (txtApellidos.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese apellidos.\n";
                flag = true;
            }

            if (deFechaIngreso.Text == "")
            {
                strMensaje = strMensaje + "- Ingrese la fecha de Ingreso.\n";
                flag = true;
            }

            if (optInactivo.Checked && deFechaCese.Text=="")
            {
                if (XtraMessageBox.Show("Desea registrar la fecha de cese?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //strMensaje = strMensaje + "- Ingrese la fecha de cese.\n";
                    deFechaCese.Select();
                    flag = true;
                }

            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPersonal.Where(oB => oB.Dni.ToUpper() == txtDni.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El dni ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaDerechoHabiente()
        {
            mListaDerechoHabienteOrigen = new List<CDerechoHabiente>();

            List<DerechoHabienteBE> lstTmpDerechoHabiente = null;
            lstTmpDerechoHabiente = new DerechoHabienteBL().ListaTodosActivo(IdPersona);

            foreach (DerechoHabienteBE item in lstTmpDerechoHabiente)
            {
                CDerechoHabiente objE_DerechoHabiente = new CDerechoHabiente();
                objE_DerechoHabiente.IdPersona = item.IdPersona;
                objE_DerechoHabiente.IdDerechoHabiente = item.IdDerechoHabiente;
                objE_DerechoHabiente.IdSexo = item.IdSexo;
                objE_DerechoHabiente.DescSexo = item.DescSexo;
                objE_DerechoHabiente.IdParentesco = item.IdParentesco;
                objE_DerechoHabiente.DescParentesco = item.DescParentesco;
                objE_DerechoHabiente.NumeroDocumento = item.NumeroDocumento;
                objE_DerechoHabiente.ApeNom = item.ApeNom;
                objE_DerechoHabiente.FechaNac = item.FechaNac;
                objE_DerechoHabiente.Ocupacion = item.Ocupacion;
                objE_DerechoHabiente.FlagEps = item.FlagEps;
                objE_DerechoHabiente.TipoOper = item.TipoOper;
                mListaDerechoHabienteOrigen.Add(objE_DerechoHabiente);
            }

            bsListado.DataSource = mListaDerechoHabienteOrigen;
            gcDerechoHabiente.DataSource = bsListado;
            gcDerechoHabiente.RefreshDataSource();

            
        }

        
        private void CargaPersonal()
        {
            lstPersonal = new PersonaBL().ListaTodosActivo(13, 0);
        }

        private void CargaEstudioRealizado()
        {
            mListaEstudioRealizadoOrigen = new List<CEstudioRealizado>();

            List<EstudioRealizadoBE> lstTmpEstudioRealizado = null;
            lstTmpEstudioRealizado = new EstudioRealizadoBL().ListaTodosActivo(IdPersona);

            foreach (EstudioRealizadoBE item in lstTmpEstudioRealizado)
            {
                CEstudioRealizado objE_EstudioRealizado = new CEstudioRealizado();
                objE_EstudioRealizado.IdPersona = item.IdPersona;
                objE_EstudioRealizado.IdEstudioRealizado = item.IdEstudioRealizado;
                objE_EstudioRealizado.IdNivelEstudio = item.IdNivelEstudio;
                objE_EstudioRealizado.DescNivelEstudio = item.DescNivelEstudio;
                objE_EstudioRealizado.CentroEstudio = item.CentroEstudio;
                objE_EstudioRealizado.GradoObtenido = item.GradoObtenido;
                objE_EstudioRealizado.MesAnioIncio = item.MesAnioIncio;
                objE_EstudioRealizado.MesAnioFin = item.MesAnioFin;
                objE_EstudioRealizado.TipoOper = item.TipoOper;
                mListaEstudioRealizadoOrigen.Add(objE_EstudioRealizado);
            }

            bsListadoEstudioRealizado.DataSource = mListaEstudioRealizadoOrigen;
            gcEstudioRealizado.DataSource = bsListadoEstudioRealizado;
            gcEstudioRealizado.RefreshDataSource();


        }

        private void CargaCuentaBancaria()
        {
            mListaPersonaCuentaBancariaOrigen = new List<CPersonaCuentaBancaria>();

            List<PersonaCuentaBancariaBE> lstTmpPersonaCuentaBancaria = null;
            lstTmpPersonaCuentaBancaria = new PersonaCuentaBancariaBL().ListaTodosPersona(IdPersona);

            foreach (PersonaCuentaBancariaBE item in lstTmpPersonaCuentaBancaria)
            {
                CPersonaCuentaBancaria objE_PersonaCuentaBancaria = new CPersonaCuentaBancaria();
                objE_PersonaCuentaBancaria.IdPersona = item.IdPersona;
                objE_PersonaCuentaBancaria.IdPersonaCuentaBancaria = item.IdPersonaCuentaBancaria;
                objE_PersonaCuentaBancaria.ApeNom = item.ApeNom;
                objE_PersonaCuentaBancaria.IdBanco = item.IdBanco;
                objE_PersonaCuentaBancaria.DescBanco = item.DescBanco;
                objE_PersonaCuentaBancaria.IdMoneda = item.IdMoneda;
                objE_PersonaCuentaBancaria.DescMoneda = item.DescMoneda;
                objE_PersonaCuentaBancaria.NumeroCuenta = item.NumeroCuenta;
                objE_PersonaCuentaBancaria.IdTipoCuenta = item.IdTipoCuenta;
                objE_PersonaCuentaBancaria.DescTipoCuenta = item.DescTipoCuenta;
                objE_PersonaCuentaBancaria.Observacion = item.Observacion;
                objE_PersonaCuentaBancaria.TipoOper = item.TipoOper;
                mListaPersonaCuentaBancariaOrigen.Add(objE_PersonaCuentaBancaria);
            }

            bsListadoCuentaBancaria.DataSource = mListaPersonaCuentaBancariaOrigen;
            gcPersonaCuentaBancaria.DataSource = bsListadoCuentaBancaria;
            gcPersonaCuentaBancaria.RefreshDataSource();

        }

        private void CargaContrato()
        {
            mListaContratoOrigen = new List<CContrato>();

            List<ContratoBE> lstTmpContrato = null;
            lstTmpContrato = new ContratoBL().ListaPersona(IdPersona);

            foreach (ContratoBE item in lstTmpContrato)
            {
                CContrato objE_Contrato = new CContrato();

                objE_Contrato.IdPersona = item.IdPersona;
                objE_Contrato.IdContrato = item.IdContrato;
                objE_Contrato.IdTipoContrato = item.IdTipoContrato;
                objE_Contrato.DescTipoContrato = item.DescTipoContrato;
                objE_Contrato.IdTipoTrabajador = item.IdTipoTrabajador;
                objE_Contrato.DescTipoTrabajador = item.DescTipoTrabajador;
                objE_Contrato.IdEmpresa = item.IdEmpresa;
                objE_Contrato.RazonSocial = item.RazonSocial;
                objE_Contrato.Dni = item.Dni;
                objE_Contrato.ApeNom = item.ApeNom;
                objE_Contrato.IdTienda = item.IdTienda;
                objE_Contrato.DescTienda = item.DescTienda;
                objE_Contrato.IdArea = item.IdArea;
                objE_Contrato.DescArea = item.DescArea;
                objE_Contrato.IdCargo = item.IdCargo;
                objE_Contrato.DescCargo = item.DescCargo;
                objE_Contrato.IdHorario = item.IdHorario;
                objE_Contrato.DescHorario = item.DescHorario;
                objE_Contrato.Numero = item.Numero;
                objE_Contrato.FechaIni = item.FechaIni;
                objE_Contrato.FechaVen = item.FechaVen;
                objE_Contrato.IdTipoRenta = item.IdTipoRenta;
                objE_Contrato.DescTipoRenta = item.DescTipoRenta;
                objE_Contrato.Sueldo = item.Sueldo;
                objE_Contrato.HoraExtra = item.HoraExtra;
                objE_Contrato.Movilidad = item.Movilidad;
                objE_Contrato.BonSueldo = item.BonSueldo;
                objE_Contrato.SueldoNeto = item.SueldoNeto;
                objE_Contrato.IdClasificacionTrabajador = item.IdClasificacionTrabajador;
                objE_Contrato.DescClasificacionTrabajador = item.DescClasificacionTrabajador;
                objE_Contrato.RutaContrato = item.RutaContrato;
                objE_Contrato.Observacion = item.Observacion;
                objE_Contrato.Dias = item.Dias;
                objE_Contrato.Meses = item.Meses;
                objE_Contrato.FlagHoraExtra = item.FlagHoraExtra;
                //objE_Contrato.FechaIngreso = item.FechaIngreso;
                objE_Contrato.DescBanco = item.DescBanco;
                objE_Contrato.NumeroCuenta = item.NumeroCuenta;
                //objE_Contrato.Descanso = item.Descanso
                //objE_Contrato.SistemaPension = item.SistemaPension;
                //objE_Contrato.Ruc = reader["Ruc"].ToString();
                //objE_Contrato.UsuarioSol = reader["UsuarioSol"].ToString();
                //objE_Contrato.ClaveSol = reader["ClaveSol"].ToString();
                objE_Contrato.UsuarioRegistro = item.UsuarioRegistro;
                objE_Contrato.FechaRegistro = item.FechaRegistro;
                objE_Contrato.FlagEstado = item.FlagEstado;


                objE_Contrato.TipoOper = item.TipoOper;
                mListaContratoOrigen.Add(objE_Contrato);
            }
            bsListadoContrato.DataSource = mListaContratoOrigen;
            gcContrato.DataSource = bsListadoContrato;
            gcContrato.RefreshDataSource();

        }

        #endregion


        public class CDerechoHabiente
        {
            public Int32 IdPersona { get; set; }
            public Int32 IdDerechoHabiente { get; set; }
            public Int32 IdSexo { get; set; }
            public String DescSexo { get; set; }
            public Int32 IdParentesco { get; set; }
            public String DescParentesco { get; set; }
            public String NumeroDocumento { get; set; }
            public String ApeNom { get; set; }
            public DateTime FechaNac { get; set; }
            public String Ocupacion { get; set; }
            public Boolean FlagEps { get; set; }
            public Int32 TipoOper { get; set; }

            public CDerechoHabiente()
            {

            }
        }

        public class CEstudioRealizado
        {
            public Int32 IdPersona { get; set; }
            public Int32 IdEstudioRealizado { get; set; }
            public Int32 IdNivelEstudio { get; set; }
            public String DescNivelEstudio { get; set; }
            public String CentroEstudio { get; set; }
            public String GradoObtenido { get; set; }
            public String MesAnioIncio { get; set; }
            public String MesAnioFin { get; set; }
            public Int32 TipoOper { get; set; }

            public CEstudioRealizado()
            {

            }
        }

        public class CPersonaCuentaBancaria
        {
            public Int32 IdPersona { get; set; }
            public Int32 IdPersonaCuentaBancaria { get; set; }
            public String ApeNom { get; set; }
            public Int32 IdBanco { get; set; }
            public String DescBanco { get; set; }
            public Int32 IdMoneda { get; set; }
            public String DescMoneda { get; set; }
            public String NumeroCuenta { get; set; }
            public Int32 IdTipoCuenta { get; set; }
            public String DescTipoCuenta { get; set; }
            public String Observacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CPersonaCuentaBancaria()
            {

            }
        }

        public class CContrato
        {
            public Int32 IdContrato { get; set; }
            public Int32 IdTipoContrato { get; set; }
            public Int32 IdTipoTrabajador { get; set; }
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPersona { get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdArea { get; set; }
            public Int32 IdCargo { get; set; }
            public Int32 IdHorario { get; set; }
            public int Numero { get; set; }
            public DateTime FechaIni { get; set; }
            public DateTime? FechaVen { get; set; }
            public Int32 IdTipoRenta { get; set; }
            public Decimal Sueldo { get; set; }
            public Decimal HoraExtra { get; set; }
            public Decimal BonSueldo { get; set; }
            public Decimal Movilidad { get; set; }
            public Decimal SueldoNeto { get; set; }
            public Int32 IdClasificacionTrabajador { get; set; }
            public String RutaContrato { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagEstado { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public String DescTipoContrato { get; set; }
            public String DescTipoTrabajador { get; set; }
            public String RazonSocial { get; set; }
            public String Dni { get; set; }
            public String ApeNom { get; set; }
            public String DescTienda { get; set; }
            public String DescArea { get; set; }
            public String DescCargo { get; set; }
            public String DescHorario { get; set; }
            public String DescTipoRenta { get; set; }
            public String DescClasificacionTrabajador { get; set; }
            public Boolean FlagHoraExtra { get; set; }
            public DateTime FechaIngreso { get; set; }
            public String DescBanco { get; set; }
            public String NumeroCuenta { get; set; }
            public String Descanso { get; set; }
            public String SistemaPension { get; set; }
            public Int32 Dias { get; set; }
            public Int32 Meses { get; set; }

            public String UsuarioRegistro { get; set; }
            public DateTime FechaRegistro { get; set; }
            public Int32 TipoOper { get; set; }

            public CContrato()
            {

            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
      

        }

        private void chkhr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nuevoCuentaBancariatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManPersonaCuentaBancariaEdit movDetalle = new frmManPersonaCuentaBancariaEdit();
                movDetalle.pOperacion = frmManPersonaCuentaBancariaEdit.Operacion.Nuevo;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPersonaCuentaBancariaOrigen.Count == 0)
                        {
                            gvPersonaCuentaBancaria.AddNewRow();
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdPersonaCuentaBancaria", movDetalle.oBE.IdPersonaCuentaBancaria);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdBanco", movDetalle.oBE.IdBanco);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescBanco", movDetalle.oBE.DescBanco);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdMoneda", movDetalle.oBE.IdMoneda);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescMoneda", movDetalle.oBE.DescMoneda);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "NumeroCuenta", movDetalle.oBE.NumeroCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPersonaCuentaBancaria.UpdateCurrentRow();

                            return;

                        }
                        if (mListaPersonaCuentaBancariaOrigen.Count > 0)
                        {
                            var Buscar = mListaPersonaCuentaBancariaOrigen.Where(oB => oB.NumeroCuenta == movDetalle.oBE.NumeroCuenta).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("La cuenta ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPersonaCuentaBancaria.AddNewRow();
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdPersonaCuentaBancaria", movDetalle.oBE.IdPersonaCuentaBancaria);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdBanco", movDetalle.oBE.IdBanco);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescBanco", movDetalle.oBE.DescBanco);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdMoneda", movDetalle.oBE.IdMoneda);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescMoneda", movDetalle.oBE.DescMoneda);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "NumeroCuenta", movDetalle.oBE.NumeroCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvPersonaCuentaBancaria.SetRowCellValue(gvPersonaCuentaBancaria.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPersonaCuentaBancaria.UpdateCurrentRow();


                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarCuentaBancariatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaPersonaCuentaBancariaOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPersonaCuentaBancariaEdit movDetalle = new frmManPersonaCuentaBancariaEdit();
                movDetalle.pOperacion = frmManPersonaCuentaBancariaEdit.Operacion.Modificar;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                movDetalle.IdPersona = Convert.ToInt32(gvPersonaCuentaBancaria.GetFocusedRowCellValue("IdPersona"));
                movDetalle.IdPersonaCuentaBancaria = Convert.ToInt32(gvPersonaCuentaBancaria.GetFocusedRowCellValue("IdPersonaCuentaBancaria"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPersonaCuentaBancaria.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdPersona", movDetalle.oBE.IdPersona);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdPersonaCuentaBancaria", movDetalle.oBE.IdPersonaCuentaBancaria);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdPersonaCuentaBancaria", movDetalle.oBE.IdPersonaCuentaBancaria);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdBanco", movDetalle.oBE.IdBanco);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "DescBanco", movDetalle.oBE.DescBanco);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdMoneda", movDetalle.oBE.IdMoneda);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "DescMoneda", movDetalle.oBE.DescMoneda);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "NumeroCuenta", movDetalle.oBE.NumeroCuenta);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "IdTipoCuenta", movDetalle.oBE.IdTipoCuenta);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "DescTipoCuenta", movDetalle.oBE.DescTipoCuenta);
                        gvPersonaCuentaBancaria.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPersonaCuentaBancaria.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPersonaCuentaBancaria.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPersonaCuentaBancaria.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPersonaCuentaBancaria.UpdateCurrentRow();


                    }
                }
            }
        }

        private void eliminarCuentaBancariatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPersonaCuentaBancariaOrigen.Count > 0)
                {
                    PersonaCuentaBancariaBE objBE_PersonaCuentaBancaria = new PersonaCuentaBancariaBE();
                    objBE_PersonaCuentaBancaria.IdPersonaCuentaBancaria = int.Parse(gvPersonaCuentaBancaria.GetFocusedRowCellValue("IdPersonaCuentaBancaria").ToString());
                    objBE_PersonaCuentaBancaria.IdEmpresa = Parametros.intEmpresaId;
                    objBE_PersonaCuentaBancaria.Usuario = Parametros.strUsuarioLogin;
                    objBE_PersonaCuentaBancaria.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    PersonaCuentaBancariaBL objBL_PersonaCuentaBancaria = new PersonaCuentaBancariaBL();
                    objBL_PersonaCuentaBancaria.Elimina(objBE_PersonaCuentaBancaria);
                    gvPersonaCuentaBancaria.DeleteRow(gvPersonaCuentaBancaria.FocusedRowHandle);
                    gvPersonaCuentaBancaria.RefreshData();

                }
                else
                {
                    gvPersonaCuentaBancaria.DeleteRow(gvPersonaCuentaBancaria.FocusedRowHandle);
                    gvPersonaCuentaBancaria.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCargo, new TablaElementoBL().ListaTodosActivoPorTablaExterna(Parametros.intEmpresaId, Parametros.intTblCargos, Convert.ToInt32(cboArea.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void nuevoContratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManPersonaContratoEdit movDetalle = new frmManPersonaContratoEdit();
                movDetalle.pOperacion = frmManPersonaContratoEdit.Operacion.Nuevo;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                movDetalle.IdContrato = 0;
                //int i = 0;
                //if (mListaContratoOrigen.Count > 0)
                //    i = mListaContratoOrigen.Max(ob => Convert.ToInt32(ob.Numero));


                movDetalle.TipoRegistro = 1;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaContratoOrigen.Count == 0)
                        {
                            gvContrato.AddNewRow();
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdPersona", IdPersona);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdContrato", 0);// movDetalle.oBE.IdContrato);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Numero", Convert.ToInt32(i) + 1);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RazonSocial", movDetalle.oBE.RazonSocial);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoContrato", movDetalle.oBE.IdTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoContrato", movDetalle.oBE.DescTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoTrabajador", movDetalle.oBE.IdTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoTrabajador", movDetalle.oBE.DescTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdCargo", movDetalle.oBE.IdCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdHorario", movDetalle.oBE.IdHorario);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaIni", movDetalle.oBE.FechaIni);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaVen", movDetalle.oBE.FechaVen);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoRenta", movDetalle.oBE.IdTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoRenta", movDetalle.oBE.DescTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Sueldo", movDetalle.oBE.Sueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "HoraExtra", movDetalle.oBE.HoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "BonSueldo", movDetalle.oBE.BonSueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Movilidad", movDetalle.oBE.Movilidad);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "SueldoNeto", movDetalle.oBE.SueldoNeto);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdClasificacionTrabajador", movDetalle.oBE.IdClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescClasificacionTrabajador", movDetalle.oBE.DescClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RutaContrato", movDetalle.oBE.RutaContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Dias", movDetalle.oBE.Dias);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Meses", movDetalle.oBE.Meses);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagHoraExtra", movDetalle.oBE.FlagHoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagEstado", true);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Usuario", Parametros.strUsuarioLogin);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Maquina", WindowsIdentity.GetCurrent().Name.ToString());
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", Convert.ToInt32(cboEmpresa.EditValue));
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvContrato.UpdateCurrentRow();

                            return;

                        }
                        if (mListaContratoOrigen.Count > 0)
                        {
                            var Buscar = mListaContratoOrigen.Where(oB => oB.NumeroCuenta == movDetalle.oBE.NumeroCuenta).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("La cuenta ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvContrato.AddNewRow();
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdPersona", IdPersona);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdContrato", 0); //movDetalle.oBE.IdContrato);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Numero", Convert.ToInt32(i) + 1);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RazonSocial", movDetalle.oBE.RazonSocial);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoContrato", movDetalle.oBE.IdTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoContrato", movDetalle.oBE.DescTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoTrabajador", movDetalle.oBE.IdTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoTrabajador", movDetalle.oBE.DescTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdCargo", movDetalle.oBE.IdCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdHorario", movDetalle.oBE.IdHorario);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaIni", movDetalle.oBE.FechaIni);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaVen", movDetalle.oBE.FechaVen);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoRenta", movDetalle.oBE.IdTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoRenta", movDetalle.oBE.DescTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Sueldo", movDetalle.oBE.Sueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "HoraExtra", movDetalle.oBE.HoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "BonSueldo", movDetalle.oBE.BonSueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Movilidad", movDetalle.oBE.Movilidad);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "SueldoNeto", movDetalle.oBE.SueldoNeto);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdClasificacionTrabajador", movDetalle.oBE.IdClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescClasificacionTrabajador", movDetalle.oBE.DescClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RutaContrato", movDetalle.oBE.RutaContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Dias", movDetalle.oBE.Dias);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Meses", movDetalle.oBE.Meses);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagHoraExtra", movDetalle.oBE.FlagHoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagEstado", true);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvContrato.UpdateCurrentRow();


                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarContratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaContratoOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPersonaContratoEdit movDetalle = new frmManPersonaContratoEdit();
                movDetalle.pOperacion = frmManPersonaContratoEdit.Operacion.Modificar;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                //movDetalle.IdPersona = IdPersona;
                movDetalle.IdContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString());
                movDetalle.oBE.IdContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString());
                movDetalle.oBE.IdTipoContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdTipoContrato").ToString());
                movDetalle.oBE.IdTipoTrabajador = int.Parse(gvContrato.GetFocusedRowCellValue("IdTipoTrabajador").ToString());
                movDetalle.oBE.IdEmpresa = int.Parse(gvContrato.GetFocusedRowCellValue("IdEmpresa").ToString());
                movDetalle.oBE.IdPersona = int.Parse(gvContrato.GetFocusedRowCellValue("IdPersona").ToString());
                //movDetalle.oBE.ApeNom = gvContrato.GetFocusedRowCellValue("ApeNom").ToString();
                movDetalle.oBE.IdTienda = int.Parse(gvContrato.GetFocusedRowCellValue("IdTienda").ToString());
                movDetalle.oBE.IdArea = int.Parse(gvContrato.GetFocusedRowCellValue("IdArea").ToString());
                movDetalle.oBE.IdCargo = int.Parse(gvContrato.GetFocusedRowCellValue("IdCargo").ToString());
                movDetalle.oBE.IdHorario = int.Parse(gvContrato.GetFocusedRowCellValue("IdHorario").ToString());
                movDetalle.oBE.FechaIni = DateTime.Parse(gvContrato.GetFocusedRowCellValue("FechaIni").ToString());
                if(gvContrato.GetFocusedRowCellValue("FechaVen") !=null)
                    movDetalle.oBE.FechaVen = DateTime.Parse(gvContrato.GetFocusedRowCellValue("FechaVen").ToString());
                movDetalle.oBE.IdTipoRenta = int.Parse(gvContrato.GetFocusedRowCellValue("IdTipoRenta").ToString());
                movDetalle.oBE.Sueldo = decimal.Parse(gvContrato.GetFocusedRowCellValue("Sueldo").ToString());
                movDetalle.oBE.HoraExtra = decimal.Parse(gvContrato.GetFocusedRowCellValue("HoraExtra").ToString());
                movDetalle.oBE.BonSueldo = decimal.Parse(gvContrato.GetFocusedRowCellValue("BonSueldo").ToString());
                movDetalle.oBE.Movilidad = decimal.Parse(gvContrato.GetFocusedRowCellValue("Movilidad").ToString());
                movDetalle.oBE.SueldoNeto = decimal.Parse(gvContrato.GetFocusedRowCellValue("SueldoNeto").ToString());
                movDetalle.oBE.IdClasificacionTrabajador = int.Parse(gvContrato.GetFocusedRowCellValue("IdClasificacionTrabajador").ToString());
                movDetalle.oBE.RutaContrato = gvContrato.GetFocusedRowCellValue("RutaContrato").ToString();
                movDetalle.oBE.Observacion = gvContrato.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.oBE.Dias = int.Parse(gvContrato.GetFocusedRowCellValue("Dias").ToString());
                movDetalle.oBE.Meses = int.Parse(gvContrato.GetFocusedRowCellValue("Meses").ToString());
                movDetalle.oBE.FlagHoraExtra = Boolean.Parse(gvContrato.GetFocusedRowCellValue("FlagHoraExtra").ToString());
                movDetalle.TipoRegistro = 1;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvContrato.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvContrato.SetRowCellValue(xposition, "IdPersona", IdPersona);
                        gvContrato.SetRowCellValue(xposition, "IdContrato", movDetalle.oBE.IdContrato);
                        gvContrato.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvContrato.SetRowCellValue(xposition, "RazonSocial", movDetalle.oBE.RazonSocial);
                        gvContrato.SetRowCellValue(xposition, "IdTipoContrato", movDetalle.oBE.IdTipoContrato);
                        gvContrato.SetRowCellValue(xposition, "DescTipoContrato", movDetalle.oBE.DescTipoContrato);
                        gvContrato.SetRowCellValue(xposition, "IdTipoTrabajador", movDetalle.oBE.IdTipoTrabajador);
                        gvContrato.SetRowCellValue(xposition, "DescTipoTrabajador", movDetalle.oBE.DescTipoTrabajador);
                        gvContrato.SetRowCellValue(xposition, "IdTienda", movDetalle.oBE.IdTienda);
                        gvContrato.SetRowCellValue(xposition, "DescTienda", movDetalle.oBE.DescTienda);
                        gvContrato.SetRowCellValue(xposition, "IdArea", movDetalle.oBE.IdArea);
                        gvContrato.SetRowCellValue(xposition, "DescArea", movDetalle.oBE.DescArea);
                        gvContrato.SetRowCellValue(xposition, "IdCargo", movDetalle.oBE.IdCargo);
                        gvContrato.SetRowCellValue(xposition, "DescCargo", movDetalle.oBE.DescCargo);
                        gvContrato.SetRowCellValue(xposition, "IdHorario", movDetalle.oBE.IdHorario);
                        gvContrato.SetRowCellValue(xposition, "FechaIni", movDetalle.oBE.FechaIni);
                        gvContrato.SetRowCellValue(xposition, "FechaVen", movDetalle.oBE.FechaVen);
                        gvContrato.SetRowCellValue(xposition, "IdTipoRenta", movDetalle.oBE.IdTipoRenta);
                        gvContrato.SetRowCellValue(xposition, "DescTipoRenta", movDetalle.oBE.DescTipoRenta);
                        gvContrato.SetRowCellValue(xposition, "Sueldo", movDetalle.oBE.Sueldo);
                        gvContrato.SetRowCellValue(xposition, "HoraExtra", movDetalle.oBE.HoraExtra);
                        gvContrato.SetRowCellValue(xposition, "BonSueldo", movDetalle.oBE.BonSueldo);
                        gvContrato.SetRowCellValue(xposition, "Movilidad", movDetalle.oBE.Movilidad);
                        gvContrato.SetRowCellValue(xposition, "SueldoNeto", movDetalle.oBE.SueldoNeto);
                        gvContrato.SetRowCellValue(xposition, "IdClasificacionTrabajador", movDetalle.oBE.IdClasificacionTrabajador);
                        gvContrato.SetRowCellValue(xposition, "DescClasificacionTrabajador", movDetalle.oBE.DescClasificacionTrabajador);
                        gvContrato.SetRowCellValue(xposition, "RutaContrato", movDetalle.oBE.RutaContrato);
                        gvContrato.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        gvContrato.SetRowCellValue(xposition, "Dias", movDetalle.oBE.Dias);
                        gvContrato.SetRowCellValue(xposition, "Meses", movDetalle.oBE.Meses);
                        gvContrato.SetRowCellValue(xposition, "FlagHoraExtra", movDetalle.oBE.FlagHoraExtra);
                        gvContrato.SetRowCellValue(xposition, "FlagEstado", true);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvContrato.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvContrato.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvContrato.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvContrato.UpdateCurrentRow();


                    }
                }
            }

        }

        private void eliminarContratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaContratoOrigen.Count > 0)
                {
                    ContratoBE objBE_Contrato = new ContratoBE();
                    objBE_Contrato.IdContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString());
                    objBE_Contrato.IdEmpresa = Parametros.intEmpresaId;
                    objBE_Contrato.Usuario = Parametros.strUsuarioLogin;
                    objBE_Contrato.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    ContratoBL objBL_Contrato = new ContratoBL();
                    objBL_Contrato.Elimina(objBE_Contrato);
                    gvContrato.DeleteRow(gvContrato.FocusedRowHandle);
                    gvContrato.RefreshData();

                }
                else
                {
                    gvContrato.DeleteRow(gvContrato.FocusedRowHandle);
                    gvContrato.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimircontratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteContratoPersonaBE> lstReporte = null;
                lstReporte = new ReporteContratoPersonaBL().Listado(int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPersonal = new RptVistaReportes();
                        objRptPersonal.VerRptContratoPersona(lstReporte);
                        objRptPersonal.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el contrato, verificar que exista una plantilla para este tipo de formato.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvContrato_DoubleClick(object sender, EventArgs e)
        {
            modificarContratotoolStripMenuItem_Click(sender, e);
        }

        private void btnActualizarDescanso_Click(object sender, EventArgs e)
        {

        }

        private void chkPensionista_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPensionista.Checked)
            {
                optOnpNo.Checked = true;
                cboAfp.EditValue = Parametros.intNinguno;
                cboAfp.Properties.ReadOnly = true;
                optOnpSi.Enabled = false;
                optOnpNo.Enabled = false;
            }
            else
            {
                cboAfp.Properties.ReadOnly = false;
                optOnpSi.Enabled = true;
                optOnpNo.Enabled = true;
            }
        }

        private void deFechaCese_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(deFechaCese.EditValue) <= DateTime.Now)
            {
                optInactivo.Checked = true;
            }
            else
            {
                optActivo.Checked = true;
            }
        }

        private void cboTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cboTipoDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
            {
                txtDni.Properties.MaxLength = 8;
            }else
            {
                txtDni.Properties.MaxLength = 0;
            }
        }

        private void renovartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManPersonaContratoEdit movDetalle = new frmManPersonaContratoEdit();
                movDetalle.pOperacion = frmManPersonaContratoEdit.Operacion.Renovar;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                movDetalle.IdContrato = 0;
                movDetalle.IdPersona = IdPersona;
                //int i = 0;
                //if (mListaContratoOrigen.Count > 0)
                //    i = mListaContratoOrigen.Max(ob => Convert.ToInt32(ob.Numero));


                movDetalle.TipoRegistro = 1;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaContratoOrigen.Count == 0)
                        {
                            gvContrato.AddNewRow();
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdPersona", IdPersona);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdContrato", 0);// movDetalle.oBE.IdContrato);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Numero", Convert.ToInt32(i) + 1);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RazonSocial", movDetalle.oBE.RazonSocial);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoContrato", movDetalle.oBE.IdTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoContrato", movDetalle.oBE.DescTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoTrabajador", movDetalle.oBE.IdTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoTrabajador", movDetalle.oBE.DescTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdCargo", movDetalle.oBE.IdCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdHorario", movDetalle.oBE.IdHorario);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaIni", movDetalle.oBE.FechaIni);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaVen", movDetalle.oBE.FechaVen);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoRenta", movDetalle.oBE.IdTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoRenta", movDetalle.oBE.DescTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Sueldo", movDetalle.oBE.Sueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "HoraExtra", movDetalle.oBE.HoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "BonSueldo", movDetalle.oBE.BonSueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Movilidad", movDetalle.oBE.Movilidad);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "SueldoNeto", movDetalle.oBE.SueldoNeto);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdClasificacionTrabajador", movDetalle.oBE.IdClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescClasificacionTrabajador", movDetalle.oBE.DescClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RutaContrato", movDetalle.oBE.RutaContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Dias", movDetalle.oBE.Dias);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Meses", movDetalle.oBE.Meses);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagHoraExtra", movDetalle.oBE.FlagHoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagEstado", true);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Usuario", Parametros.strUsuarioLogin);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Maquina", WindowsIdentity.GetCurrent().Name.ToString());
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", Convert.ToInt32(cboEmpresa.EditValue));
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvContrato.UpdateCurrentRow();

                            return;

                        }
                        if (mListaContratoOrigen.Count > 0)
                        {
                            var Buscar = mListaContratoOrigen.Where(oB => oB.NumeroCuenta == movDetalle.oBE.NumeroCuenta).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("La cuenta ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvContrato.AddNewRow();
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdPersona", IdPersona);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdContrato", 0); //movDetalle.oBE.IdContrato);
                            //gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Numero", Convert.ToInt32(i) + 1);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RazonSocial", movDetalle.oBE.RazonSocial);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoContrato", movDetalle.oBE.IdTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoContrato", movDetalle.oBE.DescTipoContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoTrabajador", movDetalle.oBE.IdTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoTrabajador", movDetalle.oBE.DescTipoTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdCargo", movDetalle.oBE.IdCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdHorario", movDetalle.oBE.IdHorario);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaIni", movDetalle.oBE.FechaIni);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FechaVen", movDetalle.oBE.FechaVen);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdTipoRenta", movDetalle.oBE.IdTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescTipoRenta", movDetalle.oBE.DescTipoRenta);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Sueldo", movDetalle.oBE.Sueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "HoraExtra", movDetalle.oBE.HoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "BonSueldo", movDetalle.oBE.BonSueldo);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Movilidad", movDetalle.oBE.Movilidad);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "SueldoNeto", movDetalle.oBE.SueldoNeto);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "IdClasificacionTrabajador", movDetalle.oBE.IdClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "DescClasificacionTrabajador", movDetalle.oBE.DescClasificacionTrabajador);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "RutaContrato", movDetalle.oBE.RutaContrato);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Dias", movDetalle.oBE.Dias);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "Meses", movDetalle.oBE.Meses);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagHoraExtra", movDetalle.oBE.FlagHoraExtra);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "FlagEstado", true);
                            gvContrato.SetRowCellValue(gvContrato.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvContrato.UpdateCurrentRow();


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkas_CheckedChanged(object sender, EventArgs e)
        {
            this.MostrarAsignaciónFamiliar();
        }
        private void MostrarAsignaciónFamiliar()
        {
            lblAsigFam.Visible = false;
            lblAsigFam.Text = "";
            if (chkas.Checked)
            {
                ParametroBE Parametro = new ParametroBL().Selecciona("SueldoMinimo");
                decimal dAsigFam = (Parametro.Numero * Parametros.intPorcentajeAsigFamiliar);
                lblAsigFam.Text = "+" + Convert.ToString( Math.Round(dAsigFam, 2));  
                lblAsigFam.Visible = true;
            }
        }
    }
}