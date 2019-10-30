using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderCats.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Category")]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Category()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
