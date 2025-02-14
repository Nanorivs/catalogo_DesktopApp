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
                lecturaDB.SetearConsulta("Select A.Id,A.Codigo,A.Nombre,A.Descripcion,A.IdMarca,M.Descripcion AS Marca,A.IdCategoria,C.Descripcion AS Categoria,A.ImagenUrl,A.Precio From ARTICULOS A,CATEGORIAS C, MARCAS M where A.IdMarca = M.Id AND A.IdCategoria =  C.Id");
                lecturaDB.EjecutarLectura();

                while (lecturaDB.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)lecturaDB.Lector["Id"];
                    articulo.Codigo = (string)lecturaDB.Lector["Codigo"];
                    articulo.Nombre = (string)lecturaDB.Lector["Nombre"];
                    articulo.Descripcion = (string)lecturaDB.Lector["Descripcion"];
                    articulo.Marca = new Marca() { Id = (int)lecturaDB.Lector["IdMarca"], Descripcion = (string)lecturaDB.Lector["Marca"] };
                    articulo.Categoria = new Categoria() { Id = (int)lecturaDB.Lector["IdCategoria"], Descripcion = (string)lecturaDB.Lector["Categoria"] };
                    articulo.Imagen = (string)lecturaDB.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)lecturaDB.Lector["Precio"];

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception error) { throw error; }
            finally { lecturaDB.CerrarConexion(); }

        }
        public List<Categoria> listar_categorias()
        {
            LecturaDB lecturaDB = new LecturaDB();
            List<Categoria> lista = new List<Categoria>();

            try
            {
                lecturaDB.SetearConsulta("Select Id,Descripcion From CATEGORIAS");
                lecturaDB.EjecutarLectura();

                while (lecturaDB.Lector.Read())
                {
                    Categoria categoria = new Categoria()
                    {
                        Id = (int)lecturaDB.Lector["Id"],
                        Descripcion = (string)lecturaDB.Lector["Descripcion"]
                    };
                    lista.Add(categoria);

                }
                return lista;
            }
            catch (Exception error) { throw error; }
            finally { lecturaDB.CerrarConexion(); };
        }
        public List<Marca> listar_marcas()
        {
            LecturaDB lecturaDB = new LecturaDB();
            try
            {
                List<Marca> lista = new List<Marca>();

                lecturaDB.SetearConsulta("Select Id,Descripcion From MARCAS");
                lecturaDB.EjecutarLectura();

                while (lecturaDB.Lector.Read())
                {
                    Marca marca = new Marca() { Id = (int)lecturaDB.Lector["Id"], Descripcion = (string)lecturaDB.Lector["Descripcion"] };
                    lista.Add(marca);
                }
                return lista;
            }

            catch (Exception error) 
                { throw error; }
            finally 
                { lecturaDB.CerrarConexion(); }






        }
    }
}