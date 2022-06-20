using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_OS___Assistência_Técnica._2___Classes
{
    class CadastroClienteEstrutura
    {
        public int sv_id { get; set; }
        public string sv_nome { get; set; }
        public string sv_telefone { get; set; }
        public string sv_cpf { get; set; }
        public string sv_telefone_recado { get; set; }

        public bool isExisteServicoEmAndamentoOuConcluido { get; set; }


        public CadastroClienteEstrutura(int _svId, string _svNome, string _svTelefone, string _svCpf,
            string _svTelefoneRecado, bool _ExisteServicoEmAndamentoOuConcluido)
        {
            sv_id = _svId;
            sv_nome = _svNome;
            sv_telefone = _svTelefone;
            sv_cpf = _svCpf;
            sv_telefone_recado = _svTelefoneRecado;
            isExisteServicoEmAndamentoOuConcluido = _ExisteServicoEmAndamentoOuConcluido;


        }

    }
}
