using System.Reflection.Metadata;

namespace API.Model
{
    public class Peliculas
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Director { get; set; }
        public string? Sinopsis {get; set; }
        public string? Reparto { get; set; }
        public string? Duracion { get; set; }
        public string? Genero { get; set; }
        public string? Estreno { get; set; }
        public string? Trailer { get; set; }
        public string img { get; set; }
    }
}
