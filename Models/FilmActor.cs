using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektObiektowe.Models
{
    public class FilmActor
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}