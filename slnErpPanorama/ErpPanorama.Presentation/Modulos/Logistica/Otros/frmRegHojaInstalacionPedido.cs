using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegHojaInstalacionPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<HojaInstalacionBE> mLista = new List<HojaInstalacionBE>();

        int IdCliente = 0;
        int IdPiso = 0;

        #endregion

        #region "Eventos"

        public frmRegHojaInstalacionPedido()
        {
            InitializeComponent();
        }

        private void frmRegHojaInstalacionPedido_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now.AddDays(7);
            Cargar();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new HojaInstalacionBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcHojaInstalacion.DataSource = mLista;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvHojaInstalacion.GetFocusedRowCellValue("IdHojaInstalacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una HojaInstalacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void reservartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HojaInstalacionBE objE_Hoja = new HojaInstalacionBE();
            //objE_Hoja.IdHojaInstalacion = 0;
            //objE_Hoja.IdEmpresa = Parametros.intEmpresaId;
            //objE_Hoja.Fecha = DateTime.Parse(gvHojaInstalacion.GetFocusedRowCellValue("Fecha").ToString()); 
            //objE_Hoja.IdTurno = int.Parse(gvHojaInstalacion.GetFocusedRowCellValue("IdTurno").ToString());
            //objE_Hoja.IdCliente = IdCliente;
            //objE_Hoja.IdUbigeo = "" ;
            //objE_Hoja.Direccion = "";
            //objE_Hoja.Referencia = "";
            //objE_Hoja.FlagReserva = true;
            //objE_Hoja.Observacion = "";
            //objE_Hoja.FlagEstado = true;

            //HojaInstalacionBL ObjBL_Hoja = new HojaInstalacionBL();
            //ObjBL_Hoja.Inserta(objE_Hoja);
        }
    }
}