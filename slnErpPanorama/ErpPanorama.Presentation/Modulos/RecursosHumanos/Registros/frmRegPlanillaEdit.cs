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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPlanillaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PlanillaBE> lstPlanilla;
        public List<CPlanillaDetalle> mListaPlanillaDetalleOrigen = new List<CPlanillaDetalle>();
        public List<PlanillaDetalleBE> mListaPlanillaDetalleCalculo = new List<PlanillaDetalleBE>();

        int _IdPlanilla = 0;

        public int IdPlanilla
        {
            get { return _IdPlanilla; }
            set { _IdPlanilla = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        #endregion

        #region "Eventos"

        public frmRegPlanillaEdit()
        {
            InitializeComponent();
            gcApeNom.Caption = "Apellidos y\nNombres";
            gcSueldoBruto.Caption = "Sueldo\nBruto";
        }

        private void frmRegPlanillaEdit_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            txtHorasOrdinarias.EditValue = Parametros.intHorasOrdinarias;
            txtHorasExtrasDiarias.EditValue = Parametros.dblHorasExtrasDiarias;
            txtRemuneracionVital.EditValue = Parametros.dmlRemuneracionVital;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Planilla de Sueldos - Nuevo";
            }
            else
            {
                this.Text = "Planilla de Sueldos - Modificar";

                PlanillaBE objE_Planilla = null;
                objE_Planilla = new PlanillaBL().Selecciona(IdPlanilla);
                cboEmpresa.EditValue = objE_Planilla.IdEmpresa;
                txtPeriodo.EditValue = objE_Planilla.Periodo;
                cboMes.EditValue = objE_Planilla.Mes;
                txtDiasEfectivosTrabajados.EditValue = objE_Planilla.DiasEfectivoTrabajado;
                txtHorasOrdinarias.EditValue = objE_Planilla.HorasOrdinarias;
                txtHorasExtrasDiarias.EditValue = objE_Planilla.HorasExtrasDiarias;
                txtRemuneracionVital.EditValue = objE_Planilla.RemuneracionVital;
                txtAportacionSeguro.EditValue = objE_Planilla.AportacionSeguro;
            }

            CargaPlanillaDetalle();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    PlanillaBL objBL_Planilla = new PlanillaBL();
                    PlanillaBE objPlanilla = new PlanillaBE();

                    objPlanilla.IdPlanilla = IdPlanilla;
                    objPlanilla.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objPlanilla.Mes = Convert.ToInt32(cboMes.EditValue);
                    objPlanilla.DiasEfectivoTrabajado = Convert.ToInt32(txtDiasEfectivosTrabajados.EditValue);
                    objPlanilla.HorasOrdinarias = Convert.ToInt32(txtHorasOrdinarias.EditValue);
                    objPlanilla.HorasExtrasDiarias = Convert.ToDecimal(txtHorasExtrasDiarias.EditValue);
                    objPlanilla.RemuneracionVital = Convert.ToDecimal(txtRemuneracionVital.EditValue);
                    objPlanilla.AportacionSeguro = Convert.ToDecimal(txtAportacionSeguro.EditValue);
                    objPlanilla.FlagEstado = true;
                    objPlanilla.Usuario = Parametros.strUsuarioLogin;
                    objPlanilla.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPlanilla.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //Planilla Detalle
                    List<PlanillaDetalleBE> lstPlanillaDetalle = new List<PlanillaDetalleBE>();

                    //foreach (var item in mListaPlanillaDetalleOrigen)
                    foreach (var item in mListaPlanillaDetalleCalculo)
                    {
                        PlanillaDetalleBE objE_PlanillaDetalle = new PlanillaDetalleBE();
                        objE_PlanillaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_PlanillaDetalle.IdPlanilla = item.IdPlanilla;
                        objE_PlanillaDetalle.IdPlanillaDetalle = item.IdPlanillaDetalle;
                        objE_PlanillaDetalle.IdPersona = item.IdPersona;
                        objE_PlanillaDetalle.SueldoBruto = item.SueldoBruto;
                        objE_PlanillaDetalle.HorasLaboradas = item.HorasLaboradas;
                        objE_PlanillaDetalle.HorasExtras25 = item.HorasExtras25;
                        objE_PlanillaDetalle.RemuneracionBasica = item.RemuneracionBasica;
                        objE_PlanillaDetalle.HorasExtras250105 = item.HorasExtras250105;
                        objE_PlanillaDetalle.AsignacionFamiliar = item.AsignacionFamiliar;
                        objE_PlanillaDetalle.RemuneracionVacacional = item.RemuneracionVacacional;
                        objE_PlanillaDetalle.RemuneracionTrunca = item.RemuneracionTrunca;
                        objE_PlanillaDetalle.BonificacionEspecial0306 = item.BonificacionEspecial0306;
                        objE_PlanillaDetalle.IngresosComisiones = item.IngresosComisiones;
                        objE_PlanillaDetalle.BonificacionExtraordinaria = item.BonificacionExtraordinaria;
                        objE_PlanillaDetalle.Observacion = item.Observacion;
                        objE_PlanillaDetalle.Movilidad = item.Movilidad;
                        objE_PlanillaDetalle.Gratificaciones = item.Gratificaciones;
                        objE_PlanillaDetalle.BonificacionEspecial = item.BonificacionEspecial;
                        objE_PlanillaDetalle.RepartoUtilidad = item.RepartoUtilidad;
                        objE_PlanillaDetalle.Cts = item.Cts;
                        objE_PlanillaDetalle.TotalRemuneraciones = item.TotalRemuneraciones;
                        objE_PlanillaDetalle.FaltasTardanzas = item.FaltasTardanzas;
                        objE_PlanillaDetalle.IdPlaAfp = item.IdPlaAfp;
                        objE_PlanillaDetalle.Onp = item.Onp;
                        objE_PlanillaDetalle.FondoPensiones = item.FondoPensiones;
                        objE_PlanillaDetalle.PrimaSeguros = item.PrimaSeguros;
                        objE_PlanillaDetalle.ComisionAFP = item.ComisionAFP;
                        objE_PlanillaDetalle.Pacifico = item.Pacifico;
                        objE_PlanillaDetalle.Retencion5Categoria = item.Retencion5Categoria;
                        objE_PlanillaDetalle.TotalDescuento = item.TotalDescuento;
                        objE_PlanillaDetalle.NetoPagar = item.NetoPagar;
                        objE_PlanillaDetalle.Aportacion75 = item.Aportacion75;
                        objE_PlanillaDetalle.Aportacion25 = item.Aportacion25;
                        objE_PlanillaDetalle.Aportacion9 = item.Aportacion9;
                        objE_PlanillaDetalle.AporteEps = item.AporteEps;
                        objE_PlanillaDetalle.DiasNoLaboradoVacaciones = item.DiasNoLaboradoVacaciones;
                        objE_PlanillaDetalle.DiasNoLaboradoJustificados = item.DiasNoLaboradoJustificados;
                        objE_PlanillaDetalle.DiasNoLaboradoFaltas = item.DiasNoLaboradoFaltas;
                        objE_PlanillaDetalle.DiasNoLaboradoDm = item.DiasNoLaboradoDm;
                        objE_PlanillaDetalle.TotalDias = item.TotalDias;
                        objE_PlanillaDetalle.FechaCese = item.FechaCese;
                        objE_PlanillaDetalle.Observacion = item.Observacion;
                        objE_PlanillaDetalle.FlagEstado = true;
                        objE_PlanillaDetalle.TipoOper = item.TipoOper;
                        lstPlanillaDetalle.Add(objE_PlanillaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        
                        objBL_Planilla.Inserta(objPlanilla, lstPlanillaDetalle);
                    }
                    else
                    {
                        objBL_Planilla.Actualiza(objPlanilla, lstPlanillaDetalle);
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

        private void txtRemuneracionVital_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtRemuneracionVital.EditValue) > 0)
            {
                decimal AporteSeguro = 0;
                AporteSeguro = (Convert.ToDecimal(txtRemuneracionVital.EditValue) * Convert.ToDecimal(Parametros.dblPorAporteSeguro));
                txtAportacionSeguro.EditValue = AporteSeguro;
            }
        }

        private void btnCalcularPlanilla_Click(object sender, EventArgs e)
        {
            CalcularPlanilla();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPlanilla" + "_" + cboEmpresa.Text + "_" + txtPeriodo.Text + "_" + cboMes.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPlanillaDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }


        private void gvPlanillaDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalGeneral = 0;
                decimal decRemuneracionBasica = 0;
                decimal decAsignacionFamiliar = Convert.ToDecimal(gvPlanillaDetalle.GetRowCellValue(e.RowHandle, (gvPlanillaDetalle.Columns["AsignacionFamiliar"])));

                if (e.Column.FieldName == "RemuneracionBasica")
                {
                    decRemuneracionBasica = decimal.Parse(e.Value.ToString());
                    //Calcular Total
                    decTotal = decRemuneracionBasica + decAsignacionFamiliar;
                    gvPlanillaDetalle.SetRowCellValue(e.RowHandle, gvPlanillaDetalle.Columns["SueldoBruto"], decTotal);

                }
                ////--calculamos el total general ------------
                //for (int i = 0; i < gvPlanillaDetalle.RowCount; i++)
                //{
                //    decTotalGeneral = decTotalGeneral + Convert.ToDecimal(gvDenominacion.GetRowCellValue(i, (gvDenominacion.Columns["Total"])));
                //}
                //txtTotal.EditValue = decTotalGeneral;

                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPlanillaDetalle_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPlanillaDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FechaCese"]);
                    if (objDocRetiro != null)
                    {
                        DateTime FechaCese = DateTime.Parse(objDocRetiro.ToString());
                        if (FechaCese.Date < DateTime.Today)
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.BackColor2 = Color.SeaShell;
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

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboEmpresa.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar una Empresa.\n";
                flag = true;
            }

            if (cboMes.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar un mes.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtDiasEfectivosTrabajados.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Los días efectivos trabajados no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtHorasOrdinarias.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Las horas ordinarias no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtHorasExtrasDiarias.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Las horas extras diarias no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtRemuneracionVital.EditValue) == 0)
            {
                strMensaje = strMensaje + "- La remuneración mínima vital no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtAportacionSeguro.EditValue) == 0)
            {
                strMensaje = strMensaje + "- La aportación del seguro no puede ser 0.\n";
                flag = true;
            }

            if (mListaPlanillaDetalleCalculo.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la planilla, mientra no haya trabajadores.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                List<PlanillaBE> lstTmpPlanilla = null;
                lstTmpPlanilla = new PlanillaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                if (lstTmpPlanilla.Count > 0)
                {
                    strMensaje = strMensaje + "- La planilla ya existe.\n";
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

        private bool ValidarCalculo()
        {
            bool flag = false;
            string strMensaje = "No se pudo realizar la operación:\n";

            if (cboEmpresa.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar una Empresa.\n";
                flag = true;
            }

            if (cboMes.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar un mes.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtDiasEfectivosTrabajados.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Los días efectivos trabajados no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtHorasOrdinarias.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Las horas ordinarias no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtHorasExtrasDiarias.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Las horas extras diarias no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtRemuneracionVital.EditValue) == 0)
            {
                strMensaje = strMensaje + "- La remuneración mínima vital no puede ser 0.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtAportacionSeguro.EditValue) == 0)
            {
                strMensaje = strMensaje + "- La aportación del seguro no puede ser 0.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                List<PlanillaBE> lstTmpPlanilla = null;
                lstTmpPlanilla = new PlanillaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));

                if (lstTmpPlanilla.Count > 0)
                {
                    strMensaje = strMensaje + "- La planilla ya existe.\n";
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

        private void CargaPlanillaDetalle2()
        {
            mListaPlanillaDetalleOrigen = new List<CPlanillaDetalle>();

            List<PlanillaDetalleBE> lstTmpPlanillaDetalle = null;
            lstTmpPlanillaDetalle = new PlanillaDetalleBL().ListaTodosActivo(IdPlanilla);

            foreach (PlanillaDetalleBE item in lstTmpPlanillaDetalle)
            {
                CPlanillaDetalle objE_PlanillaDetalle = new CPlanillaDetalle();
                objE_PlanillaDetalle.IdEmpresa = item.IdEmpresa;
                objE_PlanillaDetalle.IdPlanilla = item.IdPlanilla;
                objE_PlanillaDetalle.IdPlanillaDetalle = item.IdPlanillaDetalle;
                objE_PlanillaDetalle.IdPersona = item.IdPersona;
                objE_PlanillaDetalle.ApeNom = item.ApeNom;
                objE_PlanillaDetalle.SueldoBruto = item.SueldoBruto;
                objE_PlanillaDetalle.HorasLaboradas = item.HorasLaboradas;
                objE_PlanillaDetalle.HorasExtras25 = item.HorasExtras25;
                objE_PlanillaDetalle.RemuneracionBasica = item.RemuneracionBasica;
                objE_PlanillaDetalle.HorasExtras250105 = item.HorasExtras250105;
                objE_PlanillaDetalle.AsignacionFamiliar = item.AsignacionFamiliar;
                objE_PlanillaDetalle.RemuneracionVacacional = item.RemuneracionVacacional;
                objE_PlanillaDetalle.RemuneracionTrunca = item.RemuneracionTrunca;
                objE_PlanillaDetalle.BonificacionEspecial0306 = item.BonificacionEspecial0306;
                objE_PlanillaDetalle.IngresosComisiones = item.IngresosComisiones;
                objE_PlanillaDetalle.BonificacionExtraordinaria = item.BonificacionExtraordinaria;
                objE_PlanillaDetalle.Movilidad = item.Movilidad;
                objE_PlanillaDetalle.Gratificaciones = item.Gratificaciones;
                objE_PlanillaDetalle.BonificacionEspecial = item.BonificacionEspecial;
                objE_PlanillaDetalle.RepartoUtilidad = item.RepartoUtilidad;
                objE_PlanillaDetalle.Cts = item.Cts;
                objE_PlanillaDetalle.TotalRemuneraciones = item.TotalRemuneraciones;
                objE_PlanillaDetalle.FaltasTardanzas = item.FaltasTardanzas;
                objE_PlanillaDetalle.IdPlaAfp = item.IdPlaAfp;
                objE_PlanillaDetalle.Onp = item.Onp;
                objE_PlanillaDetalle.FondoPensiones = item.FondoPensiones;
                objE_PlanillaDetalle.PrimaSeguros = item.PrimaSeguros;
                objE_PlanillaDetalle.ComisionAFP = item.ComisionAFP;
                objE_PlanillaDetalle.Pacifico = item.Pacifico;
                objE_PlanillaDetalle.Retencion5Categoria = item.Retencion5Categoria;
                objE_PlanillaDetalle.TotalDescuento = item.TotalDescuento;
                objE_PlanillaDetalle.NetoPagar = item.NetoPagar;
                objE_PlanillaDetalle.Aportacion75 = item.Aportacion75;
                objE_PlanillaDetalle.Aportacion25 = item.Aportacion25;
                objE_PlanillaDetalle.Aportacion9 = item.Aportacion9;
                objE_PlanillaDetalle.AporteEps = item.AporteEps;
                objE_PlanillaDetalle.DiasNoLaboradoVacaciones = item.DiasNoLaboradoVacaciones;
                objE_PlanillaDetalle.DiasNoLaboradoJustificados = item.DiasNoLaboradoJustificados;
                objE_PlanillaDetalle.DiasNoLaboradoFaltas = item.DiasNoLaboradoFaltas;
                objE_PlanillaDetalle.DiasNoLaboradoDm = item.DiasNoLaboradoDm;
                objE_PlanillaDetalle.TotalDias = item.TotalDias;
                objE_PlanillaDetalle.FechaCese = item.FechaCese;
                objE_PlanillaDetalle.Observacion = item.Observacion;
                objE_PlanillaDetalle.TipoOper = item.TipoOper;
                objE_PlanillaDetalle.Observacion = item.Observacion;
                objE_PlanillaDetalle.TipoOper = item.TipoOper;
                mListaPlanillaDetalleOrigen.Add(objE_PlanillaDetalle);
            }

            bsListado.DataSource = mListaPlanillaDetalleOrigen;
            gcPlanillaDetalle.DataSource = bsListado;
            gcPlanillaDetalle.RefreshDataSource();

        }

        private void CargaPlanillaDetalle()
        {
            mListaPlanillaDetalleCalculo = new List<PlanillaDetalleBE>();

            List<PlanillaDetalleBE> lstTmpPlanillaDetalle = null;
            lstTmpPlanillaDetalle = new PlanillaDetalleBL().ListaTodosActivo(IdPlanilla);

            foreach (PlanillaDetalleBE item in lstTmpPlanillaDetalle)
            {
                PlanillaDetalleBE objE_PlanillaDetalle = new PlanillaDetalleBE();
                objE_PlanillaDetalle.IdEmpresa = item.IdEmpresa;
                objE_PlanillaDetalle.IdPlanilla = item.IdPlanilla;
                objE_PlanillaDetalle.IdPlanillaDetalle = item.IdPlanillaDetalle;
                objE_PlanillaDetalle.IdPersona = item.IdPersona;
                objE_PlanillaDetalle.ApeNom = item.ApeNom;
                objE_PlanillaDetalle.SueldoBruto = item.SueldoBruto;
                objE_PlanillaDetalle.HorasLaboradas = item.HorasLaboradas;
                objE_PlanillaDetalle.HorasExtras25 = item.HorasExtras25;
                objE_PlanillaDetalle.RemuneracionBasica = item.RemuneracionBasica;
                objE_PlanillaDetalle.HorasExtras250105 = item.HorasExtras250105;
                objE_PlanillaDetalle.AsignacionFamiliar = item.AsignacionFamiliar;
                objE_PlanillaDetalle.RemuneracionVacacional = item.RemuneracionVacacional;
                objE_PlanillaDetalle.RemuneracionTrunca = item.RemuneracionTrunca;
                objE_PlanillaDetalle.BonificacionEspecial0306 = item.BonificacionEspecial0306;
                objE_PlanillaDetalle.IngresosComisiones = item.IngresosComisiones;
                objE_PlanillaDetalle.BonificacionExtraordinaria = item.BonificacionExtraordinaria;
                objE_PlanillaDetalle.Movilidad = item.Movilidad;
                objE_PlanillaDetalle.Gratificaciones = item.Gratificaciones;
                objE_PlanillaDetalle.BonificacionEspecial = item.BonificacionEspecial;
                objE_PlanillaDetalle.RepartoUtilidad = item.RepartoUtilidad;
                objE_PlanillaDetalle.Cts = item.Cts;
                objE_PlanillaDetalle.TotalRemuneraciones = item.TotalRemuneraciones;
                objE_PlanillaDetalle.FaltasTardanzas = item.FaltasTardanzas;
                objE_PlanillaDetalle.IdPlaAfp = item.IdPlaAfp;
                objE_PlanillaDetalle.Onp = item.Onp;
                objE_PlanillaDetalle.FondoPensiones = item.FondoPensiones;
                objE_PlanillaDetalle.PrimaSeguros = item.PrimaSeguros;
                objE_PlanillaDetalle.ComisionAFP = item.ComisionAFP;
                objE_PlanillaDetalle.Pacifico = item.Pacifico;
                objE_PlanillaDetalle.Retencion5Categoria = item.Retencion5Categoria;
                objE_PlanillaDetalle.TotalDescuento = item.TotalDescuento;
                objE_PlanillaDetalle.NetoPagar = item.NetoPagar;
                objE_PlanillaDetalle.Aportacion75 = item.Aportacion75;
                objE_PlanillaDetalle.Aportacion25 = item.Aportacion25;
                objE_PlanillaDetalle.Aportacion9 = item.Aportacion9;
                objE_PlanillaDetalle.AporteEps = item.AporteEps;
                objE_PlanillaDetalle.DiasNoLaboradoVacaciones = item.DiasNoLaboradoVacaciones;
                objE_PlanillaDetalle.DiasNoLaboradoJustificados = item.DiasNoLaboradoJustificados;
                objE_PlanillaDetalle.DiasNoLaboradoFaltas = item.DiasNoLaboradoFaltas;
                objE_PlanillaDetalle.DiasNoLaboradoDm = item.DiasNoLaboradoDm;
                objE_PlanillaDetalle.TotalDias = item.TotalDias;
                objE_PlanillaDetalle.FechaCese = item.FechaCese;
                objE_PlanillaDetalle.Observacion = item.Observacion;
                objE_PlanillaDetalle.TipoOper = item.TipoOper;
                objE_PlanillaDetalle.Observacion = item.Observacion;
                objE_PlanillaDetalle.TipoOper = item.TipoOper;
                mListaPlanillaDetalleCalculo.Add(objE_PlanillaDetalle);
            }

            bsListado.DataSource = mListaPlanillaDetalleCalculo;
            gcPlanillaDetalle.DataSource = bsListado;
            gcPlanillaDetalle.RefreshDataSource();

            lblTotalRegistros.Text = gvPlanillaDetalle.RowCount.ToString() + " Registros encontrados";
        }

        private void CalcularPlanilla()
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (!ValidarCalculo())
                {
                    XtraMessageBox.Show("El Cálculo se realizará para el mes de " + cboMes.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    mListaPlanillaDetalleCalculo = new PlanillaDetalleBL().ListaCalculo(0, Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(txtDiasEfectivosTrabajados.Text), Convert.ToDecimal(txtHorasOrdinarias.Text), Convert.ToDecimal(txtHorasExtrasDiarias.EditValue), Convert.ToDecimal(txtRemuneracionVital.EditValue), Convert.ToDecimal(txtAportacionSeguro.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                    gcPlanillaDetalle.DataSource = mListaPlanillaDetalleCalculo;

                    lblTotalRegistros.Text = gvPlanillaDetalle.RowCount.ToString() + " Registros encontrados";
                }

            }
        }

        #endregion

        public class CPlanillaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPlanilla { get; set; }
            public Int32 IdPlanillaDetalle { get; set; }
            public Int32 IdPersona { get; set; }
            public String ApeNom { get; set; }
            public Decimal SueldoBruto { get; set; }
            public Int32 HorasLaboradas { get; set; }
            public Decimal HorasExtras25 { get; set; }
            public Decimal RemuneracionBasica { get; set; }
            public Decimal HorasExtras250105 { get; set; }
            public Decimal AsignacionFamiliar { get; set; }
            public Decimal RemuneracionVacacional { get; set; }
            public Decimal RemuneracionTrunca { get; set; }
            public Decimal BonificacionEspecial0306 { get; set; }
            public Decimal IngresosComisiones { get; set; }
            public Decimal BonificacionExtraordinaria { get; set; }
            public Decimal Movilidad { get; set; }
            public Decimal Gratificaciones { get; set; }
            public Decimal BonificacionEspecial { get; set; }
            public Decimal RepartoUtilidad { get; set; }
            public Decimal Cts { get; set; }
            public Decimal TotalRemuneraciones { get; set; }
            public Decimal FaltasTardanzas { get; set; }
            public Int32 IdPlaAfp { get; set; }
            public String Abreviatura { get; set; }
            public Decimal Onp { get; set; }
            public Decimal FondoPensiones { get; set; }
            public Decimal PrimaSeguros { get; set; }
            public Decimal ComisionAFP { get; set; }
            public Decimal Pacifico { get; set; }
            public Decimal Retencion5Categoria { get; set; }
            public Decimal TotalDescuento { get; set; }
            public Decimal NetoPagar { get; set; }
            public Decimal Aportacion75 { get; set; }
            public Decimal Aportacion25 { get; set; }
            public Decimal Aportacion9 { get; set; }
            public Decimal AporteEps { get; set; }
            public Int32 DiasNoLaboradoVacaciones { get; set; }
            public Int32 DiasNoLaboradoJustificados { get; set; }
            public Int32 DiasNoLaboradoFaltas { get; set; }
            public Int32 DiasNoLaboradoDm { get; set; }
            public Int32 TotalDias { get; set; }
            public DateTime? FechaCese { get; set; }
            public String Observacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CPlanillaDetalle()
            {

            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = Convert.ToDateTime("01/" + cboMes.EditValue + "/" + Parametros.intPeriodo);  //DateTime.Now;
            deFechaHasta.EditValue = deFechaDesde.DateTime.AddDays(DateTime.DaysInMonth(Parametros.intPeriodo, Convert.ToInt32(cboMes.EditValue))-1);
            //XtraMessageBox.Show(DateTime.DaysInMonth(2014, 7).ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gvPlanillaDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvPlanillaDetalle.RowCount.ToString() + " Registros encontrados";
        }




       
    }
}