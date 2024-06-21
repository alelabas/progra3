using System;
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
        private static ListaDivisiones listaDivisiones = new ListaDivisiones();

        public static void Main()
        {
            switch (Interfaz.DarOpcion())
            {
                case 1:
                    Console.WriteLine("\nInforme la remuneracion basica por hora semanal deseada: ");
                    double remu = Convert.ToDouble(Console.ReadLine());
                    Docente.SetRemuHoraSemanal(remu);
                    Docente.MostrarRemuHoraSemanal();
                    Console.WriteLine("DATOS DOCENTES: ");
                    Console.WriteLine(listaDocentes.ToString());
                    break;
                case 2:
                    Console.WriteLine("Ingrese el legajo del docente:");
                    UInt32 legajo = UInt32.Parse(Console.ReadLine());
                    while (listaDocentes.BuscarLegajo(legajo) == 0)
                    {
                        Console.WriteLine("Legajo inválido. Por favor, ingrese un número entero sin signo válido.");
                        Console.WriteLine("Ingrese el legajo del docente:");
                        legajo = UInt32.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Ingrese los apellidos del docente:");
                    string apellidos = Console.ReadLine();

                    Console.WriteLine("Ingrese los nombres del docente:");
                    string nombres = Console.ReadLine();

                    Console.WriteLine("Ingrese los años de antigüedad del docente:");
                    ulong anioservicio;
                    while (!ulong.TryParse(Console.ReadLine(), out anioservicio) || anioservicio < 0)
                    {
                        Console.WriteLine("Porcentaje de antigüedad inválido. Por favor, ingrese un número decimal válido mayor o igual a cero.");
                    }

                    Console.WriteLine("Ingrese la formacion del docente");
                    string formacion = Console.ReadLine();

                    // Crear una nueva instancia de Docente utilizando el constructor 
                    Docente docente = new Docente(legajo, anioservicio, nombres, apellidos, formacion);

                    // Agregar el nuevo docente a la lista de docentes del Instituto
                    listaDocentes.AgregarDocente(docente);

                    Console.WriteLine("Docente registrado correctamente.");
                    break;

                case 3:
                    Console.WriteLine("Ingrese el año(1 - 7): ");
                    UInt32 anio;
                    if (!UInt32.TryParse(Console.ReadLine(), out anio) && anio > 7 && anio < 1)
                    {
                        Console.WriteLine("Año inválido. Por favor, ingrese un número entero válido.");
                        return;
                    }

                    Console.WriteLine("Ingrese la letra de la division:");
                    char letra = char.Parse((Console.ReadLine()));

                    Console.WriteLine("Ingrese el Aula: ");
                    UInt32 aula = UInt32.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el legajo del Tutor de la Division: ");
                    Docente tutor = listaDocentes.BuscarDocente(UInt32.Parse(Console.ReadLine()));

                    //Crear una nueva instancia de Docente utilizando el constructor 
                    Divisiones divisiones = new Divisiones(anio, letra, aula, tutor);

                    //Agregar la division a la lista
                    listaDivisiones.AgregarDivision(divisiones);
                    break;
                case 4:
                    //AsociarDocenteComoProfesor();
                    break;
                case 5:
                    Console.WriteLine("Ingrese el año de la división(1-7): ");
                    Console.WriteLine(listaDivisiones);
                    UInt32 anioIngresado = UInt32.Parse(Console.ReadLine());

                    while (anioIngresado < 1 && anioIngresado > 7)
                    {
                        Console.WriteLine("Opción invalida.");
                        Console.WriteLine("Ingrese el año de la división(1-7): ");
                        anioIngresado = UInt32.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Ingrese la letra de la división: ");
                    char letraIngresada = char.Parse((Console.ReadLine()));

                    Divisiones divaux = listaDivisiones.EncontrarDivision(anioIngresado, letraIngresada);

                    if (divaux == null)
                    {
                        Console.WriteLine("La división ingresada no existe");
                        break;
                    }
                    else
                    {
                        if (divaux.GetTutor() == null)
                        {
                            Console.WriteLine(listaDocentes);
                            Console.WriteLine("Ingrese el legajo del docente: ");
                            UInt32 legajoIngresado = UInt32.Parse(Console.ReadLine());
                            Docente tutorIngresado = listaDocentes.BuscarDocente(legajoIngresado);
                            divaux.SetTutor(tutorIngresado);
                        }
                        else
                        {
                            Console.WriteLine("La división ya posee un tutor");
                            break;
                        }
                    }

                    break;
                case 6:
                    Console.WriteLine("Ingrese el nombre de la asignatura:");
                    string nombreAsignatura = Console.ReadLine();

                    Console.WriteLine("Ingrese el año y la letra de la división:");
                    string datosDivision = Console.ReadLine();
                    break;
                case 7:
                    /*
                    ListaDocentes docenteEncontrado;
                    docenteEncontrado = new List<ListaDocentes>();

                    Console.WriteLine("Ingrese el legajo del Docente: ");
                    ulong leg = Console.ReadLine();

                    var docenteEncontrado = Docente.FirstOrDefault(d => d.leg == leg);
                    if (docenteEncontrado == null)
                    {
                        Console.WriteLine("No se encontró un docente con ese legajo.");
                        return;
                    }

                    */

                    break;
                case 8:

                    /*
                    Console.WriteLine("Ingrese al Docente que quire desasociar: ");
                    ulong borrarLegajo = Console.ReadLine();

                    foreach(//da una vulta por la lista profesor)
                    {
                        if(borrarLegajo==//legajo de la lista )
                            {
                            auxListaProfesor.Remove();
                            Console.WriteLine("El Docente se removio con exito")
                            }
                    }

                    foreach(//de una vuelta por la lista tutor)
                    {
                        if (borrarLegajo==//legajo de la lista)
                            {
                            auxListaTutor.Remove();
                            Console.WriteLine("El Docente se removio con exito")
                            }

                    }
                    */

                    break;
                case 9:
                    Console.WriteLine("Saliendo del Programa...");
                    break;
                
                default:/*
                    Console.WriteLine("Opcion no valida. Por favor, seleccione una opcion del menu.");
                    */
                    break;
                


            } 
        }
    }
}

