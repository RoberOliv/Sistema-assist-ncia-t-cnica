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
    public partial class form_ClientesComMaisServicos : Form
    {


        private form_ModuloServicoAndamento formModuloServicoAndamento;
        private List<IGrouping<int, CadastroServicoEstrutura>> rankingClienteMaisServicos;
        private form_Financeiro formTelasDeLucro;
        public form_ClientesComMaisServicos(form_ModuloServicoAndamento _formModuloServicoAndamento)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            CriarDataTableLucrosPrejuizos();
            formModuloServicoAndamento = _formModuloServicoAndamento;
        }

        public form_ClientesComMaisServicos(form_Financeiro _formTelasDeLucro)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            BuscarRankingMaisServicos();
            CriarDataTableLucrosPrejuizos();
            formTelasDeLucro = _formTelasDeLucro;

        }

        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
            BancoGlobal.IniciarTabelaCadastroClientes();
        }

        private void CriarDataTableLucrosPrejuizos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nome Cliente");
            dt.Columns.Add("Qtd. Serviços");

            foreach (var servico in rankingClienteMaisServicos)
            {
                int qtdServicosClientes = PegarMaioresQtdServicoCliente(servico.Key);
                dt.Rows.Add(BuscarNomeCliente(servico.Key), qtdServicosClientes);
            }

            gdv_ExibicaoLucrosPrejuizos.DataSource = dt;
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


        private void BuscarRankingMaisServicos()
        {
            rankingClienteMaisServicos = BancoGlobal.listaCadastrosServicosEstrutura
                .Where(clienteWhere => clienteWhere.sv_status == 0)
                .GroupBy(cliente => cliente.sv_fk_cl_idCliente)
                .OrderByDescending(clienteOrdem => clienteOrdem.Count()).ToList();




            foreach (var cliente in rankingClienteMaisServicos)
            {
                int qtdServicosClientes = PegarMaioresQtdServicoCliente(cliente.Key);
            }
        }

        private int PegarMaioresQtdServicoCliente(int _idCliente)
        {
            int qtdServicosClientes = 0;

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_fk_cl_idCliente == _idCliente)
                {
                    qtdServicosClientes++;
                }
            }

            return qtdServicosClientes;
        }

    }

}


