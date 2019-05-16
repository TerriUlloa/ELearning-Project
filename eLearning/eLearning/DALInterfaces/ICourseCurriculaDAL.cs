using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public interface ICourseCurriculaDAL
    {
        IList<Curricula> GetCurriculas(int courseId);
        Curricula GetCurricula(int id);

        IList<CurriculaLineItem> GetCurriculaLineItems(int curriculaId);
        CurriculaLineItem GetCurriculaLineItem(int curriculaLineItemId);
        void SaveCurriculaLineItem(CurriculaLineItem newCLI);
        void UpdateCurriculaLineItem(CurriculaLineItem cli);
        void SaveCurricula(Curricula curr);
    }
}
