using System;
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

        private float VisusIndiretasTT { get; set; }
        private float totalCompartilhar { get; set; }
        private float ClicksIndiretosTT { get; set; }

        private int SumVisu { get; set; }
        private int SumCPM { get; set; }
        private int SumClicks { get; set; }


        public void Start()
        {
            CalculoBase();
        }

        public void CalculoBase()
        {

            Console.WriteLine("Insira o valor de seu investimento:");

            while (!float.TryParse(Console.ReadLine(), out Investimento)) // While loop para evitar possível erro
            {
                Console.Clear();
                Console.WriteLine("Tente inserir um número!");
            }

            Console.WriteLine("O valor de seu investimento é " + Investimento + "R$"); // Base do código

            VisusDiretas = Investimento * 30;   // Multiplica o investimento para visualizações Diretas
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
            SomaArredondada();
        }

        public void SomaArredondada()
        {
            SumVisu = (int)Math.Round(VisusIndiretasTT) + (int)Math.Round(VisusDiretas);
            SumCPM = (int)Math.Round(totalCompartilhar) + (int)Math.Round(Compartilhamentos);
            SumClicks = (int)Math.Round(ClicksIndiretosTT) + (int)Math.Round(ClicksInicial);

            WriteLine(); // DEBUG P VERIFICAR CALCULOS
        }

        public void Soma()
        {
            SumVisu = (int)Math.Round(VisusIndiretasTT) + (int)Math.Round(VisusDiretas);
            SumCPM = (int)totalCompartilhar + (int)Compartilhamentos;
            SumClicks = (int)Math.Round(ClicksIndiretosTT) + (int)Math.Round(ClicksInicial);

            WriteLine(); // DEBUG P VERIFICAR CALCULOS

        }

        public void WriteLine() 
        {

            Console.WriteLine("Para o investimento de " + Investimento + "R$ você terá aproximadamente:");
            Console.WriteLine(SumVisu + " Visualizações");
            Console.WriteLine(SumCPM + " Compartilhamentos");
            Console.WriteLine(SumClicks + " Clicks");

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

            Chamadas.Start();

        }



    }



}