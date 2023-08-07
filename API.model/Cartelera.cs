namespace API.Model
{
    public class Cartelera
    {
        public int CarteleraID { get; set; }
        public string Pelicula { get; set; }
        public string sinopsis { get; set; }
        public string Estreno { get; set; }
        public string Genero { get; set; }
        public string Duracion { get; set; }
        public int IDPelicula {get; set;}
        public string img { get; set; }

    }
}
