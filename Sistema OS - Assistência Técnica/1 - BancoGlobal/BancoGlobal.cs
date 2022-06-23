using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_OS___Assistência_Técnica._2___Classes;

namespace Sistema_OS___Assistência_Técnica._1___BancoGlobal
{
    class BancoGlobal
    {

        private static bool tabelaCadastroServicoEstruturaInicializou = false;
        private static bool tabelaCadastroClienteEstruturaInicializou = false;


        public static List<CadastroServicoEstrutura> listaCadastrosServicosEstrutura = new List<CadastroServicoEstrutura>();
        public static List<CadastroClienteEstrutura> listaCadastrosClientesEstrutura = new List<CadastroClienteEstrutura>();


        public static void IniciarTabelaCadastroServicos()
        {
            if (tabelaCadastroServicoEstruturaInicializou == false)
            {
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(1, 1, "Samsung Galaxy A32 Preto", "Tela Trincada", "0589", "Cliente trouxe o aparelho celular com um trinco 'fio de cabelo'na tela", "Deixou um cartão de memória 8GB", Convert.ToDateTime("16/06/2022"), Convert.ToDateTime("20/06/2022"), 100, 200, 100, "Tela foi trocada", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(2, 2, "Poco M4 Pro 5G Smartphone", "Camera frontal danificada", "0800", "Cliente trouxe o aparelho celular com a camera frontal danificada ", "N/A", Convert.ToDateTime("20/06/2022"), Convert.ToDateTime("24/05/2022"), 50, 180, 130, "Camera frontal foi substituída por uma nova", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(3, 3, "Smartphone Nokia 5.4", "Bateria viciada", "0000", "Bateria descarregando mais rápido que o normal", "Deixou o carregador do celular", Convert.ToDateTime("24/06/2022"), Convert.ToDateTime("28/06/2022"), 30, 100, 70, "Feita a troca da bateria", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(4, 4, "Apple iPhone 12 (256 GB) - Verde", "Display pifou", "HG45", "Aparelho liga porém não exibe as imagens", "N/A", Convert.ToDateTime("02/07/2022"), Convert.ToDateTime("06/07/2022"), 1200, 2000, 800, "Feita a troca do display", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(5, 5, "Smartphone Infinix Note 10 Pro", "Aparelho não liga", "5468", "O Aparelho não liga", "Deixou um carregador tipo C", Convert.ToDateTime("10/07/2022"), Convert.ToDateTime("14/05/2022"), 250, 800, 550, "Feita a troca da placa do aparelho celular", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(6, 6, "Huawei Nova 5T ", "Pelicula de vidro", "N/A", "Aparelho Novo", "N/A", Convert.ToDateTime("18/07/2022"), Convert.ToDateTime("22/07/2022"), 15, 30, 15, "Aplicação de uma pelicula de vidro", 1));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(7, 7, "Smartphone Samsung Galaxy S22 Ultra", "Visor da camera trincado", "xyJz", "Cliente trouxe o aparelho celular com o visor da camera traseira trincada", "N/A", Convert.ToDateTime("26/07/2022"), Convert.ToDateTime("30/07/2022"), 100, 300, 200, "Visor da camera traseira foi substituída por uma nova", 1));
                
                tabelaCadastroServicoEstruturaInicializou = true;
            }

        }

        public static void IniciarTabelaCadastroClientes()
        {
            if (tabelaCadastroClienteEstruturaInicializou == false)
            {
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(1, "Robinho", "(71) 0000-0000", "000.000.000-01", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(2, "Adriano", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(3, "Rafael", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(4, "Israel", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(5, "Jorge", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(6, "Tiago", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(7, "Flávio", "(71) 0000-0000", "000.000.000-00", "(71) 9738-0419", true));
            
                tabelaCadastroClienteEstruturaInicializou = true;
            }
        }

    }
}
