using System;
using System.Collections;
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
        private static ListaAsignaturas listaAsignaturas = new ListaAsignaturas();

        public static void Main()
        {
            int opcion = 0;
            while (opcion != 9)
            {
                opcion = Interfaz.DarOpcion();
                switch (opcion)
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
                        Console.WriteLine("Ingrese el legajo del Tutor de la Division (Ingrese 0 en caso de no asignar tutor): ");
                        UInt32 ingreso = UInt32.Parse(Console.ReadLine());

                        if (ingreso == 0)
                        {
                            //Crear una nueva instancia de Docente utilizando el constructor con tutor
                            Divisiones divisiones = new Divisiones(anio, letra, aula);
                            listaDivisiones.AgregarDivision(divisiones);
                        }
                        else
                        {
                            //Crear una nueva instancia de Docente utilizando el constructor con tutor
                            Docente tutor = listaDocentes.BuscarDocente(ingreso);
                            Divisiones divisiones = new Divisiones(anio, letra, aula, tutor);
                            listaDivisiones.AgregarDivision(divisiones);
                        }

                        //Agregar la division a la lista

                        break;
                    case 4:
                        Console.WriteLine("Ingrese el legajo del docente a asignar: ");
                        UInt32 ingresoDocente = UInt32.Parse(Console.ReadLine());

                        Docente docenteAux = listaDocentes.BuscarDocente(ingresoDocente);

                        Console.WriteLine("Ingrese el año de la división: ");
                        UInt32 ingresoDivision = UInt32.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la letra de la división: ");
                        char ingresoLetra = char.Parse(Console.ReadLine());

                        Divisiones divisionAux = listaDivisiones.EncontrarDivision(ingresoDivision, ingresoLetra);

                        Console.WriteLine("Ingrese el nombre de la asignatura: ");
                        string ingresoAsignatura = Console.ReadLine();

                        Console.WriteLine("Ingrese la carga semanal de la materia: ");
                        UInt32 ingresoHoras = UInt32.Parse(Console.ReadLine());

                        listaAsignaturas.AgregarAsignatura(new Asignatura(docenteAux, ingresoHoras, ingresoAsignatura, divisionAux));
                        break;
                    case 5:
                        Console.WriteLine(listaDivisiones.ToString());
                        Console.WriteLine("Ingrese el año de la división(1-7): ");
                        UInt32 anioIngresado = UInt32.Parse(Console.ReadLine());

                        while (anioIngresado < 1 || anioIngresado > 7)
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
                            if (divaux.GetTutor().GetLegajo() == 0)
                            {
                                Console.WriteLine(listaDocentes.ToString());
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
                        Console.WriteLine("Ingrese el año de la division:");
                        uint AnioDiv = UInt32.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la letra de la división:");
                        char LetraDiv = char.Parse(Console.ReadLine());

                        Divisiones division = listaDivisiones.EncontrarDivision(AnioDiv, LetraDiv);
                        if (division == null)
                        {
                            Console.WriteLine("La division ingresada no existe. ");
                        }
                        else
                        {
                            //informar aula asignada
                            Console.WriteLine($"Aula asignada: {division.GetAula()}");

                            //informar tutor
                            Docente tutor = division.GetTutor();
                            if (tutor != null && tutor.GetLegajo() != 0)
                            {
                                Console.WriteLine("Tutor Asignado: ");
                                Console.WriteLine($"- Legajo: {tutor.GetLegajo()}, Nombre: {tutor.GetNombres()} {tutor.GetApellidos()}");
                            }
                            else
                            {
                                Console.WriteLine("No hay tutor asignado para esta division. ");
                            }

                            //informar docentes asignados
                            ArrayList asignaturas = listaAsignaturas.GetAsignaturaPorDivision(division);

                            if (asignaturas != null && asignaturas.Count > 0)
                            {
                                Console.WriteLine("Docentes asignados: ");
                                foreach (Asignatura asignatura in asignaturas)
                                {
                                    Docente docenteAsignado = asignatura.GetProfesorTitular();
                                    Console.WriteLine($"- Legajo: {docenteAsignado.GetLegajo()}, Nombre: {docenteAsignado.GetNombres()}, {docenteAsignado.GetApellidos()} ");

                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay docentes asignados a esta division");
                            }


                        }


                        break;
                    case 7:
                        /*
                                                Console.WriteLine("Ingrese el legajo del docente:");
                                                UInt32 legajo = UInt32.Parse(Console.ReadLine());

                                                ListaDocentes.DarDatosDocentes(legajo);
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
                Console.WriteLine("\n");
            }
        }
    }
}

