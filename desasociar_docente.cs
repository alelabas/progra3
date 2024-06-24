using System;
using System.Collections;

namespace Instituto
{
    public class Eliminar_docente
    {
        public static void EliminarDocente(Docente docente, Divisiones division, string nombre)
        {
            ArrayList profesoresDivision = division.GetProfesoresDivision();
            bool esProfesor = false;
            int indice = -1;

            // Busca al docente en la lista de profesores de la división
            for (int i = 0; i < profesoresDivision.Count; i++)
            {
                Docente profesor = (Docente)profesoresDivision[i];

                if (profesor.GetNombres() == nombre)
                {
                    indice = i;
                    esProfesor = true;
                    break;
                }
            }

            // Si se encontró al docente como profesor, lo elimina
            if (esProfesor && indice != -1)
            {
                profesoresDivision.RemoveAt(indice);
                Console.WriteLine($"Docente \"{nombre}\" eliminado correctamente.");
            }
            else
            {   
                //si esProfesor es falso ,es tutor y se procede a eliminar
                if (!esProfesor)
                {
                    Docente tutorActual = division.GetTutor();
                    if (tutorActual.GetNombres() == nombre)
                    {
                        division.SetTutor(null);
                        Console.WriteLine($"Tutor \"{nombre}\" eliminado correctamente de la división.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún docente con el nombre \"{nombre}\" como profesor ni como tutor en esta división.");
                    }
                }
            }
        }
    }
}