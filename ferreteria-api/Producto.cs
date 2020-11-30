using System;
using System.Collections.Generic;
using System.Text;

namespace ferreteria_api {

    public class Producto {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidadDisponible { get; set; }
        public int precioUnitario { get; set; }
        public int precioVenta { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
    }

}
