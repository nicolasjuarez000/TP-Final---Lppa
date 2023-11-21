using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;

namespace MobileApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new MobileApp.App());
            var purcheases = GetPurchases().Result;
            llenarGridView(purcheases);

        }

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

            grid1.DataContext = dt;
        }

        public async Task<List<dynamic>> GetPurchases()
        {
            var purchases = await CallWebService($@"POST /WebService.asmx HTTP/1.1
            Host: localhost
            Content-Type: application/soap+xml; charset=utf-8
            Content-Length: length

            <?xml version=""1.0"" encoding=""utf-8""?>
            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
              <soap12:Body>
                <getPurchases xmlns=""http://tempuri.org/"" />
              </soap12:Body>
            </soap12:Envelope>");

            return purchases;
        }


        public async Task<dynamic> GetPurchasesByBuyerID(List<dynamic> lista, int buyerId)
        {
            string listaXml = string.Join("", lista.Select(item => $"<item>{item}</item>"));

            return await CallWebService($@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
              <soap12:Body>
                <getPurchasesByBuyerID xmlns=""http://tempuri.org/"">
                  <lista>
                    {listaXml}
                  </lista>
                  <buyerId>{buyerId}</buyerId>
                </getPurchasesByBuyerID>
              </soap12:Body>
            </soap12:Envelope>");

        }

        public async Task<dynamic> GetPurchasesByDate(List<dynamic> lista, DateTime date)
        {
            string listaXml = string.Join("", lista.Select(item => $"<item>{item}</item>"));

            return await CallWebService($@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
              <soap12:Body>
                <getPurchasesByDate xmlns=""http://tempuri.org/"">
                  <lista>
                    {listaXml}
                  </lista>
                  <date>{date}</date>
                </getPurchasesByDate>
              </soap12:Body>
            </soap12:Envelope>");
        }

        public async Task<dynamic> GetPurchasesByProductID(List<dynamic> lista, int productId)
        {
            string listaXml = string.Join("", lista.Select(item => $"<item>{item}</item>"));

            return await CallWebService($@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
              <soap12:Body>
                <getPurchasesByProductID xmlns=""http://tempuri.org/"">
                  <lista>
                    {listaXml}
                  </lista>
                  <productId>{productId}</productId>
                </getPurchasesByProductID>
              </soap12:Body>
            </soap12:Envelope>");
        }



        private async Task<dynamic> CallWebService(string soapContent)
        {
            string webServiceUrl = "http://localhost/WebService.asmx/getPurchases";


            using (HttpClient client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await client.GetAsync(webServiceUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {
                        return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }

        private void DropDownList1_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            // Manejar el evento de selección para DropDownList1
        }

        private void dropBuyer_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            // Manejar el evento de selección para dropBuyer
        }

        private void Calendar1_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            // Manejar el cambio de elementos del calendario
        }

        private void btnDescarga_Click(object sender, RoutedEventArgs e)
        {
            // Manejar el clic del botón de descarga
        }
    }
}

