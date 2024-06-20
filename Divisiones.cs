using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Instituto
{
    public class Divisiones
    {
        private char kaka;
        private UInt32 anio;
        private char letra;
        private UInt32 aula;
        private string? tutor;
        //private ArrayList profesoresDivision;
        //private ArrayList materias;

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
    }
}