using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final___Lppa
{
    public partial class Purchases : System.Web.UI.Page
    {
        private readonly BLL.PurchaseBLL _purchaseBLL;
        private readonly BLL.ProductBLL _productBLL;

        public Purchases()
        {
            _purchaseBLL = new BLL.PurchaseBLL();
            _productBLL = new BLL.ProductBLL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Unauthorized.aspx");
                return;
            }
            var purchases = _purchaseBLL.getAll();
            GridView1.DataSource = purchases;
            GridView1.DataBind();

            var products = _productBLL.getAll();
            DropDownList1.DataSource = products;
            DropDownList1.DataTextField = "id";
            DropDownList1.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            var valor = DropDownList1.SelectedValue;
            var valor1 = DropDownList1.SelectedItem;
            var valor2 = DropDownList1.SelectedIndex;
            WebService webService = new WebService();
            var purchases = _purchaseBLL.getAll();
            var products = _productBLL.getAll();
            if (cbFiltroProducto.Checked)
            {
                GridView1.DataSource = webService.getPurchasesByProductID(purchases, DropDownList1.SelectedIndex);
                GridView1.DataBind();
            }
        }
    }
}