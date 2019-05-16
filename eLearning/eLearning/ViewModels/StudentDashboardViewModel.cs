using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class StudentDashboardViewModel
    {
        public int DashStudentId { get; set; }
        public string DashStudentName { get; set; }
        public List<StudentDashboardModel> DashCourseList { get; set; }

        public StudentDashboardViewModel()
        {
            DashCourseList = new List<StudentDashboardModel>();
        }
    }
}
