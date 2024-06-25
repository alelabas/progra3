namespace Instituto
{
    public class Docente
    {
        private ulong Legajo;    // UNICO
        private ulong AñosServicio;
        private double Sueldo;
        private string Nombres;
        private string Apellidos;
        private string Formacion;
        private static double RemuHoraSemanal;

        public override string ToString()
        {
            string datos = "";
            datos += "\nLegajo: " + Legajo.ToString() + " - Apellidos: " + Apellidos + " - Nombres: " + Nombres +
                     " - Antigüedad: " + AñosServicio.ToString() + " años - Formacion: " + Formacion +
                     " - Sueldo: " + Sueldo.ToString();
            return datos;
        }

        // Constructor
        public Docente(ulong leg, ulong añosservicio, string nom, string ape, string formacion)
        {
            Legajo = leg;
            AñosServicio = añosservicio;
            Sueldo = 0d;
            Nombres = nom;
            Apellidos = ape;
            Formacion = formacion;
        }

        public Docente()
        {
            Legajo = 99999;
            AñosServicio = 0;
            Sueldo = 0d;
            Nombres = "X";
            Apellidos = "X";
            Formacion = "X";
        }

        // Setters
        public void SetLegajo(ulong leg)
        { Legajo = leg; }

        public void SetAñosServicio(ulong añosservicio)
        { AñosServicio = añosservicio; }

        public void SetSueldo(double sueldo)
        { Sueldo = sueldo; }

        public void SetNombres(string nom)
        { Nombres = nom; }

        public void SetApellidos(string ape)
        { Apellidos = ape; }

        public void SetFormacion(string formacion)
        { Formacion = formacion; }
        public static void SetRemuHoraSemanal(double remu)
        { RemuHoraSemanal = remu; }

        // Getters
        public ulong GetLegajo()
        { return Legajo; }

        public ulong GetAñosServicio()
        { return AñosServicio; }

        public double GetSueldo()
        { return Sueldo; }
        public string GetNombres()
        { return Nombres; }

        public string GetApellidos()
        { return Apellidos; }

        public string GetFormacion()
        { return Formacion; }

        public static double GetRemuHoraSemanal()
        { return RemuHoraSemanal; }

        public static void MostrarRemuHoraSemanal()
        {
            Console.WriteLine("- Remuneracion por hora semanal: " + RemuHoraSemanal.ToString());
        }

        public double CalcularRemuPorHoraProfesor(){

            double remuporhoraprofesor = 0;
            double adicionalAntiguedad = 0;


            if (this.AñosServicio == 1)
                adicionalAntiguedad = (RemuHoraSemanal * 0.1);
            else if (this.AñosServicio >= 2 && this.AñosServicio <= 4)
                adicionalAntiguedad = (RemuHoraSemanal * 0.2);
            else if (this.AñosServicio >= 5 && this.AñosServicio <= 6)
                adicionalAntiguedad = (RemuHoraSemanal * 0.35);
            else if (this.AñosServicio >= 7 && this.AñosServicio <= 9)
                adicionalAntiguedad = (RemuHoraSemanal * 0.45);
            else if (this.AñosServicio >= 10 && this.AñosServicio <= 11)
                adicionalAntiguedad = (RemuHoraSemanal * 0.6);
            else if (this.AñosServicio >= 12 && this.AñosServicio <= 14)
                adicionalAntiguedad = (RemuHoraSemanal * 0.65);
                else adicionalAntiguedad = (RemuHoraSemanal * 0.70);

            remuporhoraprofesor = RemuHoraSemanal + adicionalAntiguedad;

            return remuporhoraprofesor;
        }
    }
}