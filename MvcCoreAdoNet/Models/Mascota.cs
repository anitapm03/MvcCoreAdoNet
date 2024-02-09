namespace MvcCoreAdoNet.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }

        public Mascota(string nombre, string raza, int edad) 
        {
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
        }
    }
}
