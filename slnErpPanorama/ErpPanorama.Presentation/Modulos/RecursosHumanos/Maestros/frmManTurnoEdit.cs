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
using DevExpress.Utils.Drawing;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManTurnoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TurnoBE> lstTurno;
        private List<TurnoDetalleBE> mListaTurno  = new List<TurnoDetalleBE>();
        private List<HorarioBE> mListaHorario = new List<HorarioBE>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TurnoBE pTurnoBE { get; set; }

        int _IdTurno = 0;

        public int IdTurno
        {
            get { return _IdTurno; }
            set { _IdTurno = value; }
        }

        #endregion

        #region "Eventos"
        public frmManTurnoEdit()
        {
            InitializeComponent();
        }

        private void frmManTurnoEdit_Load(object sender, EventArgs e)
        {
            deHoraSalRef.DateTime = DateTime.Today;
            deHoraIngRef.DateTime = DateTime.Today;
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Turno Laboral - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Turno Laboral - Modificar";

                txtDescTurno.Text = pTurnoBE.DescTurno;
                txtTotalHorasRef.EditValue = pTurnoBE.TotalHorasRef;
                txtTotalHorasTrab.EditValue = pTurnoBE.TotalHorasTrab;
                txtObservacion.Text = pTurnoBE.Observacion;
            }
            CargarHorario();
            Cargar();

            txtDescTurno.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TurnoBL objBL_Turno = new TurnoBL();

                    TurnoBE objTurno = new TurnoBE();
                    objTurno.IdTurno = IdTurno;
                    objTurno.DescTurno = txtDescTurno.Text;
                    objTurno.TotalHorasRef = Convert.ToDecimal(txtTotalHorasRef.EditValue);
                    objTurno.TotalHorasTrab = Convert.ToDecimal(txtTotalHorasTrab.EditValue);
                    objTurno.Observacion = txtObservacion.Text;
                    objTurno.FlagEstado = true;
                    objTurno.Usuario = Parametros.strUsuarioLogin;
                    objTurno.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTurno.IdEmpresa = Parametros.intEmpresaId;

                    //Turno Detalle
                    List<TurnoDetalleBE> lstTurnoDetalle = new List<TurnoDetalleBE>();

                    foreach (var item in mListaTurno)
                    {
                        TurnoDetalleBE objE_TurnoDetalle = new TurnoDetalleBE();
                        objE_TurnoDetalle.IdTurno = item.IdTurno;
                        objE_TurnoDetalle.IdTurnoDetalle = item.IdTurnoDetalle;
                        objE_TurnoDetalle.DiaSemana = item.DiaSemana;
                        objE_TurnoDetalle.HoraIngreso = item.HoraIngreso;
                        objE_TurnoDetalle.HoraSalidaRef = item.HoraSalidaRef;
                        objE_TurnoDetalle.HoraIngresoRef = item.HoraIngresoRef;
                        objE_TurnoDetalle.HoraSalida = item.HoraSalida;
                        objE_TurnoDetalle.HorasRef = item.HorasRef;
                        objE_TurnoDetalle.HorasTrab = item.HorasTrab;
                        objE_TurnoDetalle.FlagEstado = true;
                        objE_TurnoDetalle.TipoOper = item.TipoOper;
                        objE_TurnoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_TurnoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstTurnoDetalle.Add(objE_TurnoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Turno.Inserta(objTurno, lstTurnoDetalle);
                    else
                        objBL_Turno.Actualiza(objTurno, lstTurnoDetalle);

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

        private void btnAplicarHoras_Click(object sender, EventArgs e)
        {
            Decimal decTotalHorRef = 0;
            Decimal decTotalHorTra = 0;

            foreach (var item in mListaTurno)
            {
                if (item.FlagEstado == true)
                {
                    item.HoraIngreso = deHoraIngreso.DateTime;
                    item.HoraSalidaRef = deHoraSalRef.DateTime;
                    item.HoraIngresoRef = deHoraIngRef.DateTime;
                    item.HoraSalida = deHoraSalida.DateTime;
                }
                item.HorasRef = Convert.ToDecimal((item.HoraIngresoRef-item.HoraSalidaRef).TotalHours);
                item.HorasTrab = Convert.ToDecimal((item.HoraSalida - item.HoraIngreso).TotalHours) - item.HorasRef;
                decTotalHorRef = decTotalHorRef + item.HorasRef;
                decTotalHorTra = decTotalHorTra + item.HorasTrab;
            }
            gcTurnoDetalle.RefreshDataSource();

            txtTotalHorasRef.EditValue = decTotalHorRef;
            txtTotalHorasTrab.EditValue = decTotalHorTra;
        }

        private void gvHorario_Click(object sender, EventArgs e)
        {
            DateTime Ingreso = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaIni").ToString());
            DateTime Salida = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaFin").ToString());

            deHoraIngreso.EditValue = Ingreso;
            deHoraSalida.EditValue = Salida;
        }

        private void gvHorario_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DateTime Ingreso = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaIni").ToString());
            DateTime Salida = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaFin").ToString());

            deHoraIngreso.EditValue = Ingreso;
            deHoraSalida.EditValue = Salida;
        }

        #endregion

        #region "Metodos"
        private void Cargar()
        {
            if(pOperacion == Operacion.Nuevo)
            {
                mListaTurno = new TurnoDetalleBL().ListaFormato();
                gcTurnoDetalle.DataSource = mListaTurno;
            }
            else
            {
                mListaTurno = new TurnoDetalleBL().ListaTodosActivo(IdTurno);
                int Reg = 0;
                foreach (var item in mListaTurno)
                {
                    mListaTurno[Reg].FlagEstado = false;
                    Reg = Reg + 1;
                }
                gcTurnoDetalle.DataSource = mListaTurno;
            }
        }

        private void CargarHorario()
        {
            mListaHorario = new HorarioBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcHorario.DataSource = mListaHorario;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescTurno.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el nombre del Turno.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTurno.Where(oB => oB.DescTurno == txtDescTurno.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El nombre del Turno ya existe.\n";
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

        #endregion

    
    }
}