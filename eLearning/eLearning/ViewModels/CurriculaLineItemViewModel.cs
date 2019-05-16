using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
    public class CurriculaLineItemViewModel
    {
        public int Id { get; set; }
        public int CurriculaId { get; set; }
        public int CurriculaTypeId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

    }
}
