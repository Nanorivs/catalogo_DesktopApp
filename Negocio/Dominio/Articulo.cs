using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Negocio.Dominio
{
    public class Articulo
    {
      public int Id { get; set; }


      [DisplayName("Código")]
      public string Codigo {  get; set; }  

      public string Nombre { get; set; }


      [DisplayName("Descripción")]
      public string Descripcion { get; set; }


      public Marca Marca { get; set; }


      [DisplayName("Categoría")]
      public Categoria Categoria { get; set; }


      public string Imagen {  get; set; } 


      public decimal Precio {  get; set; }
    }
}
