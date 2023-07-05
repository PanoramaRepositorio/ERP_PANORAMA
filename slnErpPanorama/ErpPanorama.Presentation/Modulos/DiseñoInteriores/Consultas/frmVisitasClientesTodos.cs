using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Consultas
{
    public partial class frmVisitasClientesTodos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<AgendaVisitaBE> mLista = new List<AgendaVisitaBE>();
        private List<AgendaVisitaDetalleBE> mListaDetalle = new List<AgendaVisitaDetalleBE>();
        #endregion
        public frmVisitasClientesTodos()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
                mLista = new AgendaVisitaBL().ListaVisitasTodas(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue)); //  
                gcVisitas.DataSource = mLista;
        }

        private void frmVisitasClientesTodos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now.Date;  // DateTime.Now.AddMonths(-1);
            deHasta.EditValue = DateTime.Now.Date.AddDays(35);

            btnConsultar_Click(null,null);

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            mLista = new AgendaVisitaBL().ListaFechaVisitasProgramadas(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue)); //  
            gcVisitas.DataSource = mLista;
        }

        private void gvVisitas_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                object obj = gvVisitas.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Situacion"]);
                    if (objDocRetiro != null)
                    {
                        string IdSituacion = (objDocRetiro.ToString());
                        if (IdSituacion == "CANCELADO")
                        {
                            e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Regular | FontStyle.Strikeout);
                            //e.Appearance.ForeColor = Color.Gray;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        //else if (IdSituacion == "PROGRAMADO")
                        //{
                        //    e.Appearance.BackColor = Color.Yellow;
                        //}
                        //else if (IdSituacion == "VISITADO")
                        //{
                        //    e.Appearance.BackColor = Color.LightGreen;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}