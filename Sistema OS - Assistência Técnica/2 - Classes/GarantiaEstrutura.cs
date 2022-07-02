using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_OS___Assistência_Técnica._2___Classes
{
    class GarantiaEstrutura
    {
        public int gar_id { get; set; }
        public int gar_fk_idServico { get; set; }

        public int gar_fk_idCliente { get; set; }

        public DateTime gar_data_inicial { get; set; }

        public DateTime gar_data_final { get; set; }

        public GarantiaEstrutura(int _gar_Id, int _gar_fk_idServico, int _gar_fk_idCliente,
            DateTime _gar_data_final)
        {
            gar_id = _gar_Id;
            gar_fk_idServico = _gar_fk_idServico;
            gar_fk_idCliente = _gar_fk_idCliente;
            gar_data_inicial = DateTime.Now;
            gar_data_final = _gar_data_final;
        }

    }
}
