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
    }
}