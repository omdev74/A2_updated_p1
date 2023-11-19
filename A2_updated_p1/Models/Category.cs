using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace A2_updated_p1.Models
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public List<Topic> Topics { get; set; }
    }
}
