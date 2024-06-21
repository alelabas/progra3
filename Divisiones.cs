using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Instituto
{
    public class Divisiones
    {
        private UInt32 anio;
        private char letra;
        private UInt32 aula;
        private Docente tutor;
        private ArrayList profesoresDivision = new ArrayList();
        private ArrayList materias = new ArrayList();

        //constructor
        public Divisiones(UInt32 anioAsignado, char letraAsignada, UInt32 aulaAsignada, Docente tutorAsignado)
        {
            this.anio = anioAsignado;
            this.letra = letraAsignada;
            this.aula = aulaAsignada;
            this.tutor = tutorAsignado;
        }
        public Divisiones(UInt32 anioAsignado, char letraAsignada, UInt32 aulaAsignada)
        {
            this.anio = anioAsignado;
            this.letra = letraAsignada;
            this.aula = aulaAsignada;
            this.tutor = new Docente(0, 0, "", "", "");
        }

        //setters
        public void SetAnio(uint anioDivision)
        {this.anio = anioDivision;}

        public void SetLetra(char letraDivision)
        {this.letra = letraDivision;}

        public void SetAula(UInt32 aulaDivision)
        {this.aula = aulaDivision;}

        public void SetTutor(Docente tutorDivision)
        {this.tutor = tutorDivision;}

        public void SetMaterias(string asignatura, UInt32 horassemanales)
        {
            //previo chequeo que la asignatura no exista
            string horas = horassemanales.ToString();
            string asignarMateria = asignatura + " " + horassemanales.ToString();
            this.materias.Add(asignarMateria);
        }

        public void SetProfesores(string nombre, string apellido)
        {
            string profesor = nombre + " " + apellido;
            this.profesoresDivision.Add(profesor);
        }

        public void SetTutor(string nombre, string apellido, UInt32 legajo)
        {
            string tutor = nombre + " " + apellido + " " + legajo.ToString();
        }

        //En caso de que no haya tutor asignado
        public void SetTutor()
        {
            this.tutor = new Docente(0, 0, "", "", "");
        }

        //getters
        public UInt32 GetAnio()
        {return this.anio;}
        public char GetLetra()
        {return this.letra;}

        public UInt32 GetAula()
        {return this.aula;}

        public Docente GetTutor()
        {
            return this.tutor;
        }

        public override string ToString()
        {
            string datos = " Año: " + this.anio.ToString() + " Letra: " + this.letra + " Aula: " + this.aula.ToString() + " ";
            if (this.tutor.GetLegajo() == 0) datos+= "\nProfesores: \n";
            else datos+= "Tutor: \nLegajo: " + this.tutor.GetLegajo().ToString()+ " Nombres: " + this.tutor.GetNombres() + " Apellidos: " + this.tutor.GetApellidos() + "\nProfesores: \n";

            foreach(Docente aux in profesoresDivision)
            {
                datos+= aux.ToString() + "\nAsignatura: ";
            }
            return datos;
        }
    }
}