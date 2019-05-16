using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class CurriculaLineItem
    {
        public int Id { get; set; }
        public int CurriculaId { get; set; }
        public int CurriculaTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string  URL { get; set; }
        public int LineItem { get; set; }
        public bool IsCompleted { get; set; }
    }
}
