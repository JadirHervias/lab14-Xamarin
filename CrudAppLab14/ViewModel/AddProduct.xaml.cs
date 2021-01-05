using CrudAppLab14.Model;
using CrudAppLab14.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                txtCantidad.Text = obj.Cantidad;
                txtFecha.Text = obj.Fecha;
                txtEntrega.Text = obj.Entrega;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Producto obj = new Producto();
            obj.Persona = txtPersona.Text;
            obj.Colegio = txtColegio.Text;
            obj.Product = txtProduct.Text;
            obj.Cantidad = txtCantidad.Text;
            obj.Fecha = txtFecha.Text;
            obj.Entrega = txtEntrega.Text;
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