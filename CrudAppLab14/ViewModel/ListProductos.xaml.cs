using CrudAppLab14.Model;
using CrudAppLab14.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudAppLab14.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProductos : ContentPage
    {

        ProductoService services;

        public ListProductos()
        {
            InitializeComponent();
            services = new ProductoService();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showEmployee();
        }
        private void showEmployee()
        {
            var res = services.GetAllProductos().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Producto obj = (Producto)e.SelectedItem;
                string res = await DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await this.Navigation.PushAsync(new AddProduct(obj));
                        break;
                    case "Eliminar":
                        services.DeleteProducto(obj);
                        showEmployee();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }

    }
}