using System;
using System.Collections;

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
            listadocentes.add(new Docente(Legajo, Apellidos, Nombres, PorcentajeAntiguedad, Sueldo));
        }

    }
}
