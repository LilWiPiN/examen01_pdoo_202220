using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricadorOrquideas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Programa para gestionar los diferentes tipos de orquideas que se venderan en la feria de las flores.");
            Console.WriteLine("Se produciran 1000 orquideas.\n");

            Orquidea[] flor = new Orquidea[1000];

            string[] region = { "Andina", "Pacifico", "Caribe", "Orinoquia", "Amazonia", "Territorio insular" };
            string[] mesFloracion = { "Febrero", "Marzo", "Abril", "Septiembre", "Octubre" };

            InicializaOrquideas(flor, region, mesFloracion);

            Visualiza(flor);

            ushort[] orquideaPorRegion = RecorreRegion(flor, region);
            string[] usoPorRegion = UsoExitosoPorRegion(flor, region);
            string[] mesPorRegion = MesFloracionPorRegion(flor, region);

            Console.WriteLine("Datos orquideas:");

            for (byte i = 0; i < region.Length; i++)
                Console.WriteLine($"Region: {region[i]}, Total orquideas: {orquideaPorRegion[i]}, Mes floracion: {mesPorRegion[i]}, Uso mas exitoso: {usoPorRegion[i]}");
        }

        /// <summary>
        /// Inicializa las 1000 orquideas, genera aleatoriamente sus atributos.
        /// </summary>
        /// <param name="arrOrquideas">Arreglo de orquideas(1000)</param>
        /// <param name="arrRegion">Arreglo de las regiones(6)</param>
        /// <param name="arrMesFloracion">Arreglo de mes floracion(5)</param>
        public static void InicializaOrquideas(Orquidea[] arrOrquideas, string[] arrRegion, string[] arrMesFloracion)
        {
            Random random = new Random();

            byte uso; //0 = Comestible, 1 = Perfumable, 2 = Ambos

            for (ushort i = 0; i < arrOrquideas.Length; i++)
            {
                uso = (byte)random.Next(3);

                switch (uso)
                {
                    case 0:
                        arrOrquideas[i] = new OrquideaComestible(arrRegion[random.Next(arrRegion.Length)], arrMesFloracion[random.Next(arrMesFloracion.Length)], "Comestible");
                        break;

                    case 1:
                        arrOrquideas[i] = new OrquideaPerfumable(arrRegion[random.Next(arrRegion.Length)], arrMesFloracion[random.Next(arrMesFloracion.Length)], "Perfumable");
                        break;

                    case 2:
                        arrOrquideas[i] = new OrquideaAmbas(arrRegion[random.Next(arrRegion.Length)], arrMesFloracion[random.Next(arrMesFloracion.Length)], "Comestible y Perfumable");
                        break;
                }
            }
        }

        /// <summary>
        /// Recorre las 1000 orquideas para saber la cantidad de orquideas de cada region
        /// </summary>
        /// <param name="arrOrquideas">Arreglo de orquideas(1000)</param>
        /// <param name="arrRegion">Arreglo de las regiones(6)</param>
        /// <returns></returns>
        public static ushort[] RecorreRegion(Orquidea[] arrOrquideas, string[] arrRegion)
        {
            ushort[] contadorRegion = new ushort[arrRegion.Length];

            for (byte i = 0; i < contadorRegion.Length; i++)
                contadorRegion[i] = 0;

            for (ushort i = 0; i < arrOrquideas.Length; i++)
                for (byte j = 0; j < arrRegion.Length; j++)
                    if (arrOrquideas[i].Region == arrRegion[j])
                        contadorRegion[j]++;

            return contadorRegion;
        }

        /// <summary>
        /// Recorre las 1000 orquideas para saber cual es el uso mas exitoso para cada region
        /// </summary>
        /// <param name="arrOrquideas">Arreglo de orquideas(1000)</param>
        /// <param name="arrRegion">Arreglo de las regiones(6)</param>
        /// <returns></returns>
        public static string[] UsoExitosoPorRegion(Orquidea[] arrOrquideas, string[] arrRegion)
        {
            string[] usoExitoso = new string[6];
            ushort[] contadorUso = new ushort[3];
            ushort usoMasExitoso = contadorUso[0];

            string[] usos = { "Comestible", "Perfumable", "Comestible y Perfumable" };

            for (ushort i = 0; i < arrRegion.Length; i++)
            {
                for (ushort j = 0; j < arrOrquideas.Length; j++)
                    if (arrOrquideas[j].Region == arrRegion[i])
                    {
                        if (arrOrquideas[j].Uso == usos[0])
                            contadorUso[0]++;
                        else if (arrOrquideas[j].Uso == usos[1])
                            contadorUso[1]++;
                        else if (arrOrquideas[j].Uso == usos[2])
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
                                usoExitoso[i] = usos[j];
                                break;

                            case 1:
                                usoExitoso[i] = usos[j];
                                break;

                            case 2:
                                usoExitoso[i] = usos[j];
                                break;
                        }
                    }
                }
            }

            return usoExitoso;
        }

        /// <summary>
        /// Recorre las 1000 orquideas para determinar cual es el mes de floracion mas frecuente para cada region
        /// </summary>
        /// <param name="arrOrquideas">Arreglo de orquideas(1000)</param>
        /// <param name="arrRegion">Arreglo de las regiones(6)</param>
        /// <returns></returns>
        public static string[] MesFloracionPorRegion(Orquidea[] arrOrquideas, string[] arrRegion)
        {
            string[] mesRegion = new string[6];
            ushort[] contadorMes = new ushort[5];
            ushort mesMasFrecuente = contadorMes[0];

            string[] meses = { "Febrero", "Marzo", "Abril", "Septiembre", "Octubre" };

            for (ushort i = 0; i < arrRegion.Length; i++)
            {
                for (ushort j = 0; j < arrOrquideas.Length; j++)
                    if (arrOrquideas[j].Region == arrRegion[i])
                    {
                        if (arrOrquideas[j].PeriodoFloracion == meses[0])
                            contadorMes[0]++;
                        else if (arrOrquideas[j].PeriodoFloracion == meses[1])
                            contadorMes[1]++;
                        else if (arrOrquideas[j].PeriodoFloracion == meses[2])
                            contadorMes[2]++;
                        else if (arrOrquideas[j].PeriodoFloracion == meses[3])
                            contadorMes[3]++;
                        else if (arrOrquideas[j].PeriodoFloracion == meses[4])
                            contadorMes[4]++;
                    }

                for (byte j = 0; j < contadorMes.Length; j++)
                {
                    if (contadorMes[j] > mesMasFrecuente)
                    {
                        mesMasFrecuente = contadorMes[j];

                        switch (j)
                        {
                            case 0:
                                mesRegion[i] = meses[j];
                                break;

                            case 1:
                                mesRegion[i] = meses[j];
                                break;

                            case 2:
                                mesRegion[i] = meses[j];
                                break;

                            case 3:
                                mesRegion[i] = meses[j];
                                break;

                            case 4:
                                mesRegion[i] = meses[j];
                                break;
                        }
                    }
                }
            }

            return mesRegion;
        }

        /// <summary>
        /// Metodo que escribe la informacion de las 1000 orquideas
        /// </summary>
        /// <param name="arrOrquideas">Arreglo de orquideas(1000)</param>
        public static void Visualiza(Orquidea[] arrOrquideas)
        {
            for (ushort i = 0; i < arrOrquideas.Length; i++)
                Console.WriteLine($"Orquidea No {(i + 1)} - Region: {arrOrquideas[i].Region} - Mes: {arrOrquideas[i].PeriodoFloracion} - Uso: {arrOrquideas[i].Uso}");

            Console.WriteLine("");
        }
    }
}
