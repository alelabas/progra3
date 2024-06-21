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

        public Docente BuscarDocente(UInt32 legajo)
        {
            foreach (Docente aux in listaDocentes)
            {
                if (aux != null)
                {
                    if (aux.GetLegajo() == legajo)
                    {
                        return aux;
                    }
                }
            }
            return null;
        }
        
        public UInt32 BuscarLegajo(UInt32 leg)
        {
            int cont = 0;
            foreach (Docente aux in listaDocentes)
            {
                if (aux != null)
                {
                    cont++;
                    if (aux.GetLegajo() == leg)
                    {
                        return 0;
                    }
                }
            }
            if (cont >= 0) return 1;
            else return 0;
        }

        public Docente listaDocentes(UInt32 lega)
        {

            string Datos = "";
            foreach (Docente aux in listaDocentes)
            {
                if(aux != null)
                {

                    if (aux.GetLegajo() == lega)
                    {
                    Datos += aux.ToString() + "\n";
                    }
                }
            }
        }
    }

