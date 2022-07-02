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


        private void txtDocumentoCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
          ValidarDigitos.PadraoDocumentoCPFTextbox(sender, e);
        }

        private void txtNumeroTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
           ValidarDigitos.PadraoTelefonicoTextBox(sender, e);
        }

        private void txtTelefoneRecado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
            ValidarDigitos.PadraoTelefonicoTextBox(sender, e);
        }
    }
}