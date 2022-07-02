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
    public partial class form_ServicosConcluidos : Form
    {
        private form_ModuloServicoAndamento formModuloServicoAndamento;
        private form_GarantiaServicosConcluidos formGarantiaServicosConcluidos;

        public form_ServicosConcluidos(form_ModuloServicoAndamento _formModuloServicoAndamento)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            PreencherTabelaComDadosServicosConcluidos();
            formModuloServicoAndamento = _formModuloServicoAndamento;

        }



        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
            BancoGlobal.IniciarTabelaCadastroClientes();
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

        public void PreencherTabelaComDadosServicosConcluidos()
        {
            DataTable dt = CriarDataTableServicos();
            AdicionarLinhaGridView(dt);

            gdv_CadastroServicosConcluidos.DataSource = dt;
        }
        public void SetarValoresTextBox()
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicosConcluidos.SelectedRows.Count;


            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                form_EditarServicos form = new form_EditarServicos(this);
                form.lbliDServico.Text = gdv_CadastroServicosConcluidos.SelectedCells[1].Value.ToString();
                form.dtpDataAtualCadastro.Text = gdv_CadastroServicosConcluidos.SelectedCells[0].Value.ToString();
                form.txtAparelho.Text = gdv_CadastroServicosConcluidos.SelectedCells[3].Value.ToString();
                form.txtDefeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[4].Value.ToString();
                form.txtSenha.Text = gdv_CadastroServicosConcluidos.SelectedCells[5].Value.ToString();
                form.txtSituacao.Text = gdv_CadastroServicosConcluidos.SelectedCells[6].Value.ToString();
                form.txtAcessorios.Text = gdv_CadastroServicosConcluidos.SelectedCells[7].Value.ToString();
                form.txtvalorServico.Text = gdv_CadastroServicosConcluidos.SelectedCells[8].Value.ToString();
                form.txtvalorPeca.Text = gdv_CadastroServicosConcluidos.SelectedCells[9].Value.ToString();
                form.txtServicoFeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[11].Value.ToString();
                form.ShowDialog();

            }

        }

        private void AdicionarLinhaGridView(DataTable dt)
        {

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_status == 0)
                {
                    dt.Rows.Add(servico.sv_dataCadastro.ToShortDateString(), servico.sv_id,
                        BuscarNomeCliente(servico.sv_fk_cl_idCliente),
                        servico.sv_aparelho,
                        servico.sv_defeito, servico.sv_senha,
                        servico.sv_situacao, servico.sv_acessorios, servico.sv_valorServico, servico.sv_valorPeca,
                        servico.sv_lucroServico.ToString("C"), servico.sv_servicoFeito,
                        servico.sv_dataConclusao = DateTime.Now.Date,
                            (servico.sv_status == 1) ? "Em Andamento" : "Concluido");
                }
            }
        }

        private DataTable CriarDataTableServicos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Data de Cadastro"); ;
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

        public void BuscarServicoPorAparelho(string _textoDigitado)
        {


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
                    if (servico.sv_status == 0)
                    {
                        if (servico.sv_aparelho.ToLower().Contains(_textoDigitado.ToLower()))
                        {

                            dt.Rows.Add(servico.sv_dataCadastro.ToShortDateString(), servico.sv_id, BuscarNomeCliente(servico.sv_fk_cl_idCliente),
                                servico.sv_aparelho,
                                servico.sv_defeito, servico.sv_senha,
                                servico.sv_situacao, servico.sv_acessorios, servico.sv_valorServico, servico.sv_valorPeca,
                                servico.sv_lucroServico.ToString("C"), servico.sv_servicoFeito, servico.sv_dataConclusao.ToString(),
                                (servico.sv_status == 1) ? "Em Andamento" : "Concluido");
                        }
                    }
                }

                gdv_CadastroServicosConcluidos.DataSource = dt;
            }
        }

        private void btnBuscarServicos_Click(object sender, EventArgs e)
        {
            formModuloServicoAndamento.pctHome.Image = Resources.icons8_pesquisar_100__1_;
            formModuloServicoAndamento.lblHome.Text = "BUSCAR SERVIÇOS";
            BuscarServicoPorAparelho(txtBuscarServicoAparelho.Text);
        }

        private void contextEditarServico_Click(object sender, EventArgs e)
        {
            SetarValoresTextBox();
        }

        private void contextVerGarantiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SetarValoresTextBoxFormVerGarantia();

        }

        private void txtBuscarServicoAparelho_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarServicoAparelho.Text == "")
            {
                PreencherTabelaComDadosServicosConcluidos();
            }
        }

        private void SetarValoresTextBoxFormGarantia()
        {

            int qtdDeLinhasSelecionadas = gdv_CadastroServicosConcluidos.SelectedRows.Count;


            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA SERVIÇO NÃO CONCLUIDO,VER GARANTIA OU EDITAR !", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                form_GarantiaServicosConcluidos form = new form_GarantiaServicosConcluidos(this);
                form.txtDataCadastroServico.Text = gdv_CadastroServicosConcluidos.SelectedCells[0].Value.ToString();
                form.txtNomeCliente.Text = gdv_CadastroServicosConcluidos.SelectedCells[2].Value.ToString();
                form.txtAparelho.Text = gdv_CadastroServicosConcluidos.SelectedCells[3].Value.ToString();
                form.txtDefeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[4].Value.ToString();
                form.ShowDialog();

            }


        }

        private void SetarValoresTextBoxFormVerGarantia()
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicosConcluidos.SelectedRows.Count;


            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                form_VerGarantia form = new form_VerGarantia(this);
                form.lblID.Text = gdv_CadastroServicosConcluidos.SelectedCells[1].Value.ToString();
                form.txtDataEmissaoGarantia.Text = gdv_CadastroServicosConcluidos.SelectedCells[12].Value.ToString();
                form.txtNomeCliente.Text = gdv_CadastroServicosConcluidos.SelectedCells[2].Value.ToString();
                form.txtServicoFeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[11].Value.ToString();
                form.txtAparelho.Text = gdv_CadastroServicosConcluidos.SelectedCells[3].Value.ToString();
                form.ShowDialog();
            }
        }

        private void contextNãoConcluidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetarValoresTextBoxFormGarantia();
        }

        private void txtBuscarServicoAparelho_Enter(object sender, EventArgs e)
        {
            if (txtBuscarServicoAparelho.Text == "Busca feita por aparelho")
            {
                txtBuscarServicoAparelho.Text = "";
            }
        }

        private void txtBuscarServicoAparelho_Leave(object sender, EventArgs e)
        {
            if (txtBuscarServicoAparelho.Text == "")
            {
                txtBuscarServicoAparelho.Text = "Busca feita por aparelho";
            }
        }

        private void form_ServicosConcluidos_Load(object sender, EventArgs e)
        {
            gdv_CadastroServicosConcluidos.ClearSelection();
        }

    }
}

