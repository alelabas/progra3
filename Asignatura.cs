using System;
using System.Collections;

namespace Instituto
{
    public class Asignatura
    {
        private Docente profesorTitular;
        private UInt32 horasSemanales;
        private string nombreAsignatura;
        private Divisiones division;

        public Asignatura(Docente docente, UInt32 horas, string nombre, Divisiones divRecibida)
        {
            this.profesorTitular = docente;
            this.horasSemanales = horas;
            this.nombreAsignatura = nombre;
            this.division = divRecibida;
        }

        //setters
        public void SetProfesorTitular(Docente docente)
        {this.profesorTitular = docente;}
        public void SetHorasSemanales(UInt32 horas)
        {this.horasSemanales=horas;}
        public void SetNombreAsignatura(string nombre)
        {this.nombreAsignatura=nombre;}
        public void SetDivision(Divisiones divRecibida)
        {this.division=divRecibida;}

        //getters
        public Docente GetProfesorTitular()
        {return this.profesorTitular;}
        public UInt32 GetHorasSemanales()
        {return this.horasSemanales;}
        public string GetNombreAsignatura()
        {return this.nombreAsignatura;}
        public Divisiones GetDivision()
        {return this.division;}
    }
}