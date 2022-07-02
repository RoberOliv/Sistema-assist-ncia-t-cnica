using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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

            foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
            {
                dt.Rows.Add(cliente.cl_id, cliente.cl_nome, cliente.cl_telefone, cliente.cl_cpf,
                    cliente.cl_telefone_recado);
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
            if (txtNomeCliente.Text == "Nome do cliente" || txtDocumentoCPF.Text == "Digite o CPF")
            {
                MessageBox.Show("FAVOR PREENCHER OS CAMPOS DE NOME E CPF!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (txtNumeroTelefone.Text == "Número" || txtTelefoneRecado.Text == "Número")
            {
                txtNumeroTelefone.Text = "";
                txtTelefoneRecado.Text = "";
            }

            if (txtNomeCliente.Text.Length <= 2 || txtDocumentoCPF.Text.Length < 14 || txtNumeroTelefone.Text.Length < 13 || txtTelefoneRecado.Text.Length < 13)
            {
                MessageBox.Show("EXISTEM CAMPOS  VAZIOS OU INCOMPLETOS!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            int novaID = BancoGlobal.listaCadastrosClientesEstrutura.Count;

            BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(novaID + 1,
                txtNomeCliente.Text, txtNumeroTelefone.Text, txtDocumentoCPF.Text, txtTelefoneRecado.Text));

            MessageBox.Show("Cliente cadastrado com Sucesso!", "SUCESSO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearTextBox();
            ResetarTextBox();

        }

        private void ResetarTextBox()
        {
            txtNomeCliente.Text = "Nome do cliente";
            txtDocumentoCPF.Text = "Digite o CPF";
            txtNumeroTelefone.Text = "Número";
            txtTelefoneRecado.Text = "Número";
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
                        if (cliente.cl_nome.ToLower().Contains(txtBuscarClienteNomeEDocumento.Text.ToLower()))
                        {
                            dt.Rows.Add(cliente.cl_id, cliente.cl_nome, cliente.cl_cpf, cliente.cl_telefone,
                                cliente.cl_telefone_recado);

                            MessageBox.Show("CLIENTE ENCONTRADO COM SUCESSO", "BUSCA", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearTextBox();
                            ResetarTextBox();
                            break;
                        }

                    }
                    gdv_CadastroClientes.DataSource = dt;
                }
                else if (chkDocumentoCPF.Checked == true)
                {
                    DataTable dt = CriarDataTableClientes();
                    foreach (CadastroClienteEstrutura cliente in BancoGlobal.listaCadastrosClientesEstrutura)
                    {
                        if (cliente.cl_cpf.ToLower().Contains(txtBuscarClienteNomeEDocumento.Text.ToLower()))
                        {
                            dt.Rows.Add(cliente.cl_id, cliente.cl_nome, cliente.cl_cpf, cliente.cl_telefone,
                                cliente.cl_telefone_recado);

                            MessageBox.Show("CPF ENCONTRADO COM SUCESSO", "BUSCA", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearTextBox();
                            ResetarTextBox();
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
            gdv_CadastroClientes.ClearSelection();
        }

        private void chkNomeCliente_Click(object sender, EventArgs e)
        {

            if (chkNomeCliente.Checked == false && chkDocumentoCPF.Checked == false)
            {
                txtBuscarClienteNomeEDocumento.Text = "Campo de busca";
            }
            else if (chkNomeCliente.Checked == true)
            {
                txtBuscarClienteNomeEDocumento.Text = "Buscar nome do cliente";
                chkDocumentoCPF.Checked = false;
            }
        }

        private void chkDocumentoCPF_Click(object sender, EventArgs e)
        {
            if (chkNomeCliente.Checked == false && chkDocumentoCPF.Checked == false)
            {
                txtBuscarClienteNomeEDocumento.Text = "Campo de busca";
            }

            if (chkDocumentoCPF.Checked == true)
            {
                txtBuscarClienteNomeEDocumento.Text = "Buscar CPF";
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
            int qtdDeLinhasSelecionadas = gdv_CadastroClientes.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                form_EditarCadastrosClientes form = new form_EditarCadastrosClientes(this);

                form.lblAlteracaoClientes.Text = gdv_CadastroClientes.SelectedCells[0].Value.ToString();
                form.txtNomeCliente.Text = gdv_CadastroClientes.SelectedCells[1].Value.ToString();
                form.txtDocumentoCPF.Text = gdv_CadastroClientes.SelectedCells[3].Value.ToString();
                form.txtNumeroTelefone.Text = gdv_CadastroClientes.SelectedCells[2].Value.ToString();
                form.txtTelefoneRecado.Text = gdv_CadastroClientes.SelectedCells[4].Value.ToString();

                form.ShowDialog();
            }
        }

        private void contextEditarCliente_Click(object sender, EventArgs e)
        {
            SetarValoresTextBox();
        }

        private bool VerificarClientePossuiServicos(int _idCliente)
        {
            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_fk_cl_idCliente == _idCliente)
                {
                    return true;
                }
            }

            return false;
        }

        private void DeletarCliente()
        {
            int qtdDeLinhasSelecionadas = gdv_CadastroClientes.SelectedRows.Count;

            if (qtdDeLinhasSelecionadas == 0)
            {
                MessageBox.Show("SELECIONE ALGUMA LINHA DA TABELA PARA EDITAR OU DELETAR OS DADOS!", "ATENÇÃO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (VerificarClientePossuiServicos(Convert.ToInt32(gdv_CadastroClientes.SelectedCells[0].Value.ToString())) ==
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

                        }

                        break;
                    }
                }
            }
        }

        private void contextDeletarCliente_Click(object sender, EventArgs e)
        {
            DeletarCliente();
        }

        private void txtNumeroTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.PadraoTelefonicoTextBox(sender, e);
            ValidarDigitos.ApenasNumerosBackspace(e);
        }

        private void txtTelefoneRecado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
            ValidarDigitos.PadraoTelefonicoTextBox(sender, e);
        }

        private void txtDocumentoCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
            ValidarDigitos.PadraoDocumentoCPFTextbox(sender, e);
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
                ValidarDigitos.PadraoDocumentoCPFTextbox(sender, e);

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

        private void SetarTextBoxNomeClienteEventoEnter()
        {
            if (txtNomeCliente.Text == "Nome do cliente")
            {
                txtNomeCliente.Text = "";
            }
        }

        private void SetarTextBoxNomeClienteEventoLeave()
        {
            if (txtNomeCliente.Text == "")
            {
                txtNomeCliente.Text = "Nome do cliente";
            }
        }

        private void txtNomeCliente_Enter(object sender, EventArgs e)
        {
            SetarTextBoxNomeClienteEventoEnter();
        }

        private void txtNomeCliente_Leave(object sender, EventArgs e)
        {
            SetarTextBoxNomeClienteEventoLeave();
        }

        private void SetarTextBoxNumeroTelefoneEventoEnter()
        {
            if (txtNumeroTelefone.Text == "Número")
            {
                txtNumeroTelefone.Text = "";
            }
        }

        private void SetarTextBoxNumeroTelefoneEventoLeave()
        {
            if (txtNumeroTelefone.Text == "")
            {
                txtNumeroTelefone.Text = "Número";
            }
        }

        private void txtNumeroTelefone_Enter(object sender, EventArgs e)
        {
            SetarTextBoxNumeroTelefoneEventoEnter();
        }

        private void txtNumeroTelefone_Leave(object sender, EventArgs e)
        {
            SetarTextBoxNumeroTelefoneEventoLeave();
        }

        private void SetarTextBoxNumeroTelefoneRecadoEventoEnter()
        {
            if (txtTelefoneRecado.Text == "Número")
            {
                txtTelefoneRecado.Text = "";
            }
        }

        private void txtTelefoneRecado_Enter(object sender, EventArgs e)
        {
            SetarTextBoxNumeroTelefoneRecadoEventoEnter();
        }

        private void SetarTextBoxNumeroTelefoneRecadoEventoLeave()
        {
            if (txtTelefoneRecado.Text == "")
            {
                txtTelefoneRecado.Text = "Número";
            }
        }

        private void txtTelefoneRecado_Leave(object sender, EventArgs e)
        {
            SetarTextBoxNumeroTelefoneRecadoEventoLeave();
        }

        private void SetarTextBoxCampoDeBuscaEventoEnter()
        {
            if (txtBuscarClienteNomeEDocumento.Text == "Buscar nome do cliente")
            {
                txtBuscarClienteNomeEDocumento.Text = "";
            }

            if (txtBuscarClienteNomeEDocumento.Text == "Buscar CPF")
            {
                txtBuscarClienteNomeEDocumento.Text = "";
            }

            if (txtBuscarClienteNomeEDocumento.Text == "Campo de busca")
            {
                txtBuscarClienteNomeEDocumento.Text = "";
            }
        }

        private void txtBuscarClienteNomeEDocumento_Enter(object sender, EventArgs e)
        {
            SetarTextBoxCampoDeBuscaEventoEnter();
        }

        private void SetarTextBoxCampoDeBuscaEventoLeave()
        {
            if (txtBuscarClienteNomeEDocumento.Text == "")
            {
                txtBuscarClienteNomeEDocumento.Text = "Buscar nome do cliente";
            }

            if (txtBuscarClienteNomeEDocumento.Text == "")
            {
                txtBuscarClienteNomeEDocumento.Text = "Buscar CPF";
            }

            if (txtBuscarClienteNomeEDocumento.Text == "")
            {
                txtBuscarClienteNomeEDocumento.Text = "Campo de busca";
            }
        }

        private void txtBuscarClienteNomeEDocumento_Leave(object sender, EventArgs e)
        {
            SetarTextBoxCampoDeBuscaEventoLeave();
        }

        private void form_CadastrarClientes_Load(object sender, EventArgs e)
        {
            gdv_CadastroClientes.ClearSelection();
        }
    }
}