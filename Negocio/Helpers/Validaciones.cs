using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Helpers
{
    public class Validaciones
    {
        public static bool ValidarEntrada(TextBox textBox, string mensaje, bool soloLetras = true)
        {

            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show(mensaje);
                return false;
            }

            Func<char, bool> criterio = soloLetras ? new Func<char, bool>(char.IsLetter) : char.IsDigit;

            foreach (char caracter in textBox.Text)
            {
                if (!criterio(caracter))
                {
                    MessageBox.Show(mensaje);
                    return false;
                }
            }

            return true;
        }
        public static bool ValidarEntrada(ComboBox comboBox, string mensaje)
        {

            if (comboBox.SelectedIndex < 0)
            {
                MessageBox.Show(mensaje);
                return false;
            }

            return true;
        }
    }

}
