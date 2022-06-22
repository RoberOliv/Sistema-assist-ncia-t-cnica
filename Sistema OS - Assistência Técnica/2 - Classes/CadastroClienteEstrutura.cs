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

        public CadastroClienteEstrutura(int _id, string _nome, string _telefone, string _cpf,
            string _svTelefoneRecado)
        {
            cl_id = _id;
            cl_nome = _nome;
            cl_telefone = _telefone;
            cl_cpf = _cpf;
            cl_telefone_recado = _svTelefoneRecado;
        }
    }
}