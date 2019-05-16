using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int CurriculaLineItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

    }
}
