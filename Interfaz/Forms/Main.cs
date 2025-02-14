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
using AccesoDB;
using Negocio.Dominio;



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
            OperacionesDB operacionesDB = new OperacionesDB();
            try
            {

                dgv_Articulos.DataSource = operacionesDB.listar_articulos();
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
    }
}
