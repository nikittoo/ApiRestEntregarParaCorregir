namespace RequerimientosEntities
{
    public class RequerimientoEntitie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int EstadoActual { get; set; }

        public RequerimientoEntitie()
        {
            EstadoActual = 0;
        }
    }
}
