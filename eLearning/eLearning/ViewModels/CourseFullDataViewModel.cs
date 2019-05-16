using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class CourseFullDataViewModel
    {
        public int FullDataUserId { get; set; }
        public string DisplayUser { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Estimated Duration")]
        public int EstimatedDuration { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string Category { get; set; }

        public List<Curricula> MyCurricula { get; set; }

        public List<List<CurriculaLineItem>> MyCurriculaLineItems { get; set; }
    }
}
