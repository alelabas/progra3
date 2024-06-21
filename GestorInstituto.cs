﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Instituto
{
    public class GestorInstituto
    {
        private static ListaDocentes listaDocentes = new ListaDocentes();

        public static void Main()
        {
            
            int opcion;

                do
                {
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



                    Console.WriteLine("Ingrese la opcion deseada: ");
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("Opcion invalida. Por favor, ingrese un numero deseado.");
                        continue;
                    }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nInforme la remuneracion basica por hora semanal deseada: ");
                        double remu = Convert.ToDouble(Console.ReadLine());
                        Docente.SetRemuHoraSemanal(remu);
                        Console.WriteLine("DATOS: ");
                        Docente.MostrarRemuHoraSemanal();
                        Console.WriteLine(listaDocentes.ToString());
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el legajo del docente:");
                        ulong legajo;
                        if (!ulong.TryParse(Console.ReadLine(), out legajo))
                        {
                            Console.WriteLine("Legajo inválido. Por favor, ingrese un número entero sin signo válido.");
                            return;
                        }

                        Console.WriteLine("Ingrese los apellidos del docente:");
                        string apellidos = Console.ReadLine();

                        Console.WriteLine("Ingrese los nombres del docente:");
                        string nombres = Console.ReadLine();

                        Console.WriteLine("Ingrese la remuneración básica por hora del docente:");
                        float sueldo;
                        while (!float.TryParse(Console.ReadLine(), out sueldo) || sueldo < 0)
                        {
                            Console.WriteLine("Remuneración básica inválida. Por favor, ingrese un número decimal válido mayor o igual a cero.");
                        }

                        Console.WriteLine("Ingrese los años de antigüedad del docente:");
                        ulong anioservicio;
                        while (!ulong.TryParse(Console.ReadLine(), out anioservicio) || anioservicio < 0)
                        {
                            Console.WriteLine("Porcentaje de antigüedad inválido. Por favor, ingrese un número decimal válido mayor o igual a cero.");
                        }

                        Console.WriteLine("Ingrese la formacion del docente");
                        string formacion = Console.ReadLine();

                        // Crear una nueva instancia de Docente utilizando el constructor 
                        Docente docente = new Docente(legajo, anioservicio, sueldo, nombres, apellidos, formacion);

                        // Agregar el nuevo docente a la lista de docentes del Instituto
                        listaDocentes.AgregarDocente(docente);

                        Console.WriteLine("Docente registrado correctamente.");
                        break;

                    case 3:
                        //Console.WriteLine("Ingrese el año: ");
                        //UInt32 anio;
                        //if (!UInt32.TryParse(Console.ReadLine(), out anio))
                        //{
                        //    Console.WriteLine("Año inválido. Por favor, ingrese un número entero sin signo válido.");
                        //    return;
                        //}

                        //Console.WriteLine("Ingrese la letra de la division:");
                        //char letra = Console.ReadLine();

                        //Console.WriteLine("Ingrese el Aula: ");
                        //UInt32 aula = Console.ReadLine();

                        //Console.WriteLine("Ingrese el Tutor de la Division: ");
                        //string tutor = Console.ReadLine();

                        //// Crear una nueva instancia de Docente utilizando el constructor 
                        //Divisiones divisiones = new Divisiones(anio, letra, aula, tutor);

                        break;
                    case 4:
                        //AsociarDocenteComoProfesor();
                        break;
                    case 5:
                        //AsociarDocenteTutor();
                        break;
                    case 6:
                        Console.WriteLine("Ingrese el nombre de la asignatura:");
                        string nombreAsignatura = Console.ReadLine();

                        Console.WriteLine("Ingrese el año y la letra de la división:");
                        string datosDivision = Console.ReadLine();
                        break;
                    case 7:

                        //ListaDocentes docenteEncontrado;
                        //docenteEncontrado = new List<ListaDocentes>();

                        //Console.WriteLine("Ingrese el legajo del Docente: "
                        //ulong leg = Console.ReadLine();

                        //var docenteEncontrado = Docente.FirstOrDefault(d => d.leg == leg);
                        //if (docenteEncontrado == null)
                        //{
                        //    Console.WriteLine("No se encontró un docente con ese legajo.");
                        //    return;
                        //}

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

