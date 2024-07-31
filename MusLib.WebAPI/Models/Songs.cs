using Microsoft.EntityFrameworkCore;

namespace MusLib.WebAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Release { get; set; }

        public Genre? Genre { get; set; }
        public int? GenreId { get; set; }
    }
}
