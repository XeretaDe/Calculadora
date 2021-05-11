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


            float[] CalculoDeVisus = new float[4];   // Criação de arrays
            float[] CalculoDeCompartilhamentos = new float[3];
            float[] CalculoDeClicks = new float[4];


                while (MaxCompartilha < 4){

                ClicksIndiretos = VisusIndiretas * PorcentoClicks;
                CompartilhamentosNew = ClicksIndiretos * PorcentoCompartilhar;  
                
                CalculoDeVisus[MaxCompartilha] = VisusIndiretas; // Definir Array

                VisusIndiretas = CompartilhamentosNew * 40;  


                    if (MaxCompartilha < 3){
                    CalculoDeCompartilhamentos[MaxCPM] = CompartilhamentosNew; //Definir array
                    }

                CalculoDeClicks[MaxCompartilha] = ClicksIndiretos; // Definir Array

                MaxCompartilha++;  // Aumento do index

                    if(MaxCompartilha < 3){
                    MaxCPM++;  // Aumento do index especifico para compartilhamentos
                    }

                }
   

                float VisusIndiretasTT = CalculoDeVisus.Aggregate((a, b) => a + b);     // Soma dos arrays
                float totalCompartilhar = CalculoDeCompartilhamentos.Aggregate((a, b) => a + b);
                float ClicksIndiretosTT = CalculoDeClicks.Aggregate((a, b) => a + b);


                int SumVisu = (int)Math.Round(VisusIndiretasTT) + (int)Math.Round(VisusDiretas); 
                int SumCPM = (int)Math.Round(totalCompartilhar) + (int)Math.Round(Compartilhamentos);
                int SumClicks = (int)Math.Round(ClicksIndiretosTT) + (int)Math.Round(ClicksInicial);

                Console.WriteLine(SumVisu +" Visus");
                Console.WriteLine(SumCPM + " Compartilhamentos");
                Console.WriteLine(SumClicks + " Clicks");

                // Console.WriteLine("Suas visualizações diretas serão por volta de " + VisusDiretas + " e seu número de Clicks serão aproximadamente " + ClicksFinal);
                // Console.WriteLine("Seus Clicks devido a compartilhamentos são: " + ClicksIndiretos + " e os compartilhamentos totais são: " + CompartilhamentosFinal);
            





        }
    }
}