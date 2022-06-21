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
using Sistema_OS___Assistência_Técnica.Properties;
using Utilities.BunifuCheckBox.Transitions;

namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    public partial class form_CadastrarClientes : Form
    {
        private form_ModuloServicoAndamento formModuloServicoAndamento;

        public form_CadastrarClientes(form_ModuloServicoAndamento _formModuloServicoAndamento)
        {
            InitializeComponent();
            InicializarBancoGlobal();
            PreencherTabelaComDadosClientes();
            formModuloServicoAndamento = _formModuloServicoAndamento;

        }

        private void InicializarBancoGlobal()
        {
            BancoGlobal.IniciarTabelaCadastroClientes();
            BancoGlobal.IniciarTabelaCadastroServicos();
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
            formModuloServicoAndamento.pctHome.Image = Resources.icons8_mais_2_matemática_100__1_;
            formModuloServicoAndamento.lblHome.Text = "CADASTRAR";
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
                    txtNomeCliente.Text, txtNumeroTelefone.Text, txtDocumentoCPF.Text, txtTelefoneRecado.Text, true));

                ClearTextBox();

                MessageBox.Show("Serviço cadastrado com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
        }

        private void BuscarClienteNomeEDocumento()
        {

            formModuloServicoAndamento.pctHome.Image = Resources.icons8_pesquisar_100__1_;
            formModuloServicoAndamento.lblHome.Text = "BUSCAR CLIENTES";

            if (txtBuscarClienteNomeEDocumento.Text.Length == 0)
            {
                MessageBox.Show("PREENCHA CAMPO DE BUSCA", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (chkNomeCliente.Checked == false && chkDocumentoCPF.Checked == false)
            {
                MessageBox.Show("MARQUE PELO MENOS UM TIPO DE BUSCA", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {

                if (chkNomeCliente.Checked == true)
                {

                    DataTable dt = CriarDataTableClientes();
                    foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
                    {
                        if (cliente.cl_nome == txtBuscarClienteNomeEDocumento.Text)
                        {
                            dt.Rows.Add(cliente.cl_id, cliente.cl_nome, cliente.cl_cpf, cliente.cl_telefone,
                                cliente.cl_telefone_recado);

                            MessageBox.Show("CLIENTE ENCONTRADO COM SUCESSO", "BUSCA", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearTextBox();
                        }
                    }

                    gdv_CadastroClientes.DataSource = dt;
                }


                else if (chkDocumentoCPF.Checked == true)
                {
                    DataTable dt = CriarDataTableClientes();
                    foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
                    {
                        if (cliente.cl_cpf == txtBuscarClienteNomeEDocumento.Text)
                        {
                            dt.Rows.Add(cliente.cl_id, cliente.cl_nome, cliente.cl_cpf, cliente.cl_telefone,
                                cliente.cl_telefone_recado);

                            MessageBox.Show("CPF ENCONTRADO COM SUCESSO", "BUSCA", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearTextBox();
                            break;
                        }
                    }

                    gdv_CadastroClientes.DataSource = dt;
                }
            }
        }

        private void btnBuscarClienteNomeEDocumento_Click(object sender, EventArgs e)
        {
            BuscarClienteNomeEDocumento();
        }

        private void chkNomeCliente_Click(object sender, EventArgs e)
        {

            if (chkNomeCliente.Checked == true)
            {
                chkDocumentoCPF.Checked = false;

            }
        }


        private void chkDocumentoCPF_Click(object sender, EventArgs e)
        {

            if (chkDocumentoCPF.Checked == true)
            {
                chkNomeCliente.Checked = false;
            }
        }

        private void txtBuscarClienteNomeEDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarClienteNomeEDocumento.Text == "")
            {
                PreencherTabelaComDadosClientes();
            }
        }

        private void SetarValoresTextBox()
        {
            form_EditarCadastrosClientes form = new form_EditarCadastrosClientes(this);

            form.lblAlteracaoClientes.Text = gdv_CadastroClientes.SelectedCells[0].Value.ToString();
            form.txtNomeCliente.Text = gdv_CadastroClientes.SelectedCells[1].Value.ToString();
            form.txtDocumentoCPF.Text = gdv_CadastroClientes.SelectedCells[3].Value.ToString();
            form.txtNumeroTelefone.Text = gdv_CadastroClientes.SelectedCells[2].Value.ToString();
            form.txtTelefoneRecado.Text = gdv_CadastroClientes.SelectedCells[4].Value.ToString();

            form.ShowDialog();
        }

        private void contextEditarCliente_Click(object sender, EventArgs e)
        {
            SetarValoresTextBox();
        }

        private bool VerificarExistenciaCliente(int _idCliente)
        {
            foreach (CadastroServicoEstrutura cliente in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (cliente.sv_fk_cl_idCliente == _idCliente)
                {
                    return true;

                }
            }

            return false;
        }

        private void contextDeletarCliente_Click(object sender, EventArgs e)
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroClientes.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (VerificarExistenciaCliente(Convert.ToInt32(gdv_CadastroClientes.SelectedCells[0].Value.ToString())) ==
                true)
            {
                MessageBox.Show("ESTE CLIENTE POSSUI SERVIÇO EM ANDAMENTO OU CONCLUIDO!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = CriarDataTableClientes();
                AdicionarLinhaGridView(dt);

                foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
                {

                    if (cliente.cl_id == Convert.ToInt32(gdv_CadastroClientes.SelectedCells[0].Value.ToString()))
                    {
                        if (MessageBox.Show("TEM CERTEZA? ", "ATENÇÃO", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            BancoGlobal.listaCadastrosClientesEstrutura.Remove(cliente);
                            PreencherTabelaComDadosClientes();
                            break;

                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        }

        private void txtNumeroTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidarDigitos.ApenasNumerosBackspace(e);

            TextBox Tel = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Tel.SelectionStart = Tel.Text.Length + 1;

                if (Tel.Text.Length == 0 || Tel.Text.Length == 1)
                    Tel.Text += "(";
                else if (Tel.Text.Length == 3)
                    Tel.Text += ")";
                else if (Tel.Text.Length == 8)
                    Tel.Text += "-";
                Tel.SelectionStart = Tel.Text.Length + 1;
            }
        }

        private void txtTelefoneRecado_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidarDigitos.ApenasNumerosBackspace(e);

            TextBox Tel = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Tel.SelectionStart = Tel.Text.Length + 1;

                if (Tel.Text.Length == 0 || Tel.Text.Length == 1)
                    Tel.Text += "(";
                else if (Tel.Text.Length == 3)
                    Tel.Text += ")";
                else if (Tel.Text.Length == 8)
                    Tel.Text += "-";
                Tel.SelectionStart = Tel.Text.Length + 1;
            }
        }

        private void txtDocumentoCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);

            TextBox CPF = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                CPF.SelectionStart = CPF.Text.Length + 1;

                if (CPF.Text.Length == 3 || CPF.Text.Length == 7)
                    CPF.Text += ".";
                else if (CPF.Text.Length == 11)
                    CPF.Text += "-";
                CPF.SelectionStart = CPF.Text.Length + 1;
            }
        }

        private void txtDocumentoCPF_Enter(object sender, EventArgs e)
        {
            if (txtDocumentoCPF.Text == "Digite o CPF")
            {
                txtDocumentoCPF.Text = "";
            }
        }

        private void txtDocumentoCPF_Leave(object sender, EventArgs e)
        {
            if (txtDocumentoCPF.Text == "")
            {
                txtDocumentoCPF.Text = "Digite o CPF";
            }
        }

        private void txtBuscarClienteNomeEDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chkDocumentoCPF.Checked == true)
            {

                txtBuscarClienteNomeEDocumento.MaxLength = 14;
                ValidarDigitos.ApenasNumerosBackspace(e);

                TextBox CPF = sender as TextBox;
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    CPF.SelectionStart = CPF.Text.Length + 1;

                    if (CPF.Text.Length == 3 || CPF.Text.Length == 7)
                        CPF.Text += ".";
                    else if (CPF.Text.Length == 11)
                        CPF.Text += "-";
                    CPF.SelectionStart = CPF.Text.Length + 1;
                }
            }

            if (chkNomeCliente.Checked == true)
            {
                txtBuscarClienteNomeEDocumento.MaxLength = 25;
                ValidarDigitos.ApenasLetrasBackspace(e);
            }
        }

        private void txtNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasLetrasBackspace(e);
        }
    }
}






