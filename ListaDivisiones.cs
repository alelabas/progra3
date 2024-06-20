using System;
using System.Collections;

namespace Instituto
{

    public class ListaDivisiones
    {
        private ArrayList listaDivision;

        public ListaDivisiones ()
        {
            this.listaDivision = new ArrayList();
        }

        public void AgregarDivision(UInt32 anio, char letra, UInt32 aula, string? tutor)
        {
            foreach (Divisiones aux in listaDivision)
            {
                if (letra == aux.GetLetra())
                {
                    Console.WriteLine("La division ingresada ya existe");
                }
                else listaDivision.Add(new Divisiones(anio, letra, aula, tutor));
            }
        }
    
        public void BuscarDivision(UInt32 anio, char letra)
        {
            foreach (Divisiones aux in listaDivision)
            {
                if (anio == aux.GetAnio() && letra == aux.GetLetra())
                {
                    string datos = aux.ToString();
                }
            }
        }
    }
}