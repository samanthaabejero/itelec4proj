
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstUserController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/user/list")]
        public List<ApiModels.MstUserModel> ListUser()
        {
            var users = from d in db.MstUser
                          select new ApiModels.MstUserModel
                          {
                              Id = d.Id,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Password = d.Password,
                              UserTypeId = d.UserTypeId,
                              AspNetUserId = d.AspNetUserId,
                              UserName = d.UserName,
                              Email = d.Email
                          };

            return users.ToList();

        }

        [Authorize, HttpGet, Route("api/user/detail/{id}")]
        public ApiModels.MstUserModel DetailUser(String id)
        {
            var users = from d in db.MstUser
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstUserModel
                         {
                              Id = d.Id,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Password = d.Password,
                              UserTypeId = d.UserTypeId,
                              AspNetUserId = d.AspNetUserId,
                              UserName = d.UserName,
                              Email = d.Email
                         };

            return users.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/user/add")]
        public HttpResponseMessage AddUser(ApiModels.MstUserModel objUser)
        {
            try
            {
                Data.MstUser newUser = new Data.MstUser
                {
                    FirstName = objUser.FirstName,
                    LastName = objUser.LastName,
                    Password = objUser.Password,
                    UserTypeId = objUser.UserTypeId,
                    AspNetUserId = objUser.AspNetUserId,
                    UserName = objUser.UserName,
                    Email = objUser.Email
                };
                db.MstUser.InsertOnSubmit(newUser);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/user/update/{id}")]
        public HttpResponseMessage UpdateUser(ApiModels.MstUserModel objUser, String id)
        {
            try
            {
                var users = from d in db.MstUser
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (users.Any())
                {
                    var updateUser = users.FirstOrDefault();
                    updateUser.FirstName = objUser.FirstName;
                    updateUser.LastName = objUser.LastName;
                    updateUser.Password = objUser.Password;
                    updateUser.UserTypeId = objUser.UserTypeId;
                    updateUser.AspNetUserId = objUser.AspNetUserId;
                    updateUser.UserName = objUser.UserName;
                    updateUser.Email = objUser.Email;
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
             [Authorize, HttpDelete, Route("api/user/delete/{id}")]
        public HttpResponseMessage DeleteUser(String id)
        {
            try
            {
                var users = from d in db.MstUser
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (users.Any())
                {
                    db.MstUser.DeleteOnSubmit(users.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
