using System;
using System.Collections.ArrayList;

namespace Instituto
{

    public class ListaDocentes
    {
        private ArrayList listadocentes;

        public ListaDocentes()
        {
            this.listadocentes = new ArrayList();
        }

        public AgregarDocente(ulong Legajo, string Apellidos, string Nombres, float PorcentajeAntiguedad, float Sueldo)
        {
            listadocentes.add(new Docente(Legajo, Apellidos, Nombres, PorcentajeAntiguedad, Sueldo));
        }

    }
}
