using eLearning.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class StudentDashboardModel
    {
        private ICourseDAL _courseDAL = null;
        
        public StudentDashboardModel (ICourseDAL courseDAL)
        {
            _courseDAL = courseDAL;
        }

        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string CourseTitle { get; set; }
        public string Image { get; set; }
        public int Progress
        {
            get
            {
                if (_courseDAL.CourseLineItems(CourseId) == 0)
                { return 0; }
                else
                {
                    return (_courseDAL.StudentCompletedLineItems(StudentId, CourseId) * 100) / _courseDAL.CourseLineItems(CourseId) ;
                }
            }
        }
    }
}
