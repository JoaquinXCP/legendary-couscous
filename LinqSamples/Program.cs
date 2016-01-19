using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    class Program
    {


        static void dividirEjemplos()
        {

            Console.WriteLine("");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("~");

            }
            Console.WriteLine("");


        }

        public class obj
        {
            public void imprimir()
            {
                Console.WriteLine("TEST");
            }

        }

        static bool numeroImpar(int n)
        {
            bool aux = false;

            if (n % 2 != 0)
            {

                aux = true;
            }
            else
            {
                aux = false;


            }
            return aux;
        }
        public class getObj : obj { }
        static void Main(string[] args)
        {




            // Arreglo de nombres
            #region Some variable declarations
            String[] nombres = new String[6] { "JOAQUIN", "ULIAN", "BARBARA", "LUCY", "ALICIA", "MARIA" };
            String[] apellidos = new String[6] { "RODRIGUEZ", "PEREZ", "MARTINEZ", "FERNANDEZ", "SILVA", "CABALLERO" };
            int[] numeros = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Char[] vocales = new Char[5] { 'A', 'E', 'I', 'O', 'U' };
            string resultado = String.Empty;
            #endregion


            #region Aggregate

            resultado = nombres.Aggregate((a, b) =>
                a + " - " + b);
            Console.WriteLine("Ejemplo: a+\" - \"+b");
            Console.WriteLine("\n" + resultado);

            dividirEjemplos();

            resultado = nombres.Aggregate((a, b) =>
                a = a.Replace(vocales[0], Convert.ToChar('_')) + " - " + b);
            Console.WriteLine("Ejemplo: a = a.Replace(vocales[0], Convert.ToChar('_'))+ \" - \" + b");
            Console.WriteLine("\n" + resultado);

            dividirEjemplos();
            #endregion

            #region All
            Console.WriteLine("Ejemplo: booleano si todos los nombres tienen letra 'i'");
            Func<bool> imprimirNombresConLetra = () =>
            {
                return nombres.All(x => x.Contains("I"));

            };
            Console.WriteLine(imprimirNombresConLetra());

            dividirEjemplos();

            Console.WriteLine("Ejemplo: booleano si todos los nombres tienen más de 4 letras");
            Func<bool> imprimirNombresMayorCantidadLetras = () =>
            {
                return nombres.All(x => x.Length > 4);

            };
            Console.WriteLine(imprimirNombresMayorCantidadLetras());


            dividirEjemplos();

            #endregion

            #region Any
            Console.WriteLine("Ejemplo: booleano sobre si algún elemento es igual a 'LUCY'");
            Console.WriteLine(nombres.Any(x => x.Equals("LUCY")));

            dividirEjemplos();


            #endregion

            #region AsEnumerable
            Console.WriteLine("Ejemplo: Imprimir números");
            var query = numeros.AsEnumerable();
            foreach (var element in query)
            {
                Console.Write(element + " ");
            }

            dividirEjemplos();
            #endregion

            #region AsParallel

            int[] array = Enumerable.Range(0, short.MaxValue).ToArray();

            Console.WriteLine("Ejemplo: Imprimir números .SumAsDefault, luego .SumAsParallel y diferencia de tiempo");
            Func<int[], double> sumAsParallel = x =>
            {

                Stopwatch sw = new Stopwatch();
                sw.Start();
                x.AsParallel().Sum();
                return sw.Elapsed.TotalMilliseconds;
            };
            Console.WriteLine("SumAsParallel: " + sumAsParallel(array));
            Func<int[], double> SumAsDefault = x =>
            {

                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                x.Sum();
                return sw1.Elapsed.TotalMilliseconds;
            };

            Console.WriteLine("SumAsDefault: " + SumAsDefault(array));

            dividirEjemplos();


            #endregion

            #region Cast

            //  Cast objects
            Console.WriteLine("Ejemplo: Casteo de objetos, clase getObj deriva de obj");
            getObj[] elements = new getObj[3] { new getObj(), new getObj(), new getObj() };

            var resultCast = elements.Cast<obj>();
            foreach (obj element in resultCast)
            {
                element.imprimir();

            }

            dividirEjemplos();
            // Cast numbers
            Console.WriteLine("Ejemplo: Casteo de números int -> double ");

            int i = 100;
            double num = (double)i;
            Console.WriteLine("Entero: {0}, Double: {1}", i, num);

            dividirEjemplos();

            #endregion

            #region Concat
            Console.WriteLine("Ejemplo: \n Concatenar dos arreglos, invirtiendo el orden del segundo");

            var nombreConcatApellido = nombres.Concat(apellidos.Reverse());
            foreach (var registro in nombreConcatApellido)
            {
                Console.Write(registro + " ");

            }

            dividirEjemplos();

            #endregion

            #region Contains
            Console.WriteLine("Ejemplo: \n Cantidad de letras que repite contienen y comparten un nombre - apellido SIN REPETIR");
            Console.Write("Nombre: {0}, Apellido: {1}\nLetras compartidas: ", nombres[2], apellidos.First());
            string letrasCompartidas = String.Empty;
            StringBuilder sb = new StringBuilder();

            foreach (char letraNombre in nombres[2])
            {
                string letra_Aux = letraNombre.ToString();
                if (apellidos.First().Contains(letra_Aux) && !(letrasCompartidas.Contains(letra_Aux)))
                {
                    sb.Append(letra_Aux);
                    letrasCompartidas = sb.ToString();
                    Console.Write(letra_Aux + " ");
                }

            }

            dividirEjemplos();
            #endregion

            #region DefaultIfEmpty
            Console.WriteLine("Ejemplo: \n Set X value by default if list of char is empty");

            List<char> listOfChar = new List<char>();

            var empty = listOfChar.DefaultIfEmpty();
            foreach (char ch in empty)
            {
                Console.WriteLine("\nEmpty: " + ch);
            }

            empty = listOfChar.DefaultIfEmpty('X');

            foreach (char ch in empty)
            {
                Console.WriteLine("DefaultIfEmpty: " + ch);
            }

            #endregion

            #region Distinct
            Console.WriteLine("Ejemplo: \n Traer un representante de cada número en un arreglo con elementos iguales");

            int[] numerosRepetidos = new int[12] { 1, 1, 2, 4, 3, 3, 4, 4, 3, 1, 3, 3 };
            Console.Write("Elementos dentro del arreglo: ");

            foreach (int numR_ in numerosRepetidos)
            {
                Console.Write(numR_ + " ");

            }
            var representantesNumeros = numerosRepetidos.Distinct();
            Console.Write("\nNúmeros representantes: ");
            foreach (int numR in representantesNumeros)
            {
                Console.Write(numR + " ");
            }

            dividirEjemplos();
            #endregion

            #region ElementAtOrDefault
            Console.WriteLine("Ejemplo: \n Acceso a elemento dentro de nombres[] a través de su índice");

            for (int contadorNombres = 0; contadorNombres < nombres.Length; contadorNombres++)
            {
                Console.WriteLine("Elemento en posición {0} = {1}", contadorNombres, nombres.ElementAtOrDefault(contadorNombres));

            }
            Console.WriteLine("Ejemplo: \n Acceso a elemento dentro de nombres[] a través de su índice");

            Console.WriteLine("Manejo de excepción out-of-range access");

            Console.WriteLine("Elemento en posición {0} = '{1}'", nombres.Length + 1, nombres.ElementAtOrDefault(nombres.Length + 1));


            dividirEjemplos();

            #endregion

            #region Except



            #endregion

            #region GroupBy

            var numerosImpares = numeros.GroupBy(x => numeroImpar(x));

            foreach (var gr in numerosImpares)
            {
                Console.WriteLine("Numero impar: {0}", gr.Key);
                foreach (var number in gr)
                {

                    Console.WriteLine("{0}", number);

                }

            }

            dividirEjemplos();

            #endregion





            Console.ReadKey();


        }
    }
}
