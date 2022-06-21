using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
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

            CarregarComboBoxClientes();
            PreencherTabelaComDadosServicosAndamentos();
            formModulo = _formModulo;
            CalcularLucro();
            dtpDataAtualCadastro.Text = DateTime.Now.ToShortDateString();

        }


        //MÉTODO SEM RETORNO ( QUANDO VOID NÃO RETORNA NADA )
        private void InicilizarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
            BancoGlobal.IniciarTabelaCadastroClientes();
        }

        private void CarregarComboBoxClientes()
        {
            foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
            {
                cmbCliente.Items.Add(cliente.cl_nome);
            }
        }

        //METODO COM RETORNO
        private DataTable CriarDataTableServicos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Data de Cadastro");
            ;
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome Cliente");
            dt.Columns.Add("Aparelho");
            dt.Columns.Add("Defeito");
            dt.Columns.Add("Senha");
            dt.Columns.Add("Situação");
            dt.Columns.Add("Acessórios");
            dt.Columns.Add("R$ Valor do Serviço");
            dt.Columns.Add("R$ Valor da Peça");
            dt.Columns.Add("Lucro");
            dt.Columns.Add("Serviço Feito");
            dt.Columns.Add("Data de Conclusão");
            dt.Columns.Add("Status de Serviço");

            return dt;
        }

        private void AdicionarLinhaGridView(DataTable dt)
        {
            foreach (CadastroServicoEstrutura cadastro in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (cadastro.sv_status == 1)
                {
                    dt.Rows.Add(cadastro.sv_dataCadastro.ToShortDateString(), cadastro.sv_id,
                        BuscarNomeCliente(cadastro.sv_fk_cl_idCliente),
                        cadastro.sv_aparelho,
                        cadastro.sv_defeito, cadastro.sv_senha,
                        cadastro.sv_situacao, cadastro.sv_acessorios, cadastro.sv_valorServico, cadastro.sv_valorPeca,
                        cadastro.sv_lucroServico.ToString("C"), cadastro.sv_servicoFeito,
                        cadastro.sv_dataConclusao.ToShortDateString(),
                        (cadastro.sv_status == 1) ? "Em Andamento" : "Concluido");
                }

            }
        }

        private string BuscarNomeCliente(int _idCliente)
        {
            foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
            {
                if (cliente.cl_id == _idCliente)
                {
                    return cliente.cl_nome;
                }
            }

            return "";
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
            dtpDataAtualCadastro.Text = gdv_CadastroServicos.SelectedCells[0].Value.ToString();
            form.txtvalorServico.Text = gdv_CadastroServicos.SelectedCells[8].Value.ToString();
            form.txtvalorPeca.Text = gdv_CadastroServicos.SelectedCells[9].Value.ToString();
            form.txtServicoFeito.Text = gdv_CadastroServicos.SelectedCells[11].Value.ToString();
            form.ShowDialog();
        }

        public void BuscarServicoAndamento()
        {
            formModulo.pctHome.Image = Resources.icons8_pesquisar_100__1_;
            formModulo.lblHome.Text = "BUSCAR SERVIÇOS";

            if (txtBuscarServicoAparelho.Text == "")
            {
                MessageBox.Show("INSIRA UMA BUSCA!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                DataTable dt = CriarDataTableServicos();
                foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
                {
                    if (servico.sv_aparelho.ToLower().Contains(txtBuscarServicoAparelho.Text.ToLower()))
                    {
                        dt.Rows.Add(servico.sv_id, servico.sv_fk_cl_idCliente, servico.sv_aparelho,
                            servico.sv_defeito, servico.sv_senha, servico.sv_situacao, servico.sv_acessorios,
                            servico.sv_dataCadastro.ToShortDateString(), servico.sv_dataConclusao.ToShortDateString(),
                            servico.sv_valorServico, servico.sv_valorPeca,
                            servico.sv_lucroServico, servico.sv_servicoFeito,
                            (servico.sv_status == 1) ? "Em Andamento" : "Concluido");

                        ClearTextBox();
                    }
                }

                gdv_CadastroServicos.DataSource = dt;
            }
        }

        public void PreencherTabelaComDadosServicosAndamentos()
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
            cmbCliente.Text = "";
        }

        private Decimal CalcularLucro()
        {

            decimal valorServico = 0;
            decimal valorPeca = 0;


            if (txtvalorPeca.Text != "")
            {
                valorPeca = Convert.ToDecimal(txtvalorPeca.Text);
            }

            if (txtvalorServico.Text != "")
            {
                valorServico = Convert.ToDecimal(txtvalorServico.Text);
            }

            decimal lucro = valorServico - valorPeca;

            return lucro;
        }

        private int BuscarIDCliente(string _Nome)
        {
            foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
            {
                if (cliente.cl_nome == _Nome)
                {
                    return cliente.cl_id;
                }
            }

            return 0;
        }

        private void CadastrarServicos()
        {
            //Verificação
            if (cmbCliente.Text.Length <= 0 || txtAparelho.Text.Length <= 0 || txtDefeito.Text.Length <= 0)
            {
                MessageBox.Show("INSIRA OS CAMPOS OBRIGATÓRIOS!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Decimal lucro = CalcularLucro();


            int novaID = BancoGlobal.listaCadastrosServicosEstrutura.Count;
            int novaIDCliente = BancoGlobal.listaCadastrosServicosEstrutura.Count;


            BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(novaID + 1,
                BuscarIDCliente(cmbCliente.Text), txtAparelho.Text, txtDefeito.Text, txtSenha.Text, txtSituacao.Text,
                txtAcessorios.Text,
                dtpDataAtualCadastro.Value, dtpDataConclusao.Value,
                Convert.ToDecimal(txtvalorPeca.Text == "" ? "0" : txtvalorPeca.Text),
                Convert.ToDecimal(txtvalorServico.Text == "" ? "0" : txtvalorServico.Text), lucro, txtServicoFeito.Text,
                1));
            //Ternário é um if else simplificado.

            MessageBox.Show("Serviço cadastrado com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearTextBox();
        }

        private void btnCadastrarServicos_Click(object sender, EventArgs e)
        {
            formModulo.pctHome.Image = Resources.icons8_mais_2_matemática_100__1_;
            formModulo.lblHome.Text = "CADASTRAR";
            CadastrarServicos();
            PreencherTabelaComDadosServicosAndamentos();
            gdv_CadastroServicos.ClearSelection();
        }

        private void btnBuscarServicoEmAndamento_Click(object sender, EventArgs e)
        {
            BuscarServicoAndamento();
        }

        private void txtBuscarServicoAparelho_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtBuscarServicoAparelho.Text == "")
            {
                PreencherTabelaComDadosServicosAndamentos();
            }
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
                        PreencherTabelaComDadosServicosAndamentos();
                        break;

                    }
                    else
                    {
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

        private void contextConcluirServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt = CriarDataTableServicos();
            AdicionarLinhaGridView(dt);

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {

                if (servico.sv_id == Convert.ToInt32(gdv_CadastroServicos.SelectedCells[1].Value.ToString()))
                {
                    if (servico.sv_status == 1)
                    {
                        if (MessageBox.Show("TEM CERTEZA? ", "ATENÇÃO", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            servico.sv_status = 0;
                            PreencherTabelaComDadosServicosAndamentos();
                            break;

                        }
                    }
                }
            }
        }
    }
}



