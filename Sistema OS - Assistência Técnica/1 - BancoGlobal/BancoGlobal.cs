using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_OS___Assistência_Técnica._2___Classes;

namespace Sistema_OS___Assistência_Técnica._1___BancoGlobal
{
    internal class BancoGlobal
    {
        
        private static bool isTabelaCadastroServicoEstruturaInicializou = false;
        private static bool isTabelaCadastroClienteEstruturaInicializou = false;
        private static bool isTabelaGarantiaEstruturaInicializou = false;

        public static List<CadastroServicoEstrutura> listaCadastrosServicosEstrutura = new List<CadastroServicoEstrutura>();
        public static List<CadastroClienteEstrutura> listaCadastrosClientesEstrutura = new List<CadastroClienteEstrutura>();

        
        public static List<GarantiaEstrutura> listaGarantiasEstrutura = new List<GarantiaEstrutura>();

        public static void IniciarTabelaCadastroServicos()
        {
            if (isTabelaCadastroServicoEstruturaInicializou == false)
            {
                
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(1, 1, "Samsung Galaxy A32 Preto", "Tela Trincada", "0589", "Cliente trouxe o aparelho celular com um trinco 'fio de cabelo'na tela", "Deixou um cartão de memória 8GB", Convert.ToDateTime("16/06/2022"), 200, 100, -100, "Tela foi trocada", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(1, 1, "Samsung Galaxy A32 Preto", "Tela Trincada", "0589", "Cliente trouxe o aparelho celular com um trinco 'fio de cabelo'na tela", "Deixou um cartão de memória 8GB", Convert.ToDateTime("16/06/2022"), 100, 200, 100, "Tela foi trocada", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(2, 2, "Poco M4 Pro 5G Smartphone", "Camera frontal danificada", "0800", "Cliente trouxe o aparelho celular com a camera frontal danificada ", "N/A", Convert.ToDateTime("20/06/2022"), 50, 180, 130, "Camera frontal foi substituída por uma nova", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(3, 3, "Smartphone Nokia 5.4", "Bateria viciada", "0000", "Bateria descarregando mais rápido que o normal", "Deixou o carregador do celular", Convert.ToDateTime("24/06/2022"), 100, 30, -70, "Feita a troca da bateria", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(3, 3, "Smartphone Nokia 5.4", "Bateria viciada", "0000", "Bateria descarregando mais rápido que o normal", "Deixou o carregador do celular", Convert.ToDateTime("24/06/2022"), 30, 100, 70, "Feita a troca da bateria", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(3, 3, "Smartphone Nokia 5.4", "Bateria viciada", "0000", "Bateria descarregando mais rápido que o normal", "Deixou o carregador do celular", Convert.ToDateTime("24/06/2022"), 30, 100, 70, "Feita a troca da bateria", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(4, 4, "Apple iPhone 12 (256 GB) - Verde", "Display pifou", "HG45", "Aparelho liga porém não exibe as imagens", "N/A", Convert.ToDateTime("02/07/2022"), 2000, 1200, -800, "Feita a troca do display", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(5, 5, "Smartphone Infinix Note 10 Pro", "Aparelho não liga", "5468", "O Aparelho não liga", "Deixou um carregador tipo C", Convert.ToDateTime("10/07/2022"), 250, 800, 550, "Feita a troca da placa do aparelho celular", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(6, 6, "Huawei Nova 5T ", "Pelicula de vidro", "N/A", "Aparelho Novo", "N/A", Convert.ToDateTime("18/07/2022"), 15, 30, 15, "Aplicação de uma pelicula de vidro", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(6, 6, "Huawei Nova 5T ", "Pelicula de vidro", "N/A", "Aparelho Novo", "N/A", Convert.ToDateTime("18/07/2022"), 15, 30, 15, "Aplicação de uma pelicula de vidro", 0));
                BancoGlobal.listaCadastrosServicosEstrutura.Add(new CadastroServicoEstrutura(7, 7, "Smartphone Samsung Galaxy S22 Ultra", "Visor da camera trincado", "xyJz", "Cliente trouxe o aparelho celular com o visor da camera traseira trincada", "N/A", Convert.ToDateTime("26/07/2022"), 100, 300, 200, "Visor da camera traseira foi substituída por uma nova", 0));

                isTabelaCadastroServicoEstruturaInicializou = true;
            }
        }

        public static void IniciarTabelaCadastroClientes()
        {
            if (isTabelaCadastroClienteEstruturaInicializou == false)
            {
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(1, "Robinho", "(71) 0000-0001", "000.000.000-01", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(2, "Adriano", "(71) 0000-0002", "000.000.000-02", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(3, "Rafael", "(71) 0000-0003", "000.000.000-03", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(4, "Israel", "(71) 0000-0004", "000.000.000-04", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(5, "Jorge", "(71) 0000-0005", "000.000.000-05", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(6, "Tiago", "(71) 0000-0006", "000.000.000-06", "(71) 9738-0419"));
                BancoGlobal.listaCadastrosClientesEstrutura.Add(new CadastroClienteEstrutura(7, "Flávio", "(71) 0000-0007", "000.000.000-07", "(71) 9738-0419"));

                isTabelaCadastroClienteEstruturaInicializou = true;
            }
        }

        public static void InciarGarantiaEstrutura()
        {
            if (isTabelaGarantiaEstruturaInicializou == false)
            {
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(1, 1, 1, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(2, 2, 3, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(3, 3, 3, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(4, 4, 4, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(5, 5, 5, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(6, 6, 6, DateTime.Now));
                BancoGlobal.listaGarantiasEstrutura.Add(new GarantiaEstrutura(7, 7, 7, DateTime.Now));

                isTabelaGarantiaEstruturaInicializou = true;
            }
        }
    }
}