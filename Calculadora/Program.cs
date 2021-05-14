using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculadora
{
    //a cada 100 pessoas que visualizam o anúncio 12 clicam nele.       --> 12%
    //a cada 20 pessoas que clicam no anúncio 3 compartilham nas redes sociais. --> 15%
    //cada compartilhamento nas redes sociais gera 40 novas visualizações.
    //30 pessoas visualizam o anúncio original (não compartilhado) a cada R$ 1,00 investido.
    //o mesmo anúncio é compartilhado no máximo 4 vezes em sequência   


    // Crie um script em sua linguagem de programação preferida que receba o valor investido em reais e retorne uma projeção aproximada da quantidade máxima de pessoas que visualizarão o mesmo anúncio


    public class Chamadas
    {
        // Indexes
        int MaxCompartilha = 0;
        int MaxCPM = 0;

        //Valores Não Atribuidos
        float Investimento;
        float VisusIndiretas;
        float VisusDiretas;
        float ClicksInicial;
        float ClicksIndiretos;
        float Compartilhamentos;
        float CompartilhamentosNew;


        // Valores Atribuidos
        float PorcentoClicks = 0.12F;
        float PorcentoCompartilhar = 0.15F;

        // Criação de arrays
        float[] CalculoDeVisus = new float[4];
        float[] CalculoDeCompartilhamentos = new float[3];
        float[] CalculoDeClicks = new float[4];

        // valores totais indiretos

        private float VisusIndiretasTT { get; set; }
        private float totalCompartilhar { get; set; }
        private float ClicksIndiretosTT { get; set; }

        // Soma dos valores totais

        private int SumVisu { get; set; }
        private int SumCPM { get; set; }
        private int SumClicks { get; set; }


        // Valores de anuncio
        List<string> NomeAd = new();
        List<string> NomeUser = new();
        List<float> InvestDiario = new();
        List<DateTime> DataInicial = new();
        List<DateTime> DataFinal = new();
        List<int> DataTotal = new();
        List<int> CPM = new();
        List<int> Visus = new();
        List<int> Clicks = new();

        


        //Valores individuais
        DateTime ValorDataIni;
        DateTime ValorDataFin;
        string AdEscrito;
        string User;

        string LastAd;
        string LastUser;

        float LastInvest;
        float TotalInvest;

        bool start_registrando = true;

        int TotalDays;

        int LastVisus;
        int LastCPM;
        int LastClicks;



        public void Start()
        {
            Console.WriteLine("Opção 1: Registrar seu AD");
            Console.WriteLine("Opção 2: Verificar ADs registrados");
            Console.WriteLine("Opção 3: Fazer uma simulação de AD");

            Console.WriteLine();
            Console.WriteLine("Selecione sua opção com os número 1, 2 ou 3!");

            SwitchLoop();

        }

        public void SwitchLoop()
        {
            bool start = false;
            char Option = Console.ReadKey().KeyChar;

            switch (Option)
            {

                case '1':
                    start = true;
                    AdReg();
                    break;

                case '2':
                    start = true;
                    CheckRegistros();
                    break;

                case '3':
                    start = true;
                    CalculoSimples();
                    break;
            }

            if (start is false) {
                Console.WriteLine();
                Console.WriteLine("Opção inválida, tente novamente");
                Start();
            }
        }

        public void AdReg()
        {
            Console.Clear();


            Console.WriteLine("Insira o nome de seu anúncio:");
            ChamadaNome();
            NomeAd.Add(AdEscrito);


            Console.WriteLine("Insira o nome de seu cliente:");
            ChamadaUser();
            NomeUser.Add(User);

            Console.WriteLine("Insira a data de ínicio de seu AD em dd/MM/yyyy");
            CalculoDataInicial();
            if(ValorDataIni < DateTime.Today)
            {
                Console.WriteLine("ERRO: A data de finalização da aplicação deve sever maior que: " + DateTime.Today);
                CalculoDataInicial();
            }
            else
            {
             DataInicial.Add(ValorDataIni);
            }

            Console.WriteLine("Insira a data de finalização de seu AD em dd/MM/yyyy");
            CalculoDataFinal();
            if(ValorDataFin < DateTime.Today && ValorDataFin > ValorDataIni)
            {
                Console.WriteLine("ERRO: A data de finalização da aplicação deve ser maior que: " + DateTime.Now + "e maior que a data inicial.");
                CalculoDataFinal();
            }
            else
            {
                DataFinal.Add(ValorDataFin);
            }

            Console.WriteLine("Insira o valor de seu investimento diário");
            ChamadaInvest();
            InvestDiario.Add(Investimento);

            Console.Clear();
            Registrando();

        }

        public void ChamadaNome()
        {
            AdEscrito = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(AdEscrito))
            {
                Console.WriteLine("O nome de seu anúncio deve ter no mínimo um caracter, tente novamente");
                AdEscrito = Console.ReadLine();
            }
        }

        public void ChamadaUser()
        {
            User = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(User))
            {
                Console.WriteLine("O nome de seu anúncio deve ter no mínimo um caracter, tente novamente");
                User = Console.ReadLine();
            }
        }

        public void CalculoDataInicial()
        {
            while (!DateTime.TryParse(Console.ReadLine(), null, System.Globalization.DateTimeStyles.None, out ValorDataIni))
            {

                Console.WriteLine("Formato inválido, tente novamente, lembre-se dd/MM/YYYY");
            }
        }

        public void CalculoDataFinal()
        {


            while (!DateTime.TryParse(Console.ReadLine(), null, System.Globalization.DateTimeStyles.None, out ValorDataFin))
            {

                    Console.WriteLine("Formato inválido, tente novamente, lembre-se dd/MM/YYYY");
            }
        }

        public void ChamadaInvest()
        {
            while (!float.TryParse(Console.ReadLine(), out Investimento)) // While loop para evitar possível erro
            {
                Console.WriteLine("Tente inserir um número!");
            }
        }

        public void Registrando()
        {
            LastAd = NomeAd[NomeAd.Count - 1];
            LastUser = NomeUser[NomeUser.Count - 1];
            var LastDateIn = DataInicial[DataInicial.Count - 1];
            var LastDatFin = DataFinal[DataFinal.Count - 1];
            LastInvest = InvestDiario[InvestDiario.Count - 1];

            TotalDays = (LastDatFin.Date - LastDateIn.Date).Days;
            TotalInvest = TotalDays * LastInvest;

            Console.WriteLine(LastAd + " registrado com sucesso, com os seguintes dados:");
            Console.WriteLine("Cliente: " + LastUser);
            Console.WriteLine("Data de ínicio " + LastDateIn);
            Console.WriteLine("Data de término " + LastDatFin);
            Console.WriteLine("O valor de seu investimento diário é: " + LastInvest + "R$");
            Console.WriteLine("Seu AD durará " + TotalDays + " dias e custará no total: " + TotalInvest + "R$");
            CalculoBase();
        }

        public void RegistrandoValores()
        {
            Visus.Add(SumVisu);
            CPM.Add(SumCPM);
            Clicks.Add(SumClicks);

            LastVisus = Visus[Visus.Count - 1];
            LastCPM = CPM[CPM.Count - 1];
            LastClicks = Clicks[Clicks.Count - 1];

            int ID = 1;

            //      var AD = new List<Tuple<int, string, string, float, int, int, int, int>>()
            //         .Select(t => new { ID = t.Item1, ADname = t.Item2, User = t.Item3, InvDia = t.Item4, Data = t.Item5, Cpm = t.Item6, visus = t.Item7, clicks = t.Rest });
            //            AD.(new { ID = ID, ADname = LastAd, User = LastUser, InvDia = TotalInvest, Data = TotalDays, Cpm = LastCPM, visus = LastVisus, clicks = LastClicks });

            List<(int, string, string, float, int, int, int, int)> AD = new List<(int, string, string, float, int, int, int, int)>();
            AD.Add((ID, LastAd, LastUser, TotalInvest, TotalDays, LastCPM, LastVisus, LastClicks));


            ID++;


            WriteLine();
        }


        public void CheckRegistros()
        {
            Console.Clear();

            Console.WriteLine("Opção 1: Filtrar por clientes");
            Console.WriteLine("Opção 2: Filtrar por duração dos ADs");

            Console.WriteLine();
            Console.WriteLine("Selecione sua opção com os número 1 ou 2!");

            char Option = Console.ReadKey().KeyChar;
            if (Option == 1) 
            {
                NomeUser.ForEach(user => Console.WriteLine(user + ","));
                   // numbers.ForEach(num => Console.WriteLine(num + ", "));//prints 1, 2, 5, 7, 8, 10,



            }
            else if(Option == 2)
            {

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("ERRO, o valor selecionado não existe, tente novamente com 1 ou 2.");
                CheckRegistros();

            }

        }

        public void CalculoBase()
        {
            VisusDiretas = TotalInvest * 30;   // Multiplica o investimento para visualizações Diretas
            ClicksInicial = VisusDiretas * PorcentoClicks;   // Define o numero de clicks por visualização
            Compartilhamentos = ClicksInicial * PorcentoCompartilhar;  // Define o número de compartilhamentos do anúncio
            VisusIndiretas = Compartilhamentos * 40; // Visualizações de compartilhamento

            if (Compartilhamentos > 1)     // DEBUG para verificar valores e calculos.
            {
                CalculoCPM();
            }
            else
            {

                Soma();

            }
        }

        public void CalculoSimples()
        {
            Console.Clear();

            Console.WriteLine("Bem-Vindo(a), teste nossa calculadora de investimentos a seguir.");
            Console.WriteLine();

            Console.WriteLine("Insira o valor de seu investimento:");
            
            while (!float.TryParse(Console.ReadLine(), out Investimento)) // While loop para evitar possível erro
            {
            Console.Clear();
            Console.WriteLine("Tente inserir um número!");
            }

            Console.WriteLine("O valor de seu investimento é " + Investimento + "R$"); // Base do código

            VisusDiretas = TotalInvest * 30;   // Multiplica o investimento para visualizações Diretas
            ClicksInicial = VisusDiretas * PorcentoClicks;   // Define o numero de clicks por visualização
            Compartilhamentos = ClicksInicial * PorcentoCompartilhar;  // Define o número de compartilhamentos do anúncio
            VisusIndiretas = Compartilhamentos * 40; // Visualizações de compartilhamento

            start_registrando = false;

            if (Compartilhamentos > 1)     // DEBUG para verificar valores e calculos.
            {
                CalculoCPM();
            }
            else
            {

                Soma();

            }




        }


        public void CalculoCPM()
        {

            while (MaxCompartilha < 4)
            {

                ClicksIndiretos = VisusIndiretas * PorcentoClicks;
                CompartilhamentosNew = ClicksIndiretos * PorcentoCompartilhar;

                CalculoDeVisus[MaxCompartilha] = VisusIndiretas; // Definir Array

                VisusIndiretas = CompartilhamentosNew * 40;


                if (MaxCompartilha < 3)
                {
                    CalculoDeCompartilhamentos[MaxCPM] = CompartilhamentosNew; //Definir array
                }

                CalculoDeClicks[MaxCompartilha] = ClicksIndiretos; // Definir Array

                MaxCompartilha++;  // Aumento do index + DEBUG P VERIFICAR VALORES DOS ARRAYS

                if (MaxCompartilha < 3)
                {
                    MaxCPM++;  // Aumento do index especifico para compartilhamentos
                }

            }

            // Soma dos arrays
            VisusIndiretasTT = CalculoDeVisus.Aggregate((a, b) => a + b);
            totalCompartilhar = CalculoDeCompartilhamentos.Aggregate((a, b) => a + b);
            ClicksIndiretosTT = CalculoDeClicks.Aggregate((a, b) => a + b);
            SomaArredondada(); // DEBUG P VERIFICAR SOMAS DOS ARRAYS
            
        }

        public void SomaArredondada()
        {
            SumVisu = (int)Math.Round(VisusIndiretasTT) + (int)Math.Round(VisusDiretas);
            SumCPM = (int)Math.Round(totalCompartilhar) + (int)Math.Round(Compartilhamentos);
            SumClicks = (int)Math.Round(ClicksIndiretosTT) + (int)Math.Round(ClicksInicial);

            if (start_registrando)
            {
                RegistrandoValores();
            }
            else
            {
                start_registrando = true;
                WriteLine(); // DEBUG P VERIFICAR CALCULOS
            }
        }

        public void Soma()
        {
            SumVisu = (int)Math.Round(VisusIndiretasTT) + (int)Math.Round(VisusDiretas);
            SumCPM = (int)totalCompartilhar + (int)Compartilhamentos;
            SumClicks = (int)Math.Round(ClicksIndiretosTT) + (int)Math.Round(ClicksInicial);

            if (start_registrando)
            {
                RegistrandoValores();
            }
            else
            {
                start_registrando = true;
                WriteLine(); // DEBUG P VERIFICAR CALCULOS
            }
        }

        public void WriteLine() 
        {

            Console.WriteLine("Para o investimento de " + Investimento + "R$ você terá aproximadamente:");
            Console.WriteLine(SumVisu + " Visualizações totais");
            Console.WriteLine(SumCPM + " Compartilhamentos totais");
            Console.WriteLine(SumClicks + " Clicks totais");

            //

            exit(); // DEBUG P VERIFICAR CALCULOS

        }

        public  void exit()
        {
            Console.WriteLine("Digite 1 se quiser fechar o programa, se quiser recomeçar o processo clique qualquer outra tecla.");

            string Exit = Console.ReadLine();
            if (Exit == "1")
            {
                return;
            //  System.Environment.Exit(0);

            }
            else
            {
                Console.Clear();
                Start();
            }
        }



    }

    class Program
    {


        public static void Main(string[] args)
        {

            Chamadas Chamadas = new Chamadas();

            Console.WriteLine("Bem vindo a calculadora de rendimento de ADs!");
            Console.WriteLine();
            Console.WriteLine("Aqui você poderá adicionar seu próprio AD, verificar outros ADs ou simplesmente fazer uma simulação do rendimento de um investimento em um possível AD contratado.");
            Console.WriteLine();


            Chamadas.Start();

        }



    }



}