using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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

        public List<dynamic> GetAllToGridview()
        {
            List<dynamic> dList = new List<dynamic>();
            var tabla = _db.ReadStoredProcedure("SP_GET_DATA_TO_GRIDVIEW", null);

            foreach (DataRow registro in tabla.Rows)
            {
                dynamic dObject = new ExpandoObject();
                dObject.purchaseId = int.Parse(registro["PURCHASE_ID"].ToString());
                dObject.buyerId = int.Parse(registro["BUYER_ID"].ToString());
                dObject.productId = int.Parse(registro["PRODUCT_ID"].ToString());
                dObject.buyer = registro["BUYER"].ToString();
                dObject.product = registro["PRODUCT"].ToString();
                dObject.date = DateTime.Parse(registro["DATE"].ToString());
                dObject.amount = int.Parse(registro["AMOUNT"].ToString());
                dList.Add(dObject);
            }
            return dList;
        }

        public List<Purchase> getAllPurchaseToGridview()
        {
            List<Purchase> pList = new List<Purchase>();
            var tabla = _db.ReadStoredProcedure("SP_GET_DATA_TO_GRIDVIEW", null);

            foreach (DataRow registro in tabla.Rows)
            {
                Purchase p = new Purchase();
                p.id = int.Parse(registro["PURCHASE_ID"].ToString());
                p.buyerId = int.Parse(registro["BUYER_ID"].ToString());
                p.productId = int.Parse(registro["PRODUCT_ID"].ToString());
                p.buyer = registro["BUYER"].ToString();
                p.product = registro["PRODUCT"].ToString();
                p.date = DateTime.Parse(registro["DATE"].ToString());
                p.amount = int.Parse(registro["AMOUNT"].ToString());
                pList.Add(p);
            }
            return pList;
        }
        
    }
}
