using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_OS___Assistência_Técnica._2___Classes
{
    class CadastroServicoEstrutura
    {
        public int sv_id { get; set; }
        public int sv_fk_cl_idCliente { get; set; }
        public string sv_aparelho { get; set; }
        public string sv_defeito { get; set; }

        public  string sv_senha { get; set; }
        public string sv_situacao { get; set; }
        public string sv_acessorios { get; set; }
        public DateTime sv_dataCadastro { get; set; }
        public DateTime sv_dataConclusao { get; set; }
        public decimal sv_valorServico { get; set; }
        public decimal sv_valorPeca { get; set; }
        public decimal sv_lucroServico { get; set; }
        public string sv_servicoFeito { get; set; }
        public int sv_status { get; set; }


        public CadastroServicoEstrutura(int _sv_id, int _sv_fk_cl_idCliente, string _sv_aparelho, string _sv_defeito, string _sv_senha,
            string _sv_situacao, string _sv_acessorios, DateTime _sv_dataCadastro, DateTime _sv_dataConclusao, decimal _sv_valorPeca,
            decimal _sv_valorServico, decimal _sv_lucroServico, string _sv_servicoFeito, int _sv_status)

        {

            sv_id = _sv_id;
            sv_fk_cl_idCliente = _sv_fk_cl_idCliente;
            sv_aparelho = _sv_aparelho;
            sv_defeito = _sv_defeito;
            sv_senha = _sv_senha;
            sv_situacao = _sv_situacao;
            sv_acessorios = _sv_acessorios;
            sv_dataCadastro = _sv_dataCadastro;
            sv_dataConclusao = _sv_dataConclusao;
            sv_valorServico = _sv_valorServico;
            sv_valorPeca = _sv_valorPeca;
            sv_lucroServico = _sv_lucroServico;
            sv_servicoFeito = _sv_servicoFeito;
            sv_status = _sv_status;
            


        }

    }

}
