using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

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
                // Guardo el valor en una variable de sesion para poder luego descargar el archivo en XML
                //ya que no se podia hacer un gridView.dataSource porque el valor de la tabla no se almacena
                //en distintas paginas
                Session["GridViewData"] = dData;
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

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            var data = (List<dynamic>)Session["GridViewData"];
            var xmlData = ConvertDatatableToXml(ConvertToDataTable(data));

            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("Content-Disposition", "attachment; filename=datos.xml");
            Response.Write(xmlData);
            Response.End();
        }

        #region Convertir Datatable a XML
        private string ConvertDatatableToXml(DataTable dt)
        {
            // Utilizar un objeto XmlTextWriter para escribir el XML
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(sw))
                {
                    // Especificar formato del XML
                    xmlWriter.Formatting = Formatting.Indented;

                    // Escribir el inicio del documento y el elemento raíz
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Datos");

                    // Escribir cada fila como un elemento en el XML
                    foreach (DataRow row in dt.Rows)
                    {
                        xmlWriter.WriteStartElement("Compra");

                        foreach (DataColumn col in dt.Columns)
                        {
                            xmlWriter.WriteStartElement(col.ColumnName);
                            xmlWriter.WriteString(row[col].ToString());
                            xmlWriter.WriteEndElement();
                        }

                        xmlWriter.WriteEndElement();
                    }

                    // Escribir el final del documento
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }

                // Obtener el XML como una cadena
                return sw.ToString();
            }
        }
        #endregion

        #region Convertir lista dynamic a datatable
        // esto se hace por el problema con la data del GridView. Necesitamos
        // obtener la data de la session (lista dynamic) y convertirla a un datatable
        // para luego poder convertir eso a un xml
        private static DataTable ConvertToDataTable(List<dynamic> dynamicList)
        {
            DataTable dataTable = new DataTable();

            if (dynamicList == null || dynamicList.Count == 0)
                return dataTable;

            // Obtener las propiedades del primer elemento dinámico
            var properties = (IDictionary<string, object>)dynamicList[0];

            // Crear columnas para cada propiedad
            foreach (var property in properties)
            {
                dataTable.Columns.Add(new DataColumn(property.Key, property.Value.GetType()));
            }

            // Agregar filas al DataTable
            foreach (var item in dynamicList)
            {
                var values = ((IDictionary<string, object>)item).Values.ToArray();
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion
    }
}