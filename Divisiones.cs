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
        private string? tutor;
        private ArrayList profesoresDivision = new ArrayList();
        private ArrayList materias = new ArrayList();

        //constructor
        public Divisiones(UInt32 anioAsignado, char letraAsignada, UInt32 aulaAsignada, string? tutorAsignado)
        {
            this.anio = anioAsignado;
            this.letra = letraAsignada;
            this.aula = aulaAsignada;
            this.tutor = tutorAsignado;
        }

        //setters
        public void SetAnio(uint anioDivision)
        {this.anio = anioDivision;}

        public void SetLetra(char letraDivision)
        {this.letra = letraDivision;}

        public void SetAula(UInt32 aulaDivision)
        {this.aula = aulaDivision;}

        public void SetTutor(string tutorDivision)
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
            string profesor = nombre + " " + apellido
            this.profesoresDivision.Add(profesor);
        }

        public void SetTutor(string nombre, string apellido, UInt32 legajo)
        {
            string tutor = nombre + " " + apellido + " " + legajo.ToString();
        }

        //En caso de que no haya tutor asignado
        public void SetTutor()
        {
            this.tutor = "Sin tutor asignado";
        }
    }
}