using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    internal class Libreria
    {
        private string[] nombres;
        private decimal[] precios;

        public Libreria()
        {
            nombres = new string[0];
            precios = new decimal[0];
        }

        public void Registrar()
        {
            Console.Write("Ingrese el nombre del libro: ");
            string nombre = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("No se permite un nombre vacío ");
                return;
            }

            if (Array.Exists(nombres, n => n.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ya existe un libro con ese nombre ");
                return;
            }

            Console.Write("Ingrese el precio del libro: ");
            string texto = Console.ReadLine();

            if (string.IsNullOrEmpty(texto) || !decimal.TryParse(texto, out decimal precio))
            {
                Console.WriteLine("El precio debe ser un número válido ");
                return;
            }

            if (precio < 0)
            {
                Console.WriteLine("El precio no puede ser negativo ");
                return;
            }

            if (precio > 1000)
            {
                Console.WriteLine("El precio máximo permitido es 1000 ");
                return;
            }

            Array.Resize(ref nombres, nombres.Length + 1);
            Array.Resize(ref precios, precios.Length + 1);

            nombres[nombres.Length - 1] = nombre;
            precios[precios.Length - 1] = precio;

            Console.WriteLine("Libro registrado correctamente ");
        }

        public void Mostrar()
        {
            if (nombres.Length == 0)
            {
                Console.WriteLine("No hay libros registrados todavía ");
                return;
            }

            Console.WriteLine("\n--- LISTA DE LIBROS ---");
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/. {precios[i]:0.00}");
            }
        }

        public void Modificar()
        {
            Console.Write("Ingrese el nombre del libro que desea modificar: ");
            string buscar = Console.ReadLine()?.Trim();

            int index = Array.FindIndex(nombres, n => n.Equals(buscar, StringComparison.OrdinalIgnoreCase));

            if (index == -1)
            {
                Console.WriteLine("El libro no fue encontrado ");
                return;
            }

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                Console.WriteLine("El nuevo nombre no puede estar vacío ");
                return;
            }

            if (Array.Exists(nombres, n => n.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)) &&
                !nuevoNombre.Equals(buscar, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ya existe otro libro con ese nombre ");
                return;
            }

            Console.Write("Nuevo precio: ");
            string texto = Console.ReadLine();

            if (string.IsNullOrEmpty(texto) || !decimal.TryParse(texto, out decimal nuevoPrecio))
            {
                Console.WriteLine("El precio debe ser un número válido ");
                return;
            }

            if (nuevoPrecio < 0 || nuevoPrecio > 1000)
            {
                Console.WriteLine("El precio debe ser mayor o igual a 0 y menor o igual a 1000 ");
                return;
            }

           
            nombres[index] = nuevoNombre;
            precios[index] = nuevoPrecio;

            Console.WriteLine("Datos del libro actualizados correctamente ");
        }

        public void Eliminar()
        {
            Console.Write("Ingrese el nombre del libro a eliminar: ");
            string eliminar = Console.ReadLine()?.Trim();

            int index = Array.FindIndex(nombres, n => n.Equals(eliminar, StringComparison.OrdinalIgnoreCase));

            if (index == -1)
            {
                Console.WriteLine("No se encontró ese libro ");
                return;
            }

            string[] nuevosNombres = new string[nombres.Length - 1];
            decimal[] nuevosPrecios = new decimal[precios.Length - 1];

            int pos = 0;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (i != index)
                {
                    nuevosNombres[pos] = nombres[i];
                    nuevosPrecios[pos] = precios[i];
                    pos++;
                }
            }

            nombres = nuevosNombres;
            precios = nuevosPrecios;

            Console.WriteLine("Libro eliminado correctamente ");
        }
    }
}
