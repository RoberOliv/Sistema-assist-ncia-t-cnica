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
    public partial class form_GarantiaServicosConcluidos : Form
    {
        private form_ServicosConcluidos formServicosConcluidos;

        public form_GarantiaServicosConcluidos(form_ServicosConcluidos _formServicosConcluidos)
        {
            InitializeComponent();
            formServicosConcluidos = _formServicosConcluidos;
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
                        servico.sv_dataConclusao.ToShortDateString(),
                        (servico.sv_status == 1) ? "Em Andamento" : "Concluido");
                }
            }
        }

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

            formServicosConcluidos.gdv_CadastroServicosConcluidos.DataSource = dt;
        }

        private void btnNaoDesfazerServico_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesfazerServico_Click(object sender, EventArgs e)
        {
            ServicoNaoConcluido();
            RemoverGarantia();
        }

        private void ServicoNaoConcluido()
        {
            int qtdDeLinhasSelecionadas = formServicosConcluidos.gdv_CadastroServicosConcluidos.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = CriarDataTableServicos();
                AdicionarLinhaGridView(dt);

                int idServico = 0;

                foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
                {
                    if (servico.sv_id == Convert.ToInt32(formServicosConcluidos.gdv_CadastroServicosConcluidos
                            .SelectedCells[1].Value.ToString()))
                    {
                        idServico = servico.sv_id;
                        servico.sv_status = 1;
                        PreencherTabelaComDadosServicosConcluidos();
                        break;
                    }
                }

                this.Close();
            }
        }

        private void RemoverGarantia()
        {
            int idServico = 0;
            foreach (GarantiaEstrutura garantia in BancoGlobal.listaGarantiasEstrutura)
            {
                if (garantia.gar_fk_idServico == idServico)
                {
                    BancoGlobal.listaGarantiasEstrutura.Remove(garantia);
                    PreencherTabelaComDadosServicosConcluidos();
                    break;
                }
            }
        }
    }
}