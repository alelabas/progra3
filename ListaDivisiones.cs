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

        public uint DivisionesTutoreadas(Docente aux)
        {
            uint cont = 0;
            foreach (Divisiones divisionaux in listaDivision)
            {
                cont = 0;
                if (divisionaux.GetTutor() == aux) cont++;
            }
            return cont;
        }

        public void AgregarDivision(Divisiones division)
        {
            foreach (Divisiones aux in listaDivision)
            {
                if (aux !=null)
                {
                    if (division.GetLetra() == aux.GetLetra() && division.GetAnio() == aux.GetAnio())
                    {
                        Console.WriteLine("La division ingresada ya existe");
                        return;
                    }
                }
            }
            listaDivision.Add(division);
        }
    
        public void BuscarDivision(UInt32 anio, char letra)
        {
            foreach (Divisiones aux in listaDivision)
            {
                if (aux != null)
                {
                    if (anio == aux.GetAnio() && letra == aux.GetLetra())
                    {
                        string datos = aux.ToString();
                    }
                }
            }
        }

        public Divisiones EncontrarDivision(UInt32 anio, char letra)
        {
            foreach (Divisiones divisionaux in listaDivision)
            {
                if (divisionaux != null)
                {
                    if (divisionaux.GetAnio() == anio && letra == divisionaux.GetLetra())
                    {
                        return divisionaux;
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            string datos = "\n";
            foreach (Divisiones divisionaux in listaDivision)
            {
                datos += divisionaux.ToString() + "\n";
            }
            return datos;
        }

        public void DesasociarTutorDeDivisiones(Docente tutor)
        {
            foreach (Divisiones division in listaDivision)
            {
                if (division != null)
                    if (division.GetTutor() == tutor)
                    {
                        division.SetTutor();
                    }
            }
        }

        public ArrayList BuscarTutorias(Docente tutor)
        {
            ArrayList listaTutorias = new ArrayList();

            foreach (Divisiones aux in listaDivision)
            {
                if (aux.GetTutor() == tutor)
                {
                    listaTutorias.Add(aux);
                }
            }
            return listaTutorias;
        }
    }
}