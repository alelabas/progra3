using System;
using System.Collections;
using System.Collections.ArrayList;

namespace Instituto
{

    public class ListaDocentes
    {
        private ArrayList listaDocentes;

        public ListaDocentes()
        {
            this.listaDocentes = new ArrayList();
        }

        public void AgregarDocente(ulong Legajo, string Apellidos, string Nombres, float PorcentajeAntiguedad, float Sueldo)
        {
            listaDocentes.Add(new Docente(Legajo, Apellidos, Nombres, PorcentajeAntiguedad, Sueldo));
        }

        public override string ToString()
        {
            string Datos = "";
            foreach (Docente aux in listaDocentes)
            {
                Datos += aux.ToString();
            }
            return Datos;
        }
    }
}
