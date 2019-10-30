using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCats.Entities
{
   public class Movie
    {

        public Movie()
        {
            Actors = new HashSet<Actor>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name ="Title of Movie")]
        public string Title { get; set; }
        public int Year { get; set; }
        public bool  Watched { get; set; }

        [ForeignKey("Category")]
        public string Genre { get; set; }

        public virtual Category Category { get; set; }


        [DisplayName("Director")]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }


        public virtual ICollection<Actor> Actors { get; set; }
    }
}
