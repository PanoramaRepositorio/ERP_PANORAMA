using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmRegPersonaTrabajoCopia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<PersonaTrabajoDetalleBE> mLista = new List<PersonaTrabajoDetalleBE>();

        int _IdPersonaTrabajo = 0;

        public int IdPersonaTrabajo
        {
            get { return _IdPersonaTrabajo; }
            set { _IdPersonaTrabajo = value; }
        }

        public string Dni;
        public string ApeNom;


        #endregion

        #region "Eventos"
        public frmRegPersonaTrabajoCopia()
        {
            InitializeComponent();
        }

        private void frmRegPersonaTrabajoCopia_Load(object sender, EventArgs e)
        {
            mLista = new PersonaTrabajoDetalleBL().ListaTodosActivo(IdPersonaTrabajo);
            txtObservacion.EditValue = "Copia de la lista N°" + IdPersonaTrabajo.ToString();
            deFecha.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PersonaTrabajoBL objBL_PersonaTrabajo = new PersonaTrabajoBL();
                    PersonaTrabajoBE objPersonaTrabajo = new PersonaTrabajoBE();

                    objPersonaTrabajo.IdPersonaTrabajo = 0;
                    objPersonaTrabajo.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPersonaTrabajo.HoraInicio = Convert.ToDateTime(deFechaIni.EditValue);
                    objPersonaTrabajo.HoraFin = Convert.ToDateTime(deFechaFin.EditValue);
                    objPersonaTrabajo.Observacion = txtObservacion.Text;
                    objPersonaTrabajo.FlagEstado = true;
                    objPersonaTrabajo.Usuario = Parametros.strUsuarioLogin;
                    objPersonaTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPersonaTrabajo.IdEmpresa = Parametros.intEmpresaId;

                    //Solciitud Producto Detalle
                    List<PersonaTrabajoDetalleBE> lstPersonaTrabajoDetalle = new List<PersonaTrabajoDetalleBE>();

                    foreach (var item in mLista)
                    {
                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, item.IdPersona);

                        //Día de descanso
                        if (objE_Persona.Descanso.Length > 0)
                        {
                            var culture = new System.Globalization.CultureInfo("es-ES");
                            var DiaDescanso = culture.DateTimeFormat.GetDayName(deFecha.DateTime.DayOfWeek);

                            if (objE_Persona.Descanso.ToUpper() == DiaDescanso.ToUpper())
                            {
                                item.Observacion = "Día Descanso";
                            }
                        }

                        PersonaTrabajoDetalleBE objE_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                        objE_PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = 0;
                        objE_PersonaTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_PersonaTrabajoDetalle.IdPersonaTrabajo = 0;
                        objE_PersonaTrabajoDetalle.IdPersona = item.IdPersona;
                        objE_PersonaTrabajoDetalle.Fecha = item.Fecha;
                        objE_PersonaTrabajoDetalle.IdTienda = item.IdTienda;
                        objE_PersonaTrabajoDetalle.IdArea = item.IdArea;
                        objE_PersonaTrabajoDetalle.Importe = item.Importe;
                        objE_PersonaTrabajoDetalle.Observacion = item.Observacion;
                        objE_PersonaTrabajoDetalle.FlagEstado = true;
                        objE_PersonaTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PersonaTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PersonaTrabajoDetalle.TipoOper = item.TipoOper;
                        lstPersonaTrabajoDetalle.Add(objE_PersonaTrabajoDetalle);
                    }

                    objBL_PersonaTrabajo.Inserta(objPersonaTrabajo, lstPersonaTrabajoDetalle);
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
        #endregion

        #region "Métodos"
        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (deFecha.Text == "")
            {
                strMensaje = strMensaje + "- Ingresar una Fecha válida.\n";
                flag = true;
            }

            if (deFechaIni.Text == "")
            {
                strMensaje = strMensaje + "- Ingresar la hora de Ingreso.\n";
                flag = true;
            }
            if (deFechaFin.Text == "")
            {
                strMensaje = strMensaje + "- Ingresar la hora de Salida.\n";
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
    }
}