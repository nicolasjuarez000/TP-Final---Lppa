using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ProductsDAL
    {
        private readonly DAO _db;

        public ProductsDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public List<Product> GetAll()
        {
            List<Product> productsList = new List<Product>();
            var tabla = _db.ReadStoredProcedure("SP_PRODUCTS_GET_ALL", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var product = new Product();
                product.id = int.Parse(registro["ID"].ToString());
                product.description = registro["DESCRIPTION"].ToString();
                product.unitPrice = int.Parse(registro["UNIT_PRICE"].ToString());
                productsList.Add(product);
            }
            return productsList;
        }

        public Product getById(int productId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@productId", productId)
                };
            var tabla = _db.ReadStoredProcedure("SP_PRODUCT_GET_BY_ID", parameters);

            var registro = tabla.Rows[0];
            var product = new BE.Product
            {
                id = int.Parse(registro["ID"].ToString()),
                description = registro["DESCRIPTION"].ToString(),
                unitPrice = int.Parse(registro["UNIT_PRICE"].ToString())
            };
            return product;
        }
    }
}
