using CapaNegocios;
using Proyecto2.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2.Catalogos.Pedidos
{
    public partial class RegistrodePedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var listCliente = BillTiendaOnline.GetListClientes(null);
                DDLCliente.DataSource = listCliente;
                DDLCliente.DataValueField = "CTECLI_CODIGO_K";
                DDLCliente.DataTextField = "CTECLI_NOMBRE";
                DDLCliente.DataBind();

                DDLCliente.Items.Insert(0, new ListItem("Selecciona Cliente", ""));
                DDLCliente.SelectedIndex = 0;

                var listEstados = BillTiendaOnline.GetListEstados(null);
                DDLEstado.DataSource = listEstados;
                DDLEstado.DataValueField = "CFGEDO_CODIGO_K";
                DDLEstado.DataTextField = "CFGEDO_DESCRIPCION";
                DDLEstado.DataBind();

                DDLEstado.Items.Insert(0, new ListItem("Selecciona Estado", ""));
                DDLEstado.SelectedIndex = 0;

                var listProductos = BillTiendaOnline.GetListProductos(null);

                DDLProducto.DataSource = listProductos;
                DDLProducto.DataValueField = "PRODUC_CODIGO_K";
                DDLProducto.DataTextField = "PRODUC_DESCRIPCION";
                DDLProducto.DataBind();

                DDLProducto.Items.Insert(0, new ListItem("Selecciona Producto", ""));
                DDLProducto.SelectedIndex = 0;



                ViewState["GVPedidos"] = new DataTable();

                DataTable dt = (DataTable)ViewState["GVPedidos"];
                dt.Columns.Add("PRODUC_CODIGO_K", typeof(int));
                dt.Columns.Add("PEDCTED_CANTIDAD", typeof(int));
                dt.Columns.Add("PEDCTED_CANTPZA", typeof(int));
                dt.Columns.Add("PEDCTED_PRECIO", typeof(decimal));
                dt.Columns.Add("TOTAL", typeof(decimal));
            }
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["GVPedidos"];
            DataRow dr = dt.NewRow();


            dr["PRODUC_CODIGO_K"] = int.Parse(DDLProducto.SelectedValue);
            dr["PEDCTED_CANTIDAD"] = int.Parse(txtCantidad.Text);
            dr["PEDCTED_CANTPZA"] = int.Parse(txtPieza.Text);
            dr["PEDCTED_PRECIO"] = decimal.Parse(txtPrecio.Text);

            var PZASXUND = BillTiendaOnline.GetProductoById(int.Parse(DDLProducto.SelectedValue));
            int iPzasxUnd = PZASXUND.PRODUC_PZAXUND;

            decimal dTotal = ((((Convert.ToInt32(txtCantidad.Text ) * iPzasxUnd) + Convert.ToInt32(txtPieza.Text)) * Convert.ToDecimal(txtPrecio.Text))/iPzasxUnd);
            dr["TOTAL"] = Math.Round(dTotal,2);

            dt.Rows.Add(dr);
            GVPedidos.DataSource = dt;
            GVPedidos.DataBind();

            ViewState["GVPedidos"] = dt;
        }

        protected void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                int CTECLI_CODGO_K = 0;
                int CFGEDO_CODIGO_K = 0;

                if (!int.TryParse(DDLCliente.SelectedValue, out CTECLI_CODGO_K))
                {
                    UtilControls.SweetBox("Error!", "Selecciona un cliente válido.", SweetAlertConstants.sError, this.Page, this.GetType());
                    return;
                }
                
                string PEDCTE_FECHA = txtFecha.Text;
                string PEDCTE_OBSERVACIONES = txtObservaciones.Text;

                int iFolioGenerado;
                BillTiendaOnline.InsertarPedidoEnc(CTECLI_CODGO_K,PEDCTE_FECHA,PEDCTE_OBSERVACIONES, out iFolioGenerado);
                int iFolioGenerado2 = iFolioGenerado;

                DataTable dt = (DataTable)ViewState["GVPedidos"];

                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    UtilControls.SweetBox("Info", $"Filas a insertar: {dt.Rows.Count}", SweetAlertConstants.sInfo, this.Page, this.GetType());

                    foreach (DataRow dr in dt.Rows)
                    {

                        int PRODUC_CODIGO_K = Convert.ToInt32(dr["PRODUC_CODIGO_K"]);
                        int PEDCTED_CANTIDAD = Convert.ToInt32(dr["PEDCTED_CANTIDAD"]);
                        int PEDCTED_CANTPZA = Convert.ToInt32(dr["PEDCTED_CANTPZA"]);
                        decimal PEDCTED_PRECIO = Convert.ToDecimal(dr["PEDCTED_PRECIO"]);

                        BillTiendaOnline.InsertarPedidoDet(iFolioGenerado2, PRODUC_CODIGO_K, PEDCTED_CANTIDAD, PEDCTED_CANTPZA, PEDCTED_PRECIO);
                    }
                }
                else
                {
                    UtilControls.SweetBox("Error!", "Tabla no trae datos", SweetAlertConstants.sError, this.Page, this.GetType());
                }
                    //Mensaje de éxito
                    Util.UtilControls.SweetBox("Exito!", "Pedido agregado exitosamente", SweetAlertConstants.sSuccess, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                //Mensaje de error
                UtilControls.SweetBox("Error!", ex.ToString(), SweetAlertConstants.sError, this.Page, this.GetType());
            }

        }


        protected void GVPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ( e.CommandName == "EliminarRow" )
            {
                int iIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dt = (DataTable)ViewState["GVPedidos"];
                if(dt != null && dt.Rows.Count > 0)
                {
                    dt.Rows[iIndex].Delete();
                    dt.AcceptChanges();

                    GVPedidos.DataSource = dt;
                    GVPedidos.DataBind();

                    ViewState["GVPedidos"] = dt;
                }
            }
        }
    }
}