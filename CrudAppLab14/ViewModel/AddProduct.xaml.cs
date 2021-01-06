using CrudAppLab14.Model;
using CrudAppLab14.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudAppLab14.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {

        ProductoService _services;

        bool _isUpdate;
        int productoID;
        public AddProduct()
        {
            InitializeComponent();
            _services = new ProductoService();
            _isUpdate = false;
        }
        public AddProduct(Producto obj)
        {
            InitializeComponent();
            _services = new ProductoService();
            if (obj != null)
            {
                productoID = obj.Id;
                txtPersona.Text = obj.Persona;
                txtColegio.Text = obj.Colegio;
                txtProduct.Text = obj.Product;
                txtCantidad.Text = obj.Cantidad.ToString();
                txtFecha.Date = obj.Fecha;
                txtEntrega.IsChecked = obj.Entrega;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Producto obj = new Producto();
            obj.Persona = txtPersona.Text;
            obj.Colegio = txtColegio.Text;
            obj.Product = txtProduct.Text;
            obj.Cantidad = int.Parse(txtCantidad.Text);
            obj.Fecha = txtFecha.Date;
            obj.Entrega = txtEntrega.IsChecked;
            if (_isUpdate)
            {
                obj.Id = productoID;
                await _services.UpdateProducto(obj);
            }
            else
            {
                _services.InsertProducto(obj);
            }
            await this.Navigation.PopAsync();
        }

    }
}