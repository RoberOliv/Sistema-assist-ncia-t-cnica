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

        public static bool ApenasNumerosBackspaceBarra(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 47 && e.KeyChar != 32 && e.KeyChar != 8)
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
    }
}

