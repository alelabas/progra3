using System;
using System.Collections;

namespace Instituto
{
    public class ListaAsignaturas
    {
        private ArrayList listaAsignaturas;

        public ListaAsignaturas()
        {
            listaAsignaturas = new ArrayList();
        }

        public void AgregarAsignatura(Asignatura asignatura)
        {
            foreach (Asignatura asignaturaAux in listaAsignaturas)
            {
                if (asignaturaAux != null)
                {
                    if (asignatura.GetNombreAsignatura() == asignaturaAux.GetNombreAsignatura() && asignaturaAux.GetDivision().GetAnio() == asignatura.GetDivision().GetAnio() && asignaturaAux.GetDivision().GetLetra() == asignatura.GetDivision().GetLetra())
                    {
                        Console.WriteLine("La asignatura ingresada ya existe en la división");
                        return;
                    }
                }
            }
            listaAsignaturas.Add(asignatura);
        }

        public ArrayList GetAsignaturaPorDivision(Divisiones division)
        {
            ArrayList asignaturasDivison = new ArrayList();
            foreach( Asignatura asignatura in listaAsignaturas)
            {
                if(asignatura.GetDivision().Equals(division))
                {
                    asignaturasDivison.Add( asignatura);
                }
            }
            return asignaturasDivison;
        }

        public ArrayList GetAsignaturaDocente (Docente docente)
        {
            ArrayList asignaturaDocente = new ArrayList();
            foreach(Asignatura aux in listaAsignaturas)
            {
                if (aux.GetProfesorTitular() == docente)
                {
                    asignaturaDocente.Add(aux);
                }
            }
            return asignaturaDocente;
        }

        public void EliminarDocente(Docente docente)
        {
            foreach (Asignatura aux in listaAsignaturas.ToArray())//El .ToArray permite eliminar una elemento de la lista sin romper el programa.
            {
                if (aux != null)
                    if (aux.GetProfesorTitular() == docente)
                    {
                        listaAsignaturas.Remove(aux);
                    }
            }
        }

    }
}