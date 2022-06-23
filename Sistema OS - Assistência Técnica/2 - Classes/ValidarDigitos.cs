using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_OS___Assistência_Técnica._2___Classes
{
    class ValidarDigitos
    {
        public static bool ApenasSpaceLetrasNumerosBackspace(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32 && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return false;
            }

            return false;
        }

        public static bool ApenasNumerosBackspace(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                return false;
            }

            return false;
        }

        public static bool ApenasLetrasBackspace(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
                return false;
            }

            return false;
        }

        public void PadraoTelefonicoTextBox(object sender, KeyPressEventArgs e)
        {
            TextBox Tel = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Tel.SelectionStart = Tel.Text.Length + 1;

                if (Tel.Text.Length == 0 || Tel.Text.Length == 1)
                    Tel.Text += "(";
                else if (Tel.Text.Length == 3)
                    Tel.Text += ")";
                else if (Tel.Text.Length == 8)
                    Tel.Text += "-";
                Tel.SelectionStart = Tel.Text.Length + 1;
            }
        }

    }
}

