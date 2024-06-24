using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    internal class Interfaz
    {
            static Interfaz()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        public static int DarOpcion()
        {
            int opcion;
            Console.WriteLine("----- Menú Principal -----");
            Console.WriteLine("1. Establecer remuneración básica por hora semanal e informar todos los datos de los docentes");
            Console.WriteLine("2. Registrar docente");
            Console.WriteLine("3. Registrar división");
            Console.WriteLine("4. Asociar un Docente como profesor de una asignatura de una division");
            Console.WriteLine("5. Asociar un Docente como tutor de una division");
            Console.WriteLine("6. Informar aula designada, legajo y nombres tutor o docente");
            Console.WriteLine("7. Informar datos completos del docente por legajo");
            Console.WriteLine("8. Desasociar a un docente de como profesor o tutor de una division");
            Console.WriteLine("9. Salir");
            Console.WriteLine("---------------------------\n");


            Console.WriteLine("Ingrese la opcion deseada: ");
            while (!(int.TryParse(Console.ReadLine(), out opcion) && opcion <= 9 && opcion >= 1))
            {
                Console.WriteLine("Opcion invalida. Por favor, ingrese un numero deseado.");
            }

            return opcion;
        }
    }
}
