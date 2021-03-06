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

        private form_CadastrarClientes formCalcularDataGarantia;

        //CONSTRUTOR PQ TEM O MESMO NOME DO FORM        (PARAMETRO)
        public form_CadastrarServicos(form_ModuloServicoAndamento _formModulo)
        {
            InitializeComponent();
            InicilizarBancoGlobal();

            CarregarComboBoxClientes();
            PreencherTabelaComDadosServicosAndamentos();
            formModulo = _formModulo;
            gdv_CadastroServicos.Columns[12].Visible = false;
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
            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_status == 1)
                {
                    dt.Rows.Add(servico.sv_dataCadastro.ToShortDateString(), servico.sv_id,
                        BuscarNomeCliente(servico.sv_fk_cl_idCliente),
                        servico.sv_aparelho,
                        servico.sv_defeito, servico.sv_senha,
                        servico.sv_situacao, servico.sv_acessorios, servico.sv_valorServico, servico.sv_valorPeca,
                        servico.sv_lucroServico.ToString("C"), servico.sv_servicoFeito,
                        servico.sv_dataConclusao.ToShortDateString() == "01/01/0001" ? "" : servico.sv_dataConclusao.ToShortDateString(),
                        (servico.sv_status == 1) ? "Em Andamento" : "Concluido");
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
            int qtdDeLinhasSelecionadas = gdv_CadastroServicos.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR,DELETAR OS DADOS OU CONCLUIR SERVIÇO!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                form_EditarServicos form = new form_EditarServicos(this);
                form.lbliDServico.Text = gdv_CadastroServicos.SelectedCells[1].Value.ToString();
                form.txtNomeCliente.Text = gdv_CadastroServicos.SelectedCells[2].Value.ToString();
                form.txtAparelho.Text = gdv_CadastroServicos.SelectedCells[3].Value.ToString();
                form.txtDefeito.Text = gdv_CadastroServicos.SelectedCells[4].Value.ToString();
                form.txtSenha.Text = gdv_CadastroServicos.SelectedCells[5].Value.ToString();
                form.txtSituacao.Text = gdv_CadastroServicos.SelectedCells[6].Value.ToString();
                form.txtAcessorios.Text = gdv_CadastroServicos.SelectedCells[7].Value.ToString();
                form.txtvalorServico.Text = gdv_CadastroServicos.SelectedCells[8].Value.ToString();
                form.txtvalorPeca.Text = gdv_CadastroServicos.SelectedCells[9].Value.ToString();
                form.txtServicoFeito.Text = gdv_CadastroServicos.SelectedCells[11].Value.ToString();
                form.ShowDialog();
            }
        }

        public void BuscarServicoAndamento(string _textoDigitado)
        {
            formModulo.pctHome.Image = Resources.icons8_pesquisar_100__1_;
            formModulo.lblHome.Text = "BUSCAR SERVIÇOS";

            if (txtBuscarServicoAparelho.Text == "Busca feita por aparelho")
            {
                MessageBox.Show("INSIRA UMA BUSCA!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                DataTable dt = CriarDataTableServicos();
                foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
                {
                    if (servico.sv_status == 1)
                    {
                        if (servico.sv_aparelho.ToLower().Contains(_textoDigitado.ToLower()))
                        {
                            dt.Rows.Add(servico.sv_dataCadastro.ToShortDateString(), servico.sv_id, BuscarNomeCliente(servico.sv_fk_cl_idCliente), servico.sv_aparelho,
                                servico.sv_defeito, servico.sv_senha, servico.sv_situacao, servico.sv_acessorios,
                                servico.sv_valorServico, servico.sv_valorPeca,
                                servico.sv_lucroServico, servico.sv_servicoFeito, servico.sv_dataConclusao.ToShortDateString(),
                                (servico.sv_status == 1) ? "Em Andamento" : "Concluido");

                            ClearTextBox();
                        }
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

        private void ResetarValoresTextBox()
        {
            txtAparelho.Text = "Modelo do aparelho";
            txtDefeito.Text = "Digite o defeito";
            txtAcessorios.Text = "Acessórios do cliente";
            txtSenha.Text = "Senha do aparelho";
            txtServicoFeito.Text = "Serviço feito";
            txtSituacao.Text = "Situação do aparelho";
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

            if (txtAparelho.Text == "Modelo do aparelho" || txtDefeito.Text == "Digite o defeito" || txtAcessorios.Text == "Acessórios do cliente" ||
                txtSenha.Text == "Senha do aparelho" || txtServicoFeito.Text == "Serviço feito" || txtSituacao.Text == "Situação do aparelho")
            {
                MessageBox.Show("PREENCHA OS CAMPOS CORRETAMENTE!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            Decimal lucro = CalcularLucro();

            int novaID = BancoGlobal.listaCadastrosServicosEstrutura.Count;

            BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(novaID + 1,
                BuscarIDCliente(cmbCliente.Text), txtAparelho.Text, txtDefeito.Text, txtSenha.Text, txtSituacao.Text,
                txtAcessorios.Text,
                DateTime.Now,
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
            ResetarValoresTextBox();
            gdv_CadastroServicos.ClearSelection();
        }

        private void btnBuscarServicoEmAndamento_Click(object sender, EventArgs e)
        {
            BuscarServicoAndamento(txtBuscarServicoAparelho.Text);
            gdv_CadastroServicos.ClearSelection();
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
            SetarValoresTextBox();
        }

        private void form_CadastrarServicos_Load(object sender, EventArgs e)
        {
            gdv_CadastroServicos.ClearSelection();
        }

        private void DeletarCadastroServiço()
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

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletarCadastroServiço();
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

        private void ConcluirServico()
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicos.SelectedRows.Count;
            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR,DELETAR DADOS OU PARA CONCLUIR O SERVIÇO!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = CriarDataTableServicos();
                AdicionarLinhaGridView(dt);

                foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
                {
                    if (servico.sv_id == Convert.ToInt32(gdv_CadastroServicos.SelectedCells[1].Value.ToString()))
                    {
                        if (MessageBox.Show("TEM CERTEZA? ", "ATENÇÃO", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            form_CalcularDataGarantia form = new form_CalcularDataGarantia(this);
                            form.lblIDCliente.Text = gdv_CadastroServicos.SelectedCells[2].Value.ToString();
                            form.lblIDservico.Text = gdv_CadastroServicos.SelectedCells[1].Value.ToString();

                            form.ShowDialog();
                            MessageBox.Show("Serviço concluido com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            servico.sv_status = 0;
                            PreencherTabelaComDadosServicosAndamentos();
                            break;
                        }
                    }
                }
            }
        }

        private void contextConcluirServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConcluirServico();
        }

        private void SetarValoresTextBoxAparelhoEventoEnter()
        {
            if (txtAparelho.Text == "Modelo do aparelho")
            {
                txtAparelho.Text = "";
            }
        }

        private void txtAparelho_Enter(object sender, EventArgs e)
        {
            SetarValoresTextBoxAparelhoEventoEnter();
        }

        private void txtAparelho_Leave(object sender, EventArgs e)
        {
            if (txtAparelho.Text == "")
            {
                txtAparelho.Text = "Modelo do aparelho";
            }
        }

        private void SetarValoresTextBoxAparelhoEventoLeave()
        {
            if (txtDefeito.Text == "Digite o defeito")
            {
                txtDefeito.Text = "";
            }
        }

        private void txtDefeito_Enter(object sender, EventArgs e)
        {
            SetarValoresTextBoxAparelhoEventoLeave();
        }

        private void txtDefeito_Leave(object sender, EventArgs e)
        {
            SetarValoresTextBoxDefeitoEventoLeave();
        }

        private void SetarValoresTextBoxDefeitoEventoLeave()
        {
            if (txtDefeito.Text == "")
            {
                txtDefeito.Text = "Digite o defeito";
            }
        }

        private void SetarValoresTextBoxAcessoriosEventoEnter()
        {
            if (txtAcessorios.Text == "Acessórios do cliente")
            {
                txtAcessorios.Text = "";
            }
        }


        private void txtAcessorios_Enter(object sender, EventArgs e)
        {
            SetarValoresTextBoxAcessoriosEventoEnter();
        }

        private void SetarValoresTextBoxAcessoriosEventoLeave()
        {
            if (txtAcessorios.Text == "")
            {
                txtAcessorios.Text = "Acessórios do cliente";
            }
        }

        private void txtAcessorios_Leave(object sender, EventArgs e)
        {
            SetarValoresTextBoxAcessoriosEventoLeave();
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha do aparelho")
            {
                txtSenha.Text = "";
            }
        }

        private void SetarValoresTextBoxSenhaEventoLeave()
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Senha do aparelho";
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
          SetarValoresTextBoxSenhaEventoLeave();   
        }

        private void SetarValoresTextBoxSenhaEventoEnter()
        {
            if (txtServicoFeito.Text == "Serviço feito")
            {
                txtServicoFeito.Text = "";
            }
        }

        private void txtServicoFeito_Enter(object sender, EventArgs e)
        {
           SetarValoresTextBoxSenhaEventoEnter();
        }

        private void txtServicoFeito_Leave(object sender, EventArgs e)
        {
            SetarTextBoxServicoFeitoEventoLeave();
        }

        private void SetarTextBoxServicoFeitoEventoLeave()
        {
            if (txtServicoFeito.Text == "")
            {
                txtServicoFeito.Text = "Serviço feito";
            }
        }

        private void txtSituacao_Enter(object sender, EventArgs e)
        {
            SetarTextBoxSituacaoEventoEnter();
        }

        private void SetarTextBoxSituacaoEventoEnter()
        {
            if (txtSituacao.Text == "Situação do aparelho")
            {
                txtSituacao.Text = "";
            }
        }


        private void txtSituacao_Leave(object sender, EventArgs e)
        {
            SetarTextBoxSituacaoEventoLeave();
        }

        private void SetarTextBoxSituacaoEventoLeave()
        {
            if (txtSituacao.Text == "")
            {
                txtSituacao.Text = "Situação do aparelho";
            }
        }

        private void txtBuscarServicoAparelho_Enter(object sender, EventArgs e)
        {
            SetarTextBoxServicoEventoEnter();
        }

        private void SetarTextBoxServicoEventoEnter()
        {
            if (txtBuscarServicoAparelho.Text == "Busca feita por aparelho")
            {
                txtBuscarServicoAparelho.Text = "";
            }
        }

        private void SetarTextBoxServicoEventoLeave ()
        {
            if (txtBuscarServicoAparelho.Text == "")
            {
                txtBuscarServicoAparelho.Text = "Busca feita por aparelho";
            }
        }

        private void txtBuscarServicoAparelho_Leave(object sender, EventArgs e)
        {
           SetarTextBoxServicoEventoLeave();
        }
    }
}