using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDB;
using Negocio.Dominio;
using Negocio.Helpers;

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
                OperacionesDB operacionesDB = new OperacionesDB();

                comBox_Marca.DataSource = operacionesDB.listar_marcas();
                comBox_Marca.ValueMember = "Id";
                comBox_Marca.DisplayMember = "Descripcion";

                comBox_Categoria.DataSource = operacionesDB.listar_categorias();
                comBox_Categoria.ValueMember = "Id";
                comBox_Categoria.DisplayMember = "Descripcion";

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

                }

                Utilidades.CargarImagen(pb_Articulo,articulo.Imagen);


            }catch(Exception error) { throw error; }

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
