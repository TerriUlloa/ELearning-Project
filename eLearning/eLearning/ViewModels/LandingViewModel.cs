using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class LandingViewModel
    {
        public string Name { get; set; }
        public int EstimatedDuration { get; set; }
        public string TeacherName { get; set; }
        public int CourseRating { get; set; } = 5;
        public string Image { get; set; }
    }
}
