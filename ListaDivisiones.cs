using System;
using System.Collections.ArrayList;

namespace Instituto
{

    public class ListaDivisiones
    {
        private ArrayList listaDivisiones;

        public void ListaDivisiones()
        {
            this.listaDivisiones = new ArrayList();
        }

        public void AgregarDivision(UInt32 anio, char letra, UInt32 aula, string? tutor)
        {
            listaDivisiones.Add(new Divisiones(anio, letra, aula, tutor));
        }

    }
}