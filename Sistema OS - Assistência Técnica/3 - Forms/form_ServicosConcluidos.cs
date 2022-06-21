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
    public partial class form_ServicosConcluidos : Form
    {



        public form_ServicosConcluidos()
        {
            InitializeComponent();
            InicilizarBancoGlobal();
            PreencherTabelaComDadosServicosConcluidos();

        }


        private void InicilizarBancoGlobal()
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

            form_EditarServicos form = new form_EditarServicos(this);
            form.lbID.Text = gdv_CadastroServicosConcluidos.SelectedCells[1].Value.ToString();
            form.txtAparelho.Text = gdv_CadastroServicosConcluidos.SelectedCells[3].Value.ToString();
            form.txtDefeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[4].Value.ToString();
            form.txtSenha.Text = gdv_CadastroServicosConcluidos.SelectedCells[5].Value.ToString();
            form.txtSituacao.Text = gdv_CadastroServicosConcluidos.SelectedCells[6].Value.ToString();
            form.txtAcessorios.Text = gdv_CadastroServicosConcluidos.SelectedCells[7].Value.ToString();
            //form. = gdv_CadastroServicosConcluidos.SelectedCells[0].Value.ToString();
            form.txtvalorServico.Text = gdv_CadastroServicosConcluidos.SelectedCells[8].Value.ToString();
            form.txtvalorPeca.Text = gdv_CadastroServicosConcluidos.SelectedCells[9].Value.ToString();
            form.txtServicoFeito.Text = gdv_CadastroServicosConcluidos.SelectedCells[11].Value.ToString();

            form.ShowDialog();
        }


        private void AdicionarLinhaGridView(DataTable dt)
        {

            foreach (CadastroServicoEstrutura cadastro in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (cadastro.sv_status == 0)
                {
                    dt.Rows.Add(cadastro.sv_dataCadastro.ToShortDateString(), cadastro.sv_id, BuscarNomeCliente(cadastro.sv_fk_cl_idCliente),
                        cadastro.sv_aparelho,
                        cadastro.sv_defeito, cadastro.sv_senha,
                        cadastro.sv_situacao, cadastro.sv_acessorios, cadastro.sv_valorServico, cadastro.sv_valorPeca,
                        cadastro.sv_lucroServico.ToString("C"), cadastro.sv_servicoFeito, cadastro.sv_dataConclusao.ToShortDateString(),
                        (cadastro.sv_status == 0) ? "Em Andamento" : "Concluido");
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



        public void BuscarServico()
        {


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

                    }
                }
                gdv_CadastroServicosConcluidos.DataSource = dt;
            }
        }

        private void btnBuscarServicos_Click(object sender, EventArgs e)
        {
            BuscarServico();
        }

        private void contextEditarServico_Click(object sender, EventArgs e)
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroServicosConcluidos.SelectedRows.Count;


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

        private void contextVerGarantiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_GarantiaServicosConcluidos form = new form_GarantiaServicosConcluidos();


            form.ShowDialog();
        }

        private void txtBuscarServicoAparelho_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarServicoAparelho.Text == "")
            {
                PreencherTabelaComDadosServicosConcluidos();
            }
        }

        private void contextNãoConcluidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = CriarDataTableServicos();
            AdicionarLinhaGridView(dt);

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {

                if (servico.sv_id == Convert.ToInt32(gdv_CadastroServicosConcluidos.SelectedCells[1].Value.ToString()))
                {
                    if (servico.sv_status == 0)
                    {
                        if (MessageBox.Show("TEM CERTEZA? ", "ATENÇÃO", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            servico.sv_status = 1;
                            PreencherTabelaComDadosServicosConcluidos();
                            break;

                        }
                    }
                }
            }
        }
    }
}
