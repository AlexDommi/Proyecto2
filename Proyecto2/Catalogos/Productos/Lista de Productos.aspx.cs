using CapaNegocios;
using Proyecto2.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Proyecto2.Catalogos
{
    public partial class Lista_de_Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var listEstados = BillTiendaOnline.GetListEstados(null);
                DDLEstado.DataSource = listEstados;
                DDLEstado.DataValueField = "CFGEDO_CODIGO_K";
                DDLEstado.DataTextField = "CFGEDO_DESCRIPCION";
                DDLEstado.DataBind();
                
                DDLEstado.Items.Insert(0, new ListItem("Selecciona Estado", ""));
                DDLEstado.SelectedIndex = 0;


                if (Request.QueryString["PRODUC_CODIGO_K"] == null)
                {
                    RefrescarGrid();
                }
                else {                     // Obtener el Id del Producto 
                    int PRODUC_CODIGO_K = int.Parse(Request.QueryString["PRODUC_CODIGO_K"]);
                    ProductosVo Productos = BillTiendaOnline.GetProductoById(PRODUC_CODIGO_K);
                    // Validar que el Producto es correcto
                    if (Productos.PRODUC_CODIGO_K == PRODUC_CODIGO_K)
                    {
                        //Desplegamos la información del Producto
                        this.txtId.Text = PRODUC_CODIGO_K.ToString();
                        this.txtDescripcion.Text = Productos.PRODUC_DESCRIPCION;
                        this.txtDescCorta.Text = Productos.PRODUC_DESCCORTA;
                        this.txtPeso.Text = Productos.PRODUC_PESO.ToString();
                        this.txtObservaciones.Text = Productos.PRODUC_OBSERVACIONES;
                        this.txtCodBarras.Text = Productos.PRODUC_CODIGO_BARRAS;
                        this.DDLEstado.SelectedValue = Productos.CFGEDO_CODIGO_K.ToString();
                    }
                    else
                    {
                        Response.Redirect("/Catalogos/Productos/Lista de Productos.aspx");
                    }
                }
            }
        }

        public void RefrescarGrid()
        {
            GVProductos.DataSource = BillTiendaOnline.GetListProductos(null);
            GVProductos.DataBind();
        }
        protected void GVProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtDescCorta.Text = "";
            txtPeso.Text = "";
            txtObservaciones.Text = "";
            txtCodBarras.Text = "";
            DDLEstado.SelectedIndex = 0;

            GridViewRow row = GVProductos.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txtDescripcion.Text = row.Cells[2].Text;
            txtDescCorta.Text = row.Cells[3].Text;
            txtPeso.Text = row.Cells[4].Text;
            txtObservaciones.Text = row.Cells[5].Text;
            txtCodBarras.Text = row.Cells[6].Text;
            DDLEstado.SelectedValue = row.Cells[7].Text;



        }

        protected void btnRegistrarNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string PRODUC_DESCRIPCION = txtDescripcion.Text;
                string PRODUC_DESCCORTA = txtDescCorta.Text;
                decimal PRODUC_PESO = decimal.Parse(txtPeso.Text);
                string PRODUC_OBSERVACIONES = txtObservaciones.Text;
                string PRODUC_CODIGO_BARRAS = txtCodBarras.Text;
                int CFGEDO_CODIGO_K = int.Parse(DDLEstado.SelectedValue);
                BillTiendaOnline.InsertarProducto(PRODUC_DESCRIPCION, PRODUC_DESCCORTA, PRODUC_PESO, PRODUC_OBSERVACIONES, PRODUC_CODIGO_BARRAS, CFGEDO_CODIGO_K);

                RefrescarGrid();

                Util.UtilControls.SweetBox("Exito!", "Cliente agregado exitosamente", SweetAlertConstants.sSuccess, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), SweetAlertConstants.sError, this.Page, this.GetType());
            }

            txtId.Text = "";
            txtDescripcion.Text = "";
            txtDescCorta.Text = "";
            txtPeso.Text = "";
            txtObservaciones.Text = "";
            txtCodBarras.Text = "";
            DDLEstado.SelectedIndex = 0;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string sub = "";
            string clase = "";

            GridViewRow fila = GVProductos.SelectedRow;

            int PRODUC_CODIGO_K = int.Parse(GVProductos.DataKeys[fila.RowIndex].Value.ToString());
            string PRODUC_DESCRIPCION = txtDescripcion.Text;
            string PRODUC_DESCCORTA = txtDescCorta.Text;
            decimal PRODUC_PESO = decimal.Parse(txtPeso.Text);
            string PRODUC_OBSERVACIONES = txtObservaciones.Text;
            string PRODUC_CODIGO_BARRAS = txtCodBarras.Text;
            int CFGEDO_CODIGO_K = int.Parse(DDLEstado.SelectedValue);

            try
            {
                int iResultado = BillTiendaOnline.ActualizarProducto (PRODUC_CODIGO_K, PRODUC_DESCRIPCION, PRODUC_DESCCORTA, PRODUC_PESO, PRODUC_OBSERVACIONES, PRODUC_CODIGO_BARRAS, CFGEDO_CODIGO_K);

                if (iResultado == 1)
                {
                    mensaje = "Exito!";
                    sub = "Producto actualizado exitosamente";
                    clase = SweetAlertConstants.sSuccess;
                }
                else
                {
                    mensaje = "Error!";
                    sub = "No se pudo actualizar el Producto";
                    clase = SweetAlertConstants.sError;
                }

                txtId.Text = "";
                txtDescripcion.Text = "";
                txtDescCorta.Text = "";
                txtPeso.Text = "";
                txtObservaciones.Text = "";
                txtCodBarras.Text = "";
                DDLEstado.SelectedIndex = 0;

                RefrescarGrid();

                UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR AL ACTUALIZAR METODO LDP.ASPX.CS-L130!", ex.Message, SweetAlertConstants.sError, this.Page, this.GetType());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow fila = GVProductos.SelectedRow;
            int PRODUC_CODIGO_K = int.Parse(GVProductos.DataKeys[fila.RowIndex].Value.ToString());

            try
            {
                string mensaje = string.Empty;
                string sub = string.Empty;
                string clase = string.Empty;
                
                int iResultado = BillTiendaOnline.EliminarProducto(PRODUC_CODIGO_K);
                
                switch (iResultado)
                {
                    case 1:
                        mensaje = "Producto Eliminado con éxito";
                        sub = "";
                        clase = SweetAlertConstants.sSuccess;
                        break;
                    case 0:
                        mensaje = "Producto no puede ser eliminado";
                        sub = "El producto ya esta asignado a pedidos";
                        clase = SweetAlertConstants.sWarning;
                        break;
                    default:
                        break;
                }

                txtId.Text = "";
                txtDescripcion.Text = "";
                txtDescCorta.Text = "";
                txtPeso.Text = "";
                txtObservaciones.Text = "";
                txtCodBarras.Text = "";
                DDLEstado.SelectedIndex = 0;

                RefrescarGrid();

                UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("ERROR AL ELIMINAR METODO LDP.ASPX.CS-L98!", ex.Message, SweetAlertConstants.sError, this.Page, this.GetType());
            }
        }
    }
}