using System;

namespace Lab01
{
    internal class Operaciones
    {
        private int opcionElegida = 0;
        private int primerNumero = 0;
        private int segundoNumero = 0;
        private double resultado = 0;

        public void Ejecutar()
        {
            Menu();
            Console.ReadKey();
        }

        private void Menu()
        {
            while (opcionElegida == 0)
            {
                Console.WriteLine("=== Menú de Opciones ===");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");

                opcionElegida = Convert.ToInt32(Console.ReadLine());

                RealizarOperaciones();
            }
        }

        private void ConsultarNumero()
        {
            Console.WriteLine("Ingrese su primer número: ");
            primerNumero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingres su segundo número: ");
            segundoNumero = Convert.ToInt32(Console.ReadLine());
        }

        private void RealizarOperaciones()
        {
            switch (opcionElegida)
            {
                case 1:
                    ConsultarNumero();
                    resultado = Sumar(primerNumero, segundoNumero);
                    Console.WriteLine("Resultado de la suma: " + resultado);
                    NuevaOperacion();
                    break;

                case 2:
                    ConsultarNumero();
                    if (primerNumero > segundoNumero)
                    {
                        resultado = Restar(primerNumero, segundoNumero);
                        Console.WriteLine("Resultado de la resta: " + resultado);
                        NuevaOperacion();
                    }
                    else
                    {
                        resultado = Restar(segundoNumero, primerNumero);
                        Console.WriteLine("Resultado de la resta: " + resultado);
                        NuevaOperacion();
                    }
                    break;

                case 3:
                    ConsultarNumero();
                    resultado = Multiplicar(primerNumero, segundoNumero);
                    Console.WriteLine("Resultado de la multiplicación: " + resultado);
                    NuevaOperacion();
                    break;

                case 4:
                    ConsultarNumero();
                    if (primerNumero > 0 && segundoNumero > 0)
                    {
                        resultado = Dividir(primerNumero, segundoNumero);
                        Console.WriteLine("Resultado de la división: " + resultado);
                        NuevaOperacion();
                    }
                    else
                    {
                        Console.WriteLine("No se puede realizar la operación");
                        NuevaOperacion();
                    }
                    break;

                case 5:
                    Salir();
                    break;

                default:
                    Console.WriteLine("Operación no permitida");
                    break;
            }
        }

        private double Sumar(int a, int b)
        {
            return a + b;
        }

        private double Restar(int a, int b)
        {
            return a - b;
        }

        private double Multiplicar(int a, int b)
        {
            return a * b;
        }

        private double Dividir(int a, int b)
        {
            return a / b;
        }

        private void Salir()
        {
            System.Environment.Exit(0);
        }

        private void NuevaOperacion()
        {
            Console.WriteLine("¿Desea realizar otra operación?: Sí(1) | No(0)");
            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                opcionElegida = 0;
                Console.Clear();
                Menu();
            }
            else if (opcion == 0)
            {
                Salir();
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese 1 para Sí o 0 para No.");
                NuevaOperacion();
            }
        }
    }
}