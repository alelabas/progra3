namespace Instituto
{
    class Docente
    {
        private ulong Legajo;    // UNICO
        private string Apellidos;
        private string Nombres;
        private float PorcentajeAntiguedad;
        private float Sueldo;

        // Constructor
        public Docente(ulong leg, string ape, string nom, float antiguedad, float suel)
        {
            Legajo = leg;
            Apellidos = ape;
            Nombres = nom;
            PorcentajeAntiguedad = antiguedad;
            Sueldo = suel;
        }

        // Setters
        public void SetLegajo(ulong leg)
        { Legajo = leg; }

        public void SetApellidos(string ape)
        { Apellidos = ape; }

        public void SetNombres(string nom)
        { Nombres = nom; }

        public void SetPorcentajeAntiguedad(float antiguedad)
        { PorcentajeAntiguedad = antiguedad; }

        public void SetSueldo(float suel)
        { Sueldo = suel; }

        // Getters
        public ulong GetLegajo()
        { return Legajo; }

        public string GetApellidos()
        { return Apellidos; }

        public string GetNombres()
        { return Nombres; }

        public float GetAPorcentajeAntiguedad()
        { return PorcentajeAntiguedad; }

        public float GetSueldo()
        { return Sueldo; }

    }
}