using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final___Lppa
{
    public partial class Cart : Page
    {
        private readonly BLL.ProductBLL _productBLL;

        public Cart()
        {
            _productBLL = new BLL.ProductBLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Unauthorized.aspx");
                return;
            }

            if (!IsPostBack)
            {
                llenarDropDownProductos();
                List<dynamic> productList = new List<dynamic>();
                Session["dynamicList"] = productList;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var productIdSelected = int.Parse(DropDownList1.SelectedValue);
            var productData = getProductById(productIdSelected);

            var productList = (List<dynamic>)Session["dynamicList"];

            ActualizarOAgregarProducto(productIdSelected, productData, productList);

            llenarGridView(productList);

            CargarControles(productList);
        }

        #region LlenarDropDown
        private void llenarDropDownProductos()
        {
            var products = _productBLL.getAll();
            DropDownList1.DataSource = products;
            DropDownList1.DataTextField = "description";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Mostrar todo", "0"));
        }
        #endregion

        #region Obtener producto por ID
        private BE.Product getProductById(int productIdSelected)
        {
            return _productBLL.getById(productIdSelected);
        }
        #endregion

        #region llenarGridView
        private void llenarGridView(List<dynamic> dData)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productName");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("unitQuantity");
            foreach (var data in dData)
            {
                dt.Rows.Add(data.productName, data.unitPrice, data.unitQuantity);
            }
            Session["GridViewData"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        #endregion

        #region ActualizarOAgregarProducto
        private void ActualizarOAgregarProducto(int productIdSelected, dynamic productData, List<dynamic> productList)
        {
            dynamic existingProduct = productList.FirstOrDefault(dObj => dObj.productId == productIdSelected);

            if (existingProduct != null)
            {
                // Si el producto ya existe, incremento la cantidad en 1
                existingProduct.unitQuantity += 1;
            }
            else
            {
                // Si el producto no existe, lo agrego a la lista con cantidad inicial 1
                dynamic dObject = new ExpandoObject();
                dObject.productName = productData.description;
                dObject.unitPrice = productData.unitPrice;
                dObject.productId = productIdSelected;
                dObject.unitQuantity = 1;

                productList.Add(dObject);
            }
        }
        #endregion

        #region CargarControles
        private void CargarControles(List<dynamic> productList)
        {
            lblCantidad.Visible = true;
            lblImporteTotal.Visible = true;
            Label3.Visible = true;
            Label2.Visible = true;
            lblCantidad.Text = ObtenerProductosTotal(productList).ToString();
            lblImporteTotal.Text = ObtenerImporteTotal(productList).ToString();
        }
        #endregion

        #region ObtenerImporteTotal
        private decimal ObtenerImporteTotal(List<dynamic> productList)
        {
            decimal importeTotal = 0;

            foreach (var product in productList)
            {
                decimal importeProducto = product.unitPrice * product.unitQuantity;

                importeTotal += importeProducto;
            }

            return importeTotal;
        }
        #endregion

        #region ObtenerProductosTotal
        private int ObtenerProductosTotal(List<dynamic> productList)
        {
            return productList.Sum(prod => prod.unitQuantity);
        }
        #endregion
    }
}