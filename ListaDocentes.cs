using System;
using System.Collections;
using System.Runtime.InteropServices;

using Instituto;

    public class ListaDocentes
    {
        private ArrayList listaDocentes;

        public ListaDocentes()
        {
            this.listaDocentes = new ArrayList();
        }

        public void AgregarDocente(Docente nuevoDocente)
        {
            foreach (Docente docente in listaDocentes)
            {
                if (docente.GetLegajo() == nuevoDocente.GetLegajo())
                {
                    Console.WriteLine("El legajo ingresado ya pertenece al sistema");
                    return;
                }
            }
        
        float nuevoSueldo = nuevoDocente.GetSueldo() * nuevoDocente.GetAñosServicio();
        nuevoDocente.SetSueldo(nuevoSueldo);

        listaDocentes.Add(nuevoDocente);
    }

        public override string ToString()
        {
            string Datos = "";
            foreach (Docente aux in listaDocentes)
            {
                Datos += aux.ToString() + "\n";
            }

        if (Datos == "") return "- NO HAY DOCENTES CARGADOS EN LA LISTA";
        else return Datos;
        }
    
        
    }

