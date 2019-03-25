using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objeto
{
    public class Productos
    {
        public int codigo { get; set; }
        public string Nombre { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Boolean Activo { get; set; }
    }
}
