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
    public partial class form_LucrosGastos : Form
    {

        private List<CadastroServicoEstrutura> maioresLucrosGastos;


        public form_LucrosGastos()
        {
            InitializeComponent();
            InicializarBancoGlobal();
            BuscarMaioresLucrosGastos();

        }

        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroServicos();
            BancoGlobal.IniciarTabelaCadastroClientes();
        }


        private void CriarDataTableLucrosGastos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nome Cliente");
            dt.Columns.Add("Maiores Gastos");
            dt.Columns.Add("Maiores Lucros");

            foreach (CadastroServicoEstrutura servico in maioresLucrosGastos)
            {
                if (servico.sv_lucroServico > 0)
                {
                    dt.Rows.Add(BuscarNomeCliente(servico.sv_fk_cl_idCliente), servico.sv_valorPeca,
                        servico.sv_lucroServico);
                }

                
            }

            gdv_ExibicaoLucrosGastos.DataSource = dt;
        }

        private decimal CalcularValoresGastos()
        {
            decimal total = 0;
            

            for (int i = 0; i < gdv_ExibicaoLucrosGastos.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(gdv_ExibicaoLucrosGastos.Rows[i].Cells[1].Value);
            }
            return total;
        }

        private decimal CalcularValoresLucro()
        {
            decimal total = 0;


            for (int i = 0; i < gdv_ExibicaoLucrosGastos.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(gdv_ExibicaoLucrosGastos.Rows[i].Cells[2].Value);
            }
            return total;
        }

        private void CalculaValor()
        {
            if (gdv_ExibicaoLucrosGastos.Rows.Count > 0)
            {
                lblGastos.Text = CalcularValoresGastos().ToString("N");
                lblLucro.Text = CalcularValoresLucro().ToString("N");

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


        private void BuscarMaioresLucrosGastos()
        {
            maioresLucrosGastos = BancoGlobal.listaCadastrosServicosEstrutura
                .Where(clienteWhere => clienteWhere.sv_status == 0)
                .OrderByDescending(ordemLucroServico => ordemLucroServico.sv_lucroServico).ToList();



            foreach (var cliente in maioresLucrosGastos)
            {
                PegarMaioresLucrosGastos(cliente.sv_lucroServico);
            }
        }

        private decimal PegarMaioresLucrosGastos(decimal _idCliente)
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

        private void btnBuscarLucroGastos_Click_1(object sender, EventArgs e)
        {

            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (dtpDataFim.Value > dtpDataInicio.Value)
                {
                    CriarDataTableLucrosGastos();
                    CalculaValor();


                }
            }
        }
    }
}
