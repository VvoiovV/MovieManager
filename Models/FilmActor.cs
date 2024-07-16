using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektObiektowe.Models
{
    public class FilmActor
    {
        public int? FilmId { get; set; }
        public Film? Film { get; set; }
        public int? ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
