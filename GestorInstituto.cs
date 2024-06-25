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
                        // CALCULAR SUELDOS
                        double remutotalprofesor = 0;
                        double remutotaltutor = 0;
                        double adicionalAntiguedad = 0;
                        double remutotal = 0;
                        
                        ArrayList listaProfesores = listaDocentes.DocenteUniversidad();

                        foreach (Docente aux in listaProfesores)
                        {
                            UInt32 horas = listaAsignaturas.CantHoras(aux);
                            
                        }

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

                        if (docenteAux != null)
                        {
                        Console.WriteLine("Ingrese el año de la división: ");
                        UInt32 ingresoDivision = UInt32.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la letra de la división: ");
                        char ingresoLetra = char.Parse(Console.ReadLine());

                        Divisiones divisionAux = listaDivisiones.EncontrarDivision(ingresoDivision, ingresoLetra);

                        Console.WriteLine("Ingrese el nombre de la asignatura: ");
                        string ingresoAsignatura = Console.ReadLine();

                        Console.WriteLine("Ingrese la carga semanal de la materia: ");
                        UInt32 ingresoHoras = UInt32.Parse(Console.ReadLine());

                        //Agrega la asignatura con su identificador a la lista de asignaturas
                        listaAsignaturas.AgregarAsignatura(new Asignatura(docenteAux, ingresoHoras, ingresoAsignatura, divisionAux));
                        }
                        else
                        {
                            Console.WriteLine("Legajo incorrecto");
                        }

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

                        //Carga la division ingresada
                        Divisiones divaux = listaDivisiones.EncontrarDivision(anioIngresado, letraIngresada);

                        if (divaux == null)
                        {
                            Console.WriteLine("La división ingresada no existe");
                            break;
                        }
                        else
                        {
                            //Chequea que la division no tenga tutor
                            if (divaux.GetTutor().GetLegajo() == 0)
                            {
                                //Agrega el tutor
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

                        //Carga la division seleccionada
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

                            //Carga en la lista todas las asignaturas de la division
                            ArrayList asignaturas = listaAsignaturas.GetAsignaturaPorDivision(division);

                            if (asignaturas != null && asignaturas.Count > 0)
                            {
                                Console.WriteLine("Docentes asignados: ");
                                foreach (Asignatura asignatura in asignaturas)
                                {
                                    Docente docenteAsignado = asignatura.GetProfesorTitular();
                                    Console.WriteLine($"- Legajo: {docenteAsignado.GetLegajo()}, Nombre: {docenteAsignado.GetNombres()}, {docenteAsignado.GetApellidos()} ");
                                    Console.WriteLine($"\nAsignatura: {asignatura.GetNombreAsignatura()} - Carga horaria: {asignatura.GetHorasSemanales()}");

                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay docentes asignados a esta division");
                            }


                        }


                        break;
                    case 7:

                        Console.WriteLine("Ingrese el legajo del docente: ");
                        UInt32 legajoBuscar;

                        if (!UInt32.TryParse(Console.ReadLine(), out legajoBuscar))
                        {
                            Console.WriteLine("Legajo inválido. Debe ingresar un nuevo legajo válido.");
                            break;
                        }

                        //Busca al docente
                        Docente docenteBuscar = listaDocentes.BuscarDocente(legajoBuscar);
                        //Carga a la lista todas las materias a cargo del docente ingresado
                        ArrayList listaMaterias = listaAsignaturas.GetAsignaturaDocente(docenteBuscar);
                        //Carga a la lista todas las divisiones que el docente tutora
                        ArrayList listaTutorias = listaDivisiones.BuscarTutorias(docenteBuscar);

                        if (docenteBuscar != null)
                        {
                            
                            Console.WriteLine($"Datos docente: {docenteBuscar.ToString()}\nAsignaturas: ");
                            foreach(Asignatura aux in listaMaterias)
                            {
                                Console.WriteLine($"Asignatura: {aux.GetNombreAsignatura()} - División: {aux.GetDivision().ToString()}");
                            }

                            Console.WriteLine("Tutorias: ");
                            foreach (Divisiones aux in listaTutorias)
                            {
                                Console.WriteLine($"Division: {aux.GetAnio()} {aux.GetLetra()}");
                            }

                            Console.WriteLine($"Sueldo: {docenteBuscar.GetSueldo()}");

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún docente con ese legajo.");
                        }

                        break;
                    case 8:

                        Console.WriteLine("Ingrese el legajo del docente que desea desasociar:");
                        UInt32 legajoDesasociar;

                        if (!UInt32.TryParse(Console.ReadLine(), out legajoDesasociar))
                        {
                            Console.WriteLine("Legajo inválido. Debe ingresar un nuevo legajo válido.");
                            break;
                        }

                        // Buscar el docente por legajo en ListaDocentes
                        Docente docenteEliminar = listaDocentes.BuscarDocente(legajoDesasociar);

                        if (docenteEliminar != null)
                        {
                            // Eliminar al docente y sus asignaturas de las divisiones.
                            listaAsignaturas.EliminarDocente(docenteEliminar);
                            //Elimina al profesor de las divisiones que tutor
                            listaDivisiones.DesasociarTutorDeDivisiones(docenteEliminar);

                            Console.WriteLine("El docente fue desasociado correctamente.");
                            Console.WriteLine($"Docente con legajo {legajoDesasociar} desasociado como profesor y/o tutor.");

                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún docente con ese legajo.");
                        }
                        
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

