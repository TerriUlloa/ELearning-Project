using eLearning.DAL;
using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        #region Member Variables
        private readonly string connectionString;
        #endregion

        #region Constructor
        public CategoryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region public Methods / Actions
        /// <summary>
        /// Gets a course and all it's information from the database.
        /// </summary>
        /// <param name="id">The unique id of the course.</param>
        /// <returns>A course object.</returns>
        public Category GetCategory(int id)
        {
            Category cat = new Category();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM category where Id = @id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cat.Id = Convert.ToInt32(reader["Id"]);
                    cat.Name = Convert.ToString(reader["Name"]);
                    cat.Description = Convert.ToString(reader["Description"]);
                }
            }

            return cat;
        }

        /// <summary>
        /// Returns a list of all categories.
        /// </summary>
        /// <returns>Returns a list of all categories</returns>
        public IList<Category> GetCategories()
        {
            IList<Category> categories = new List<Category>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM category ", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cat = new Category()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"])
                    };

                    categories.Add(cat);
                }
            }

            return categories;
        }

        /// <summary>
        /// Saves a new category to the system.
        /// </summary>
        /// <param name="newCategory"></param>
        /// <returns></returns>
        public void SaveCategory(Category newCategory)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO category(Name, Description) ";
                SQL += "VALUES (@name, @description);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@name", newCategory.Name);
                cmd.Parameters.AddWithValue("@description", newCategory.Description);
               
                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert category.");
                }
            }
        }
        #endregion
    }
}
