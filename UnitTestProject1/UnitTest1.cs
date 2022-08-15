using System;
using FabricadorOrquideas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DebeIdentificarUsoExitosoDeAndina()
        {
            //Arrange
            string[] region = { "Andina", "Pacifico", "Caribe", "Orinoquia", "Amazonia", "Territorio insular" }; ;
            Orquidea[] arrOrquideas = new Orquidea[5];

            arrOrquideas[0] = new OrquideaComestible() { Region = "Andina", Uso = "Comestible" };
            arrOrquideas[1] = new OrquideaAmbas() { Region = "Andina", Uso = "Comestible y Perfumable" };
            arrOrquideas[2] = new OrquideaPerfumable() { Region = "Andina", Uso = "Perfumable" };
            arrOrquideas[3] = new OrquideaAmbas() { Region = "Andina", Uso = "Comestible y Perfumable" };
            arrOrquideas[4] = new OrquideaPerfumable() { Region = "Andina", Uso = "Perfumable" };

            string usoExitoso = "";
            ushort[] contadorUso = new ushort[3];
            ushort usoMasExitoso = contadorUso[0];

            string[] usos = { "Comestible", "Perfumable", "Comestible y Perfumable" };

            for (byte i = 0; i < arrOrquideas.Length; i++)
            {
                if (arrOrquideas[i].Uso == usos[0])
                    contadorUso[0]++;
                else if (arrOrquideas[i].Uso == usos[1])
                    contadorUso[1]++;
                else if (arrOrquideas[i].Uso == usos[2])
                    contadorUso[2]++;
            }

            for (byte j = 0; j < contadorUso.Length; j++)
            {
                if (contadorUso[j] > usoMasExitoso)
                {
                    usoMasExitoso = contadorUso[j];

                    switch (j)
                    {
                        case 0:
                            usoExitoso = usos[j];
                            break;

                        case 1:
                            usoExitoso = usos[j];
                            break;

                        case 2:
                            usoExitoso = usos[j];
                            break;
                    }
                }
            }

            //Act
            string usoReal = Program.UsoExitosoPorRegion(arrOrquideas, region)[0];

            //Assert
            Assert.AreEqual(usoExitoso, usoReal); ;
        }

        [TestMethod]
        public void DebeIdentificarMesFloracionDeCaribe()
        {
            //Arrange
            string[] region = { "Andina", "Pacifico", "Caribe", "Orinoquia", "Amazonia", "Territorio insular" }; ;
            Orquidea[] arrOrquideas = new Orquidea[5];

            arrOrquideas[0] = new OrquideaComestible() { Region = "Caribe", PeriodoFloracion = "Septiembre" };
            arrOrquideas[1] = new OrquideaAmbas() { Region = "Caribe", PeriodoFloracion = "Abril" };
            arrOrquideas[2] = new OrquideaPerfumable() { Region = "Caribe", PeriodoFloracion = "Octubre" };
            arrOrquideas[3] = new OrquideaAmbas() { Region = "Caribe", PeriodoFloracion = "Abril" };
            arrOrquideas[4] = new OrquideaPerfumable() { Region = "Caribe", PeriodoFloracion = "Abril" };

            string mesFrecuente = "";
            ushort[] contadorMeses = new ushort[5];
            ushort mesMasFrecuente = contadorMeses[0];

            string[] meses = { "Febrero", "Marzo", "Abril", "Septiembre", "Octubre" };

            for (byte i = 0; i < arrOrquideas.Length; i++)
            {
                if (arrOrquideas[i].PeriodoFloracion == meses[0])
                    contadorMeses[0]++;
                else if (arrOrquideas[i].PeriodoFloracion == meses[1])
                    contadorMeses[1]++;
                else if (arrOrquideas[i].PeriodoFloracion == meses[2])
                    contadorMeses[2]++;
                else if (arrOrquideas[i].PeriodoFloracion == meses[3])
                    contadorMeses[3]++;
                else if (arrOrquideas[i].PeriodoFloracion == meses[4])
                    contadorMeses[4]++;
            }

            for (byte j = 0; j < contadorMeses.Length; j++)
            {
                if (contadorMeses[j] > mesMasFrecuente)
                {
                    mesMasFrecuente = contadorMeses[j];

                    switch (j)
                    {
                        case 0:
                            mesFrecuente = meses[j];
                            break;

                        case 1:
                            mesFrecuente = meses[j];
                            break;

                        case 2:
                            mesFrecuente = meses[j];
                            break;
                    }
                }
            }

            //Act
            string mesReal = Program.MesFloracionPorRegion(arrOrquideas, region)[2];

            //Assert
            Assert.AreEqual(mesFrecuente, mesReal); ;
        }
    }
}
