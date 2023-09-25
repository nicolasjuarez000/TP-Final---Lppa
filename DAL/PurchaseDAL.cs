using System;
using System.Collections.Generic;
using System.Data;
using BE;

namespace DAL
{
    public class PurchaseDAL
    {
        private readonly DAO _db;

        public PurchaseDAL(DAO db = null)
        {
            _db = db ?? new DAO();
        }

        public List<Purchase> GetAll()
        {
            List<Purchase> purchasesList = new List<Purchase>();
            var tabla = _db.ReadStoredProcedure("SP_PURCHASES_GET_ALL", null);

            foreach (DataRow registro in tabla.Rows)
            {
                var purchase = new Purchase();
                purchase.id = int.Parse(registro["PURCHASE_ID"].ToString());
                purchase.buyerId = int.Parse(registro["BUYER_ID"].ToString());
                purchase.productId = int.Parse(registro["PRODUCT_ID"].ToString());
                purchase.date = DateTime.Parse(registro["DATE"].ToString());
                purchase.amount = int.Parse(registro["AMOUNT"].ToString());
                purchasesList.Add(purchase);
            }
            return purchasesList;
        }
    }
}
