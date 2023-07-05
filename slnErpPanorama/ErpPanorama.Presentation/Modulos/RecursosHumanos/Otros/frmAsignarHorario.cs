using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmAsignarHorario : DevExpress.XtraEditors.XtraForm
    {

        public int intOrigen = 0; //1=Turno, 2=HorarioPersona
        public int IdHorarioPersona = 0;
        public DateTime Fecha = DateTime.Now;
        public TurnoDetalleBE pTurnoDetalleBE { get; set; }


        public frmAsignarHorario()
        {
            InitializeComponent();
        }

        private void frmAsignarHorario_Load(object sender, EventArgs e)
        {
            deFecha.DateTime = DateTime.Today;
            deHoraIngreso.DateTime = DateTime.Today;
            deHoraSalRef.DateTime = DateTime.Today;
            deHoraIngRef.DateTime = DateTime.Today;
            deHoraSalida.DateTime = DateTime.Today;
            
            if (intOrigen == 2)
            {
                deFecha.DateTime = Fecha;
                deFecha.Properties.ReadOnly = true;

                deHoraIngreso.DateTime = pTurnoDetalleBE.HoraIngreso;
                deHoraSalRef.DateTime = pTurnoDetalleBE.HoraSalidaRef;
                deHoraIngRef.DateTime = pTurnoDetalleBE.HoraIngresoRef;
                deHoraSalida.DateTime = pTurnoDetalleBE.HoraSalida;

                deHoraIngreso.Select();
            }

        }

        private void btnAplicarHoras_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                pTurnoDetalleBE.HoraIngreso = deHoraIngreso.DateTime;
                pTurnoDetalleBE.HoraSalidaRef = deHoraSalRef.DateTime;
                pTurnoDetalleBE.HoraIngresoRef = deHoraIngRef.DateTime;
                pTurnoDetalleBE.HoraSalida = deHoraSalida.DateTime;

                pTurnoDetalleBE.HorasRef = Convert.ToDecimal((pTurnoDetalleBE.HoraIngresoRef - pTurnoDetalleBE.HoraSalidaRef).TotalHours);
                pTurnoDetalleBE.HorasTrab = Convert.ToDecimal((pTurnoDetalleBE.HoraSalida - pTurnoDetalleBE.HoraIngreso).TotalHours) - pTurnoDetalleBE.HorasRef; ;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}