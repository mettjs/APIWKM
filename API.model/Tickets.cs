namespace API.Model
{
    public class Tickets
    {
        public int IDTicket { get; set; }
        public string Pelicula { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public int PeliculaID { get; set; }
        public int SalaID { get; set; }
        public int Total { get; set; }
        public int ComboID { get; set; }
    }
}
