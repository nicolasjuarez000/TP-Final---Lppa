using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TP_Final___Lppa
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<dynamic> getPurchasesByBuyerID(List<dynamic> lista, int buyerId)
        {
            return lista.Where(product => product.buyerId == buyerId).ToList();
        }

        [WebMethod]
        public List<dynamic> getPurchasesByDate(List<dynamic> lista, DateTime date)
        {
            return lista.Where(purchase => purchase.date == date).ToList();
        }

        [WebMethod]
        public List<dynamic> getPurchasesByProductID(List<dynamic> lista, int productId)
        {
            return lista.Where(product => product.productId == productId).ToList();
        }

        [WebMethod]
        public List<dynamic> getPurchases()
        {
            PurchaseBLL purchaseBLL = new PurchaseBLL();
            return purchaseBLL.getAllToGridview();
        }
    }
}
