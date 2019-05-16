using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class StudentProgressViewModel : StudentProgress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalLineItems { get; set; }
        public int Progress { get; set; }
    }
}
