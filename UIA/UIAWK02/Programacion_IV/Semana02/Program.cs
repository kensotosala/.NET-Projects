using System;

namespace Semana02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int primerNumero = 0;
            int segundoNumero = 0;
            int resultadoOperacion = 0;
            int tipoOperacion = 0;

            do
            {
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicación");
                Console.WriteLine("4. División");
                Console.WriteLine("5. Salir");

                tipoOperacion = Convert.ToInt32(Console.ReadLine());

                if (tipoOperacion >= 5)
                {
                    Console.WriteLine("Saliendo...");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("Digite el primer número: ");
                primerNumero = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite el segundoNumero número: ");
                segundoNumero = Convert.ToInt32(Console.ReadLine());

                switch (tipoOperacion)
                {
                    case 1:
                        // Suma
                        resultadoOperacion = primerNumero + segundoNumero;
                        Console.WriteLine("El resultado de la suma es : " + resultadoOperacion);
                        break;

                    case 2:
                        // Resta
                        resultadoOperacion = primerNumero - segundoNumero;
                        Console.WriteLine("El resultado de la resta es : " + resultadoOperacion);
                        break;

                    case 3:
                        // Multiplicación
                        resultadoOperacion = primerNumero * segundoNumero;
                        Console.WriteLine("El resultado de la multiplicación es : " + resultadoOperacion);
                        break;

                    case 4:
                        // División
                        resultadoOperacion = primerNumero / segundoNumero;
                        Console.WriteLine("El resultado de la división es : " + resultadoOperacion);
                        break;

                    default:
                        Console.WriteLine("Error!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (tipoOperacion != 5);
        }
    }
}