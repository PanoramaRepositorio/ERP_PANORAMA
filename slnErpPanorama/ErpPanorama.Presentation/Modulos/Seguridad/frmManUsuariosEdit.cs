using System.ComponentModel;
using System;
using System.Collections.Generic;
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
using ErpPanorama.Presentation.Criptografia;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    public partial class frmManUsuariosEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        List<AccesoUsuarioBE> pListaAccesoUsuario = new List<AccesoUsuarioBE>();
        List<AccesoBE> pListaAcceso = new List<AccesoBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UsuarioBE pUsuarioBE { get; set; }

        bool find = false;

        int _IdPerfil = 0;

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        int _IdUser = 0;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        int menuID = 0;
        int IdPersona = 0;

        #endregion

        #region "Eventos"

        public frmManUsuariosEdit()
        {
            InitializeComponent();
        }

        private void frmManUsuariosEdit_Load(object sender, EventArgs e)
        {
            PopulateMenu(0, new MenuBL().ListaTodosActivo(), null);

            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            BSUtils.LoaderLook(cboPerfil, new PerfilBL().ListaTodosActivo(), "DescPerfil", "IdPerfil", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Usuario - Nuevo";
                txtPersona.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                this.Text = "Usuario - Modificar";
                txtUsuario.Text = pUsuarioBE.Usuario;
                IdPersona = pUsuarioBE.IdPersona;
                txtPersona.Text = pUsuarioBE.Descripcion;
                txtPassword.Text = objCrypto.DescifrarCadena(pUsuarioBE.Password);
                cboEmpresa.EditValue = pUsuarioBE.IdEmpresa;
                cboPerfil.EditValue = pUsuarioBE.IdPerfil;
                chkMaster.EditValue = pUsuarioBE.FlagMaster;
                chkAutorizaEliminaDocumentoVenta.EditValue = pUsuarioBE.FlagAutorizaEliminaDocumentoVenta;
                chkEstado.EditValue = pUsuarioBE.FlagEstado;
                
            }

            chkEstado.Checked = true;

            AccessByUserPerfilID(IdUser, IdPerfil);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = Parametros.Key;
                    objCrypto.IV = Parametros.IV;
                    string Password = "";
                    Password = objCrypto.CifrarCadena(this.txtPassword.Text.Trim());

                    UsuarioBL objBL_Usuario = new UsuarioBL();
                    UsuarioBE objUsuario = new UsuarioBE();
                   
                    objUsuario.IdEmpresa = int.Parse(cboEmpresa.EditValue.ToString());
                    objUsuario.IdPerfil = int.Parse(cboPerfil.EditValue.ToString());
                    objUsuario.IdPersona = IdPersona;
                    objUsuario.Descripcion = txtPersona.Text.Trim();
                    objUsuario.Usuario = txtUsuario.Text.Trim();
                    objUsuario.Password = Password;
                    objUsuario.FlagMaster = chkMaster.Checked;
                    objUsuario.FlagAutorizaEliminaDocumentoVenta = chkAutorizaEliminaDocumentoVenta.Checked;
                    objUsuario.FlagEstado = chkEstado.Checked;
                    objUsuario.UsuarioCrea = Parametros.strUsuarioLogin;
                    objUsuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUsuario.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Usuario.Inserta(objUsuario, pListaAccesoUsuario);
                    }
                    else if (pOperacion == Operacion.Modificar)
                    {
                        objUsuario.IdUser = pUsuarioBE.IdUser;
                        objBL_Usuario.Actualiza(objUsuario, pListaAccesoUsuario);

                        if (Convert.ToInt32(cboEmpresa.EditValue) != pUsuarioBE.IdEmpresa)
                        {
                            XtraMessageBox.Show("No se puede cambiar de empresa al usuario por esta opción, Ir a Personal y modificar Empresa \nSin embargo se grabará con la empresa a la que pertenece el personal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

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

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;

                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        private void CheckNodes(TreeNodeCollection col, int menuID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ';' });

                if (Convert.ToInt32(objectString[0]) == menuID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, menuID);
            }
        }

        private void trwMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                //Para marcar y desmarcar todos los nodos            
                foreach (TreeNode oNodo in e.Node.Nodes)
                {
                    string[] objectString = oNodo.Tag.ToString().Split(new char[] { ';' });
                    //AGREGAR EL FLAG AQUI .....
                    if (find == false)
                        oNodo.Checked = e.Node.Checked;

                    //insertar en la lista solo las ventanas que es el ultimo nivel
                    if (e.Node.Checked == true)
                    {
                        //if (objectString[1] == "4")
                        //{
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //}
                    }
                    if (e.Node.Checked == false)
                    {
                        RemoveMenu(Convert.ToInt32(objectString[0]));
                    }
                }

                if (e.Node.Parent != null)
                {
                    string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                    //e.Node.Parent.Checked=true;
                    if (!e.Node.Checked == true)
                    {
                        //Desmarco
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Regular);
                        RemoveMenu(Convert.ToInt32(objectString[0]));

                    }
                    else
                    {
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Bold);
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //Marco
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trwMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                this.lblMenu.Text = e.Node.Text;
                menuID = Convert.ToInt32(objectString[0]);

                if (pListaAccesoUsuario.Count > 0)
                {
                    AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    if (Acceso != null)
                    {
                        //Mostrar datos en los checkbox
                        this.chkAllowRead.Checked = Acceso.FlagLectura;
                        this.chkAllowWrite.Checked = Acceso.FlagAdicion; ;
                        this.chkAllowUpdate.Checked = Acceso.FlagActualizacion; ;
                        this.chkAllowDelete.Checked = Acceso.FlagEliminacion; ;
                        this.chkAllowPrint.Checked = Acceso.FlagImpresion; ;
                    }
                    else
                    {
                        this.chkAllowRead.Checked = false;
                        this.chkAllowWrite.Checked = false;
                        this.chkAllowUpdate.Checked = false;
                        this.chkAllowDelete.Checked = false;
                        this.chkAllowPrint.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAllowRead_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                {
                    if (_Acc.IdMenu == menuID)
                    {
                        return true;
                    }
                    return false;
                });

                if (Acceso != null)
                {
                    CheckBox obj = new CheckBox();
                    obj = (CheckBox)sender;

                    AccesoUsuarioBE AccesoMenu = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    switch (obj.Name)
                    {
                        case "chkAllowRead":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagLectura = chkAllowRead.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagLectura = chkAllowRead.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowWrite":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagAdicion = chkAllowWrite.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagAdicion = chkAllowWrite.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowUpdate":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowDelete":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowPrint":
                            if (IdUser == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagImpresion = chkAllowPrint.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagImpresion = chkAllowPrint.Checked;

                                if (AccesoMenu.TipoOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipoOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPerfil_EditValueChanged(object sender, EventArgs e)
        {
            AccessByPerfilID(int.Parse(cboPerfil.GetColumnValue("IdPerfil").ToString()));
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
                    txtPersona.Text = frm._Be.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {

            
        }

        #endregion
       
        #region "Metodos"

        public void PopulateMenu(int HijoID, List<MenuBE> pMenuAccess, TreeNode nodeParent)
        {
            try
            {
                var ListMenuHijos =
                    from p in pMenuAccess
                    where p.IdMenuPadre == HijoID
                    select p;

                foreach (var HijoMenu in ListMenuHijos)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = HijoMenu.MenuDescripcion;
                    switch (HijoMenu.IdMenuTipo)
                    {
                        case 0:
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                            break;
                        default:
                            newNode.ImageIndex = 1;
                            newNode.SelectedImageIndex = 1;
                            break;
                    }

                    newNode.Tag = HijoMenu.IdMenu.ToString() + ";" + HijoMenu.IdMenuTipo.ToString();
                    if (nodeParent == null)
                    {
                        this.trwMenu.Nodes.Add(newNode);
                    }
                    else
                    {
                        nodeParent.Nodes.Add(newNode);
                    }
                    PopulateMenu(HijoMenu.IdMenu, pMenuAccess, newNode);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AddMenu(int IdMenu)
        {
            var Buscar = pListaAccesoUsuario.Where(oB => oB.IdMenu == IdMenu).ToList();
            if (Buscar.Count > 0)
            {

            }
            else
            {
                AccesoUsuarioBE accesousuario = null;
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = IdUser;
                accesousuario.IdPerfil = IdPerfil;
                accesousuario.IdMenu = IdMenu;
                accesousuario.FlagLectura = true;
                accesousuario.FlagAdicion = true;
                accesousuario.FlagActualizacion = true;
                accesousuario.FlagEliminacion = true;
                accesousuario.FlagImpresion = true;
                accesousuario.FlagEstado = true;
                accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                pListaAccesoUsuario.Add(accesousuario);
            }
                
        }

        void RemoveMenu(int IdMenu)
        {
            //Borrar en bloque
            AccesoUsuarioBE Acceso = pListaAccesoUsuario.Find(delegate(AccesoUsuarioBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipoOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipoOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipoOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipoOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        void AccessByPerfilID(int perfilID)
        {
            try
            {
                pListaAccesoUsuario.Clear();//Limpiamos by ed

                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAcceso = new AccesoBL().SeleccionaPerfil(perfilID);

                foreach (AccesoBE item in pListaAcceso)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;

                //Llenamos la Lista de AccesoUsuario de acuerdo al perfil

                foreach (AccesoBE item in pListaAcceso)
                {
                    AccesoUsuarioBE accesousuario = null;
                    accesousuario = new AccesoUsuarioBE();
                    accesousuario.IdUser = IdUser;
                    accesousuario.IdPerfil = IdPerfil;
                    accesousuario.IdMenu = item.IdMenu;
                    accesousuario.FlagLectura = item.FlagLectura;
                    accesousuario.FlagAdicion = item.FlagAdicion;
                    accesousuario.FlagActualizacion = item.FlagActualizacion;
                    accesousuario.FlagEliminacion = item.FlagEliminacion;
                    accesousuario.FlagImpresion = item.FlagImpresion;
                    accesousuario.FlagEstado = item.FlagEstado;
                    accesousuario.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    pListaAccesoUsuario.Add(accesousuario);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AccessByUserPerfilID(int UserID, int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAccesoUsuario = new AccesoUsuarioBL().SeleccionaUserPerfil(UserID, perfilID);

                foreach (AccesoUsuarioBE item in pListaAccesoUsuario)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                XtraMessageBox.Show("Seleccione la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmpresa.Select();
                flag = true;
            }

            if (string.IsNullOrEmpty(cboPerfil.Text))
            {
                XtraMessageBox.Show("Seleccione el perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPerfil.Select();
                flag = true;
            }

            if (IdPersona == 0)
            {
                XtraMessageBox.Show("Seleccione a una persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Select();
                flag = true;
            }

            if (txtPersona.Text.ToString() == "")
            {
                XtraMessageBox.Show("Seleccione descripción del Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Select();
                flag = true;
            }

            if (txtUsuario.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese el Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Select();
                flag = true;
            }

            if (txtPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la clave del usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion






    }
}