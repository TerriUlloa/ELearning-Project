using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class StudentLineItem
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CurriculaLineItemId  { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Grade { get; set; }
    }
}
