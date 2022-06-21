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
    public partial class form_EditarServicos : Form
    {
        private form_CadastrarServicos formCadastrarServicos;
        private form_ServicosConcluidos formServicosConcluidos;

        public form_EditarServicos(form_CadastrarServicos _formCadastrarServicos)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            formCadastrarServicos = _formCadastrarServicos;

        }
        public form_EditarServicos(form_ServicosConcluidos _formServicosConcluidos)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            formServicosConcluidos = _formServicosConcluidos;

        }


        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
        }

        private Decimal CalcularLucro()
        {

            decimal valorPeca = 0;
            decimal valorServico = 0;
            char[] caracteres = { 'R', '$' };


            if (txtvalorPeca.Text != "")
            {

                valorPeca = Convert.ToDecimal(txtvalorPeca.Text.TrimStart(caracteres));
            }

            if (txtvalorServico.Text != "")
            {
                valorServico = Convert.ToDecimal(txtvalorServico.Text.TrimStart(caracteres));
            }


            decimal lucro = valorServico - valorPeca;

            return lucro;

        }

        private void SalvarAlteracaoServico()
        {

            if (txtAcessorios.Text.Length <= 0 || txtvalorServico.Text.Length <= 0 || txtAparelho.Text.Length <= 0 || txtDefeito.Text.Length <= 0 || txtSenha.Text.Length <= 0 || txtSituacao.Text.Length <= 0 || txtvalorPeca.Text.Length <= 0 ||
                txtServicoFeito.Text.Length <= 0)
            {
                MessageBox.Show("PREENCHA OS CAMPOS EM BRANCO PARA CONCLUIR A ALTERAÇÃO!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {

                if (servico.sv_id == Convert.ToInt32(lbID.Text))
                {
                    Decimal lucro = CalcularLucro();
                    char[] caracteres = { 'R', '$' };

                    servico.sv_aparelho = txtAparelho.Text;
                    servico.sv_dataCadastro = dtpDataAtualCadastro.Value;
                    servico.sv_defeito = txtDefeito.Text;
                    servico.sv_senha = txtSenha.Text;
                    servico.sv_valorServico = Convert.ToDecimal(txtvalorServico.Text.TrimStart(caracteres) == "" ? "0" : txtvalorServico.Text.TrimStart(caracteres));
                    servico.sv_valorPeca = Convert.ToDecimal(txtvalorPeca.Text.TrimStart(caracteres) == "" ? "0" : txtvalorPeca.Text.TrimStart(caracteres));
                    servico.sv_servicoFeito = txtServicoFeito.Text;
                    servico.sv_situacao = txtSituacao.Text;
                    servico.sv_acessorios = txtAcessorios.Text;
                    servico.sv_lucroServico = lucro;

                    if (formServicosConcluidos != null)
                    {
                        formServicosConcluidos.PreencherTabelaComDadosServicosConcluidos();

                    }
                    else if (formCadastrarServicos != null)
                    {
                        formCadastrarServicos.PreencherTabelaComDadosServicosAndamentos();
                    }

                    MessageBox.Show("Dados alterados com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                }
            }

            this.Close();
        }

        private void btnSalvarAlteracaoServico_Click(object sender, EventArgs e)
        {
            pctHome.Image = Resources.icons8_alterar_100__1_;
            lblHome.Text = "ALTERAR DADOS";
            SalvarAlteracaoServico();
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

        private void btnConcluirAbrirGarantia_Click(object sender, EventArgs e)
        {
            pctHome.Image = Resources.icons8_garantia_100;
            lblHome.Text = "EMITIR GARANTIA";
        }
    }
}
