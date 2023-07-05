using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmReservaNuevo : DevExpress.XtraEditors.XtraForm
    {
        public frmReservaNuevo()
        {
            InitializeComponent();
        }

        private void frmReservaNuevo_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboInicio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 104), "DescTablaElemento", "IdTablaElemento", true);
            cboInicio.EditValue = 653;
            BSUtils.LoaderLook(cboFin, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 104), "DescTablaElemento", "IdTablaElemento", true);
            cboFin.EditValue = 653;

            txtReserva.Text = Parametros.strUsuarioNombres;
            denavAgenda_EditValueChanged(null, null);
            lblFecha.Text = DateTime.Now.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void denavAgenda_Click(object sender, EventArgs e)
        {
            lblFecha.Text = Convert.ToString(denavAgenda.EditValue);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            { 
                if (txtAgenda.Text == "")
                {
                    XtraMessageBox.Show("Ingrese la agenda de la reserva de sala.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgenda.Select();
                    return;
                }

                if (Convert.ToInt32(cboInicio.EditValue) == 0 || Convert.ToInt32(cboFin.EditValue) == 0)
                {
                    XtraMessageBox.Show("Seleccione una hora válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgenda.Select();
                    return;
                }


                if (Convert.ToInt32(cboInicio.EditValue) > Convert.ToInt32(cboFin.EditValue) )
                {
                    XtraMessageBox.Show("La hora de inicio no puede ser mayor a la hora de fin de la reserva.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgenda.Select();
                    return;
                }

                ReservaSalaBE objAgenda = new ReservaSalaBE();
                ReservaSalaBL objBL_Agenda = new ReservaSalaBL();
                ReservaSalaBE objE_Reserva = null;

                // Validad si ya esta reservada la hora de inicio
                //objE_Reserva = new ReservaSalaBL().ValidaHoraInicio(Convert.ToDateTime(cboInicio.Text), Convert.ToDateTime(denavAgenda.EditValue));

                //if (objE_Reserva != null)
                //{
                //    XtraMessageBox.Show("La hora de inicio seleccionada ya esta reservada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}

                // Validad si ya esta reservada la hora de fin
                objE_Reserva = new ReservaSalaBL().ValidaHoraFin(Convert.ToDateTime(cboFin.Text), Convert.ToDateTime(denavAgenda.EditValue));

                if (objE_Reserva != null)
                {
                    XtraMessageBox.Show("La hora final seleccionada ya esta reservada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }


                objAgenda.IdPersona = Parametros.intPersonaId;
                objAgenda.Agenda = txtAgenda.Text;
                objAgenda.FecReserva = Convert.ToDateTime(denavAgenda.EditValue);
                objAgenda.HoraInicio = Convert.ToDateTime(cboInicio.Text);
                objAgenda.HoraFin = Convert.ToDateTime(cboFin.Text);

            objBL_Agenda.Inserta(objAgenda);

             XtraMessageBox.Show("Se registro satisfactoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
         }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

    }

        private void denavAgenda_EditValueChanged(object sender, EventArgs e)
        {
            lblFecha.Text = Convert.ToString(denavAgenda.EditValue);
        }

        private void denavAgenda_KeyUp(object sender, KeyEventArgs e)
        {
            lblFecha.Text = Convert.ToString(denavAgenda.EditValue);
        }

        private void cboFin_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}