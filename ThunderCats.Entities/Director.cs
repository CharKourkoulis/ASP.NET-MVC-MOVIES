using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCats.Entities
{
    public class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Director's Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
