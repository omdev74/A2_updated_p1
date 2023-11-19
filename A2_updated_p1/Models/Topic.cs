using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace A2_updated_p1.Models
{
    public class Topic
    {
        [Key]
        public string TopicId { get; set; }

        public string Name { get; set; }

        public List<FAQ> FAQs { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
