using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TP_Final___Lppa
{
    /// <summary>
    /// Descripción breve de FiltradoCompras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class FiltradoCompras : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Compras> GetCompras(DateTime fechaInicio, DateTime fechaFin, string comprador, int? idProducto)
        {
            ComprasDAL comprasDAL = new ComprasDAL();
            List<Compras> Compras = comprasDAL.GetShoppingForUser(comprador);

            var comprasFiltered = Compras
                .Where(c => c.FechaCompra >= fechaInicio && c.FechaCompra <= fechaFin) // Filtro por fecha
                .ToList();

            if (idProducto.HasValue)
            {
                comprasFiltered = comprasFiltered
                    .Where(c => c.Productos.Id == idProducto.Value) // Filtro por ID de producto
                    .ToList();
            }

            return comprasFiltered;
        }
    }
}
