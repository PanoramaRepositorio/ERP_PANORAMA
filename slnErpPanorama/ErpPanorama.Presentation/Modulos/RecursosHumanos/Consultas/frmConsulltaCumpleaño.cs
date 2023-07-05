using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConsulltaCumpleaño : DevExpress.XtraEditors.XtraForm
    {
        public frmConsulltaCumpleaño()
        {
            InitializeComponent();
        }

        private void frmCumple_Load(object sender, EventArgs e)
        {
            PersonaBE objCe = new PersonaBE();
            PersonaBL objcl = new PersonaBL();

            int cuenta = objcl.ListaCumpleaño().Count;
            // MessageBox.Show(cuenta.ToString());
            if (cuenta > 0)
            {
                this.gcCumpleaños.DataSource = objcl.ListaCumpleaño();
            }
        }

        private void gvCumpleaños_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCumpleaños.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvPromocionTemporalDetalle.GetDataRow(e.FocusedRowHandle);
                int IdPersona = 0;
                IdPersona = int.Parse(gvCumpleaños.GetFocusedRowCellValue("IdPersona").ToString());

                //IdProducto = int.Parse(dr["IdProducto"].ToString());

                PersonaBE objE_Persona = null;
                objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);

                if (objE_Persona.Foto != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Persona.Foto);
                    txtNombres.Text = objE_Persona.Nombres;
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.NoImagePerson;
                    txtNombres.Text = "";
                }
            }
        }

        private void gvCumpleaños_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvCumpleaños.RowCount > 0)
            {
                int IdPersona = 0;
                IdPersona = int.Parse(gvCumpleaños.GetFocusedRowCellValue("IdPersona").ToString());

                PersonaBE objE_Persona = null;
                objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);

                if (objE_Persona.Foto != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Persona.Foto);
                    txtNombres.Text = objE_Persona.Nombres;
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.NoImagePerson;
                    txtNombres.Text = "";
                }
            }
        }
    }
}