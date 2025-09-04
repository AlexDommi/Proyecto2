using CapaNegocios;
using Proyecto2.Util;
using System;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

using VO;
namespace Proyecto2.Catalogos.Clientes
{
    public partial class ListaDeClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CTECLI_CODIGO_K"] == null)
                {
                    RefrescarGrid();
                }
                else
                {

                    // Obtener el Id del Chofer 
                    int CTECLI_CODIGO_K = int.Parse(Request.QueryString["CTECLI_CODIGO_K"]);
                    ClientesVo Clientes = BillTiendaOnline.GetClientesById(CTECLI_CODIGO_K);

                    // Validar que el Chofer es correcto
                    if (Clientes.CTECLI_CODIGO_K == CTECLI_CODIGO_K)
                    {
                        //Desplegamos la información del chofer
                        this.txtId.Text = CTECLI_CODIGO_K.ToString();
                        this.txtNombre.Text = Clientes.CTECLI_NOMBRE;
                        this.txtRazonSocial.Text = Clientes.CTECLI_RAZONSOCIAL;
                        this.txtCorreo.Text = Clientes.CTECLI_CORREO;
                        this.txtTelefono.Text = Clientes.CTECLI_TELEFONO;
                        this.txtDireccion.Text = Clientes.CTECLI_DIRECCION;
                    }
                    else
                    {
                        Response.Redirect("/Catalogos/Clientes/ListaDeClientes.aspx");
                    }

                }
            }
        }

        public void RefrescarGrid()
        {
            GVClientes.DataSource = BillTiendaOnline.GetListClientes(null);

            GVClientes.DataBind();
        }

        protected void GVClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            // Obtener la fila seleccionada
            GridViewRow fila = GVClientes.SelectedRow;
         
            // Llenar los TextBox con los valores de la fila
            txtId.Text = GVClientes.DataKeys[fila.RowIndex].Value.ToString();
            txtNombre.Text = fila.Cells[2].Text.ToString();
            txtRazonSocial.Text = fila.Cells[3].Text.ToString();
            txtCorreo.Text = fila.Cells[4].Text.ToString();
            txtTelefono.Text = fila.Cells[5].Text.ToString();
            txtDireccion.Text = fila.Cells[6].Text.ToString();


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow fila = GVClientes.SelectedRow;
            int CTECLI_CODIGO_K = int.Parse(GVClientes.DataKeys[fila.RowIndex].Value.ToString());

            try
            {
                string mensaje = string.Empty;
                string sub = string.Empty;
                string clase = string.Empty;
                string sResultado = BillTiendaOnline.EliminarCliente(CTECLI_CODIGO_K).ToString();

                switch (sResultado)
                {
                    case "1":
                        mensaje = "Cliente Eliminado con éxito";
                        sub = "";
                        clase = SweetAlertConstants.sSuccess;
                        break;
                    case "0":
                        mensaje = "Cliente no puede ser eliminado";
                        sub = "El cliente ya esta asignado a pedidos";
                        clase = SweetAlertConstants.sWarning;
                        break;
                    default:
                        break;
                }

                txtId.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtRazonSocial.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtDireccion.Text = string.Empty;

                RefrescarGrid();

                UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR AL ELIMINAR METODO LDC.ASPX.CS-L130!", ex.Message, SweetAlertConstants.sError, this.Page, this.GetType());
            }
        }

        protected void btnRegistrarNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                string CTECLI_NOMBRE = txtNombre.Text;
                string CTECLI_RAZONSOCIAL = txtRazonSocial.Text;
                string CTECLI_CORREO = txtCorreo.Text;
                string CTECLI_TELEFONO = txtTelefono.Text;
                string CTECLI_DIRECCION = txtDireccion.Text;

                BillTiendaOnline.InsertarCliente(CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION);

                RefrescarGrid();

                Util.UtilControls.SweetBox("Exito!", "Cliente agregado exitosamente", SweetAlertConstants.sSuccess, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), SweetAlertConstants.sError, this.Page, this.GetType());
            }


            txtId.Text = "";
            txtNombre.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string sub = string.Empty;
            string clase = string.Empty;

            GridViewRow fila = GVClientes.SelectedRow;
            int CTECLI_CODIGO_K = int.Parse(GVClientes.DataKeys[fila.RowIndex].Value.ToString());
            string CTECLI_NOMBRE = txtNombre.Text;
            string CTECLI_RAZONSOCIAL = txtRazonSocial.Text;
            string CTECLI_CORREO = txtCorreo.Text;
            string CTECLI_TELEFONO = txtTelefono.Text;
            string CTECLI_DIRECCION = txtDireccion.Text;
           

            /*if (!int.TryParse(CTECLI_CODIGO_K.ToString(), out 
             * idCliente))
            {
                // No es un número válido
                mensaje = "Error!";
                sub = "El Id del cliente no es válido."+ CTECLI_CODIGO_K;
                clase = SweetAlertConstants.sWarning;
                UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
                return; // salir del método
            }*/

            string sResultado = BillTiendaOnline.ActualizarCliente(CTECLI_CODIGO_K, CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION);

            switch (sResultado)
            {

                case "1":
                    mensaje = "Exito!";
                    sub = "Cliente actualizado exitosamente";
                    clase = SweetAlertConstants.sSuccess;
                    break;
                case "0":
                    mensaje = "Error!";
                    sub = "No se pudo actualizar el cliente";
                    clase = SweetAlertConstants.sWarning;
                    break;
                default:
                    break;
            }

            txtId.Text = "";
            txtNombre.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            RefrescarGrid();

            UtilControls.SweetBox(mensaje, sub, SweetAlertConstants.sSuccess, this.Page, this.GetType());

            
        }
    }
}