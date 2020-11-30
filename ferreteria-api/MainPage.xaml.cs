using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ferreteria_api {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            //BindingContext = new ProductoViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            string IdBuscar = lblBuscar.Text;

                HttpClient httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync("http://192.168.1.66:8087/home/productos/" + IdBuscar);

                if (respuesta.IsSuccessStatusCode) {
                    var jsoncontenido = await respuesta.Content.ReadAsStringAsync();
                    jsoncontenido = jsoncontenido.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                    var contenido = JObject.Parse(jsoncontenido);

                    lblIdProducto.Text = contenido["id"].ToString();
                    lblNombre.Text = contenido["nombre"].ToString();
                    lblDescripcion.Text = contenido["descripcion"].ToString();
                    lblCantidadDisponible.Text = contenido["cantidadDisponible"].ToString();
                    lblPrecioUnitario.Text = contenido["precioUnitario"].ToString();
                    lblPrecioVenta.Text = contenido["precioVenta"].ToString();
                    lblMarca.Text = contenido["marca"].ToString();
                    lblCategoria.Text = contenido["categoria"].ToString();

              
                }


            
        }
    }
}
