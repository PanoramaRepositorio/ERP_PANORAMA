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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegInmueblePagoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InmueblePagoBE> lstInmueblePago;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdCliente = 0;
        public int IdInmueble = 0;
        public string TipoRegistro = "I";
        private int IdEmpresa = 0;
        private int Periodo = Parametros.intPeriodo;

        int _IdInmueblePago = 0;

        public int IdInmueblePago
        {
            get { return _IdInmueblePago; }
            set { _IdInmueblePago = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegInmueblePagoEdit()
        {
            InitializeComponent();
        }

        private void frmRegInmueblePagoEdit_Load(object sender, EventArgs e)
        {
            deFechaPago.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inmueble Pago - Nuevo";
                //cboBanco.EditValue = IdBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inmueble Pago - Modificar";

                InmueblePagoBE objE_InmueblePago = null;
                objE_InmueblePago = new InmueblePagoBL().Selecciona(IdInmueblePago);

                IdInmueblePago = objE_InmueblePago.IdInmueblePago;
                IdInmueble = objE_InmueblePago.IdInmueble;
                IdEmpresa = objE_InmueblePago.IdEmpresa;
                Periodo = objE_InmueblePago.Periodo;
                cboMes.EditValue = objE_InmueblePago.Mes;
                IdCliente = objE_InmueblePago.IdCliente;
                txtNumero.EditValue = objE_InmueblePago.NumeroDocumento;
                deFechaPago.EditValue = objE_InmueblePago.FechaPago;
                deFechaVencimiento.EditValue = objE_InmueblePago.FechaVencimiento;
                txtConcepto.EditValue = objE_InmueblePago.Concepto;
                cboMoneda.EditValue = objE_InmueblePago.IdMoneda;
                txtImporte.EditValue = objE_InmueblePago.Importe;
                txtObservacion.EditValue = objE_InmueblePago.Observacion;

                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);
                txtDescCliente.EditValue = objE_Cliente.DescCliente;
                txtNumeroDocumento.EditValue = objE_Cliente.NumeroDocumento;
                txtDireccion.EditValue = objE_Cliente.Direccion;

                InmuebleBE objE_Inmueble = null;
                objE_Inmueble = new InmuebleBL().Selecciona(IdInmueble);
                txtInmueblePago.EditValue = objE_Inmueble.DescInmueble;
                txtPrecioAlquiler.EditValue = objE_Inmueble.PrecioAlquiler;

                switch (objE_InmueblePago.TipoMovimiento)
                {
                    case "I":
                        optPagoAbono.Checked = true;
                        break;
                    case "S":
                        optCreditoCargo.Checked = true;
                        break;
                    case "G":
                        optGarantia.Checked = true;
                        break;
                    default:
                        //optGarantia.Checked = true;
                        break;                
                }



                /*if (objE_InmueblePago.TipoMovimiento == "I")
                    optPagoAbono.Checked = true;
                else 
                    optCreditoCargo.Checked = true;*/

            }

            ValidarTipoRegistro(); // option

            txtNumero.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    if (optPagoAbono.Checked == true)
                        TipoRegistro = "I";
                    else if(optCreditoCargo.Checked == true)
                        TipoRegistro = "S";
                    else
                        TipoRegistro = "G";


                    InmueblePagoBL objBL_InmueblePago = new InmueblePagoBL();
                    InmueblePagoBE objInmueblePago = new InmueblePagoBE();

                    if (deFechaPago.Text == "")
                        objInmueblePago.FechaPago = null;
                    else
                        objInmueblePago.FechaPago = Convert.ToDateTime(deFechaPago.DateTime.ToShortDateString());

                    if (deFechaVencimiento.Text == "")
                        objInmueblePago.FechaVencimiento = null;
                    else
                        objInmueblePago.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());


                    objInmueblePago.IdInmueblePago = IdInmueblePago;
                    objInmueblePago.IdEmpresa = IdEmpresa;
                    objInmueblePago.Periodo = Parametros.intPeriodo;
                    objInmueblePago.Mes = Convert.ToInt32(cboMes.EditValue);
                    objInmueblePago.IdInmueble = IdInmueble;
                    objInmueblePago.IdCliente = IdCliente;
                    objInmueblePago.NumeroDocumento = txtNumero.Text.Trim();
                    objInmueblePago.FechaPago = objInmueblePago.FechaPago; //Convert.ToDateTime(deFechaPago.EditValue);
                    objInmueblePago.FechaVencimiento = objInmueblePago.FechaVencimiento; // Convert.ToDateTime(deFechaVencimiento.EditValue);
                    objInmueblePago.Concepto = txtConcepto.Text.Trim();
                    objInmueblePago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objInmueblePago.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objInmueblePago.TipoMovimiento = TipoRegistro;
                    objInmueblePago.Observacion = txtObservacion.Text.Trim();
                    objInmueblePago.FlagEstado = true;
                    objInmueblePago.Usuario = Parametros.strUsuarioLogin;
                    objInmueblePago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_InmueblePago.Inserta(objInmueblePago);
                    else
                        objBL_InmueblePago.Actualiza(objInmueblePago);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnInmueble_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaInmueble frm = new frmBuscaInmueble();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    //cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdInmueble = frm._Be.IdInmueble;
                    txtInmueblePago.Text = frm._Be.DescInmueble;
                    txtPrecioAlquiler.EditValue = frm._Be.PrecioAlquiler;
                    IdEmpresa = frm._Be.IdEmpresa;
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
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";


            if (txtConcepto.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese  Concepto.\n";
                flag = true;
            }

            if (txtNumero.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese el N° de Pago.\n";
                flag = true;
            }

            if (txtImporte.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese Importe.\n";
                flag = true;
            }

            //if (txtInmueblePago.Text.Trim() == "")
            //{
            //    strMensaje = strMensaje + "- Selecione el Inmueble.\n";
            //    flag = true;
            //}

            //if (txtDescCliente.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese el Cliente.\n";
            //    flag = true;
            //}

            //if (txtDireccion.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese dirección.\n";
            //    flag = true;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInmueblePago.Where(oB => oB.DescInmueble == txtInmueblePago.Text.Trim() && oB.NumeroDocumento == txtNumero.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Pago ya existe.\n";
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

        private void ValidarTipoRegistro()
        {
            if (TipoRegistro == "I")
            {
                optPagoAbono.Checked = true;

            }
            else
            {
                optCreditoCargo.Checked = true;
            }
        }

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "Enero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "Febrero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "Marzo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "Abril";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "Mayo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "Junio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "Julio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "Agosto";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "Septiembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "Octubre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "Noviembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "Diciembre";
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion

        private void optPagoAbono_CheckedChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                deFechaVencimiento.EditValue = "";
                deFechaPago.EditValue = DateTime.Now;
            }
        }

        private void optCreditoCargo_CheckedChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                deFechaPago.EditValue = "";
                deFechaVencimiento.EditValue = DateTime.Now;
            }

        }



    }
}