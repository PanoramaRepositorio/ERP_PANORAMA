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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPersonaTrabajoDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public PersonaTrabajoDetalleBE oBE;

        //public int intCorrelativo = 0;

        public int IdPersonaTrabajo = 0;
        public int IdPersonaTrabajoDetalle = 0;
        public DateTime Fecha;
        public int IdTienda = 0;
        public int IdArea = 0;
        public string ApeNom = "";
        public string DescCargo = "";

        public int IdPersona = 0;
        public bool FlagApoyo = false;
        public bool bNuevo = false;
        public int TipoOper = 0;

        #endregion

        #region "Eventos"

        public frmRegPersonaTrabajoDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegPersonaTrabajoDetalleEdit_Load(object sender, EventArgs e)
        {
            //deFecha.EditValue = DateTime.Now;
            deFecha.EditValue = Fecha;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboArea, CargarPuesto(), "Descripcion", "Id", true);

            if (!bNuevo)
            {
                cboArea.EditValue = IdArea;
                cboTienda.EditValue = IdTienda;
                txtPersona.Text = ApeNom;
            }

            btnBuscar.Focus();
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPersona == 0)
                {
                    XtraMessageBox.Show("Seleccionar Personal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                oBE = new PersonaTrabajoDetalleBE();
                oBE.IdPersona = IdPersona;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.IdPersonaTrabajo = IdPersonaTrabajo;
                oBE.IdPersonaTrabajoDetalle = IdPersonaTrabajoDetalle;
                //oBE.Item = intCorrelativo;
                oBE.Fecha = Convert.ToDateTime(deFecha.EditValue);
                oBE.ApeNom = txtPersona.Text;
                oBE.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                oBE.DescTienda = cboTienda.Text;
                oBE.IdArea = Convert.ToInt32(cboArea.EditValue);
                oBE.DescArea = cboArea.Text;
                oBE.DescCargo = DescCargo;
                oBE.Importe = Convert.ToDecimal(txtImporte.EditValue);
                oBE.Observacion = txtObservacion.Text;
                oBE.FlagApoyo = FlagApoyo;
                oBE.TipoOper = TipoOper;
                oBE.FlagEstado = true;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    //cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
                    cboTienda.EditValue = frm._Be.IdTienda;
                    cboArea.EditValue = frm._Be.IdArea;
                    DescCargo = frm._Be.DescCargo;
                    //txtImporte.EditValue = automatico
                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                    FlagApoyo = objE_Persona.FlagApoyo;

                    List<ContratoBE> lst_Contrato = new List<ContratoBE>();
                    lst_Contrato = new ContratoBL().ListaTodosActivo(Parametros.intPeriodo, objE_Persona.Dni);
                    if (lst_Contrato.Count > 0)
                    {
                        txtSueldoNeto.Visible = true;
                        lblSueldoNeto.Visible = true;
                        txtSueldoNeto.EditValue = lst_Contrato[0].SueldoNeto;
                        txtImporte.EditValue = (Convert.ToDecimal(txtSueldoNeto.EditValue)+ lst_Contrato[0].BonSueldo) / Convert.ToDecimal("30");
                    }

                    //Día de descanso
                    if (objE_Persona.Descanso.Length > 0)
                    {
                        lblMensaje.Text = objE_Persona.Descanso;
                        lblMensaje.Visible = true;
                        lblMensajeTitulo.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "";
                        lblMensaje.Visible = false;
                        lblMensajeTitulo.Visible = false;
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

        private DataTable CargarPuesto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "ND";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ALMACEN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "CAJA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "DESPACHO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "RECEPCION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "SEGURIDAD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "SISTEMAS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "VENTAS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "VISUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "ETIQUETADOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "AUXILIAR DE TIENDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "ENCARGADO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "ENCARGADO ALMACEN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 13;
            dr["Descripcion"] = "ENCARGADO DESPACHO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 14;
            dr["Descripcion"] = "ENCARGADO VISUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 15;
            dr["Descripcion"] = "ENCARGADO TIENDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 16;
            dr["Descripcion"] = "DISEÑO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 17;
            dr["Descripcion"] = "INVENTARIO";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        private void btnPorDos_Click(object sender, EventArgs e)
        {
            txtImporte.EditValue = Math.Round(Convert.ToDecimal(txtImporte.EditValue) * Convert.ToDecimal("2"),2);
        }

        private void btnMostrarSueldo_Click(object sender, EventArgs e)
        {
            PersonaBE objE_Persona = new PersonaBE();
            objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);

            List<ContratoBE> lst_Contrato = new List<ContratoBE>();
            lst_Contrato = new ContratoBL().ListaTodosActivo(Parametros.intPeriodo, objE_Persona.Dni);
            if (lst_Contrato.Count > 0)
            {
                txtSueldoNeto.Visible = true;
                lblSueldoNeto.Visible = true;
                txtSueldoNeto.EditValue = lst_Contrato[0].SueldoNeto;
                txtImporte.EditValue = Math.Round(Convert.ToDecimal(txtSueldoNeto.EditValue) / Convert.ToDecimal("30"),2);
            }
        }
    }
}