using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    public class Articulo
    {
      public int Id { get; set; }   
      public string Codigo {  get; set; }  
      public string Nombre { get; set; } 
      public string Descripcion { get; set; }
      public Marca Marca { get; set; }
      public Categoria Categoria { get; set; }
      public string Imagen {  get; set; } 
      public decimal Precio {  get; set; }
    }
}
