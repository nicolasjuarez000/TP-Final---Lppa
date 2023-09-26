using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final___Lppa
{
    public partial class Purchases : Page
    {
        private readonly BLL.PurchaseBLL _purchaseBLL;
        private readonly BLL.ProductBLL _productBLL;
        private readonly BLL.BuyerBLL _buyerBLL;
        private readonly WebService webService;

        public Purchases()
        {
            _purchaseBLL = new BLL.PurchaseBLL();
            _productBLL = new BLL.ProductBLL();
            _buyerBLL = new BLL.BuyerBLL();
            webService = new WebService();
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
                var dData = _purchaseBLL.getAllToGridview();
                llenarGridView(dData);
                llenarDropDownProductos();
                llenarDropDownBuyers();
            }
        }

        #region llenarGridView
        private void llenarGridView(List<dynamic> dData)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PurchaseId");
            dt.Columns.Add("Buyer");
            dt.Columns.Add("Product");
            dt.Columns.Add("Date");
            dt.Columns.Add("Amount");
            foreach (var purchase in dData)
            {
                dt.Rows.Add(purchase.purchaseId, purchase.buyer, purchase.product, purchase.date, purchase.amount);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        #endregion

        #region llenarDropDowns
        private void llenarDropDownProductos()
        {
            var products = _productBLL.getAll();
            DropDownList1.DataSource = products;
            DropDownList1.DataTextField = "description";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Mostrar todo", "0"));
        }

        private void llenarDropDownBuyers()
        {
            var buyers = _buyerBLL.getAllBuyers();
            dropBuyer.DataSource = buyers;
            dropBuyer.DataTextField = "fullName";
            dropBuyer.DataValueField = "id";
            dropBuyer.DataBind();
            dropBuyer.Items.Insert(0, new ListItem("Mostrar todo", "0"));
        }
        #endregion

        #region filtros
        private void AplicarFiltros(bool bFiltrarFecha = false)
        {
            var dData = _purchaseBLL.getAllToGridview();
            //Filtro por producto
            if (int.Parse(DropDownList1.SelectedValue) == 0)
            {
                llenarGridView(dData);
            }
            else
            {
                var idProducto = int.Parse(DropDownList1.SelectedValue);
                dData = webService.getPurchasesByProductID(dData, idProducto);
                llenarGridView(dData);
            }

            //Filtro por buyer
            if (int.Parse(dropBuyer.SelectedValue) == 0)
            {
                llenarGridView(dData);
            }
            else
            {
                var buyerId = int.Parse(dropBuyer.SelectedValue);
                dData = webService.getPurchasesByBuyerID(dData, buyerId);
                llenarGridView(dData);
            }

            //Filtro por fecha
            if (bFiltrarFecha)
            {
                var fecha = Calendar1.SelectedDate;
                dData = webService.getPurchasesByDate(dData, fecha);
                llenarGridView(dData);
            }            
        }
        #endregion

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        protected void dropBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            AplicarFiltros(true);
        }
    }
}