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
    public partial class frmRegIncidenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<IncidenciaBE> lstIncidencia;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public IncidenciaBE pIncidenciaBE { get; set; }

        int _IdIncidencia = 0;

        public int IdIncidencia
        {
            get { return _IdIncidencia; }
            set { _IdIncidencia = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegIncidenciaEdit()
        {
            InitializeComponent();
        }

        private void frmRegIncidenciaEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSolicitante, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            BSUtils.LoaderLook(cboReponsable, new PersonaBL().SeleccionaSistemas(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            BSUtils.LoaderLook(cboPrioridad, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTicketPrioridad), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEstado, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTicketSituacion), "DescTablaElemento", "IdTablaElemento", true);

            cboSolicitante.EditValue = Parametros.intPersonaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Incidencia - Nuevo";
                cboPrioridad.EditValue = 0;
                cboEstado.EditValue = 189;
            }
            else if (pOperacion == Operacion.Modificar)
            {

                //IncidenciaBE objE_Incidencia = new IncidenciaBE();
                pIncidenciaBE = new IncidenciaBL().Selecciona(IdIncidencia);

                this.Text = "Incidencia - Modificar";
                txtNumero.Text = pIncidenciaBE.Numero;
                deFecha.EditValue = pIncidenciaBE.Fecha;
                cboSolicitante.EditValue = pIncidenciaBE.IdSolicitante;
                txtDescripcion.EditValue = pIncidenciaBE.Descripcion;
                txtSolucion.EditValue = pIncidenciaBE.Solucion;
                cboReponsable.EditValue = pIncidenciaBE.IdResponsable;
                deFechaCierre.EditValue = pIncidenciaBE.FechaCierre;
                cboPrioridad.EditValue = pIncidenciaBE.IdPrioridad;
                cboEstado.EditValue = pIncidenciaBE.IdEstado;
            }

            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "jsanchez" || Parametros.strUsuarioLogin == "gsanchez" || Parametros.strUsuarioLogin == "jmontenegro" || Parametros.strUsuarioLogin == "fbustamante")
            {
                Desbloquear();
            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    IncidenciaBL objBL_Incidencia = new IncidenciaBL();

                    IncidenciaBE objIncidencia = new IncidenciaBE();
                    objIncidencia.IdIncidencia = IdIncidencia;
                    objIncidencia.Numero = txtNumero.Text;
                    objIncidencia.Fecha = deFecha.DateTime;
                    objIncidencia.IdSolicitante = Convert.ToInt32(cboSolicitante.EditValue);
                    objIncidencia.IdResponsable = Convert.ToInt32(cboReponsable.EditValue);
                    objIncidencia.IdPrioridad = Convert.ToInt32(cboPrioridad.EditValue);
                    objIncidencia.IdEstado = Convert.ToInt32(cboEstado.EditValue);
                    objIncidencia.Descripcion = txtDescripcion.Text;
                    objIncidencia.Solucion = txtSolucion.Text;
                    objIncidencia.FechaCierre = deFechaCierre.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaCierre.DateTime.ToShortDateString());
                    objIncidencia.FlagEstado = true;
                    objIncidencia.Usuario = Parametros.strUsuarioLogin;
                    objIncidencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objIncidencia.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Incidencia.Inserta(objIncidencia);
                    else
                        objBL_Incidencia.Actualiza(objIncidencia);

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

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Requerimiento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstIncidencia.Where(oB => oB.DescIncidencia.ToUpper() == txtIncidencia.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El Incidencia ya existe.\n";
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