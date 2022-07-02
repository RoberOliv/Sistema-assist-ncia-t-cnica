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
    public partial class form_VerGarantia : Form
    {
        private form_ServicosConcluidos formServicosConcluidos;

        public form_VerGarantia(form_ServicosConcluidos _formServicosConcluidos)
        {
            InitializeComponent();
            formServicosConcluidos = _formServicosConcluidos;
        }

        private DateTime BuscaDataInicialGarantia(int _idServico)
        {
            DateTime dataIncial = DateTime.MinValue;

            foreach (GarantiaEstrutura garantia in BancoGlobal.listaGarantiasEstrutura)
            {
                
                if (garantia.gar_fk_idServico == _idServico)
                {
                    dataIncial = garantia.gar_data_inicial;
                }
            }

            return dataIncial;
        }

        private DateTime BuscaDataFinalGarantia(int _idServico)
        {
            DateTime dataFinal = DateTime.MinValue;

            foreach (GarantiaEstrutura garantia in BancoGlobal.listaGarantiasEstrutura)
            {
                if (garantia.gar_fk_idServico == _idServico)
                {
                    dataFinal = garantia.gar_data_final;
                }
            }

            return dataFinal;
        }

        private void btnSalvarGarantia_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_VerGarantia_Load(object sender, EventArgs e)
        {
            txtDataEmissaoGarantia.Text = BuscaDataInicialGarantia(Convert.ToInt32(lblID.Text)).ToShortDateString();
            txtDataFinalGarantia.Text = BuscaDataFinalGarantia(Convert.ToInt32(lblID.Text)).ToShortDateString();
        }
    }
}