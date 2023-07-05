using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmAsignarPersona : DevExpress.XtraEditors.XtraForm
    {
        public int IdPersona = 0 ;

        public frmAsignarPersona()
        {
            InitializeComponent();
        }

        private void frmAsignarPersona_Load(object sender, EventArgs e)
        {

        }

        private void txtPIN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //if (txtPIN.Text.Length == 0)
                    //{
                    //    return;
                    //}

                    //IdPersona = Convert.ToInt32(txtPIN.Text);
                    //this.DialogResult = DialogResult.OK;


                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(txtPIN.Text));

                    if (objE_Persona != null)
                    {
                        if (objE_Persona.FlagEstado == true)
                        {
                            IdPersona = Convert.ToInt32(txtPIN.Text);
                            this.DialogResult = DialogResult.OK;                        
                        }
                        else
                            this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }




            }
        }


    }
}