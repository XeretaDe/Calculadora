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


    class Program
    {
        static void Main(string[] args)
        {

            int MaxCompartilha = 0;

            float Investimento;
            float VisusIndiretas;
            float VisusDiretas;
            float ClicksInicial;
            float ClicksIndiretos;
            float ClicksFinal;
            float Compartilhamentos;
            float CompartilhamentosNew;
            float CompartilhamentosFinal;

            float PorcentoClicks = 0.12F;
            float PorcentoCompartilhar = 0.15F;

      


            Console.WriteLine("Insira o valor de seu investimento:");

            while (!float.TryParse(Console.ReadLine(), out Investimento)) // While loop para evitar possível erro
            {
                Console.Clear();
                Console.WriteLine("Tente inserir um número!");
            }

            Console.WriteLine("O valor de seu investimento é " + Investimento + "R$");

            VisusDiretas = Investimento * 30;   // Multiplica o investimento para visualizações Diretas
            ClicksInicial = VisusDiretas * PorcentoClicks;   // Define o numero de clicks por visualização
            Compartilhamentos = ClicksInicial * PorcentoCompartilhar;  // Define o número de compartilhamentos do anúncio
            VisusIndiretas = Compartilhamentos * 40; // Visualizações de compartilhamento

            int[] CalculoDeVisus = new int[4];
            int[] CalculoDeCompartilhamentos = new int[4];
            int[] CalculoDeClicks = new int[4];



            if (Compartilhamentos != 0)
            {

                while (MaxCompartilha < 4)
                {

                    ClicksIndiretos = VisusIndiretas * PorcentoClicks;
                    CompartilhamentosNew = ClicksIndiretos * PorcentoCompartilhar;
                    CompartilhamentosFinal = CompartilhamentosNew + Compartilhamentos;
                    ClicksFinal = ClicksIndiretos + ClicksInicial;

                    if (MaxCompartilha != 1)
                    {
                        VisusIndiretas = CompartilhamentosNew * 40;
                    }

                    CalculoDeVisus[MaxCompartilha] = (int)VisusIndiretas;

                    CalculoDeCompartilhamentos[MaxCompartilha] = (int)CompartilhamentosNew;

                    CalculoDeClicks[MaxCompartilha] = (int)ClicksIndiretos;


                    //  Console.WriteLine(ClicksIndiretos);
                    //   Console.WriteLine(CompartilhamentosNew);

                    MaxCompartilha++;


                    if (MaxCompartilha == 4)
                    {
                    int VisusIndiretas = CalculoDeVisus.Aggregate((a, b) => a + b);
                    int totalCompartilhar = CalculoDeCompartilhamentos.Aggregate((a, b) => a + b);
                    int ClicksIndiretos = CalculoDeClicks.Aggregate((a, b) => a + b);

                        Console.WriteLine(VisusIndiretas);
                        Console.WriteLine(totalCompartilhar);
                        Console.WriteLine(ClicksIndiretos);

                        // Console.WriteLine("Suas visualizações diretas serão por volta de " + VisusDiretas + " e seu número de Clicks serão aproximadamente " + ClicksFinal);
                        // Console.WriteLine("Seus Clicks devido a compartilhamentos são: " + ClicksIndiretos + " e os compartilhamentos totais são: " + CompartilhamentosFinal);
                    }


                }
            }

            


        }
    }
}