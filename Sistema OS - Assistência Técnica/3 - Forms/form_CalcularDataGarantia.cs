using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void txtQuantidadeDiasGarantia_TextChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    DateTime dataHoje = Convert.ToDateTime(formCadastrarServicos.dtpDataAtualCadastro.Text);

            //    formCadastrarServicos.dtpDataConclusao.Text = dataHoje.AddDays(Convert.ToInt32(formCadastrarServicos.dtpDataConclusao.Text)).ToShortDateString();
            //}
            //catch (Exception exception)
            //{

            //}
        }
    }
}

