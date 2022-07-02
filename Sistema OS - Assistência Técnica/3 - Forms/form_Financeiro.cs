using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    public partial class form_Financeiro : Form
    {
        public form_Financeiro()
        {
            InitializeComponent();
        }
        private void showChildForminPanel(object Form)
        {
            if (this.pnlLucros.Controls.Count > 0)
            {
                this.pnlLucros.Controls.RemoveAt(0);
            }

            Form form = Form as Form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlLucros.Controls.Add(form);
            form.Show();
        }


        private void btnExibirRankingMaiorQtdServicos_Click(object sender, EventArgs e)
        {
            showChildForminPanel(new form_ClientesComMaisServicos(this));
        }

        private void btnLucrosGastos_Click(object sender, EventArgs e)
        {
            showChildForminPanel(new form_MaioresLucros());
        }

        private void btnLucrosGastos_Click_1(object sender, EventArgs e)
        {
            showChildForminPanel(new form_LucrosGastos());
        }

        private void btnMaioresPrejuizos_Click(object sender, EventArgs e)
        {
            showChildForminPanel(new form_MaioresPrejuizos());
        }
    }
}
