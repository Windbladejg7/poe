using System;
using Controlador;

namespace Vista
{
   internal class Program
    {
        static void Main(string[] args)
        {
            ConsolaHelper consola = new ConsolaHelper();
            Console.WriteLine("Datos del Juego");
            int id = consola.LeerNumero("Ingrese el id: ");
            string nombre = consola.LeerString("Ingrese un nombre para el juego: ");
            string descripcion = consola.LeerString("Ingrese una descripcion para el juego: ");

            JuegoControlador juegoControlador = new JuegoControlador();
            juegoControlador.AgregarJuego(id, nombre, descripcion);
        }
    }
}
