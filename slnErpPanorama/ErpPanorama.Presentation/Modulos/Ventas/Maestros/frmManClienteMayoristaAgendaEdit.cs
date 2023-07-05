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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteMayoristaAgendaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClienteBE> lstCliente;

        public List<CClienteAgenda> mListaClienteAgendaOrigen = new List<CClienteAgenda>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        public string DescCliente {get; set;}

        #endregion

        #region "Eventos"

        public frmManClienteMayoristaAgendaEdit()
        {
            InitializeComponent();
        }

        private void frmManClienteMayoristaAgendaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cliente Mayorista Agenda - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cliente Mayorista Agenda - Modificar";
                lblCliente.Text = DescCliente;
            }

            CargaClienteAgenda();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClienteAgendaBL objBL_ClienteAgenda = new ClienteAgendaBL();
                   
                    //Tracking de LLamadas
                    List<ClienteAgendaBE> lstClienteAgenda = new List<ClienteAgendaBE>();
                    foreach (var item in mListaClienteAgendaOrigen)
                    {
                        ClienteAgendaBE objE_ClienteAgenda = new ClienteAgendaBE();
                        objE_ClienteAgenda.IdClienteAgenda = item.IdClienteAgenda;
                        objE_ClienteAgenda.IdCliente = IdCliente;
                        objE_ClienteAgenda.FechaRegistro = item.FechaRegistro;
                        objE_ClienteAgenda.Numero = item.Numero;
                        objE_ClienteAgenda.Comentario = item.Comentario;
                        objE_ClienteAgenda.FechaProxima = item.FechaProxima;
                        objE_ClienteAgenda.IdSituacion = item.IdSituacion;
                        objE_ClienteAgenda.FlagEstado = true;
                        objE_ClienteAgenda.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteAgenda.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteAgenda.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteAgenda.TipoOper = item.TipoOper;
                        lstClienteAgenda.Add(objE_ClienteAgenda);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ClienteAgenda.Inserta(lstClienteAgenda);
                    else
                        objBL_ClienteAgenda.Actualiza(lstClienteAgenda);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoClienteAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvClienteAgenda.AddNewRow();
                if (pOperacion == Operacion.Modificar)
                {
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "IdClienteAgenda", 0);
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "FechaRegistro", DateTime.Now);
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "FechaProxima", DateTime.Now);
                }
                else
                {
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "IdClienteAgenda", 0);
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "FechaRegistro", DateTime.Now);
                    gvClienteAgenda.SetRowCellValue(gvClienteAgenda.FocusedRowHandle, "FechaProxima", DateTime.Now);
                }
                gvClienteAgenda.FocusedColumn = gvClienteAgenda.Columns["Numero"];
                gvClienteAgenda.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaClienteAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClienteAgenda = 0;
                IdClienteAgenda = int.Parse(gvClienteAgenda.GetFocusedRowCellValue("IdClienteAgenda").ToString());
                ClienteAgendaBE objBE_ClienteAgenda = new ClienteAgendaBE();
                objBE_ClienteAgenda.IdClienteAgenda = IdClienteAgenda;
                objBE_ClienteAgenda.IdEmpresa = Parametros.intEmpresaId;
                objBE_ClienteAgenda.Usuario = Parametros.strUsuarioLogin;
                objBE_ClienteAgenda.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ClienteAgendaBL objBL_ClienteAgenda = new ClienteAgendaBL();
                objBL_ClienteAgenda.Elimina(objBE_ClienteAgenda);
                gvClienteAgenda.DeleteRow(gvClienteAgenda.FocusedRowHandle);
                gvClienteAgenda.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtNumeroTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBusClienteTelefonos objClienteTelefonos = new frmBusClienteTelefonos();
                objClienteTelefonos.IdCliente = IdCliente;
                objClienteTelefonos.ShowDialog();
                if (objClienteTelefonos._Be != null)
                {
                    int index = gvClienteAgenda.FocusedRowHandle;

                    gvClienteAgenda.SetRowCellValue(index, "Numero", objClienteTelefonos._Be.Telefonos);
                    gvClienteAgenda.UpdateCurrentRow();

                    gvClienteAgenda.FocusedRowHandle = index;
                    gvClienteAgenda.FocusedColumn = gvClienteAgenda.Columns["Comentario"];
                    gvClienteAgenda.ShowEditor();

                }
            }
        }

        private void gcTxtSituacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBuscaTablaElemento objTablaElemento = new frmBuscaTablaElemento();
                objTablaElemento.IdTabla = Parametros.intTblTrackingCliente;
                objTablaElemento.ShowDialog();
                if (objTablaElemento.pTablaElementoBE != null)
                {
                    int index = gvClienteAgenda.FocusedRowHandle;

                    gvClienteAgenda.SetRowCellValue(index, "IdSituacion", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                    gvClienteAgenda.SetRowCellValue(index, "DescSituacion", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                    gvClienteAgenda.UpdateCurrentRow();

                }
            }
        }


        #endregion

        #region "Metodos"

        private void CargaClienteAgenda()
        {
            List<ClienteAgendaBE> lstTmpClienteAgenda = null;
            lstTmpClienteAgenda = new ClienteAgendaBL().ListaTodosActivo(IdCliente);

            foreach (ClienteAgendaBE item in lstTmpClienteAgenda)
            {
                CClienteAgenda objE_ClienteAgenda = new CClienteAgenda();
                objE_ClienteAgenda.IdClienteAgenda = item.IdClienteAgenda;
                objE_ClienteAgenda.IdCliente = item.IdCliente;
                objE_ClienteAgenda.FechaRegistro = item.FechaRegistro;
                objE_ClienteAgenda.Numero = item.Numero;
                objE_ClienteAgenda.Comentario = item.Comentario;
                objE_ClienteAgenda.FechaProxima = item.FechaProxima;
                objE_ClienteAgenda.IdSituacion = item.IdSituacion;
                objE_ClienteAgenda.DescSituacion = item.DescSituacion;
                objE_ClienteAgenda.TipoOper = item.TipoOper;
                mListaClienteAgendaOrigen.Add(objE_ClienteAgenda);
            }

            bsListadoClienteAgenda.DataSource = mListaClienteAgendaOrigen;
            gcClienteAgenda.DataSource = bsListadoClienteAgenda;
            gcClienteAgenda.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (mListaClienteAgendaOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- La agenda no puede estar vacía.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        public class CClienteAgenda
        {
            public Int32 IdClienteAgenda { get; set; }
            public Int32 IdCliente { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Numero { get; set; }
            public String Comentario { get; set; }
            public DateTime FechaProxima { get; set; }
            public Int32 IdSituacion { get; set; }
            public String DescSituacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CClienteAgenda()
            {

            }
        }

        
    }
}