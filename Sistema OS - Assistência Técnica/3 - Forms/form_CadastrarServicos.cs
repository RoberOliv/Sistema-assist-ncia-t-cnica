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
    public partial class form_CadastrarServicos : Form
    {
        //VARIAVEL DO TIPO FORM MODULO SERVIÇO ANDAMENTO
        private form_ModuloServicoAndamento formModulo;

        //CONSTRUTOR PQ TEM O MESMO NOME DO FORM        (PARAMETRO)        
        public form_CadastrarServicos(form_ModuloServicoAndamento _formModulo)
        {
            InitializeComponent();
            InicilizarBancoGlobal();
            PreencherTabelaComDadosServicos();
            txtDataDeCadastro.Text = DateTime.Now.ToShortDateString();
            txtDataConclusao.Text = DateTime.Now.ToShortDateString();
            formModulo = _formModulo;
        }

        //MÉTODO SEM RETORNO ( QUANDO VOID NÃO RETORNA NADA )
        private void InicilizarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
        }

        //METODO COM RETORNO
        private DataTable CriarDataTableServicos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Data de Cadastro");
            dt.Columns.Add("ID");
            dt.Columns.Add("ID Cliente");
            dt.Columns.Add("Aparelho");
            dt.Columns.Add("Defeito");
            dt.Columns.Add("Senha");
            dt.Columns.Add("Situação");
            dt.Columns.Add("Acessórios");
            dt.Columns.Add("R$ Valor do Serviço");
            dt.Columns.Add("R$ Valor da Peça");
            dt.Columns.Add("R$ Lucro");
            dt.Columns.Add("Serviço Feito");
            dt.Columns.Add("Data de Conclusão");
            dt.Columns.Add("Status de Serviço");

            return dt;
        }

        private void AdicionarLinhaGridView(DataTable dt)
        {
            foreach (CadastroServicoEstrutura cadastro in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                dt.Rows.Add(cadastro.sv_dataCadastro.ToShortDateString(), cadastro.sv_id, cadastro.sv_fk_cl_idCliente, cadastro.sv_aparelho,
                    cadastro.sv_defeito, cadastro.sv_senha,
                    cadastro.sv_situacao, cadastro.sv_acessorios, cadastro.sv_valorServico, cadastro.sv_valorPeca,
                    cadastro.sv_lucroServico, cadastro.sv_servicoFeito, cadastro.sv_dataConclusao.ToShortDateString(),
                    (cadastro.sv_status == 1) ? "Em Andamento" : "Concluido");
            }
        }

        public void SetarValoresTextBox()
        {
            form_EditarServicos form = new form_EditarServicos(this);
            form.lbID.Text = gdv_CadastroServicos.SelectedCells[1].Value.ToString();
            form.txtAparelho.Text = gdv_CadastroServicos.SelectedCells[3].Value.ToString();
            form.txtDefeito.Text = gdv_CadastroServicos.SelectedCells[4].Value.ToString();
            form.txtSenha.Text = gdv_CadastroServicos.SelectedCells[5].Value.ToString();
            form.txtSituacao.Text = gdv_CadastroServicos.SelectedCells[6].Value.ToString();
            form.txtAcessorios.Text = gdv_CadastroServicos.SelectedCells[7].Value.ToString();
            form.txtDataDeCadastro.Text = gdv_CadastroServicos.SelectedCells[0].Value.ToString();
            form.txtvalorServico.Text = gdv_CadastroServicos.SelectedCells[8].Value.ToString();
            form.txtvalorPeca.Text = gdv_CadastroServicos.SelectedCells[9].Value.ToString();
            form.txtServicoFeito.Text = gdv_CadastroServicos.SelectedCells[11].Value.ToString();
            form.ShowDialog();
        }

        public void MetodoBuscarServicoAndamento()
        {
            formModulo.pctHome.Image = Resources.icons8_pesquisar_100__1_;
            formModulo.lblHome.Text = "BUSCAR SERVIÇO";


            if (txtBuscarServicoAparelho.Text == "")
            {
                MessageBox.Show("INSIRA UMA BUSCA!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                DataTable dt = CriarDataTableServicos();
                foreach (CadastroServicoEstrutura cadastro in BancoGlobal.listaCadastrosServicosEstrutura)
                {
                    if (cadastro.sv_aparelho.ToLower().Contains(txtBuscarServicoAparelho.Text))
                    {

                        dt.Rows.Add(cadastro.sv_id, cadastro.sv_fk_cl_idCliente, cadastro.sv_aparelho, cadastro.sv_defeito, cadastro.sv_senha, cadastro.sv_situacao, cadastro.sv_acessorios,
                            cadastro.sv_dataCadastro.ToShortDateString(), cadastro.sv_dataConclusao.ToShortDateString(), cadastro.sv_valorServico, cadastro.sv_valorPeca,
                            cadastro.sv_lucroServico, cadastro.sv_servicoFeito, (cadastro.sv_status == 1) ? "Em Andamento" : "Concluido");

                    }

                }
                gdv_CadastroServicos.DataSource = dt;
                ClearTextBox();
            }
        }

        public void PreencherTabelaComDadosServicos()
        {
            DataTable dt = CriarDataTableServicos();
            AdicionarLinhaGridView(dt);

            gdv_CadastroServicos.DataSource = dt;
        }

        private void ClearTextBox()
        {
            txtAcessorios.Clear();
            txtvalorPeca.Clear();
            txtvalorServico.Clear();
            txtAparelho.Clear();
            txtSenha.Clear();
            txtSituacao.Clear();
            txtvalorPeca.Clear();
            txtServicoFeito.Clear();
            txtDefeito.Clear();
        }

        private void MetodoFormatarData(object sender, KeyPressEventArgs e)
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

        private void CadastrarServicos()
        {
            try
            {

                if (cmbCliente.Text.Length <= 0 || txtAparelho.Text.Length <= 0 || txtDefeito.Text.Length <= 0)
                {
                    MessageBox.Show("INSIRA OS CAMPOS OBRIGATÓRIOS!", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                decimal lucro = Convert.ToDecimal(txtvalorServico.Text) - Convert.ToDecimal(txtvalorPeca.Text);
                int novaID = BancoGlobal.listaCadastrosServicosEstrutura.Count;
                int novaIDCliente = BancoGlobal.listaCadastrosServicosEstrutura.Count;

                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(novaID + 1,
                    novaIDCliente + 1, txtAparelho.Text, txtDefeito.Text, txtSenha.Text, txtSituacao.Text, txtAcessorios.Text,
                    Convert.ToDateTime(txtDataDeCadastro.Text), Convert.ToDateTime(txtDataConclusao.Text),
                    Convert.ToDecimal(txtvalorPeca.Text), Convert.ToDecimal(txtvalorServico.Text),
                    lucro, txtServicoFeito.Text, 1));

                ClearTextBox();

                MessageBox.Show("Serviço cadastrado com Sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception exception)
            {
                //MessageBox.Show($"Falha ao cadastrar o Serviço!\n\n{exception}", "FALHA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrarServicos_Click(object sender, EventArgs e)
        {
            formModulo.pctHome.Image = Resources.icons8_mais_2_matemática_100__1_;
            formModulo.lblHome.Text = "CADASTRAR";
            CadastrarServicos();
            PreencherTabelaComDadosServicos();
            gdv_CadastroServicos.ClearSelection();
        }

        private void btnBuscarServicoEmAndamento_Click(object sender, EventArgs e)
        {
            MetodoBuscarServicoAndamento();
        }

        private void txtBuscarServicoAparelho_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtBuscarServicoAparelho.Text == "")
            {
                PreencherTabelaComDadosServicos();
            }
        }

        private void txtDataDeCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspaceBarra(e);
            MetodoFormatarData(sender, e);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicos.SelectedRows.Count;


            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SetarValoresTextBox();

            }
        }

        private void form_CadastrarServicos_Load(object sender, EventArgs e)
        {
            gdv_CadastroServicos.ClearSelection();
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicos.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            DataTable dt = CriarDataTableServicos();
            AdicionarLinhaGridView(dt);


            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {

                if (servico.sv_id == Convert.ToInt32(gdv_CadastroServicos.SelectedCells[1].Value.ToString()))
                {
                    if (MessageBox.Show("TEM CERTEZA? ", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        BancoGlobal.listaCadastrosServicosEstrutura.Remove(servico);
                        PreencherTabelaComDadosServicos();
                        break;

                    }
                }
            }
        }

        private void txtAparelho_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtBuscarServicoAparelho_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtServicoFeito_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasSpaceLetrasNumerosBackspace(e);
        }

        private void txtvalorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
        }

        private void txtvalorPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
        }
    }
}


