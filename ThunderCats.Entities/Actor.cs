using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCats.Entities
{
    public class Actor
    {

        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]      
        [MinLength(5, ErrorMessage ="Name must be longer than 5")]
        [Display( Name = "Actor's Name")]
        public string Name { get; set; }

        [Range(1,120, ErrorMessage ="Invalid Age!")]
        public int Age { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
