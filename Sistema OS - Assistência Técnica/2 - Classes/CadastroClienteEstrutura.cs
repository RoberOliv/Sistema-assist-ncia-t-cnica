using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_OS___Assistência_Técnica._2___Classes
{
    internal class CadastroClienteEstrutura
    {
        public int cl_id { get; set; }
        public string cl_nome { get; set; }
        public string cl_telefone { get; set; }
        public string cl_cpf { get; set; }
        public string cl_telefone_recado { get; set; }

        

        public CadastroClienteEstrutura(int _svId, string _svNome, string _svTelefone, string _svCpf,
            string _svTelefoneRecado)
        {
            cl_id = _svId;
            cl_nome = _svNome;
            cl_telefone = _svTelefone;
            cl_cpf = _svCpf;
            cl_telefone_recado = _svTelefoneRecado;
           
        }
    }
}