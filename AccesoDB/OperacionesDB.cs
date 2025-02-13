using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Negocio.Dominio;
namespace AccesoDB
{
    public class OperacionesDB
    {
        public List<Articulo> listar_articulos()
        {
            List<Articulo> lista = new List<Articulo>();
            LecturaDB lecturaDB = new LecturaDB(); 

            try
            {
                lecturaDB.SetearConsulta("Select  Id,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS");
                lecturaDB.EjecutarLectura();

                while (lecturaDB.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)lecturaDB.Lector["Id"];
                    articulo.Codigo = (string)lecturaDB.Lector["Codigo"];
                    articulo.Nombre = (string)lecturaDB.Lector["Nombre"];
                    articulo.Descripcion = (string)lecturaDB.Lector["Descripcion"];
                    articulo.Marca = new Marca() { Id = (int)lecturaDB.Lector["IdMarca"] };
                    articulo.Categoria = new Categoria() { Id = (int)lecturaDB.Lector["IdCategoria"] }; ;
                    articulo.Imagen = (string)lecturaDB.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)lecturaDB.Lector["Precio"];

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception error) { throw error; }    
            finally { lecturaDB.CerrarConexion(); }

        }





    }
}
