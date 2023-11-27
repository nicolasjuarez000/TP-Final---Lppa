using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BLL;
using BE;


namespace Mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        private readonly BLL.PurchaseBLL _purchaseBLL;
        private readonly BLL.ProductBLL _productBLL;
        private readonly BLL.BuyerBLL _buyerBLL;
        //private readonly WebService webService;
        
        public AboutPage()
        {
            InitializeComponent();
            _purchaseBLL = new BLL.PurchaseBLL();
            List<Purchase> purchaseList = _purchaseBLL.getAllPurchaseToGridview();
            listaProductos.ItemsSource = purchaseList;


        }
        private void OnFiltrarProductos(object sender, TextChangedEventArgs e)
        {
            // Lógica para filtrar productos
        }

        private void OnFiltrarCompradores(object sender, TextChangedEventArgs e)
        {
            // Lógica para filtrar compradores
        }




    }
}