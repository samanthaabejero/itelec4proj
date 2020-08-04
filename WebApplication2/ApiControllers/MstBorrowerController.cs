
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstBorrowerController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/borrower/list")]
        public List<ApiModels.MstBorrowerModel> ListBorrower()
        {
            var borrowers = from d in db.MstBorrower
                          select new ApiModels.MstBorrowerModel
                          {
                              Id = d.Id,
                              BorrowerNumber = d.BorrowerNumber,
                              ManualBorrowerNumber = d.ManualBorrowerNumber,
                              FullName = d.FullName,
                              Department = d.Department,
                              Course = d.Course,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate,
                              BorrowerTypeId = d.BorrowerTypeId,
                              LibraryCardId = d.LibraryCardId
                          };

            return borrowers.ToList();

        }

        [Authorize, HttpGet, Route("api/borrower/detail/{id}")]
        public ApiModels.MstBorrowerModel DetailBorrower(String id)
        {
            var borrowers = from d in db.MstBorrower
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstBorrowerModel
                         {
                              BorrowerNumber = d.BorrowerNumber,
                              ManualBorrowerNumber = d.ManualBorrowerNumber,
                              FullName = d.FullName,
                              Department = d.Department,
                              Course = d.Course,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate,
                              BorrowerTypeId = d.BorrowerTypeId,
                              LibraryCardId = d.LibraryCardId
                         };

            return borrowers.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/borrower/add")]
        public HttpResponseMessage AddBorrower(ApiModels.MstBorrowerModel objBorrower)
        {
            try
            {
                Data.MstBorrower newBorrower = new Data.MstBorrower
                {
                     BorrowerNumber = objBorrower.BorrowerNumber,
                     ManualBorrowerNumber = objBorrower.ManualBorrowerNumber,
                     FullName = objBorrower.FullName,
                     Department = objBorrower.Department,
                     Course = objBorrower.Course,
                     CreatedByUserId =objBorrower.CreatedByUserId,
                     CreatedDate = objBorrower.CreatedDate,
                     UpdatedByUserId = objBorrower.UpdatedByUserId,
                     UpdatedDate = objBorrower.UpdatedDate,
                     BorrowerTypeId = objBorrower.BorrowerTypeId,
                     LibraryCardId = objBorrower.LibraryCardId
                };
                };
                db.MstBorrower.InsertOnSubmit(newBorrower);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/borrower/update/{id}")]
        public HttpResponseMessage UpdateBorrower(ApiModels.MstBorrowerModel objBorrower, String id)
        {
            try
            {
                var borrowers = from d in db.MstBorrower
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (libcards.Any())
                {
                    var updateBorrower = borrowers.FirstOrDefault();
                     updateBorrower'BorrowerNumber = objBorrower.BorrowerNumber;
                     updateBorrower.ManualBorrowerNumber = objBorrower.ManualBorrowerNumber;
                     updateBorrower.FullName = objBorrower.FullName;
                     updateBorrower.Department = objBorrower.Department;
                     updateBorrower.Course = objBorrower.Course;
                     updateBorrower.CreatedByUserId =objBorrower.CreatedByUserId;
                     updateBorrower.CreatedDate = objBorrower.CreatedDate;
                     updateBorrower.UpdatedByUserId = objBorrower.UpdatedByUserId;
                     updateBorrower.UpdatedDate = objBorrower.UpdatedDate;
                     updateBorrower.BorrowerTypeId = objBorrower.BorrowerTypeId;
                     updateBorrower.LibraryCardId = objBorrower.LibraryCardId;
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
             [Authorize, HttpDelete, Route("api/borrower/delete/{id}")]
        public HttpResponseMessage DeleteBorrower(String id)
        {
            try
            {
                var borrowers = from d in db.MstBorrower
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if borrowers.Any())
                {
                    db.MstBorrower.DeleteOnSubmit(borrowets.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "borrower data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
