using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmRepVacacionesDiasEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<VacacionesBE> lstVacaciones;
        public string ApeNom = "";
        public DateTime FechaIngreso;
        public int DiasVacacionesPendientes = 0;
        public int DiasVacacionesTomadas = 0;
        public int DiasXYear = 0;

        int _IdVacaciones = 0;

        public int IdVacaciones
        {
            get { return _IdVacaciones; }
            set { _IdVacaciones = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        private int IdPersona = 0;
        private int IdAutorizado = 0;

        #endregion

        #region "Eventos"

        public frmRepVacacionesDiasEdit()
        {
            InitializeComponent();
        }

        private void frmRepVacacionesDiasEdit_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ApeNom;
            lblFechaIngreso.Text = FechaIngreso.ToString("dd-MM-yyyy");
            if (lstVacaciones.Count > 0)
            {
                DiasVacacionesTomadas = lstVacaciones.Sum(x => x.Dias);
                gcVacaciones.DataSource = lstVacaciones;
            }

            lblDiasVacacionesPendientes.Text = DiasVacacionesPendientes.ToString();
            lblDiasVacacionesTomadas.Text = DiasVacacionesTomadas.ToString();
            lblDiasVacacionesTotal.Text = this.CalcularAniosXfechaIngreso().ToString();
        }

        private int CalcularAniosXfechaIngreso()
        {
            int DiasXAnio = 0;
            DateTime FechaIngreso_ = Convert.ToDateTime(FechaIngreso.ToString("dd-MM-yyyy")); ;
            DateTime FechaHoy_ = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            while (FechaIngreso_ <= FechaHoy_)
            {
                FechaIngreso_ = FechaIngreso_.AddYears(1);
                if (FechaIngreso_ <= FechaHoy_)
                {
                    DiasXAnio += 30;
                }
            }
            return DiasXAnio;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersona = frm._Be.IdPersona;

                    #region "Vacaciones Adelantadas"
                    PersonaBE objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                    string FechaHoy = DateTime.Now.ToString("dd-MM-yyyy");
                    string FechaIngreso = (objE_Persona.FechaIngreso).ToString("dd-MM-yyyy");

                    DateTime dFechaHoy = Convert.ToDateTime(FechaHoy);
                    DateTime dFechaIngresoAdd = Convert.ToDateTime(FechaIngreso).AddYears(1);
                    #endregion

                }
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


        #endregion

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoVacacionesDiasDETALLADO";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvVacaciones.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
    }
}