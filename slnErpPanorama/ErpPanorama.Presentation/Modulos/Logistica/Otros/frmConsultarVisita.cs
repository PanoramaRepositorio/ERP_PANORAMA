using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmConsultarVisita : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<AgendaVisitaBE> mLista = new List<AgendaVisitaBE>();
        private List<AgendaVisitaDetalleBE> mListaDetalle = new List<AgendaVisitaDetalleBE>();

        private int IdSolicitudEgreso = 0;
        private int IdBanco = 0;
        private int IdTipoCuenta = 0;
        private int IdMoneda = 0;
        private string AbreviaturaMoneda = "";
        private string DescBanco = "";
        private string AbreviaturaBanco = "";
        #endregion

        #region "Eventos"
        public frmConsultarVisita()
        {
            InitializeComponent();
        }

        private void frmConsultarVisita_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now.Date;  // DateTime.Now.AddMonths(-1);
            deHasta.EditValue = DateTime.Now.Date.AddDays(7);

            Cargar();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            frmCerrarVisita FrmCambioVisita = new frmCerrarVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.pOperacion = frmCerrarVisita.Operacion.Consultar;
            FrmCambioVisita.ShowDialog();
            Cargar();
        }

        private void bntSalirCabecera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarCabecera_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void bntExportarCabecera_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoAgendaVisita";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvVisitas.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region "Metodos"
        private void Cargar()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.strUsuarioLogin == "czuñiga")
            {
                mLista = new AgendaVisitaBL().ListaFechaVisitas(0, Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue));
                gcVisitas.DataSource = mLista;
            }
            else
            {
                mLista = new AgendaVisitaBL().ListaFechaVisitas(Parametros.intPersonaId, Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue));
                gcVisitas.DataSource = mLista;
            }
            //if (Parametros.intPerfilId == Parametros.intPerAdministrador ||
            //    Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad ||
            //    Parametros.intPerfilId == Parametros.intPerTesoreria)
            //{
            //    //groupControl3.Visible = true;
            //    CargarTotalPagar();
            //}
        }

        public void InicializarModificar()
        {
            //if (gvCuentaBanco.RowCount > 0)
            //{
            //    CuentaBancoDetalleBE objCuentaBanco = new CuentaBancoDetalleBE();
            //    objCuentaBanco.IdCuentaBancoDetalle = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBancoDetalle").ToString());
            //    objCuentaBanco.IdCuentaBanco = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBanco").ToString());

            //    //frmRegCuentaBancoEdit objManCuentaBancoEdit = new frmRegCuentaBancoEdit();
            //    //objManCuentaBancoEdit.pOperacion = frmRegCuentaBancoEdit.Operacion.Modificar;
            //    //objManCuentaBancoEdit.IdCuentaBancoDetalle = objCuentaBanco.IdCuentaBancoDetalle;
            //    //objManCuentaBancoEdit.IdCuentaBanco = objCuentaBanco.IdCuentaBanco;
            //    //objManCuentaBancoEdit.IdCuentaBanco = IdCuentaBanco;
            //    //objManCuentaBancoEdit.IdBanco = IdBanco;
            //    //objManCuentaBancoEdit.IdMoneda = IdMoneda;
            //    //objManCuentaBancoEdit.IdTipoCuenta = IdTipoCuenta;
            //    //objManCuentaBancoEdit.StartPosition = FormStartPosition.CenterParent;
            //    //objManCuentaBancoEdit.ShowDialog();

            //    //CargarDetalles(IdCuentaBanco);
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }
        #endregion
    }
}