namespace Taller_Metodos_CRUD_Quinonez.Models
{
    public class CitaMedica
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Paciente Paciente { get; set; }
        public Doctor Doctor { get; set; }
    }

}
