using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BLL;
using BE;
using System.Linq;


namespace Mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        private readonly BLL.PurchaseBLL _purchaseBLL;
        private readonly BLL.ProductBLL _productBLL;
        private readonly BLL.BuyerBLL _buyerBLL;
        public List<Purchase> purchaseList;

        public AboutPage()
        {
            InitializeComponent();
            _purchaseBLL = new BLL.PurchaseBLL();
            purchaseList = _purchaseBLL.getAllPurchaseToGridview();
            listaProductos.ItemsSource = purchaseList;


        }
        
        private void OnFiltrarProductos(object sender, TextChangedEventArgs e)
        {

            string filtro = e.NewTextValue;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                listaProductos.ItemsSource = purchaseList;
                filtro_compradores.IsEnabled = true;

            }
            else
            {
                filtro_compradores.IsEnabled = false;
                var productosFiltrados = purchaseList.Where(p => p.product.ToLower().Contains(filtro)).ToList();
                listaProductos.ItemsSource = productosFiltrados;
                
            }
        }

        private void OnFiltrarCompradores(object sender, TextChangedEventArgs e)
        {
            string filtro = e.NewTextValue.ToLower();
            if (string.IsNullOrWhiteSpace(filtro))
            {
                listaProductos.ItemsSource = purchaseList;
                filtro_productos.IsEnabled = true;
            }
            else
            {
                filtro_productos.IsEnabled = false;
                var comprasFiltradas = purchaseList.Where(p => p.buyer.ToLower().Contains(filtro)).ToList();
                listaProductos.ItemsSource = comprasFiltradas;
            }
        }

        


    }
}
