using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.DAL
{
    public interface ICourseDAL
    {
        IList<Course> GetCourses();
        IList<Course> GetStudentCourses(int studentId);
        IList<Course> GetTeacherCourses(int teacherId);
        void SaveCourse(Course newCourse);
        void EnrollStudent(StudentCourse studentCourse);
        Course GetCourse(int id);
        IList<Course> GetFiveCourses();
        void UpdateCourse(Course crs);
        void DeleteCourse(int id);
        int CourseRegistrations(int CourseId);
        double CourseRating(int CourseId);
        int CourseLineItems(int courseId);
        int StudentCompletedLineItems(int studentId, int courseId);
        IList<StudentProgress> GetAllStudentProgress(int courseId);
    }
}
