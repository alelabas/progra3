using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{

    public class GestorInstituto
    {
        public static void Main()
        {

            int opcion;

            do
            {
                Console.WriteLine("----- Menú Principal -----");
                Console.WriteLine("1. Establecer e informar remuneración básica");
                Console.WriteLine("2. Registrar docente");
                Console.WriteLine("3. Registrar división");
                Console.WriteLine("4. Asociar un Docente como profesor de una asignatura de una division");
                Console.WriteLine("5. Asociar un Docente como tutor de una division");
                Console.WriteLine("6. Informar aula designada, legajo y nombres tutor o docente");
                Console.WriteLine("7. Informar datos completos del docente por legajo");
                Console.WriteLine("8. Desasociar a un docente de como profesor o tutor de una division");
                Console.WriteLine("9. Salir");



                Console.WriteLine("Ingrese la opcion deseada: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opcion invalida. Por favor, ingrese un numero deseado.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        //EstablecerRenumeracionBasica();
                        break;
                    case 2:
                        RegistrarDocente(gestor);
                        break;
                    case 3:
                        //RegistrarDivision();
                        break;
                    case 4:
                        //AsociarDocenteComoProfesor();
                        break;
                    case 5:
                        //AsociarDocenteTutor();
                        break;
                    case 6:
                        //InformarAula();
                        break;
                    case 7:
                        //InformarDatosDocente();
                        break;
                    case 8:
                        //DesasociarDocente();
                        break;
                    case 9:
                        Console.WriteLine("Saliendo del Programa...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Por favor, seleccione una opcion del menu.");
                        break;


                }
            } while (opcion != 9);

        }
       
    }

}

