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

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmRegTicketEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TicketBE> lstTicket;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TicketBE pTicketBE { get; set; }

        int _IdTicket = 0;

        public int IdTicket
        {
            get { return _IdTicket; }
            set { _IdTicket = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegTicketEdit()
        {
            InitializeComponent();
        }

        private void frmRegTicketEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSolicitante, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            BSUtils.LoaderLook(cboReponsable, new PersonaBL().SeleccionaSistemas(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);

            BSUtils.LoaderLook(cboPrioridad, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTicketPrioridad), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEstado, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTicketSituacion), "DescTablaElemento", "IdTablaElemento", true);

            cboSolicitante.EditValue = Parametros.intPersonaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ticket - Nuevo";
                cboPrioridad.EditValue = 0;
                cboEstado.EditValue = 189;
            }
            else if (pOperacion == Operacion.Modificar)
            {

                //TicketBE objE_Ticket = new TicketBE();
                pTicketBE = new TicketBL().Selecciona(IdTicket);

                this.Text = "Ticket - Modificar";
                txtNumero.Text = pTicketBE.Numero;
                deFecha.EditValue = pTicketBE.Fecha;
                cboSolicitante.EditValue = pTicketBE.IdSolicitante;
                txtRequerimiento.EditValue = pTicketBE.Requerimiento;
                cboReponsable.EditValue = pTicketBE.IdResponsable;
                deFechaCierre.EditValue =  pTicketBE.FechaCierre;
                cboPrioridad.EditValue = pTicketBE.IdPrioridad;
                cboEstado.EditValue = pTicketBE.IdEstado;
            }

            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "jsanchez" || Parametros.strUsuarioLogin == "gsanchez" || Parametros.strUsuarioLogin == "jmontenegro" || Parametros.strUsuarioLogin == "fbustamante")
            {
                Desbloquear();
            }

            txtRequerimiento.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TicketBL objBL_Ticket = new TicketBL();

                    TicketBE objTicket = new TicketBE();
                    objTicket.IdTicket = IdTicket;
                    objTicket.Numero = txtNumero.Text;
                    objTicket.Fecha =  deFecha.DateTime;
                    objTicket.IdSolicitante = Convert.ToInt32(cboSolicitante.EditValue);
                    objTicket.IdResponsable = Convert.ToInt32(cboReponsable.EditValue);
                    objTicket.IdPrioridad = Convert.ToInt32(cboPrioridad.EditValue);
                    objTicket.IdEstado = Convert.ToInt32(cboEstado.EditValue);
                    objTicket.Requerimiento = txtRequerimiento.Text;
                    objTicket.FechaCierre = deFechaCierre.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaCierre.DateTime.ToShortDateString());
                    objTicket.FlagEstado = true;
                    objTicket.Usuario = Parametros.strUsuarioLogin;
                    objTicket.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTicket.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Ticket.Inserta(objTicket);
                    else
                        objBL_Ticket.Actualiza(objTicket);

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

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtRequerimiento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Requerimiento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstTicket.Where(oB => oB.DescTicket.ToUpper() == txtTicket.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El Ticket ya existe.\n";
                //    flag = true;
                //}
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void Desbloquear()
        {
            cboReponsable.Properties.ReadOnly = false;
            cboPrioridad.Properties.ReadOnly = false;
            cboEstado.Properties.ReadOnly = false;
            deFechaCierre.Properties.ReadOnly = false;
        }


        #endregion



    }
}