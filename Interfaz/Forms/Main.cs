using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Helpers;
using Negocio.Dominio;
using Negocio;



namespace Interfaz
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }
        public void VentanaPrincipal()
        {
            Tareas operacionesDB = new Tareas();
            try
            {
                dgv_Articulos.DataSource = operacionesDB.listarArticulos();
                dgv_Articulos.Columns["Imagen"].Visible = false;
                dgv_Articulos.Columns["Id"].Visible = false;
                dgv_Articulos.Columns["Precio"].DefaultCellStyle.Format = "N0";

                string logo = Utilidades.ObtenerRutaImagen("logo.png");
                Utilidades.CargarImagen(pb_logo, logo);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
                VentanaPrincipal(); 
        }

        private void dgv_Articulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo articulo = (Articulo)dgv_Articulos.CurrentRow.DataBoundItem;
            MostrarProducto mostrarProducto = new MostrarProducto(articulo);
            mostrarProducto.ShowDialog();
            VentanaPrincipal();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            MostrarProducto agregarProducto = new MostrarProducto(null,"agregar");
            agregarProducto.ShowDialog();
            VentanaPrincipal();
        }

        private void dgv_Articulos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)//¿Celda valida?
                {
                    dgv_Articulos.ClearSelection();
                    dgv_Articulos.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    contMenuStrip_Opciones.Show(Cursor.Position);
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgv_Articulos.CurrentRow.DataBoundItem;
            
            MostrarProducto modificarProducto = new MostrarProducto(articulo,"modificar");
            modificarProducto.ShowDialog();
            VentanaPrincipal() ;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgv_Articulos.CurrentRow.DataBoundItem;

            MostrarProducto modificarProducto = new MostrarProducto(articulo, "eliminar");
            modificarProducto.ShowDialog();
            VentanaPrincipal();
        }
    }
}
