using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Instituto
{
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

        public void CalcularRemuneracion(double RemuneracionProfesor)
        {
            double remuneracionBasicaSemanal = RemuneracionProfesor * 4; // Suponiendo 4 semanas por mes

            // Calcular adicional por antigüedad
            double adicionalAntiguedad = 0;

            foreach (Docente aux in listaDocentes)
            { 
            if (aux.GetAñosServicio() == 1)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.1);
            else if (aux.GetAñosServicio() >= 2 && aux.GetAñosServicio() <= 4)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.2);
            else if (aux.GetAñosServicio() >= 5 && aux.GetAñosServicio() <= 6)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.35);
            else if (aux.GetAñosServicio() >= 7 && aux.GetAñosServicio() <= 9)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.45);
            else if (aux.GetAñosServicio() >= 10 && aux.GetAñosServicio() <= 11)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.6);
            else if (aux.GetAñosServicio() >= 12 && aux.GetAñosServicio() <= 14)
                adicionalAntiguedad = (remuneracionBasicaSemanal * 0.65);
            }
            // Calcular remuneración total mensual
            double RemuneracionTotal = remuneracionBasicaSemanal * 10 + adicionalAntiguedad;
        }
    }
}
