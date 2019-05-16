using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class BrowseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedDuration { get; set; }
        public string TeacherName { get; set; }
        public double CourseRating { get; set; }
        public int StudentCount { get; set; }
        public string Image { get; set; }
    }
}
