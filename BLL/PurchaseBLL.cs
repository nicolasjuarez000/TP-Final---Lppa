﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class PurchaseBLL
    {
        private readonly DAL.PurchaseDAL _purchaseData;

        public PurchaseBLL()
        {
            _purchaseData = new DAL.PurchaseDAL();
        }

        public List<Purchase> getAll()
        {
            return _purchaseData.GetAll();
        }

        public List<dynamic> getAllToGridview()
        {
            return _purchaseData.GetAllToGridview();
        }

        //para xamarin
        public List<Purchase> getAllPurchaseToGridview()
        {
            return _purchaseData.getAllPurchaseToGridview();
        }

    }
}
