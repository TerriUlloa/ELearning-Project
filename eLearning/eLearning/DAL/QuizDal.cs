using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;

namespace eLearning.DAL
{
    public class QuizDAL : IQuizDAL
    {
        private readonly string connectionString;

        public QuizDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a quiz and all it's information from the database.
        /// </summary>
        /// <param name="id">The unique id of the quiz.</param>
        /// <returns>A quiz object.</returns>
        public Quiz GetQuiz(int id)
        {
            Quiz qiz = new Quiz();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM quiz where Id = @id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qiz.Id = Convert.ToInt32(reader["Id"]);
                    qiz.CurriculaLineItemId = Convert.ToInt32(reader["CurriculaLineItemId"]);
                    qiz.Name = Convert.ToString(reader["Name"]);
                    qiz.Description = Convert.ToString(reader["Description"]);
                    qiz.URL = Convert.ToString(reader["URL"]);
                }
            }

            return qiz;
        }

        /// <summary>
        /// Returns a list of all quiz questions for a given quiz.
        /// </summary>
        /// <param name="QuizId">The unique id of the quiz.</param>
        /// <returns>Returns a list of quiz questions for a given quiz.</returns>
        public IList<QuizQuestion> GetQuizQuestions(int QuizId)
        {
            IList<QuizQuestion> questions = new List<QuizQuestion>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM QuizQuestions where QuizId = @QuizId ", conn);

                cmd.Parameters.AddWithValue("@QuizId", QuizId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var question = new QuizQuestion()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        QuizId = Convert.ToInt32(reader["QuizId"]),
                        QuestionNumber = Convert.ToInt32(reader["QuestionNumber"]),
                        Question = Convert.ToString(reader["Question"]),
                        AnswerA = Convert.ToString(reader["AnswerA"]),
                        AnswerB = Convert.ToString(reader["AnswerB"]),
                        AnswerC = Convert.ToString(reader["AnswerC"]),
                        AnswerD = Convert.ToString(reader["AnswerD"]),
                        AnswerE = Convert.ToString(reader["AnswerE"]),
                        CorrectAnswer = Convert.ToString(reader["CorrectAnswer"]),
                    };

                    questions.Add(question);
                }
            }

            return questions;
        }

        /// <summary>
        /// Returns a list of all quizzes for a given curricula session.
        /// </summary>
        /// <param name="CurriculaLineItemId">The unique id of the Curricula Line Item.</param>
        /// <returns>Returns a list of all courses</returns>
        public IList<Quiz> GetQuizzesForCurricula(int CurriculaLineItemId)
        {
            IList<Quiz> quizzes = new List<Quiz>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM quiz where CurriculaLineItemId = @CurriculaLineItemId ", conn);

                cmd.Parameters.AddWithValue("@CurriculaLineItemId", CurriculaLineItemId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var qiz = new Quiz()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CurriculaLineItemId = Convert.ToInt32(reader["CurriculaLineItemId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        URL = Convert.ToString(reader["URL"]),
                    };

                    quizzes.Add(qiz);
                }
            }

            return quizzes;
        }

        /// <summary>
        /// Saves a new quiz to the system.
        /// </summary>
        /// <param name="qiz">A Quiz object</param>
        /// <returns></returns>
        public void SaveQuiz(Quiz qiz)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO quiz(CurriculaLineItemId, Name, Description, URL) ";
                SQL += "VALUES (@CurriculaLineItemId, @name, @description, @URL);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@CurriculaLineItemId", qiz.CurriculaLineItemId);
                cmd.Parameters.AddWithValue("@name", qiz.Name);
                cmd.Parameters.AddWithValue("@description", qiz.Description);
                cmd.Parameters.AddWithValue("@URL", qiz.URL);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert course.");
                }
            }
        }

        /// <summary>
        /// Saves a new quiz question to the system.
        /// </summary>
        /// <param name="qiz">A Quiz question object</param>
        /// <returns></returns>
        public void SaveQuizQuestion(QuizQuestion quizQuest)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO QuizQuestion(QuizId, QuestionNumber, Question, AnswerA, ";
                SQL += "AnswerB, AnswerC, AnswerD, AnswerE, CorrectAnswer) ";
                SQL += "VALUES (@QuizId, @QuestionNumber, @Question, @AnswerA  ";
                SQL += "@AnswerB, @AnswerC, @AnswerD, @AnswerE, @CorrectAnswer); ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@QuizId", quizQuest.QuizId);
                cmd.Parameters.AddWithValue("@QuestionNumber", quizQuest.QuestionNumber);
                cmd.Parameters.AddWithValue("@Question", quizQuest.Question);
                cmd.Parameters.AddWithValue("@AnswerA", quizQuest.AnswerA);
                cmd.Parameters.AddWithValue("@AnswerB", quizQuest.AnswerB);
                cmd.Parameters.AddWithValue("@AnswerC", quizQuest.AnswerC);
                cmd.Parameters.AddWithValue("@AnswerD", quizQuest.AnswerD);
                cmd.Parameters.AddWithValue("@AnswerE", quizQuest.AnswerE);
                cmd.Parameters.AddWithValue("@CorrectAnswer", quizQuest.CorrectAnswer);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert course.");
                }
            }
        }

        /// <summary>
        /// Saves an existing quiz question to the system.
        /// </summary>
        /// <param name="qiz">A Quiz question object</param>
        /// <returns></returns>
        public void UpdateQuizQuestion(QuizQuestion quizQuest)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "UPDATE QuizQuestion SET QuizId = @QuizId, QuestionNumber = @QuestionNumber, ";
                SQL += "Question = @QuestionNumber, AnswerA = @AnswerA, ";
                SQL += "AnswerB = @AnswerB, AnswerC = @AnswerC, AnswerD = @AnswerD, ";
                SQL += "AnswerE = @AnswerE, CorrectAnswer = @CorrectAnswer) ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@QuizId", quizQuest.QuizId);
                cmd.Parameters.AddWithValue("@QuestionNumber", quizQuest.QuestionNumber);
                cmd.Parameters.AddWithValue("@Question", quizQuest.Question);
                cmd.Parameters.AddWithValue("@AnswerA", quizQuest.AnswerA);
                cmd.Parameters.AddWithValue("@AnswerB", quizQuest.AnswerB);
                cmd.Parameters.AddWithValue("@AnswerC", quizQuest.AnswerC);
                cmd.Parameters.AddWithValue("@AnswerD", quizQuest.AnswerD);
                cmd.Parameters.AddWithValue("@AnswerE", quizQuest.AnswerE);
                cmd.Parameters.AddWithValue("@CorrectAnswer", quizQuest.CorrectAnswer);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert course.");
                }
            }
        }

    }
}
