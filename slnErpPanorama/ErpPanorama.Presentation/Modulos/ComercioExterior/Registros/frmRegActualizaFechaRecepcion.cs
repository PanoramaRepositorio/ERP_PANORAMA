using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegActualizaFechaRecepcion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdFacturaCompra { get; set; }
        public int IdSolicitudCompra { get; set; }
        public int Origen = 0;
        
        #endregion

        #region "Eventos"

        public frmRegActualizaFechaRecepcion()
        {
            InitializeComponent();
        }

        private void frmRegActualizaFechaRecepcion_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Origen == 0)
            {
                FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                FacturaCompraBE objFacturaCompra = new FacturaCompraBE();

                objFacturaCompra.IdFacturaCompra = IdFacturaCompra;
                objFacturaCompra.FechaRecepcion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objFacturaCompra.Usuario = Parametros.strUsuarioLogin;
                objFacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objBL_FacturaCompra.ActualizaFechaRecepcion(objFacturaCompra);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            else
            {
                SolicitudCompraBL objBL_SolicitudCompra = new SolicitudCompraBL();
                SolicitudCompraBE objSolicitudCompra = new SolicitudCompraBE();

                objSolicitudCompra.IdSolicitudCompra = IdSolicitudCompra;
                objSolicitudCompra.FechaRecepcion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objSolicitudCompra.Usuario = Parametros.strUsuarioLogin;
                objSolicitudCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objBL_SolicitudCompra.ActualizaFechaRecepcion(objSolicitudCompra);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        

        #region "Metodos"

        #endregion

        
    }
}