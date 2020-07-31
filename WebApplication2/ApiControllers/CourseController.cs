using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class CourseController : ApiController
    {
        Data.itelec4dbDataContext db = new Data.itelec4dbDataContext();

        [Authorize, HttpGet, Route("api/course/list")]
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

        [Authorize, HttpGet, Route("api/course/detail/{id}")]
        public ApiModels.Course_Model DetailCourse(String id)
        {

            var courses = from d in db.MstCourses
                          where d.Id == Convert.ToInt32(id)
                          select new ApiModels.Course_Model
                          {
                              Id = d.Id,
                              CourseCode = d.CourseCode,
                              Course = d.Course
                          };

            return courses.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/course/add")]
        public HttpResponseMessage AddCourse(ApiModels.Course_Model objCourse)
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
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize, HttpPut, Route("api/course/update/{id}")]
        public HttpResponseMessage UpdateCourse(ApiModels.Course_Model objCourse, String Id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(Id)
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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Course not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize, HttpDelete, Route("api/course/delete/{id}")]
        public HttpResponseMessage DeleteCourse(String Id)
        {
            try
            {
                var course = from d in db.MstCourses
                             where d.Id == Convert.ToInt32(Id)
                             select d;

                if (course.Any())
                {
                    db.MstCourses.DeleteOnSubmit(course.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
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
    }
}
    

