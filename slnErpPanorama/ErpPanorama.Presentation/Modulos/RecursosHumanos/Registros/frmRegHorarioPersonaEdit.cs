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
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using Microsoft.Office.Interop.Excel;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using DevExpress.XtraEditors.Filtering.Templates;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegHorarioPersonaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public List<CHorarioPersona> mListaHorarioPersonaOrigen = new List<CHorarioPersona>();
        public List<TurnoBE> mListaTurno = new List<TurnoBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }
        public HorarioPersonaBE pHorarioPersonaBE { get; set; }

        public int IdPersona = 0;
        public string ApeNom = "";
        private int intIdTurno = 0;
        private int NumCar = 0;
        #endregion

        #region "Eventos"
        public frmRegHorarioPersonaEdit()
        {
            InitializeComponent();
        }

        private void frmRegHorarioPersonaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            deDesde.EditValue = Convert.ToDateTime("01/"+ DateTime.Now.Month + "/"+ DateTime.Now.Year);
            deHasta.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);//DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Horario Persona - Nuevo";
            }
            else
            {
                this.Text = "Horario Persona - Modificar";

                cboEmpresa.EditValue = Parametros.intEmpresaId;
                txtPersona.Text = ApeNom;
                btnBuscar.Enabled = false;

            }

            mListaTurno = new TurnoBL().ListaTodosActivo(Parametros.intEmpresaId);
            if (mListaTurno.Count > 0)
            {
                cboTurno.Visible = true;
                cboTurno.Properties.DataSource = mListaTurno;
                cboTurno.EditValue = mListaTurno[0].IdTurno;
                cboTurno.Properties.DisplayMember = "DescTurno";
            }

            //CargaHorarioPersona();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    HorarioPersonaBL objBL_HorarioPersona = new HorarioPersonaBL();
                    //HorarioPersona Detalle
                    List<HorarioPersonaBE> lstHorarioPersona = new List<HorarioPersonaBE>();

                    foreach (var item in mListaHorarioPersonaOrigen)
                    {
                        HorarioPersonaBE objE_HorarioPersona = new HorarioPersonaBE();
                        objE_HorarioPersona.IdEmpresa = item.IdEmpresa;
                        objE_HorarioPersona.IdHorarioPersona = item.IdHorarioPersona;
                        objE_HorarioPersona.IdPersona = item.IdPersona;
                        objE_HorarioPersona.ApeNom = item.ApeNom;
                        objE_HorarioPersona.DiaSemanaName = item.DiaSemanaName;
                        objE_HorarioPersona.Fecha = item.Fecha;
                        objE_HorarioPersona.FechaIngreso = item.FechaIngreso;
                        objE_HorarioPersona.FechaSalidaRef = item.FechaSalidaRef;
                        objE_HorarioPersona.FechaIngresoRef = item.FechaIngresoRef;
                        objE_HorarioPersona.FechaSalida = item.FechaSalida;
                        objE_HorarioPersona.FlagObligatorio = item.FlagObligatorio;
                        objE_HorarioPersona.TotalHorasRef = item.TotalHorasRef;
                        objE_HorarioPersona.TotalHorasTrab = item.TotalHorasTrab;
                        objE_HorarioPersona.FechaRegistro = DateTime.Now;
                        objE_HorarioPersona.FechaModifica = DateTime.Now;
                        objE_HorarioPersona.FlagEstado = true;
                        objE_HorarioPersona.TipoOper = item.TipoOper;
                        objE_HorarioPersona.Usuario = Parametros.strUsuarioLogin;
                        objE_HorarioPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstHorarioPersona.Add(objE_HorarioPersona);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_HorarioPersona.Inserta(lstHorarioPersona);
                        
                    }
                    else
                    {
                        objBL_HorarioPersona.Actualiza(lstHorarioPersona);
                    }

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

        private void btnCrearHorario_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    if (XtraMessageBox.Show("¿Desea crear el horario desde " + deDesde.Text + " hasta " + deHasta.Text +"?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        HorarioPersonaBL objBL_HorarioPersona = new HorarioPersonaBL();

                        if (intIdTurno > 0)
                        {
                            objBL_HorarioPersona.InsertaFecha(Parametros.intEmpresaId, IdPersona, intIdTurno, deDesde.DateTime, deHasta.DateTime, Parametros.intPersonaId, "", "");
                            XtraMessageBox.Show("Horario actualizado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //this.DialogResult = DialogResult.OK;
                            CargaHorarioPersona();
                        }
                        else
                        {
                            XtraMessageBox.Show("Seleccionar turno.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor = Cursors.Default;
                    }
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTurno_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTurno.EditValue.ToString() != "0")
            {
                if (NumCar == 1)
                {
                    var item = cboTurno.GetSelectedDataRow() as TurnoBE;
                    if (item.IdTurno > 0)
                    {
                        intIdTurno = item.IdTurno;
                    }
                }
            }
        }

        private void frmRegHorarioPersonaEdit_Shown(object sender, EventArgs e)
        {
            NumCar = 1;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Num = 0;
            for (int i = 0; i < gvHorarioPersona.SelectedRowsCount; i++)
            {
                int IdEmpresa = 0;
                int IdHorarioPersona = 0;

                int row = gvHorarioPersona.GetSelectedRows()[i];
                IdEmpresa = int.Parse(gvHorarioPersona.GetRowCellValue(row, "IdEmpresa").ToString());
                IdHorarioPersona = int.Parse(gvHorarioPersona.GetRowCellValue(row, "IdHorarioPersona").ToString());


                HorarioPersonaBL objBL_Documento = new HorarioPersonaBL();
                HorarioPersonaBE objE_Documento = new HorarioPersonaBE();

                objE_Documento.IdEmpresa = IdEmpresa;
                objE_Documento.IdHorarioPersona = IdHorarioPersona;
                objE_Documento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_Documento.IdEmpresa = Parametros.intEmpresaId;

                objBL_Documento.Elimina(objE_Documento);

                Num++;
            }


            CargaHorarioPersona();
        }

        private void asignardescansotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvHorarioPersona.RowCount > 0)
                {
                    HorarioPersonaBL ojbBL_HorarioPersona = new HorarioPersonaBL();
                    HorarioPersonaBE objBE_HorarioPersona = new HorarioPersonaBE();
                    CHorarioPersona objBE_HorarioP = (CHorarioPersona)gvHorarioPersona.GetRow(gvHorarioPersona.FocusedRowHandle);

                    objBE_HorarioPersona.IdHorarioPersona = objBE_HorarioP.IdHorarioPersona;
                    objBE_HorarioPersona.IdHorarioTipoIncidencia = 1;//Día de descanso
                    objBE_HorarioPersona.Fecha = objBE_HorarioP.Fecha;
                    objBE_HorarioPersona.FechaIngreso = objBE_HorarioP.Fecha;
                    objBE_HorarioPersona.FechaSalidaRef = objBE_HorarioP.Fecha;
                    objBE_HorarioPersona.FechaIngresoRef = objBE_HorarioP.Fecha;
                    objBE_HorarioPersona.FechaSalida = objBE_HorarioP.Fecha;
                    objBE_HorarioPersona.TotalHorasRef = 0;
                    objBE_HorarioPersona.TotalHorasTrab = 0;
                    objBE_HorarioPersona.IdPersonaModifica = Parametros.intPersonaId;
                    objBE_HorarioPersona.Usuario = Parametros.strUsuarioLogin;
                    objBE_HorarioPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    ojbBL_HorarioPersona.ActualizaIncidencia(objBE_HorarioPersona);
                    XtraMessageBox.Show("Datos actualizados correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaHorarioPersona();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminardescansotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvHorarioPersona.RowCount > 0)
                {
                    CHorarioPersona objE_HorarioP = (CHorarioPersona)gvHorarioPersona.GetRow(gvHorarioPersona.FocusedRowHandle);

                    TurnoDetalleBE objE_TurnoDetalle = new TurnoDetalleBE();
                    objE_TurnoDetalle.HoraIngreso = objE_HorarioP.FechaIngreso;
                    objE_TurnoDetalle.HoraSalidaRef = objE_HorarioP.FechaSalidaRef;
                    objE_TurnoDetalle.HoraIngresoRef = objE_HorarioP.FechaIngresoRef;
                    objE_TurnoDetalle.HoraSalida = objE_HorarioP.FechaSalida;

                    frmAsignarHorario frm = new frmAsignarHorario();
                    frm.intOrigen = 2;
                    frm.IdHorarioPersona = objE_HorarioP.IdHorarioPersona;
                    frm.Fecha = objE_HorarioP.Fecha;
                    frm.pTurnoDetalleBE = objE_TurnoDetalle;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        HorarioPersonaBL ojbBL_HorarioPersona = new HorarioPersonaBL();
                        HorarioPersonaBE objBE_HorarioPersona = new HorarioPersonaBE();

                        objBE_HorarioPersona.IdHorarioPersona = frm.IdHorarioPersona;
                        objBE_HorarioPersona.IdHorarioTipoIncidencia = 3;//Día normal
                        objBE_HorarioPersona.FechaIngreso = frm.pTurnoDetalleBE.HoraIngreso;
                        objBE_HorarioPersona.FechaSalidaRef = frm.pTurnoDetalleBE.HoraSalidaRef;
                        objBE_HorarioPersona.FechaIngresoRef = frm.pTurnoDetalleBE.HoraIngresoRef;
                        objBE_HorarioPersona.FechaSalida = frm.pTurnoDetalleBE.HoraSalida;
                        objBE_HorarioPersona.TotalHorasRef = frm.pTurnoDetalleBE.HorasRef;
                        objBE_HorarioPersona.TotalHorasTrab = frm.pTurnoDetalleBE.HorasTrab;
                        objBE_HorarioPersona.IdPersonaModifica = Parametros.intPersonaId;
                        objBE_HorarioPersona.Usuario = Parametros.strUsuarioLogin;
                        objBE_HorarioPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ojbBL_HorarioPersona.ActualizaIncidencia(objBE_HorarioPersona);
                        XtraMessageBox.Show("Datos actualizados correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaHorarioPersona();
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gvHorarioPersona_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                object obj = gvHorarioPersona.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["TotalHorasTrab"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == 0)
                        {
                            e.Appearance.BackColor = Color.Red;
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

        private void deHasta_EditValueChanged(object sender, EventArgs e)
        {
            if (deDesde.Text != string.Empty && deHasta.Text != string.Empty)
                CargaHorarioPersona();
        }

        private void deDesde_EditValueChanged(object sender, EventArgs e)
        {
            if (deDesde.Text != string.Empty && deHasta.Text != string.Empty)
                CargaHorarioPersona();
        }

        #endregion
        #region "Métodos"
        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtPersona.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar al personal.\n";
                flag = true;
            }

            //if (mListaHorarioPersonaOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar el HorarioPersona, mientra no haya productos.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaHorarioPersona()
        {
            List<HorarioPersonaBE> lstTmpHorarioPersona = null;
            lstTmpHorarioPersona = new HorarioPersonaBL().ListaFecha(Parametros.intEmpresaId,IdPersona, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            mListaHorarioPersonaOrigen = new List<CHorarioPersona>(); ;

            foreach (HorarioPersonaBE item in lstTmpHorarioPersona)
            {
                CHorarioPersona objE_HorarioPersona = new CHorarioPersona();
                objE_HorarioPersona.IdEmpresa = item.IdEmpresa;
                objE_HorarioPersona.IdHorarioPersona = item.IdHorarioPersona;
                objE_HorarioPersona.IdPersona = item.IdPersona;
                objE_HorarioPersona.ApeNom = item.ApeNom;
                objE_HorarioPersona.DiaSemanaName = item.DiaSemanaName;
                objE_HorarioPersona.Fecha = item.Fecha;
                objE_HorarioPersona.FechaIngreso = item.FechaIngreso;
                objE_HorarioPersona.FechaSalidaRef = item.FechaSalidaRef;
                objE_HorarioPersona.FechaIngresoRef = item.FechaIngresoRef;
                objE_HorarioPersona.FechaSalida = item.FechaSalida;
                objE_HorarioPersona.IdHorarioTipoIncidencia = item.IdHorarioTipoIncidencia;
                objE_HorarioPersona.FlagObligatorio = item.FlagObligatorio;
                objE_HorarioPersona.TotalHorasRef = item.TotalHorasRef;
                objE_HorarioPersona.TotalHorasTrab = item.TotalHorasTrab;
                objE_HorarioPersona.DescTurno = item.DescTurno;
                 //objE_HorarioPersona.Usuario = item.Usuario;
                //objE_HorarioPersona.Maquina = item.Maquina;
                objE_HorarioPersona.TipoOper = item.TipoOper;
                mListaHorarioPersonaOrigen.Add(objE_HorarioPersona);
            }

            bsListado.DataSource = mListaHorarioPersonaOrigen;
            gcHorarioPersona.DataSource = bsListado;
            gcHorarioPersona.RefreshDataSource();

            //lblTotalRegistros.Text = mListaHorarioPersonaOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        #endregion

        public class CHorarioPersona
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdHorarioPersona { get; set; }
            public Int32 IdPersona { get; set; }
            public String ApeNom{ get; set; }
            public String DiaSemanaName{ get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdArea { get; set; }
            public Int32 IdCargo { get; set; }
            public Int32 Periodo { get; set; }
            public Int32 Mes { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaIngreso { get; set; }
            public DateTime FechaSalidaRef { get; set; }
            public DateTime FechaIngresoRef { get; set; }
            public DateTime FechaSalida { get; set; }
            public Int32 IdHorarioTipoIncidencia { get; set; }
            public String Observacion { get; set; }
            public String DescTurno { get; set; }
            public Boolean FlagObligatorio { get; set; }
            public Boolean FlagApoyo { get; set; }
            public Boolean FlagPagado { get; set; }
            public Decimal Sueldo { get; set; }
            public Decimal TotalHorasRef { get; set; }
            public Decimal TotalHorasTrab { get; set; }
            public Int32 ToleranciaTarde { get; set; }
            public Int32 IdPersonaRegistro { get; set; }
            public DateTime FechaRegistro { get; set; }
            public Int32 IdPersonaModifica { get; set; }
            public DateTime FechaModifica { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Boolean FlagEstado { get; set; }

            public Int32 TipoOper { get; set; }

            public CHorarioPersona()
            {

            }
        }



    }
}