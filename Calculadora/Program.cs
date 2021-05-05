using System;

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

            while (MaxCompartilha != 4)
            {
                if(Compartilhamentos != 0)
                {
                    ClicksIndiretos = VisusIndiretas * PorcentoClicks;
                    Compartilhamentos = ClicksIndiretos * PorcentoCompartilhar;

                }
                MaxCompartilha++;
            }

            Console.WriteLine("Suas visualizações diretas serão por volta de " + VisusDiretas + " e seu número de Clicks serão aproximadamente " + ClicksFinal);


        }
    }
}
