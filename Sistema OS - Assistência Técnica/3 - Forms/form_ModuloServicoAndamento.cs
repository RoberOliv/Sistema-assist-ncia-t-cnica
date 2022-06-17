using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_OS___Assistência_Técnica._3___Forms;
using Sistema_OS___Assistência_Técnica.Properties;


namespace Sistema_OS___Assistência_Técnica
{
    public partial class form_ModuloServicoAndamento : Form
    {
       
        public form_ModuloServicoAndamento()
        {
            InitializeComponent();
        }

        private void showChildForminPanel(object Form)
        {
            if (this.pnlDesktop.Controls.Count > 0)
            {
                this.pnlDesktop.Controls.RemoveAt(0);
            }

            Form form = Form as Form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlDesktop.Controls.Add(form);
            form.Show();
        }

        private void btnCadastrarClientes_Click(object sender, EventArgs e)
        {
            showChildForminPanel(new form_CadastrarClientes());
        }

        private void btnCadastrarServicos_Click(object sender, EventArgs e)
        {
            showChildForminPanel(new form_CadastrarServicos(this));
            pctHome.Image = Resources.icons8_adicionar_regra_100__3_;
            lblHome.Text = "CADASTRAR SERVIÇOS";
        }

        private void btnFecharJanela_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizarJanela_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
