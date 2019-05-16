using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class BrowseViewModel
    {
        public int BrowseStudentId { get; set; }
        public string BrowseStudentName { get; set; }
        public List<BrowseModel> BrowseCourseList { get; set; }

        public BrowseViewModel()
        {
            BrowseCourseList = new List<BrowseModel>();
        }
    }
}
