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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegPrestamoBancoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PrestamoBancoBE> lstPrestamoBanco;
        public List<CPrestamoBancoDetalle> mListaPrestamoBancoDetalleOrigen = new List<CPrestamoBancoDetalle>();
        public List<CuentaBancoBE> mListaCuentaBanco = new List<CuentaBancoBE>();// Cargar Descuento Cliente
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdCuentaBanco = 0;

        int _IdPrestamoBanco = 0;

        public int IdPrestamoBanco
        {
            get { return _IdPrestamoBanco; }
            set { _IdPrestamoBanco = value; }
        }
        private int NumCar = 0;
        #endregion

        #region "Eventos"
        public frmRegPrestamoBancoEdit()
        {
            InitializeComponent();
        }

        private void frmRegPrestamoBancoEdit_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboCuentaBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboTipoPrestamo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPrestamo), "DescTablaElemento", "IdTablaElemento", true);

            //CargarCombo

            if (pOperacion == Operacion.Nuevo)
            {
                CargarCombo();

                this.Text = "Préstamo Banco - Nuevo";
                cboCuentaBanco.EditValue = IdCuentaBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Préstamo Banco - Modificar";

                BSUtils.LoaderLook(cboCuentaBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);

                PrestamoBancoBE objE_PrestamoBanco = null;
                objE_PrestamoBanco = new PrestamoBancoBL().Selecciona(IdPrestamoBanco);

                IdCuentaBanco = objE_PrestamoBanco.IdCuentaBanco;
                cboCuentaBanco.EditValue = objE_PrestamoBanco.IdBanco;
                txtNumeroPrestamo.EditValue = objE_PrestamoBanco.NumeroPrestamo;
                cboMoneda.EditValue = objE_PrestamoBanco.IdMoneda;
                deFecha.EditValue = objE_PrestamoBanco.Fecha;
                deFechaVencimiento.EditValue = objE_PrestamoBanco.FechaVencimiento;
                txtNumeroPrestamo.Text = objE_PrestamoBanco.NumeroPrestamo;
                txtNumeroCuenta.Text = objE_PrestamoBanco.CuentaCargo;
                txtPrestamo.EditValue = objE_PrestamoBanco.Prestamo;
                txtSaldoPrestamo.EditValue = objE_PrestamoBanco.SaldoPrestamo;
                txtSaldoInteres.EditValue = objE_PrestamoBanco.SaldoInteres;
                txtInteres.EditValue = objE_PrestamoBanco.TotalInteres;
                txtTEA.EditValue = objE_PrestamoBanco.TEA;
                txtTasaIntMora.EditValue = objE_PrestamoBanco.TasaIntMoratorio;
                txtCuotas.EditValue = objE_PrestamoBanco.NumeroCuotas;
                cboTipoPrestamo.EditValue = objE_PrestamoBanco.IdTipoPrestamo;
                txtObservacion.EditValue = objE_PrestamoBanco.Observacion;

                    //if(Parametros.strUsuarioLogin.ToLower() !="master")
                cboCuentaBanco.Properties.ReadOnly = true;
            }


            CargaPrestamoBancoDetalle();
            cboCuentaBanco.Focus();
            //txtNumeroPrestamo.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PrestamoBancoBL objBL_PrestamoBanco = new PrestamoBancoBL();
                    PrestamoBancoBE objPrestamoBanco = new PrestamoBancoBE();

                    objPrestamoBanco.IdPrestamoBanco = IdPrestamoBanco;
                    objPrestamoBanco.IdCuentaBanco = IdCuentaBanco;
                    objPrestamoBanco.NumeroPrestamo = txtNumeroPrestamo.Text;
                    objPrestamoBanco.CuentaCargo = txtNumeroCuenta.Text;
                    objPrestamoBanco.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPrestamoBanco.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objPrestamoBanco.NumeroCuotas = Convert.ToInt32(txtCuotas.EditValue);
                    objPrestamoBanco.Prestamo = Convert.ToDecimal(txtPrestamo.EditValue);
                    objPrestamoBanco.SaldoPrestamo = Convert.ToDecimal(txtSaldoPrestamo.EditValue);
                    objPrestamoBanco.SaldoInteres = Convert.ToDecimal(txtSaldoInteres.EditValue);
                    objPrestamoBanco.TotalInteres = Convert.ToDecimal(txtInteres.EditValue);
                    objPrestamoBanco.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPrestamoBanco.TEA = Convert.ToDecimal(txtTEA.EditValue);
                    objPrestamoBanco.TasaIntMoratorio = Convert.ToDecimal(txtTasaIntMora.EditValue);
                    objPrestamoBanco.IdTipoPrestamo = Convert.ToInt32(cboTipoPrestamo.EditValue);
                    objPrestamoBanco.FlagEstado = true;
                    objPrestamoBanco.Usuario = Parametros.strUsuarioLogin;
                    objPrestamoBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPrestamoBanco.IdEmpresa = Parametros.intEmpresaId;
                    objPrestamoBanco.Observacion = txtObservacion.Text.Trim();

                    //Préstamo detalle
                    List<PrestamoBancoDetalleBE> lstListaPrestamoDetalle = new List<PrestamoBancoDetalleBE>();

                    foreach(var item in mListaPrestamoBancoDetalleOrigen)
                    {
                        PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = item.IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.NumeroCuota = item.NumeroCuota;
                        objE_PrestamoBancoDetalle.FechaVencimiento = item.FechaVencimiento;
                        objE_PrestamoBancoDetalle.SaldoPendiente = item.SaldoPendiente;
                        objE_PrestamoBancoDetalle.Amortizacion = item.Amortizacion;
                        objE_PrestamoBancoDetalle.Interes = item.Interes;
                        objE_PrestamoBancoDetalle.EnvioInformacion = item.EnvioInformacion;
                        objE_PrestamoBancoDetalle.Desgravamen = item.Desgravamen;
                        objE_PrestamoBancoDetalle.Seguro = item.Seguro;
                        objE_PrestamoBancoDetalle.TotalPagar = item.TotalPagar;
                        objE_PrestamoBancoDetalle.FlagEstado = true;
                        lstListaPrestamoDetalle.Add(objE_PrestamoBancoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_PrestamoBanco.Inserta(objPrestamoBanco, lstListaPrestamoDetalle);
                    else
                        objBL_PrestamoBanco.Actualiza(objPrestamoBanco, lstListaPrestamoDetalle);

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

        private void frmRegPrestamoBancoEdit_Shown(object sender, EventArgs e)
        {
            NumCar = 1;
        }

        private void cboCuentaBanco_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (cboCuentaBanco.EditValue.ToString() != "0")
                {
                    if (NumCar == 1)
                    {
                        var item = cboCuentaBanco.GetSelectedDataRow() as CuentaBancoBE;
                        if (item.IdCuentaBanco > 0)
                        {
                            IdCuentaBanco = item.IdCuentaBanco;
                            txtNumeroCuenta.Text = item.NumeroCuenta.ToString();
                            cboMoneda.EditValue = item.IdMoneda;
                        }
                        else
                        {
                            IdCuentaBanco = 0;
                            txtNumeroCuenta.Text = "";
                        }
                    }
                }
            }
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

        private void cancelarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota ya está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    frmEstablecerFecha frm = new frmEstablecerFecha();
                    frm.Text = "Establecer Fecha de Pago";
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                        PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                        int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                        objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
                        objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
                        objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "CANCELADO");
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", frm.Fecha);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

                        CalcularTotalSaldoPrestamo();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void gvPrestamoBancoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalGeneral = 0;
                decimal decAmortizacion = 0;
                decimal decInteres = 0;
                decimal decEnvioInfo = 0;
                decimal decDesgravamen = 0;
                decimal decSeguro = 0;

                if (e.Column.FieldName == "Amortizacion")
                {
                    decAmortizacion = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));


                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                }
                if (e.Column.FieldName == "Interes")
                {
                    decInteres = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                }
                if (e.Column.FieldName == "EnvioInformacion")
                {
                    decEnvioInfo = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                }
                if (e.Column.FieldName == "Desgravamen")
                {
                    decDesgravamen = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                }
                if (e.Column.FieldName == "Seguro")
                {
                    decSeguro = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                }





                ////--calculamos el total general ------------
                //for (int i = 0; i < gvPrestamoBancoDetalle.RowCount; i++)
                //{
                //    decTotalGeneral = decTotalGeneral + Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["Total"])));
                //}


                //txtTotal.EditValue = decTotalGeneral;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pOperacion == Operacion.Nuevo)
                {
                    int nCuotas = 0;
                    nCuotas = Convert.ToInt32(txtCuotas.EditValue);
                    if (nCuotas > 0)
                    {
                        for (int i = 1; i <= nCuotas; i++)
                        {
                            gvPrestamoBancoDetalle.AddNewRow();
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", i);
                        }
                    }
                }
            }
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion != Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota no está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                    PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                    int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                    objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                    objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                    objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
                    objE_PrestamoBancoDetalle.FechaPago = null;
                    objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", null);
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

                    CalcularTotalSaldoPrestamo();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                //throw;
            }

        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            if (IdCuentaBanco == 0)
            {
                strMensaje = strMensaje + "- Selecione el banco.\n";
                flag = true;
            }

            if (txtNumeroPrestamo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese número de Préstamo.\n";
                flag = true;
            }

            if (deFecha.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha.\n";
                flag = true;
            }

            if (deFechaVencimiento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Vencimiento.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de moneda.\n";
                flag = true;
            }



            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPrestamoBanco.Where(oB => oB.IdMoneda == Convert.ToInt32(cboMoneda.EditValue) && oB.NumeroPrestamo == txtNumeroPrestamo.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El número de Prestamo ya existe.\n";
                    flag = true;
                }

                if (Convert.ToDecimal(txtPrestamo.EditValue)<=0)
                {
                    strMensaje = strMensaje + "- Ingrese el Total de préstamo.\n";
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

        private void CargaPrestamoBancoDetalle()
        {
            List<PrestamoBancoDetalleBE> lstTmpPrestamoBancoDetalle = null;
            lstTmpPrestamoBancoDetalle = new PrestamoBancoDetalleBL().ListaTodosActivo(IdPrestamoBanco,0);

            foreach (PrestamoBancoDetalleBE item in lstTmpPrestamoBancoDetalle)
            {
                CPrestamoBancoDetalle objE_PrestamoBancoDetalle = new CPrestamoBancoDetalle();
                objE_PrestamoBancoDetalle.IdEmpresa = item.IdEmpresa;
                objE_PrestamoBancoDetalle.IdPrestamoBanco = item.IdPrestamoBanco;
                objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = item.IdPrestamoBancoDetalle;
                objE_PrestamoBancoDetalle.NumeroCuota = item.NumeroCuota;
                objE_PrestamoBancoDetalle.FechaVencimiento = item.FechaVencimiento;
                objE_PrestamoBancoDetalle.SaldoPendiente = item.SaldoPendiente;
                objE_PrestamoBancoDetalle.Amortizacion = item.Amortizacion;
                objE_PrestamoBancoDetalle.Interes = item.Interes;
                objE_PrestamoBancoDetalle.EnvioInformacion = item.EnvioInformacion;
                objE_PrestamoBancoDetalle.Desgravamen = item.Desgravamen;
                objE_PrestamoBancoDetalle.Seguro = item.Seguro;
                objE_PrestamoBancoDetalle.TotalPagar = item.TotalPagar;
                objE_PrestamoBancoDetalle.IdSituacion = item.IdSituacion;
                objE_PrestamoBancoDetalle.DescSituacion = item.DescSituacion;
                objE_PrestamoBancoDetalle.FechaPago = item.FechaPago;
                objE_PrestamoBancoDetalle.UsuarioPago = item.UsuarioPago;
                objE_PrestamoBancoDetalle.FlagEstado = true;
                objE_PrestamoBancoDetalle.TipoOper = item.TipoOper;
                mListaPrestamoBancoDetalleOrigen.Add(objE_PrestamoBancoDetalle);
            }

            bsListado.DataSource = mListaPrestamoBancoDetalleOrigen;
            gcPrestamoBancoDetalle.DataSource = bsListado;
            gcPrestamoBancoDetalle.RefreshDataSource();

            lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
        }

        private void CargarCombo()
        {
            mListaCuentaBanco = new CuentaBancoBL().Lista(0);
            if (mListaCuentaBanco.Count > 0)
            {
                //cboCuentaBanco.Visible = true;
                cboCuentaBanco.Properties.DataSource = mListaCuentaBanco;
                //cboClientePromocion.Properties.ShowHeader = false;
                //cboPromocionEventual.Properties.ShowFooter = false;
                //cboClientePromocion.EditValue = mDescuentoClientePromocion.FirstOrDefault();
                cboCuentaBanco.EditValue = mListaCuentaBanco[0].IdCuentaBanco;
                cboCuentaBanco.Properties.DisplayMember = "DescBanco";
                //cboCuentaBanco.Visible = false;
            }
        }

        private void ImportarExcel(string filename)
        {
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            int TotalAgregado = 0;
            int TotalActualizado = 0;
            decimal decAmortizacion = 0;
            decimal decTotalInteres = 0;
            decimal decInteres = 0;
            int intCuotas = 0;
            DateTime FechaVen= DateTime.Now;
            string sNumeroPrestamo = "";


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
                //prgFactura.Properties.Step = 1;
                //prgFactura.Properties.Maximum = TotRow;
                //prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string NumeroCuota = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    DateTime FechaVencimiento = Convert.ToDateTime((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    string SaldoPendiente = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    string Amortizacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();
                    string Interes = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
                    string EnvioInformacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();
                    string Desgravamen = (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim();
                    string Seguro = (string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim();
                    string TotalPagar = (string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim();
                    string Moneda = (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim();
                    string Cuotas = (string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim();
                    string NumeroPrestamo = (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim();


                    if (pOperacion == Operacion.Nuevo)
                    {
                        gvPrestamoBancoDetalle.AddNewRow();
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", NumeroCuota);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Amortizacion", Amortizacion);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Interes", Interes);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Desgravamen", Desgravamen);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Seguro", Seguro);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TotalPagar", TotalPagar);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FlagEstado", true);
                        if (pOperacion == Operacion.Modificar)
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        TotalAgregado = TotalAgregado + 1;
                    }

                    decTotalInteres = decTotalInteres + Convert.ToDecimal(Interes);
                    decInteres = decInteres + Convert.ToDecimal(Interes);
                    intCuotas = Convert.ToInt32(Cuotas);
                    FechaVen = FechaVencimiento;
                    sNumeroPrestamo = NumeroPrestamo;
                    decAmortizacion = decAmortizacion + Convert.ToDecimal(Amortizacion);
                    //prgFactura.PerformStep();
                    //prgFactura.Update();

                    Row++;
                }

                txtSaldoPrestamo.EditValue = decAmortizacion;
                txtSaldoInteres.EditValue = decTotalInteres;
                txtInteres.EditValue = decInteres;
                txtCuotas.EditValue = intCuotas;
                deFechaVencimiento.EditValue = FechaVen;
                txtNumeroPrestamo.Text = sNumeroPrestamo;
                lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
               // CalculaTotales();


                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void CalcularTotalSaldoPrestamo()
        {
            try
            {
                decimal decSaldo = 0;
                decimal decInteres = 0;
                decimal decTotalInteres = 0;
                decimal decMayorSaldo = 0;
                int intSituacion = 0;

                for (int i = 0; i < gvPrestamoBancoDetalle.RowCount; i++)
                {
                    intSituacion = Convert.ToInt32(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["IdSituacion"])));

                    decSaldo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["SaldoPendiente"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["Interes"])));

                    if (intSituacion != Parametros.intSITPagoCancelado)
                    {
                        decTotalInteres = decTotalInteres + decInteres;

                        if(decSaldo > decMayorSaldo)
                        {
                            decMayorSaldo = decSaldo;
                        }
                    }
                }
                txtSaldoPrestamo.EditValue = decMayorSaldo;
                txtSaldoInteres.EditValue = decTotalInteres;
                //lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public class CPrestamoBancoDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPrestamoBanco { get; set; }
            public Int32 IdPrestamoBancoDetalle { get; set; }
            public Int32 NumeroCuota { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public Decimal SaldoPendiente { get; set; }
            public Decimal Amortizacion { get; set; }
            public Decimal Interes { get; set; }
            public Decimal EnvioInformacion { get; set; }
            public Decimal Desgravamen { get; set; }
            public Decimal Seguro { get; set; }
            public Decimal TotalPagar { get; set; }
            public Int32  IdSituacion { get; set; }
            public String DescSituacion { get; set; }
            public DateTime? FechaPago { get; set; }
            public String UsuarioPago { get; set; }


            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CPrestamoBancoDetalle()
            {

            }
        }


    }
}