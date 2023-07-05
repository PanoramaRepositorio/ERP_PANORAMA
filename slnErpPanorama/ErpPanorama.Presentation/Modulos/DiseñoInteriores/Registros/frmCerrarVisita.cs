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
using Microsoft.VisualBasic.Devices;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmCerrarVisita : DevExpress.XtraEditors.XtraForm
    {
        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
        public AgendaVisitaBE oBE = new AgendaVisitaBE();
        #region "Propiedades"

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }


        int _IdAgenda = 0;

        public int IdAgenda
        {
            get { return _IdAgenda; }
            set { _IdAgenda = value; }
        }

        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        int _IdTipoCliente = 0;

        public int IdTipoCliente
        {
            get { return _IdTipoCliente; }
            set { _IdTipoCliente = value; }
        }

        int _IdAsesor = 0;

        public int IdAsesor
        {
            get { return _IdAsesor; }
            set { _IdAsesor = value; }
        }

        string _NombresAsesor = "";
        public string NombresAsesor
        {
            get { return _NombresAsesor; }
            set { _NombresAsesor = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public AsesoriaBE pAsesoriaBE { get; set; }

        #endregion

        #region "Eventos"

        public frmCerrarVisita()
        {
            InitializeComponent();
        }

        private void frmCerrarVisita_Load(object sender, EventArgs e)
        {
            string IdDepartamento = string.Empty;
            string IdProvincia = string.Empty;
            string IdDistrito = string.Empty;

            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            AgendaVisitaBE objE_Visita = null;
            objE_Visita = new AgendaVisitaBL().BuscarVisita(IdAgenda);

            denavAgenda.EditValue = objE_Visita.FechaAgenda;
            textBox3.Text = objE_Visita.NumAgendaVisita;
            txtNumeroDocumento.Text = objE_Visita.NumeroDocumento;
            txtDescCliente.Text = objE_Visita.DescCliente;
            txtNumProyecto.Text = objE_Visita.NumeroProyecto;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 92), "DescTablaElemento", "IdTablaElemento", true);  //Motivo VISITA
            cboMotivo.EditValue = objE_Visita.IdMotivo;
            txtCelular.Text = objE_Visita.Celular;
            txtAgenda.Text = objE_Visita.Agenda;
            txtDireccion.Text = objE_Visita.Lugar;
            txtObservaciones.Text = objE_Visita.Observacion;
            txtDuracion.Text = objE_Visita.Duracion.ToString();
            txtObs.Text = objE_Visita.PuntosTratados;
            lblDisenadora.Text = objE_Visita.Nombres;

            txtRutaArchivo.Text = objE_Visita.RutaArchivo;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nuevo";
            }
            ////else if (pOperacion == Operacion.Modificar)
            ////{
            ////   // this.Text = "Modificar";
            ////    //deFechaContrato.EditValue = pAsesoriaBE.FechaContrato;
            ////    //deFechaVenta.EditValue = pAsesoriaBE.FechaVenta;
            ////    //deFechaVisita.EditValue = pAsesoriaBE.FechaVisita;
            ////    //deFechaEntrega.EditValue = pAsesoriaBE.FechaEntrega;
            ////    //txtObservaciones.EditValue = pAsesoriaBE.Observacion;
            ////    //txtNumero.EditValue = pAsesoriaBE.Numero;
            ////    IdPedido = Convert.ToInt32(pAsesoriaBE.IdPedido);
            ////    IdCliente = pAsesoriaBE.IdCliente;
            ////    //cboAsesor.EditValue = pAsesoriaBE.IdAsesor;
            ////    //btnBuscar.Enabled = false;
            ////}
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Consulta Visita";
                btnGrabar.Enabled = false;

                txtObs.ReadOnly = true;
                timTermino.ReadOnly = true;
                simpleButton1.Enabled = false;
                timTermino.EditValue = Convert.ToDateTime(objE_Visita.TiempoTermino).ToString("HH:mm:ss");
            }

            //deFecha.Select();
            txtNumeroDocumento.Select();
            if (objE_Visita.Ubigeo.Trim() != "")
                IdDepartamento = objE_Visita.Ubigeo.Trim().Substring(0, 2);
            cboDepartamento.EditValue = IdDepartamento;
            if (objE_Visita.Ubigeo.Trim() != "")
                IdProvincia = objE_Visita.Ubigeo.Substring(2, 2);
            cboProvincia.EditValue = IdProvincia;
            if (objE_Visita.Ubigeo.Trim() != "")
                IdDistrito = objE_Visita.Ubigeo.Substring(4, 2);
               cboDistrito.EditValue = IdDistrito;

            txtNuevaRuta.EditValue = "\\\\172.16.0.155\\Varios";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                AgendaVisitaBE objAgenda = new AgendaVisitaBE();
                AgendaVisitaBL objBL_Agenda = new AgendaVisitaBL();

                //  this.DialogResult = DialogResult.OK;
                if (txtRutaArchivo.EditValue.ToString() != "")
                {
                    mycomputer.FileSystem.CopyFile(txtRutaArchivo.Text.Trim(), txtNuevaRuta.Text.Trim() + txtRutaArchivo.Text.Substring(txtRutaArchivo.Text.LastIndexOf(@"\")), true);   // Copiamos el archivo.
                }
                if (timTermino.EditValue.ToString() == "00:00:00")
                {
                    XtraMessageBox.Show("Ingrese la hora término de la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timTermino.Select();
                    return;
                }

                objAgenda.IdAgendaVisita = IdAgenda;
                objAgenda.PuntosTratados = txtObs.Text.Trim();
                objAgenda.TiempoTermino =  timTermino.EditValue.ToString();

                objAgenda.RutaArchivo = txtRutaArchivo.EditValue.ToString() == "" ? "":  txtNuevaRuta.Text.Trim() + txtRutaArchivo.Text.Substring(txtRutaArchivo.Text.LastIndexOf(@"\"));
                objAgenda.IdSituacion = Parametros.intVisitado;
                //objAgenda.fname = txtRutaArchivo.Text;
                //objAgenda.Tipo = ".pdf";

                objBL_Agenda.CerrarVisita(objAgenda);

                XtraMessageBox.Show("Se grabó satisfactoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

        private void deFechaContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaVisita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmBusCliente frm = new frmBusCliente();
            //    frm.pFlagMultiSelect = false;
            //    frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
            //    frm.ShowDialog();
            //    if (frm.pClienteBE != null)
            //    {
            //        IdCliente = frm.pClienteBE.IdCliente;
            //        txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
            //        txtDescCliente.Text = frm.pClienteBE.DescCliente;
            //        deFechaVenta.Focus();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingrese el Cliente.\n";
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

        private void cboAsesor_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pClienteBE != null)
                {
                    if (frm.pClienteBE.AbrevDomicilio == "OTR") frm.pClienteBE.AbrevDomicilio = ""; else frm.pClienteBE.AbrevDomicilio = frm.pClienteBE.AbrevDomicilio + " ";

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;

                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        DateTime FechaNac = frm.pClienteBE.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        List<DocumentoVentaBE> lstVenta = null;
                        lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, frm.pClienteBE.IdCliente);
                    }

                    string IdDepartamento = string.Empty;
                    string IdProvincia = string.Empty;
                    string IdDistrito = string.Empty;

                        ClienteBE objE_Cliente = null;
                        objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, frm.pClienteBE.NumeroDocumento);
                        txtCelular.Text = objE_Cliente.Celular;
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        cboDepartamento.EditValue = IdDepartamento;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        cboProvincia.EditValue = IdProvincia;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        cboDistrito.EditValue = IdDistrito;
                    }

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
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        txtCelular.Text = objE_Cliente.Celular;

                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        cboDepartamento.EditValue = IdDepartamento;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        cboProvincia.EditValue = IdProvincia;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        cboDistrito.EditValue = IdDistrito;
                    }
                    else
                    {
                        if (XtraMessageBox.Show("El cliente no existe, desea registrar al nuevo cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            btnNuevoCliente_Click(sender, e);
                        }
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
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;


                        ClienteBE objE_Cliente2 = null;
                        objE_Cliente2 = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, objE_Cliente.NumeroDocumento.Trim());
                        txtCelular.Text = objE_Cliente2.Celular;

                        if (objE_Cliente2 != null)
                        {
                            if (objE_Cliente2.AbrevDomicilio == "OTR")
                                objE_Cliente2.AbrevDomicilio = "";
                            else
                                objE_Cliente2.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                            IdCliente = objE_Cliente2.IdCliente;
                            txtNumeroDocumento.Text = objE_Cliente2.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente2.DescCliente;
                            txtDireccion.Text = objE_Cliente2.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                            IdTipoCliente = objE_Cliente2.IdTipoCliente;

                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdDepartamento = objE_Cliente2.IdUbigeoDom.Substring(0, 2);
                            cboDepartamento.EditValue = IdDepartamento;
                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdProvincia = objE_Cliente2.IdUbigeoDom.Substring(2, 2);
                            cboProvincia.EditValue = IdProvincia;
                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdDistrito = objE_Cliente2.IdUbigeoDom.Substring(4, 2);
                            cboDistrito.EditValue = IdDistrito;
                        }


                    }




                }
            }
            catch (Exception ex)
            {
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

        private void denavAgenda_EditValueChanged(object sender, EventArgs e)
        {
         //   XtraMessageBox.Show("Ingrese nombre/dirección cliente para la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "PDF Documents|*.pdf|JPG Images |*.jpg|All Files (*.*)|*.*";
            if (Dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                txtRutaArchivo.Text = Dialog1.FileName;
                Cursor = Cursors.Default;
            }
        }
    }
}