using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class StudentController : ApiController
    {
        Data.itelec4dbDataContext db = new Data.itelec4dbDataContext();

        [Authorize, HttpGet, Route("api/student/course/list")]
        public List<ApiModels.Course_Model> ListCourse()
        {
            var courses = from d in db.MstCourses
                          select new ApiModels.Course_Model
                          {
                              Id = d.Id,
                              CourseCode = d.CourseCode,
                              Course = d.Course
                          };

            return courses.ToList();
        }

        [Authorize, HttpGet, Route("api/student/list")]
        public List<ApiModels.Student_Model> ListStudent()
        {
            var students = from d in db.MstStudents
                           select new ApiModels.Student_Model
                           {
                               Id = d.Id,
                               StudentCode = d.StudentCode,
                               FullName = d.FullName,
                               CourseId = d.MstCourse.Id,
                               Course = d.MstCourse.Course
                           };

            return students.OrderBy(d => d.StudentCode).ToList();
        }

        [HttpGet, Route("detail/{studentId}")]
        public ApiModels.Student_Model DetailStudent(String studentId)
        {
            var student = from d in db.MstStudents
                          where d.Id == Convert.ToInt32(studentId)
                          select new ApiModels.Student_Model
                          {
                              Id = d.Id,
                              StudentCode = d.StudentCode,
                              FullName = d.FullName,
                              CourseId = d.MstCourse.Id,
                              Course = d.MstCourse.Course
                          };

            return student.FirstOrDefault();
        }

        [HttpPost, Route("api/student/add")]
        public HttpResponseMessage AddStudent(ApiModels.Student_Model objStudent)
        {
            try
            {

                var course = from d in db.MstCourses
                             where d.Id == objStudent.CourseId
                             select d;

                if (course.Any())
                {
                    Data.MstStudent newStudent = new Data.MstStudent
                    {
                        StudentCode = objStudent.StudentCode,
                        FullName = objStudent.FullName,
                        CourseId = course.FirstOrDefault().Id,
                    };

                    db.MstStudents.InsertOnSubmit(newStudent);
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut, Route("api/student/update/{studentId}")]
        public HttpResponseMessage UpdateStudent(String studentId, ApiModels.Student_Model objStudent)
        {
            try
            {
                var student = from d in db.MstStudents
                              where d.Id == Convert.ToInt32(studentId)
                              select d;

                var course = from d in db.MstCourses
                             where d.Id == objStudent.CourseId
                             select d;

                if (!course.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Course not found!");
                }

                if (student.Any())
                {
                    var updateStudent = student.FirstOrDefault();
                    updateStudent.StudentCode = objStudent.StudentCode;
                    updateStudent.FullName = objStudent.FullName;
                    updateStudent.CourseId = course.FirstOrDefault().Id;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully added!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        [HttpDelete, Route("delete/{studentId}")]
        public HttpResponseMessage DeleteStudent(String studentId)
        {
            try
            {
                var student = from d in db.MstStudents
                              where d.Id == Convert.ToInt32(studentId)
                              select d;

                if (student.Any())
                {
                    db.MstStudents.DeleteOnSubmit(student.FirstOrDefault());
                    db.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }
    }
}
