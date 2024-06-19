namespace Instituto
{
    class Docente
    {
        private ulong Legajo;    // UNICO
        private ulong AñosServicio;
        private float Sueldo;
        private string Nombres;
        private string Apellidos;
        private string Formacion;

        // Constructor
        public Docente(ulong leg, ulong añosservicio, float suel, string nom, string ape, string formacion)
        {
            Legajo = leg;
            AñosServicio = añosservicio;
            Sueldo = suel;
            Nombres = nom;
            Apellidos = ape;
            Formacion = formacion;
        }

        // Setters
        public void SetLegajo(ulong leg)
        { Legajo = leg; }

        public void SetAñosServicio(ulong añosservicio)
        { AñosServicio = añosservicio; }

        public void SetSueldo(float sueldo)
        { Sueldo = sueldo; }

        public void SetNombres(string nom)
        { Nombres = nom; }

        public void SetApellidos(string ape)
        { Apellidos = ape; }

        public void SetFormacion(string formacion)
        { Formacion = formacion; }

        // Getters
        public ulong GetLegajo() 
        { return Legajo; }

        public ulong GetAñosServicio()
        { return AñosServicio; }

        public float GetSueldo()
        { return Sueldo; }
        public string GetNombres() 
        { return Nombres; }

        public string GetApellidos() 
        { return Apellidos; }

        public string GetFormacion()
        { return Formacion; }
    }
}