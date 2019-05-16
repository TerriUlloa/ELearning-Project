using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public interface IQuizDAL
    {
        IList<Quiz> GetQuizzesForCurricula(int curriculaId);
        Quiz GetQuiz(int id);
        void SaveQuiz(Quiz qiz);
        IList<QuizQuestion> GetQuizQuestions(int quizId);
        void SaveQuizQuestion(QuizQuestion quizQuest);
    }
}
