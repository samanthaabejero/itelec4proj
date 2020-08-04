using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstUserTypeController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/usertype/list")]
        public List<ApiModels.MstUserTypeModel> ListUserType()
        {
            var userstype = from d in db.MstUserType
                          select new ApiModels.MstUserTypeModel
                          {
                              Id = d.Id,
                              UserType = d.UserType
                          };

            return userstype.ToList();

        }

        [Authorize, HttpGet, Route("api/usertype/detail/{id}")]
        public ApiModels.MstUserTypeModel DetailUserType(String id)
        {
            var userstype = from d in db.MstUserType
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstUserTypeModel
                         {
                              Id = d.Id,
                              UserType = d.UserType         
                         };

            return userstype.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/usertype/add")]
        public HttpResponseMessage AddUserType(ApiModels.MstUserTypeModel objUserType)
        {
            try
            {
                Data.MstUserType newUserType = new Data.MstUserType
                {
                    UserType = objUserType.UserType
                };
                db.MstUserType.InsertOnSubmit(newUserType);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/usertype/update/{id}")]
        public HttpResponseMessage UpdateUserType(ApiModels.MstUserTypeModel objUserType, String id)
        {
            try
            {
                var userstype = from d in db.MstUserType
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (userstype.Any())
                {
                    var updateUserType = userstype.FirstOrDefault();
                    updateUserType.UserType = objUserType.UserType;
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
             [Authorize, HttpDelete, Route("api/usertype/delete/{id}")]
        public HttpResponseMessage DeleteUserType(String id)
        {
            try
            {
                var userstype = from d in db.MstUserType
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (userstype.Any())
                {
                    db.MstUserType.DeleteOnSubmit(userstype.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User type data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
