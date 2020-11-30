using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ferreteria_api {
    public class ProductoViewModel : INotifyPropertyChanged {


        public ProductoViewModel() {
            //producto = new Producto();
            //ObtenerDatos();
            //BuscarComando = new Command(async () => await ObtenerDatos());
        }

        public Command BuscarComando { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propiedad = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        public Producto producto;

        private List<Producto> _PostList;

        public List<Producto> PostList {
            get { return _PostList; }
            set {
                _PostList = value;
                RaisePropertyChanged();
            }
        }
        private string _Id;

        public string Id {
            get { return _Id; }
            set {
                _Id = value;
                RaisePropertyChanged();
            }
        }

        private string _Nombre;

        public string Nombre {
            get { return _Nombre; }
            set {
                _Nombre = value;
                RaisePropertyChanged();
            }
        }

        private string _Descripcion;
        public string Descripcion {
            get { return _Descripcion; }
            set {
                _Descripcion = value;
                RaisePropertyChanged();
            }
        }

        private int _CantidadDisponible;
        public int CantidadDisponible {
            get { return _CantidadDisponible; }
            set {
                _CantidadDisponible = value;
                RaisePropertyChanged();
            }
        }

        private int _PrecioUnitario;
        public int PrecioUnitario {
            get { return _PrecioUnitario; }
            set {
                _PrecioUnitario = value;
                RaisePropertyChanged();
            }
        }

        private int _PrecioVenta;
        public int PrecioVenta {
            get { return _PrecioVenta; }
            set {
                _PrecioVenta = value;
                RaisePropertyChanged();
            }
        }
        private string _Marca;
        public string Marca {
            get { return _Marca; }
            set {
                _Marca = value;
                RaisePropertyChanged();
            }
        }
        private string _Categoria;

        public string Categoria {
            get { return _Categoria; }
            set {
                _Categoria = value;
                RaisePropertyChanged();
            }
        }

        private string _URL;

        public string URL {
            get { return _URL; }
            set { _URL = value; }
        }



        private async void ObtenerDatos() {
            HttpClient httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync("http://192.168.1.66:8087/home/productos/5fbb3256efae723bca0b0cb9");

            if (respuesta.IsSuccessStatusCode) {
                var jsoncontenido = await respuesta.Content.ReadAsStringAsync();
                jsoncontenido = jsoncontenido.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                //var contenido = JObject.Parse(await respuesta.Content.ReadAsStringAsync());
                var contenido = JObject.Parse(jsoncontenido);

                Id = contenido["id"].ToString();
                Nombre = contenido["nombre"].ToString();
                Descripcion = contenido["descripcion"].ToString();
                CantidadDisponible = Int32.Parse(contenido["cantidadDisponible"].ToString());
                PrecioUnitario = Int32.Parse(contenido["precioUnitario"].ToString());
                PrecioVenta = Int32.Parse(contenido["precioVenta"].ToString());
                Marca = contenido["marca"].ToString();
                Categoria = contenido["categoria"].ToString();

                //producto.id = contenido["_id"].ToString();
                //producto.nombre = contenido["nombre"].ToString();
                //producto.descripcion = contenido["descripcion"].ToString();
                //producto.cantidadDisponible = Int32.Parse(contenido["cantidadDisponible"].ToString());
                //producto.precioUnitario = Int32.Parse(contenido["precioUnitario"].ToString());
                //producto.precioVenta = Int32.Parse(contenido["precioVenta"].ToString());
                //producto.marca = contenido["marca"].ToString();
                //producto.categoria = contenido["categoria"].ToString();


                //var posts = JsonConvert.DeserializeObject<List<Producto>>(contenido);
                //PostList = new List<Producto>(posts);
            }


        }
    }
}
