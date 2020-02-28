using System;
using System.Drawing;

namespace Saif
{
    [Serializable]
    public class Equipos
    {
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Bitmap Imagen { get; set; }
        public double Precio { get; set; }
        
        public Equipos(){}

        public override string ToString()
        {
            return "Nombre: " + Nombre + "Titulo: " + Titulo + "Descripcion: " + Descripcion +
                   "Imagen: " + Imagen + "Precio: " + Precio;
        }
    }
}
