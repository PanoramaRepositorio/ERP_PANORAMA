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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManAsistenciaFecha : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AsistenciaBE> mLista = new List<AsistenciaBE>();
        
        #endregion

        #region "Eventos"

        public frmManAsistenciaFecha()
        {
            InitializeComponent();
        }

        private void frmManAsistenciaFecha_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMarcacionPersonal";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAsistencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new AsistenciaBL().ListaFecha(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcAsistencia.DataSource = mLista;
        }

        #endregion

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            OleDbDataAdapter Adapter;
            // TODO: Modify the connection string and include any
            // additional required properties for your database.

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Easy Clocking Basic\Database\Att2003.mdb";
            try
            {
                Cursor = Cursors.WaitCursor;

                conn.Open();
                // Insert code to process data.


                String dato = this.deFechaSincronizacion.EditValue.ToString();
                String dia = dato.Substring(0, 2);
                String mes = dato.Substring(3, 2);
                String ano= dato.Substring(6, 4);
                dato = mes + "/" + dia + "/" + ano;
               
               String sql = "SELECT Userid,Checktime from Checkinout2 where checktime>#" + dato + "#";


                // string sql = "SELECT Userid,Checktime FROM Checkinout WHERE Userid <> 1  and  Checktime BETWEEN " + "#" + fechanini + "#" + " and " + "#" + fechanfin + "#";

                      
               // sql= sql + " AND Checktime BETWEEN #" + deFechaDesde.Text  + "# AND #" + deFechaHasta.Text  + "#";               
                //SELECT Userid,Checktime FROM Checkinout WHERE Userid <> 1 and  Checktime Between #01/10/2014# and #06/10/2014#
             //   sql = sql + " AND Checktime > #10/06/2014#";
                //sql = sql + " AND Checktime BETWEEN #"+ deFechaDesde.DateTime +"# AND #"+ deFechaHasta.DateTime +"#";
                //sql = sql + " AND YEAR(Checktime) = " + Parametros.intPeriodo + "";
                //sql = sql + " AND MONTH(Checktime) = " + Parametros.intMes + "";

                Adapter = new OleDbDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                List<CheckinoutBE> mListaCheckinout = new List<CheckinoutBE>();

                foreach (DataRow dRow in dt.Rows)
                {
                    CheckinoutBE objE_Checkinout = new CheckinoutBE();
                    objE_Checkinout.IdCheckinout = 0;
                    objE_Checkinout.IdEmpresa = Parametros.intEmpresaId;
                    objE_Checkinout.Dni = dRow["Userid"].ToString();
                    objE_Checkinout.Fecha = DateTime.Parse(dRow["Checktime"].ToString());
                    //DateTime t2 = Convert.ToDateTime(("4:00 p.m."));
                    DateTime t2 = Convert.ToDateTime(("4:00:00 PM"));
                    if (objE_Checkinout.Fecha.TimeOfDay.Ticks >= t2.TimeOfDay.Ticks)
                        objE_Checkinout.Tipo = "O";
                    else
                        objE_Checkinout.Tipo = "I";
                    objE_Checkinout.FlagEstado = true;

                    mListaCheckinout.Add(objE_Checkinout);
                }

                CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                objBL_Checkinout.Inserta(mListaCheckinout);

                XtraMessageBox.Show("La sincronización se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
                this.btnElimina.Enabled = true;
                this.btnSincronizar.Enabled = false; 
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Failed to connect to data source", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                conn.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                List<AsistenciaBE> lista = new List<AsistenciaBE>();
                AsistenciaBE obj = new AsistenciaBE();
                AsistenciaBL obj1 = new AsistenciaBL();
                obj.Dni = this.txDni.Text;
                obj.Fecha = Convert.ToDateTime(this.txFecha.Text);


                this.gcAsistencia.DataSource = obj1.ListaDni(obj.Dni, obj.Fecha); ;
            }catch(Exception e33){

            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnSincronizar.Enabled = true;
                this.btnElimina.Enabled = false;
                EliminaBL obj = new EliminaBL();
                obj.Elimina(Convert.ToDateTime(deFechaSincronizacion.DateTime.ToShortDateString()));
            }
            catch (Exception e89) { }
        }

        private void btnSincronizacionReloj2_Click(object sender, EventArgs e)
        {
            try
            {
                CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                objBL_Checkinout.SincronizarReloj2(Convert.ToInt32(txtDiasReloj2.EditValue), false);
                btnSincronizacionReloj2.Enabled = false;
                btnEliminarReloj2.Enabled = true;

                XtraMessageBox.Show("La sincronización se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarReloj2_Click(object sender, EventArgs e)
        {
            try
            {
                CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                objBL_Checkinout.SincronizarReloj2(Convert.ToInt32(txtDiasReloj2.EditValue), true);
                //btnSincronizacionReloj2.Enabled = true;
                btnEliminarReloj2.Enabled = false;
                XtraMessageBox.Show("La sincronización se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void deFechaSincronizacion_EditValueChanged(object sender, EventArgs e)
        {
            txtDiasReloj2.EditValue = (DateTime.Now - deFechaSincronizacion.DateTime).Days;
        }

        private void btnImportarManual_Click(object sender, EventArgs e)
        {
            frmAsistenciaImportacionManual frm = new frmAsistenciaImportacionManual();
            frm.ShowDialog();
        }
    }
}