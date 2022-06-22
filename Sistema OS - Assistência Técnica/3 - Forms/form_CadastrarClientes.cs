using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_OS___Assistência_Técnica._1___BancoGlobal;
using Sistema_OS___Assistência_Técnica._2___Classes;

namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    public partial class form_CadastrarClientes : Form
    {
        public form_CadastrarClientes()
        {
            InitializeComponent();
            InicializarBancoGlobal();
            PreencherTabelaComDadosClientes();
        }

        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroClientes();
        }

        private DataTable CriarDataTableClientes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome Cliente");
            dt.Columns.Add("Telefone");
            dt.Columns.Add("Documento (CPF)");
            dt.Columns.Add("Telefone para recado");

            return dt;
        }

        private void AdicionarLinhaGridView(DataTable dt)
        {
            foreach (CadastroClienteEstrutura cadastro in BancoGlobal.listaCadastrosClientesEstrutura)
            {
                dt.Rows.Add(cadastro.cl_id, cadastro.cl_nome, cadastro.cl_telefone, cadastro.cl_cpf,
                    cadastro.cl_telefone_recado);
            }
        }
        public void PreencherTabelaComDadosClientes()
        {
            DataTable dt = CriarDataTableClientes();
            AdicionarLinhaGridView(dt);

            gdv_CadastroClientes.DataSource = dt;

        }

        private void ClearTextBox()
        {
            txtNomeCliente.Clear();
            txtDocumentoCPF.Clear();
            txtTelefoneRecado.Clear();
            txtNumeroTelefone.Clear();
        }

        private void btnCadastrarClientes_Click(object sender, EventArgs e)
        {

            CadastrarClientes();
            PreencherTabelaComDadosClientes();
            gdv_CadastroClientes.ClearSelection();

        }

        private void CadastrarClientes()
        {
            if (txtNomeCliente.Text.Length <= 0 || txtDocumentoCPF.Text.Length <= 0)
            {
                MessageBox.Show("PREENCHA OS CAMPOS OBRIGATÓRIOS!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {

                int novaID = BancoGlobal.listaCadastrosClientesEstrutura.Count;


                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(novaID + 1,
                    txtNomeCliente.Text, txtNumeroTelefone.Text, txtDocumentoCPF.Text, txtTelefoneRecado.Text));

                ClearTextBox();

                MessageBox.Show("Serviço cadastrado com Sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
