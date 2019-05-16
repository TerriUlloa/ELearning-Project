using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class CurriculaDetailViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CourseSession { get; set; }
        public string Description { get; set; }
        public List<CurriculaLineItem> Details { get; set; }
    }
}
