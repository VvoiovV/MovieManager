using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjektObiektowe.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<FilmActor>? FilmActors { get; set; }
        public ICollection<Rating>? Ratings { get; set; }

    }
}
