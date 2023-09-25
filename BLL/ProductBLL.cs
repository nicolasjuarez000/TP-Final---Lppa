using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace BLL
{
    public class ProductBLL
    {
        private readonly DAL.ProductsDAL _productsData;

        public ProductBLL()
        {
            _productsData = new DAL.ProductsDAL();
        }
        public List<Product> getAll()
        {
            return _productsData.GetAll();
        }
    }
}
