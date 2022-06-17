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

namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    public partial class form_EditarServicos : Form
    {
        private form_CadastrarServicos formCadastrarServicos;
        public form_EditarServicos(form_CadastrarServicos _formCadastrarServicos)
        {
            InitializeComponent();
            InicilizarBancoGlobal();
            txtDataDeCadastro.Text = DateTime.Now.ToShortDateString();
            formCadastrarServicos = _formCadastrarServicos;
        }

        private void InicilizarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
        }

        private void MetodoFormataData(object sender, KeyPressEventArgs e)
        {
            TextBox Data = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Data.SelectionStart = Data.Text.Length + 1;

                if (Data.Text.Length == 2 || Data.Text.Length == 5)
                    Data.Text += "/";
                else if (Data.Text.Length == 10)
                    Data.Text += "";
                Data.SelectionStart = Data.Text.Length + 1;
            }
        }

        private void MetodoSalvarAlteracaoServico()
        {
            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (txtAcessorios.Text.Length < 0 || txtvalorPeca.Text.Length < 0 || txtvalorServico.Text.Length < 0 ||
                    txtAparelho.Text.Length < 0 ||
                    txtSenha.Text.Length < 0 || txtSituacao.Text.Length < 0 || txtvalorPeca.Text.Length < 0 ||
                    txtServicoFeito.Text.Length < 0)
                {
                    MessageBox.Show("PREENCHA TODOS OS CAMPOS DE CADASTRO EM BRANCO.");
                }

                decimal lucro = Convert.ToDecimal(txtvalorServico.Text) - Convert.ToDecimal(txtvalorPeca.Text);

                if (servico.sv_id == Convert.ToInt32(lbID.Text))
                {
                    servico.sv_aparelho = txtAparelho.Text;
                    servico.sv_dataCadastro = Convert.ToDateTime(txtDataDeCadastro.Text);
                    servico.sv_defeito = txtDefeito.Text;
                    servico.sv_senha = txtSenha.Text;
                    servico.sv_valorServico = Convert.ToDecimal(txtvalorServico.Text);
                    servico.sv_valorPeca = Convert.ToDecimal(txtvalorPeca.Text);
                    servico.sv_servicoFeito = txtServicoFeito.Text;
                    servico.sv_situacao = txtSituacao.Text;
                    servico.sv_acessorios = txtAcessorios.Text;
                    servico.sv_lucroServico = lucro;

                    formCadastrarServicos.PreencherTabelaComDadosServicos();


                    MessageBox.Show("Dados alterados com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                }
            }
            this.Close();
        }

        private void btnSalvarAlteracaoServico_Click(object sender, EventArgs e)
        {
           MetodoSalvarAlteracaoServico();
        }

        private void btnFecharJanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizarJanela_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtvalorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
        }

        private void txtvalorPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
        }

        private void txtDataDeCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspaceBarra(e);
            MetodoFormataData(sender,e);
        }

        private void txtAparelho_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtDefeito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtAcessorios_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtServicoFeito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }
    }
}
