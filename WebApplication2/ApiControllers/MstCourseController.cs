using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstCourseController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/student/course/list")]
        public List<ApiModels.MstCourseModel> ListCourse()
        {
            var courses = from d in db.MstCourses
                          select new ApiModels.MstCourseModel
                          {
                              Id = d.Id,
                              CourseCode = d.CourseCode,
                              Course = d.Course
                          };

            return courses.ToList();

        }

        [Authorize, HttpGet, Route("api/student/course/detail/{id}")]
        public ApiModels.MstCourseModel DetailCourse(String id)
        {
            var course = from d in db.MstCourses
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstCourseModel
                         {
                             Id = d.Id,
                             CourseCode = d.CourseCode,
                             Course = d.Course
                         };

            return course.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/course/add")]
        public HttpResponseMessage AddCourse(ApiModels.MstCourseModel objCourse)
        {
            try
            {
                Data.MstCourse newCourse = new Data.MstCourse
                {
                    CourseCode = objCourse.CourseCode,
                    Course = objCourse.Course
                };
                db.MstCourses.InsertOnSubmit(newCourse);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/course/update/{id}")]
        public HttpResponseMessage UpdateCourse(ApiModels.MstCourseModel objCourse, String id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (course.Any())
                {
                    var updateCourse = course.FirstOrDefault();
                    updateCourse.CourseCode = objCourse.CourseCode;
                    updateCourse.Course = objCourse.Course;
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpDelete, Route("api/course/delete/{id}")]
        public HttpResponseMessage DeleteCourse(String id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (course.Any())
                {
                    db.MstCourses.DeleteOnSubmit(course.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Course data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
