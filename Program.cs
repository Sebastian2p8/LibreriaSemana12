using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libreria libreria = new Libreria();
            int opcion;

            do
            {
                Console.WriteLine("\n===== MENÚ LIBRERÍA =====");
                Console.WriteLine("1. Registrar libro ");
                Console.WriteLine("2. Mostrar libros  ");
                Console.WriteLine("3. Modificar libro ");
                Console.WriteLine("4. Eliminar libro  ");
                Console.WriteLine("5. Salir           ");
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out opcion))
                {
                    Console.WriteLine("Ingrese una opción válida ");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        libreria.Registrar();
                        break;
                    case 2:
                        libreria.Mostrar();
                        break;
                    case 3:
                        libreria.Modificar();
                        break;
                    case 4:
                        libreria.Eliminar();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa ");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente ");
                        break;
                }


            } while (opcion != 5);
        }
    }  
}
