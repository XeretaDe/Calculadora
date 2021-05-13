using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora._Tests
{
    [TestClass()]
    public class ChamadasTests
    {
        [TestMethod()]
        public void CalculoCPM_CalculoDeVisus_DEBUG_SOMA()
        {
            float VisusIndiretasTT;
            float[] CalculoDeVisus = new float[4] { 1, 3, 5, 10 };


            VisusIndiretasTT = CalculoDeVisus.Aggregate((a, b) => a + b);

            if (VisusIndiretasTT != 19)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CalculoCPM_CalculoDeCompartilhamentos_DEBUG_SOMA()
        {
            float totalCompartilhar;
            float[] CalculoDeCompartilhamentos = new float[4] { 1, 3, 5, 10 };


            totalCompartilhar = CalculoDeCompartilhamentos.Aggregate((a, b) => a + b);

            if (totalCompartilhar != 19)
            {
                Assert.Fail();
            }



        }

        [TestMethod()]
        public void CalculoCPM_CalculoDeClicks_DEBUG_SOMA()
        {
            float ClicksIndiretosTT;
            float[] CalculoDeClicks = new float[4] { 1, 3, 5, 10 };


            ClicksIndiretosTT = CalculoDeClicks.Aggregate((a, b) => a + b);

            if (ClicksIndiretosTT != 19)
            {
                Assert.Fail();
            }



        }


    }
}