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
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConsultaMarcaciones : DevExpress.XtraEditors.XtraForm
    {
        public frmConsultaMarcaciones()
        {
            InitializeComponent();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                MarcacionesBL obj = new MarcacionesBL();
                MarcacionesBE onj1 = new MarcacionesBE();
                String fecha;
                fecha = this.deDesde.Text;

                onj1.dni = this.txDni.Text.ToString();
                onj1.Fecha = this.deDesde.Text.ToString();
                this.gcMarcacion.DataSource = obj.ListaTodos(onj1.dni, onj1.Fecha); 
            }
            catch (Exception e93)
            {
                MessageBox.Show(e93.ToString());
            }
         

        }

        private void frmConsultaMarcaciones_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}