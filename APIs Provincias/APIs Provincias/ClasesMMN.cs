using System;
using System.Collections.Generic;
using System.Text;

namespace APIs_Provincias
{
    public class Parametros
    {
    }

    public class Centroide
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Provincia
    {
        public Centroide centroide { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
    }

    public class ProvinciasMMN
    {
        public int cantidad { get; set; }
        public int inicio { get; set; }
        public Parametros parametros { get; set; }
        public List<Provincia> provincias { get; set; }
        public int total { get; set; }
    }
}
