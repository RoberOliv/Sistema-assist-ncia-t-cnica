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
    public partial class form_MaioresPrejuizos : Form
    {
        private List<CadastroServicoEstrutura> maioresPrejuizos;
        public form_MaioresPrejuizos()
        {
            InitializeComponent();
            InicializarBancoGlobal();
            BuscarMaioresPrejuizos();
        }

        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
            BancoGlobal.IniciarTabelaCadastroClientes();
        }

        private void CriarDataTableMaioresPrejuizos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nome Cliente");
            dt.Columns.Add("Maiores Prejuizos");

            foreach (CadastroServicoEstrutura servico in maioresPrejuizos)
            {
                if (servico.sv_lucroServico  < 0)
                {
                    dt.Rows.Add(BuscarNomeCliente(servico.sv_fk_cl_idCliente),
                        servico.sv_lucroServico);
                }

            }

            gdv_ExibicaoPrejuizos.DataSource = dt;
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


        private void BuscarMaioresPrejuizos()
        {
            maioresPrejuizos = BancoGlobal.listaCadastrosServicosEstrutura
                .Where(clienteWhere => clienteWhere.sv_status == 0)
                .OrderBy(ordemLucroServico => ordemLucroServico.sv_lucroServico).ToList();



            foreach (var cliente in maioresPrejuizos)
            {
                PegarMaioresPrejuizos(cliente.sv_lucroServico);
            }
        }

        private decimal PegarMaioresPrejuizos(decimal _idCliente)
        {
            decimal maioresLucrosServicos = 0;

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_fk_cl_idCliente == _idCliente)
                {
                    return servico.sv_lucroServico;
                }
            }

            return maioresLucrosServicos;
        }

        private void btnBuscarMaioresPrejuizos_Click(object sender, EventArgs e)
        {
            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (dtpDataFim.Value > dtpDataInicio.Value)
                {
                    CriarDataTableMaioresPrejuizos();
                }
            }
        }
    }
}

