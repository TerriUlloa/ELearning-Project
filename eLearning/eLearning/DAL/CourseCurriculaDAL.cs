using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Models;

namespace eLearning.DAL
{
    public class CourseCurriculaDAL : ICourseCurriculaDAL
    {
        #region Member Variables
        private string connectionString;
        #endregion

        #region Constructor
        public CourseCurriculaDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region public Methods/Actions
        public Curricula GetCurricula(int id)
        {
            Curricula curr = new Curricula();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "SELECT c.id, c.CourseId, c.CourseSession, c.Description ";
                SQL += "FROM curricula c ";
                SQL += "WHERE c.id = @id ";

                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    curr.Id = Convert.ToInt32(reader["Id"]);
                    curr.CourseId = Convert.ToInt32(reader["CourseId"]);
                    curr.CourseSession = Convert.ToInt32(reader["CourseSession"]);
                    curr.Description = Convert.ToString(reader["Description"]);

                }
            }
            return curr;
        }

        public IList<Curricula> GetCurriculas(int courseId)
        {
            IList<Curricula> currs = new List<Curricula>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "SELECT c.id, c.CourseId, c.CourseSession, c.Description ";
                SQL += "FROM curricula c ";
                SQL += "WHERE CourseId = @id ";

                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", courseId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var curr = new Curricula()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CourseId = Convert.ToInt32(reader["CourseId"]),
                        CourseSession = Convert.ToInt32(reader["CourseSession"]),
                        Description = Convert.ToString(reader["Description"]),
                    };

                    currs.Add(curr);
                }
            }

            return currs;
        }

        public void SaveCurricula(Curricula curr)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO Curricula(CourseId, CourseSession, Description) ";
                SQL += "VALUES (@CourseId, @CourseSession, @Description);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@CourseId", curr.CourseId);
                cmd.Parameters.AddWithValue("@CourseSession", curr.CourseSession);
                cmd.Parameters.AddWithValue("@Description", curr.Description);
                
                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert curricula.");
                }
            }
        }

        public void UpdateCurricula(Curricula curr)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "UPDATE Curricula Set Description = @description, ";
                SQL += "CourseSession = @CourseSession ";
                SQL += "WHERE id = @id ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@description", curr.Description);
                cmd.Parameters.AddWithValue("@CourseSession", curr.CourseSession);
                cmd.Parameters.AddWithValue("@id", curr.Id);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to update curricula.");
                }
            }
        }

        public IList<CurriculaLineItem> GetCurriculaLineItems(int curriculaId)
        {
            IList<CurriculaLineItem> clis = new List<CurriculaLineItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "SELECT c.id, c.CurriculaId, c.CurriculaId, c.Description, c.LineItem, URL, FileName, ct.Name TypeName, ct.id CurriculaTypeId ";
                SQL += "FROM curriculaLineItem c ";
                SQL += "INNER JOIN CurriculaType ct on ct.id = c.CurriculaTypeId ";
                SQL += "WHERE CurriculaId = @id ";

                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", curriculaId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var curr = new CurriculaLineItem()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CurriculaId = Convert.ToInt32(reader["CurriculaId"]),
                        CurriculaTypeId = Convert.ToInt32(reader["CurriculaTypeId"]),
                        TypeName = Convert.ToString(reader["TypeName"]),
                        FileName = Convert.ToString(reader["FileName"]),
                        Description = Convert.ToString(reader["Description"]),
                        LineItem = Convert.ToInt32(reader["LineItem"]),
                        URL = Convert.ToString(reader["URL"])
                    };

                    clis.Add(curr);
                }
            }

            return clis;

        }

        public CurriculaLineItem GetCurriculaLineItem(int curriculaLineItemId)
        {

            CurriculaLineItem curr = new CurriculaLineItem();

                using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "SELECT c.id, c.CurriculaId, c.CurriculaId, c.Description, c.LineItem, URL, FileName, ct.Name TypeName, ct.id CurriculaTypeId ";
                SQL += "FROM curriculaLineItem c ";
                SQL += "INNER JOIN CurriculaType ct on ct.id = c.CurriculaTypeId ";
                SQL += "WHERE c.id = @id ";

                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", curriculaLineItemId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    curr.Id = Convert.ToInt32(reader["Id"]);
                    curr.CurriculaId = Convert.ToInt32(reader["CurriculaId"]);
                    curr.CurriculaTypeId = Convert.ToInt32(reader["CurriculaTypeId"]);
                    curr.TypeName = Convert.ToString(reader["TypeName"]);
                    curr.FileName = Convert.ToString(reader["FileName"]);
                    curr.Description = Convert.ToString(reader["Description"]);
                    curr.LineItem = Convert.ToInt32(reader["LineItem"]);
                    curr.URL = Convert.ToString(reader["URL"]);
          
                }
            }

            return curr;

        }

        public void SaveCurriculaLineItem(CurriculaLineItem newCLI)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO CurriculaLineItems(CurriculaId, CurriculaTypeId, Description, LineItem, URL, FileName) ";
                SQL += "VALUES (@CurriculaId, @CurriculaTypeId, @Description, @LineItem, @URL, @FileName);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@CurriculaId", newCLI.CurriculaId);
                cmd.Parameters.AddWithValue("@CurriculaTypeId", newCLI.CurriculaTypeId);
                cmd.Parameters.AddWithValue("@Description", newCLI.Description);
                cmd.Parameters.AddWithValue("@LineItem", newCLI.LineItem);
                cmd.Parameters.AddWithValue("@URL", newCLI.URL);
                cmd.Parameters.AddWithValue("@FileName", newCLI.FileName);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert course.");
                }
            }
        }

        public void UpdateCurriculaLineItem(CurriculaLineItem cli)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "UPDATE course Set Description = @description, ";
                SQL += "LineItem = @LineItem , URL = @URL, FileName = @FileName ";
                SQL += "WHERE id = @id ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@description", cli.Description);
                cmd.Parameters.AddWithValue("@LineItem", cli.LineItem);
                cmd.Parameters.AddWithValue("@URL", cli.URL);
                cmd.Parameters.AddWithValue("@FileName", cli.FileName);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to update course.");
                }
            }
        }
        #endregion
    }
}
