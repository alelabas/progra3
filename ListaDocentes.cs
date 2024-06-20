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

        public void AgregarDocente(ulong Legajo, string Apellidos, string Nombres, ulong PorcentajeAntiguedad, float Sueldo, string Formacion)
        {
            foreach (Docente aux in listaDocentes)
            {
                if (aux.GetLegajo()==Legajo)
                {
                    Console.WriteLine("El legajo ingresado ya pertenece al sistema");
                    break;
                }
                else listaDocentes.Add(new Docente(Legajo, PorcentajeAntiguedad, Sueldo, Nombres, Apellidos, Formacion));
            }
        }

        public override string ToString()
        {
            string Datos = "";
            foreach (Docente aux in listaDocentes)
            {
                Datos += aux.ToString() + "\n";
            }
            return Datos;
        }
    
        
    }
}
