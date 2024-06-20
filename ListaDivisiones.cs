using System;
using System.Collections.ArrayList;

namespace Instituto
{

    public class ListaDivisiones
    {
        private ArrayList listaDivisiones;

        public ListaDivisiones()
        {
            this.listaDivisiones = new ArrayList();
        }

        public AgregarDivision(UInt32 anio, char letra, UInt32 aula, string? tutor)
        {
            listaDivisiones.add(new Divisiones(anio, letra, aula, tutor));
        }

    }
}