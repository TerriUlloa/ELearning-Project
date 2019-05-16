using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public class CourseDAL : ICourseDAL
    {
        #region Member Variables
        private readonly string connectionString;

        public CourseDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Constructor


        #endregion

        #region public Methods/Actions
        /// <summary>
        /// Gets a course and all it's information from the database.
        /// </summary>
        /// <param name="id">The unique id of the course.</param>
        /// <returns>A course object.</returns>
        public Course GetCourse(int id)
        {
            Course crs = new Course();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string SQL = "SELECT c.*, u.FirstName TeacherFirstName, u.LastName TeacherLastName, ";
                SQL += "cat.id CategoryId, cat.Name CategoryName ";
                SQL += "FROM course c ";
                SQL += "inner join [User] u on u.Id = c.TeacherId ";
                SQL += "inner join Category cat on cat.Id = c.categoryid ";
                SQL += "where c.Id = @id ";

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    crs.Id = Convert.ToInt32(reader["Id"]);
                    crs.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                    crs.Name = Convert.ToString(reader["Name"]);
                    crs.Description = Convert.ToString(reader["Description"]);
                    crs.EstimatedDuration = Convert.ToInt32(reader["EstimatedDuration"]);
                    crs.TeacherLastName = Convert.ToString(reader["TeacherFirstName"]);
                    crs.TeacherFirstName = Convert.ToString(reader["TeacherLastName"]);
                    crs.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    crs.CategoryName = Convert.ToString(reader["CategoryName"]);

                }
            }

            return crs;
        }

        /// <summary>
        /// Returns a list of all courses.
        /// </summary>
        /// <returns>Returns a list of all courses</returns>
        public IList<Course> GetCourses()
        {
            IList<Course> courses = new List<Course>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "SELECT c.*, u.FirstName TeacherFirstName, u.LastName TeacherLastName, ";
                SQL += "cat.id CategoryId, cat.Name CategoryName, c.image ";
                SQL += "FROM course c ";
                SQL += "inner join [User] u on u.Id = c.TeacherId ";
                SQL += "inner join Category cat on cat.Id = c.categoryid ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var crs = new Course()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TeacherId = Convert.ToInt32(reader["TeacherId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        EstimatedDuration = Convert.ToInt32(reader["EstimatedDuration"]),
                        TeacherFirstName = Convert.ToString(reader["TeacherFirstName"]),
                        TeacherLastName = Convert.ToString(reader["TeacherLastName"]),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        Image = Convert.ToString(reader["Image"]),
                        CategoryName = Convert.ToString(reader["CategoryName"])
                    };

                    courses.Add(crs);
                }
            }

            return courses;
        }

        /// <summary>
        /// Returns a list of courses the student has enrolled in
        /// </summary>
        /// <param name="studentId">The unique Id of the student</param>
        /// <returns>Returns a list of courses</returns>
        public IList<Course> GetStudentCourses(int studentId)
        {
            IList<Course> courses = new List<Course>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "Select * From Course c ";
                SQL += "Join StudentCourse s ON s.CourseId = c.Id ";
                SQL += "WHERE UserId = @studentId";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var crs = new Course()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TeacherId = Convert.ToInt32(reader["TeacherId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        EstimatedDuration = Convert.ToInt32(reader["EstimatedDuration"]),
                        Image = Convert.ToString(reader["Image"]),

                    };

                    courses.Add(crs);
                }
                return courses;
            }
        }

        /// <summary>
        /// Returns a list of courses the student has enrolled in
        /// </summary>
        /// <param name="studentId">The unique Id of the student</param>
        /// <returns>Returns a list of courses</returns>
        public IList<Course> GetTeacherCourses(int teacherId)
        {
            IList<Course> courses = new List<Course>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "Select * From Course c ";
                SQL += "WHERE TeacherId = @teacherId";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@teacherId", teacherId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var crs = new Course()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TeacherId = Convert.ToInt32(reader["TeacherId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        EstimatedDuration = Convert.ToInt32(reader["EstimatedDuration"]),
                        Image = Convert.ToString(reader["Image"]),
                    };

                    courses.Add(crs);
                }
                return courses;
            }
        }

        /// <summary>
        /// Saves a new course to the system.
        /// </summary>
        /// <param name="newCourse"></param>
        /// <returns></returns>
        public void SaveCourse(Course newCourse)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO course(Name, Description, EstimatedDuration, TeacherId, CategoryId) ";
                SQL += "VALUES (@name, @description, @estimatedDuration, @TeacherId, @CategoryId);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@name", newCourse.Name);
                cmd.Parameters.AddWithValue("@description", newCourse.Description);
                cmd.Parameters.AddWithValue("@estimatedDuration", newCourse.EstimatedDuration);
                cmd.Parameters.AddWithValue("@TeacherId", newCourse.TeacherId);
                cmd.Parameters.AddWithValue("@CategoryId", newCourse.CategoryId);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert course.");
                }
            }
        }

        /// <summary>
        /// Enroll a student in a course.
        /// </summary>
        /// <param name="courseId">The course ID</param>
        /// <param name="userId">The user Id</param>
        public void EnrollStudent(StudentCourse studentCourse)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO StudentCourse(CourseId, UserId, RegistrationDate) ";
                SQL += "VALUES (@courseId, @userId, @registrationDate);";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@courseId", studentCourse.courseId);
                cmd.Parameters.AddWithValue("@userId", studentCourse.userId);
                cmd.Parameters.AddWithValue("@registrationDate", DateTime.Now.ToString("MM/dd/yyyy"));


                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Enrollment Failed.");
                }
            }
        }

        /// <summary>
        /// Returns a list of five courses based on rating.
        /// </summary>
        /// <returns>Returns a list of all courses</returns>
        public IList<Course> GetFiveCourses()
        {
            IList<Course> courses = new List<Course>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //BRP Need to fix to have a criteria for selecting 5 courses.  Either by rating or class size or something.
                string SQL = "SELECT TOP 5 c.*, cat.Id CategoryId, cat.Name CategoryName, ";
                SQL += "u.id TeacherId, u.FirstName TeacherFirstName, u.LastName TeacherLastName ";
                SQL += "FROM course c ";
                SQL += "inner join [User] u on u.Id = c.TeacherId ";
                SQL += "inner join Category cat on cat.Id = c.CategoryId ";

                SqlCommand cmd = new SqlCommand(SQL, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var crs = new Course()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TeacherId = Convert.ToInt32(reader["TeacherId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        EstimatedDuration = Convert.ToInt32(reader["EstimatedDuration"]),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        CategoryName = Convert.ToString(reader["CategoryName"]),
                        TeacherFirstName = Convert.ToString(reader["TeacherFirstName"]),
                        TeacherLastName = Convert.ToString(reader["TeacherLastName"]),
                        Image = Convert.ToString(reader["Image"])
                    };

                    courses.Add(crs);
                }
            }

            return courses;
        }

        public void UpdateCourse(Course crs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "UPDATE course Set Name = @name, Description = @description, ";
                SQL += "EstimatedDuration = @estimatedDuration , CategoryId = @CategoryId ";
                SQL += "WHERE id = @id ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", crs.Id);
                cmd.Parameters.AddWithValue("@name", crs.Name);
                cmd.Parameters.AddWithValue("@description", crs.Description);
                cmd.Parameters.AddWithValue("@estimatedDuration", crs.EstimatedDuration);
                cmd.Parameters.AddWithValue("@CategoryId", crs.CategoryId);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to update course.");
                }
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "Delete FROM course WHERE id = @id";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to delete course.");
                }
            }
        }

        public double CourseRating(int CourseId)
        {
            double cnt = 0;
            object CheckNull = new object();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string SQL = "select sum(rating)/CAST(count(rating) AS float) StudentRating  ";
                SQL += "from CourseRating ";
                SQL += "where courseid = @id ";
                SQL += "group by CourseId ";

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@id", CourseId);

                CheckNull = (double?)cmd.ExecuteScalar();
                if (CheckNull != null)
                {
                    cnt = (double)CheckNull;
                }

                return cnt;
            }
        }

        public int CourseRegistrations(int CourseId)
        {
            int cnt = 0;
            object CheckNull = new object();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string SQL = "select count(userid) Enrollments ";
                SQL += "from StudentCourse ";
                SQL += "where courseid = @id ";
                SQL += "group by CourseId ";

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", CourseId);

                CheckNull = (int?)cmd.ExecuteScalar();
                if (CheckNull != null)
                {
                    cnt = (int)CheckNull;
                }

            }

            return cnt;
        }

        public int CourseLineItems(int courseId)
        {
            int cnt = 0;
            object CheckNull = new object();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
//              string SQL = "select c.id CourseId, count(cli.id) LineItems ";
                string SQL = "select count(cli.id) LineItems ";
                SQL += "from CurriculaLineItem cli ";
                SQL += "inner join Curricula cur on ";
                SQL += "	cur.id = cli.CurriculaId ";
                SQL += "inner join course c on ";
                SQL += "	c.id = cur.CourseId ";
                SQL += "where c.Id = @id ";
                SQL += "group by c.id ";

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", courseId);

                CheckNull = (int?)cmd.ExecuteScalar();
                if (CheckNull != null)
                {
                    cnt = (int)CheckNull;
                }

            }

            return cnt;
        }

        public int StudentCompletedLineItems(int studentId, int courseId)
        {
            int cnt = 0;
            object CheckNull = new object();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string SQL = "SELECT count(sli.id) CompletedLineItems ";
                SQL += "FROM StudentLineItem sli ";
                SQL += "inner join CurriculaLineItem cli on ";
                SQL += "	cli.id = sli.CurriculaLineItemId ";
                SQL += "inner join Curricula cur on ";
                SQL += "	cur.id = cli.CurriculaId ";
                SQL += "inner join Course c on ";
                SQL += "	c.id = cur.CourseId ";
                SQL += "inner join [User] u on ";
                SQL += "	u.Id = sli.StudentId ";
                SQL += "where c.id = @courseId and sli.StudentId = @studentId ";

                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@courseId", courseId);

                CheckNull = (int?)cmd.ExecuteScalar();
                if (CheckNull != null)
                {
                    cnt = (int)CheckNull;
                }

            }

            return cnt;
        }

        public IList<StudentProgress> GetAllStudentProgress(int courseId)
        {
            IList<StudentProgress> students = new List<StudentProgress>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                string SQL = "select sli.StudentId, count(sli.StudentId) completed ";
                SQL += "from StudentLineItem sli ";
                SQL += "inner join CurriculaLineItem cli on ";
                SQL += "	cli.Id = sli.CurriculaLineItemId ";
                SQL += "inner join Curricula curr on ";
                SQL += "	curr.Id = cli.CurriculaId ";
                SQL += "inner join Course c on ";
                SQL += "	c.Id = curr.CourseId ";
                SQL += "where c.Id = @courseId ";
                SQL += "group by sli.StudentId ";

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@courseId", courseId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new StudentProgress()
                    {
                        StudentId   = Convert.ToInt32(reader["StudentId"]),
                        CoursesComplete = Convert.ToInt32(reader["completed"]),
                    };

                    students.Add(student);
                }
            }

            return students;
        }

        public void SaveStudentLineItem(StudentLineItem sli)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "INSERT INTO StudentLineItem(StudentId, CurriculaLineItemId, CompletionDate) ";
                SQL += "VALUES (@StudentId, @CurriculaLineItemId, @CompletionDate); ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@StudentId", sli.StudentId);
                cmd.Parameters.AddWithValue("@CurriculaLineItemId", sli.CurriculaLineItemId);
                cmd.Parameters.AddWithValue("@CompletionDate", sli.CompletionDate);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to insert Student Line Item.");
                }
            }
        }

        public void UpdateStudentLineItem(StudentLineItem sli)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string SQL = "Update StudentLineItem set CompletionDate = @CompletionDate ";
                SQL += "where id = @id ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", sli.Id);
                cmd.Parameters.AddWithValue("@CompletionDate", sli.CompletionDate);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Failed to update Student Line Item.");
                }
            }
        }
        #endregion
    }
}


