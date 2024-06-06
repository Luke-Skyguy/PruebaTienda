namespace PruebaTenda.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string Talla { get; set; } = string.Empty;
        public string Color { get; set; }= string.Empty;
        public float Precio { get; set; }
        public string Descripcion { get; set; }= string.Empty;
    }
}