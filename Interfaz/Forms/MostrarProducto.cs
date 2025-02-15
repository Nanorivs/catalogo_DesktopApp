using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Dominio;
using Negocio.Helpers;
using Negocio;

namespace Interfaz
{
    public partial class MostrarProducto : Form
    {
        Articulo articulo = null;
        
        public MostrarProducto()
        {
            InitializeComponent();
        }
        public MostrarProducto(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }

        private void MostrarProducto_Load(object sender, EventArgs e)
        {
            try { 
                Tareas tareas = new Tareas();

                comBox_Marca.DataSource = tareas.listarMarcas();
                comBox_Marca.ValueMember = "Id";
                comBox_Marca.DisplayMember = "Descripcion";

                comBox_Categoria.DataSource = tareas.listarCategorias();
                comBox_Categoria.ValueMember = "Id";
                comBox_Categoria.DisplayMember = "Descripcion";

                string imagenArticulo = null;

                if (articulo != null) 
                { 
                    txt_Codigo.Text = articulo.Codigo;
                    txt_Descripcion.Text = articulo.Descripcion;
                    txt_Imagen.Text = articulo.Imagen;
                    txt_Nombre.Text = articulo.Nombre;
                    numUpDown_Precio.Value = articulo.Precio;
                    comBox_Categoria.SelectedValue = articulo.Categoria.Id;
                    comBox_Marca.SelectedValue = articulo.Marca.Id;
                    Utilidades.SoloLectura(this);
                    imagenArticulo = articulo.Imagen;
                }

                Utilidades.CargarImagen(pb_Articulo, imagenArticulo);


            }catch(Exception error) { throw error; }

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {   Tareas tareas = new Tareas();
            bool agregar = false;

            try 
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                    agregar = true;
                } 
           
                articulo.Marca = (Marca)comBox_Marca.SelectedItem;
                articulo.Categoria = (Categoria)comBox_Categoria.SelectedItem;
                articulo.Codigo = txt_Codigo.Text;
                articulo.Nombre = txt_Nombre.Text;
                articulo.Descripcion = txt_Descripcion.Text;
                articulo.Imagen = txt_Imagen.Text;
                articulo.Precio = numUpDown_Precio.Value;

                if (agregar)
                {
                    if (Validaciones.ValidarDecision("Agregar artículo"))
                    {
                        tareas.agregarArticulo(articulo);
                        MessageBox.Show("Artículo agregado exitosamente");
                    }
                }
                else
                {
                    
                }
            
                    //tareas.modificarArticulo(articulo);
                    //MessageBox.Show("Artículo modificado exitosamente");
            }
            catch(Exception error) 
                {agregar = true; }
            finally 
                { Close(); }


            
        }

        private void txt_Imagen_Leave(object sender, EventArgs e)
        {
            Utilidades.CargarImagen(pb_Articulo, txt_Imagen.Text);
        }
    }
}
