using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class AddCourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedDuration { get; set; }
        [Display(Name = "Choose a course category")]
        public int CategoryId { get; set; }
        //public string Category { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
