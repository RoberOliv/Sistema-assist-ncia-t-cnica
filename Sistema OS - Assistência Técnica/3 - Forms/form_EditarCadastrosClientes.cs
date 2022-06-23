using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_OS___Assistência_Técnica._1___BancoGlobal;
using Sistema_OS___Assistência_Técnica._2___Classes;
using Sistema_OS___Assistência_Técnica.Properties;

namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    public partial class form_EditarCadastrosClientes : Form
    {
        private form_CadastrarClientes formCadastrarClientes;

        public form_EditarCadastrosClientes(form_CadastrarClientes _formCadastrarClientes)
        {
            InitializeComponent();
            formCadastrarClientes = _formCadastrarClientes;
        }

        private void btnFecharJanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizarJanela_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSalvarAlteracaoServico_Click(object sender, EventArgs e)
        {
            pctHome.Image = Resources.icons8_alterar_100__1_;
            lblHome.Text = "ALTERAR DADOS";

            if (txtNomeCliente.Text.Length <= 0 || txtDocumentoCPF.Text.Length <= 0 || txtNumeroTelefone.Text.Length <= 0 || txtTelefoneRecado.Text.Length <= 0)
            {
                MessageBox.Show("PREENCHA OS CAMPOS EM BRANCO PARA CONCLUIR A ALTERAÇÃO!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
            {

                if (cliente.cl_id == Convert.ToInt32(lblAlteracaoClientes.Text))
                {

                    cliente.cl_nome = txtNomeCliente.Text;
                    cliente.cl_telefone = txtNumeroTelefone.Text;
                    cliente.cl_cpf = txtDocumentoCPF.Text;
                    cliente.cl_telefone_recado = txtTelefoneRecado.Text;

                    MessageBox.Show("Dados alterados com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    formCadastrarClientes.PreencherTabelaComDadosClientes();

                    break;
                }
            }
            this.Close();
        }

        private void txtNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasLetrasBackspace(e);
        }

        private void PadraoDocumentoCPF(object sender, KeyPressEventArgs e)
        {
            TextBox CPF = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                CPF.SelectionStart = CPF.Text.Length + 1;

                if (CPF.Text.Length == 3 || CPF.Text.Length == 7)
                    CPF.Text += ".";
                else if (CPF.Text.Length == 11)
                    CPF.Text += "-";
                CPF.SelectionStart = CPF.Text.Length + 1;
            }
        }
        private void PadraoTelefonicoTextBox(object sender, KeyPressEventArgs e)
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

        private void txtDocumentoCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
            PadraoDocumentoCPF(sender, e);
        }

        private void txtNumeroTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
            PadraoTelefonicoTextBox(sender, e);
        }

        private void txtTelefoneRecado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);

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




