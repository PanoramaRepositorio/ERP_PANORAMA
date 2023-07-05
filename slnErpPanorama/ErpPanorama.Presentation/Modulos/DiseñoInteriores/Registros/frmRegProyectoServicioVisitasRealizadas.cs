using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegProyectoServicioVisitasRealizadas: DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public Dis_DisenoVisitasRealizadasBE oBE;

     //   public Dis_DisenoVisitasRealizadasBE oBE { get; set; }
        String vSituacion = "";

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdAgendaVisita = 0;
        public int IdDis_DisenoFuncional = 0;

        #endregion

        #region "Eventos"
        public frmRegProyectoServicioVisitasRealizadas()
        {
            InitializeComponent();
        }

        private void frmRegProyectoServicioVisitasRealizadas_Load(object sender, EventArgs e)
        {
            txtNumVisita.Select();
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    this.Text = "Servicio Funcional - Nuevo";
            //}
            //else if (pOperacion == Operacion.Modificar)
            //{
            //    this.Text = "Servicio Funcional - Modificar";
            //    cboAmbiente.EditValue = oBE.IdDis_Ambiente;
            //    txtActividad.Text = oBE.DescActividad.Trim();
            //    cboPieza.EditValue = oBE.IdDis_Pieza;
            //    txtPrecio.EditValue = oBE.Cantidad;
            //    cboMaterial.EditValue = oBE.IdMaterial;
            //    cboEstilo.EditValue = oBE.IdDis_Estilo;
            //    cboForma.EditValue = oBE.IdDis_Forma;
            //    txtMotivoVisita.EditValue = oBE.DescVolumen.Trim();
            //    txtTextura.EditValue = oBE.DescTextura.Trim();
            //    txtObservacion.EditValue = oBE.Observacion.Trim();
            //}

            //cboAmbiente.Focus();

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");                
                //txtPrecioVenta.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtActividad.Text.Trim() == "")
                //{
                //    XtraMessageBox.Show("La actividad no puede estar vacia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtActividad.SelectAll();
                //    txtActividad.Focus();
                //    return;
                //}

                //if (Convert.ToInt32(txtPrecio.EditValue) == 0)
                //{
                //    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPrecio.SelectAll();
                //    txtPrecio.Focus();
                //    return;
                //}

                oBE = new Dis_DisenoVisitasRealizadasBE();
                oBE.IdAgendaVisita = IdAgendaVisita;
                oBE.NumAgendaVisita = Convert.ToString(txtNumVisita.EditValue);
                oBE.HoraInicio = Convert.ToString(txtHoraInicio.EditValue);
                oBE.HoraFin = Convert.ToString(txtHoraFin.EditValue);
                oBE.FechaAgenda = Convert.ToDateTime(cboFechaVisita.EditValue);
                oBE.Disenador = Convert.ToString(txtDisenador.EditValue);
                oBE.MotivoVisita = Convert.ToString(txtMotivoVisita.EditValue);
                oBE.Agenda = Convert.ToString(txtAgenda.EditValue);
                oBE.PrecioVisita = Convert.ToDecimal(txtPrecio.EditValue);

                oBE.Situacion = Convert.ToString(vSituacion);

                this.DialogResult = DialogResult.OK;

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


        #endregion

        #region "Metodos"

        #endregion

        private void txtNumVisita_KeyPress(object sender, KeyPressEventArgs e)
        {
 
        }

        private void txtNumVisita_KeyDown(object sender, KeyEventArgs e)
        {



        }

        private void txtNumVisita_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.txtNumVisita.Text = txtNumVisita.Text.ToString().PadLeft(8, '0');
                AgendaVisitaBE objE_Visitas = null;
                objE_Visitas = new AgendaVisitaBL().BuscarNumVisita(Convert.ToString(txtNumVisita.Text.ToString().PadLeft(8, '0')));

                if (objE_Visitas != null)
                {
                    IdAgendaVisita = objE_Visitas.IdAgendaVisita;

                    txtNumVisita.EditValue = objE_Visitas.NumAgendaVisita;
                    cboFechaVisita.EditValue = objE_Visitas.FechaAgenda;
                    txtHoraInicio.EditValue = objE_Visitas.Hora;
                    txtHoraFin.EditValue = objE_Visitas.TiempoTermino;
                    txtMotivoVisita.EditValue = objE_Visitas.DescMotivo;
                    txtAgenda.EditValue = objE_Visitas.Agenda;
                    txtPrecio.EditValue = String.Format("{0:#,##0.00}", objE_Visitas.PrecioVisita);     
                    vSituacion = objE_Visitas.Situacion;
                    txtDisenador.EditValue = objE_Visitas.Nombres;
                }
                else
                {
                    AgendaVisitaBE objE_Visitas2 = null;
                    objE_Visitas2 = new AgendaVisitaBL().BuscarNumVisitaAsociada(Convert.ToString(txtNumVisita.Text.ToString().PadLeft(8, '0')));

                    if(objE_Visitas2 != null)
                    {
                        XtraMessageBox.Show("El numero de visita ya se encuentra asociada al Nro. Proyecto " + objE_Visitas2.NumeroProyecto, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
        }
    }
}