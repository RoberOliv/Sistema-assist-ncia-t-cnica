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
    public partial class form_CalcularDataGarantia : Form
    {
        private form_CadastrarServicos formCadastrarServicos;

        public form_CalcularDataGarantia(form_CadastrarServicos _formCadastrarServicos)
        {
            InitializeComponent();
            formCadastrarServicos = _formCadastrarServicos;
        }

        private void btnSalvarGarantia_Click(object sender, EventArgs e)
        {
            CalcularDataDeGarantia();
        }

        private void CalcularDataDeGarantia()
        {
            try
            {

                DateTime dataInicial = DateTime.Now;
                int qtdDiasGarantia = Convert.ToInt32(txtQuantidadeDiasGarantia.Text);
                DateTime dataFinaldaGarantia = dataInicial.AddDays(qtdDiasGarantia);


                int novaID = BancoGlobal.listaCadastrosClientesEstrutura.Count;

                int idServico = Convert.ToInt32(lblIDservico.Text);
                int idCliente = BuscarIDCliente(idServico);

                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(novaID + 1, idServico, idCliente, dataFinaldaGarantia));
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        private int BuscarIDCliente(int _idServico)
        {
            foreach (CadastroServicoEstrutura servico in BancoGlobal.listaCadastrosServicosEstrutura)
            {
                if (servico.sv_id == _idServico)
                {
                    return servico.sv_fk_cl_idCliente;
                }
            }

            return 0;
        }

        private void txtQuantidadeDiasGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos.ApenasNumerosBackspace(e);
        }
    }
}


