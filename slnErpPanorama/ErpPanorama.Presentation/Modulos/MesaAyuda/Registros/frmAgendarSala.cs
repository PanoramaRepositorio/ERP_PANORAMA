using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmAgendarSala : DevExpress.XtraEditors.XtraForm
    {
        public frmAgendarSala()
        {
            InitializeComponent();
        }

        private void frmAgendarSala_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bD_ERPPanoramaDataSet.Resources' Puede moverla o quitarla según sea necesario.
            this.resourcesTableAdapter.Fill(this.bD_ERPPanoramaDataSet.Resources);
            // TODO: esta línea de código carga datos en la tabla 'bD_ERPPanoramaDataSet.Appointments' Puede moverla o quitarla según sea necesario.
            this.appointmentsTableAdapter.Fill(this.bD_ERPPanoramaDataSet.Appointments);

            //// TODO: This line of code loads data into the 'schedulerTestDataSet.Resources' table. You can move, or remove it, as needed.
            //this.resourcesTableAdapter.Fill(this.schedulerTestDataSet.Resources);
            //// TODO: This line of code loads data into the 'schedulerTestDataSet.Appointments' table. You can move, or remove it, as needed.
            //this.appointmentsTableAdapter.Fill(this.schedulerTestDataSet.Appointments);

            schedulerControl1.Start = DateTime.Today;
            schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            schedulerControl1.DayView.TopRowTime = new TimeSpan(10, 0, 0);
            schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            schedulerControl1.DayView.ResourcesPerPage = 1;
            schedulerControl1.DayView.TimeIndicatorDisplayOptions.ShowOverAppointment = true;


            this.schedulerDataStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            this.schedulerDataStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            this.schedulerDataStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
        }

        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(bD_ERPPanoramaDataSet);
            bD_ERPPanoramaDataSet.AcceptChanges();
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
