


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class TrnBorrowerController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/trnborrow/list")]
        public List<ApiModels.TrnBorrowerModel> ListTrnBorrow()
        {
            var borrows = from d in db.TrnBorrow
                          select new ApiModels.TrnBorrowerModel
                          {
                              Id = d.Id,
                              BorrowNumber = d.BorrowNumberr,
                              BookNumber = d.BookNumber,
                              BorrowDate = d.BorrowDate,
                              ManualBorrowNumber = d.ManualBorrowNumber,
                              BorrowerId = d.BorrowerId,
                              LibraryCardId = d.LibraryCardId,
                              PreparedByUser = d.PreparedByUser,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedBy,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate
                          };

            return borrows.ToList();

        }

        [Authorize, HttpGet, Route("api/trnborrow/detail/{id}")]
        public ApiModels.TrnBorrowerModel DetailTrnBorrow(String id)
        {
            var borrows = from d in db.TrnBorrow
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.TrnBorrowerModel
                         {
                              BorrowNumber = d.BorrowNumberr,
                              BookNumber = d.BookNumber,
                              BorrowDate = d.BorrowDate,
                              ManualBorrowNumber = d.ManualBorrowNumber,
                              BorrowerId = d.BorrowerId,
                              LibraryCardId = d.LibraryCardId,
                              PreparedByUser = d.PreparedByUser,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedBy,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate
                         };

            return borrows.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/trnborrow/add")]
        public HttpResponseMessage AddTrnBorrow(ApiModels.TrnBorrowerModel objTrnBorrow)
        {
            try
            {
                Data.TrnBorrow newBorrow = new Data.TrnBorrow
                {
                              BorrowNumber = objTrnBorrow.BorrowNumberr,
                              BookNumber = objTrnBorrow.BookNumber,
                              BorrowDate = objTrnBorrow.BorrowDate,
                              ManualBorrowNumber = objTrnBorrow.ManualBorrowNumber,
                              BorrowerId = objTrnBorrow.BorrowerId,
                              LibraryCardId = objTrnBorrow.LibraryCardId,
                              PreparedByUser = objTrnBorrow.PreparedByUser,
                              CreatedByUserId = objTrnBorrow.CreatedByUserId,
                              CreatedDate = objTrnBorrow.CreatedBy,
                              UpdatedByUserId = objTrnBorrow.UpdatedByUserId,
                              UpdatedDate = objTrnBorrow.UpdatedDate
                };
                db.TrnBorrow.InsertOnSubmit(newTrnBorrow);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/trnborrow/update/{id}")]
        public HttpResponseMessage UpdateTrnBorrow(ApiModels.TrnBorrowerModel objTrnBorrow, String id)
        {
            try
            {
                var borrows = from d in db.TrnBorrow
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (borrows.Any())
                {
                    var updateTrnBorrow = borrows.FirstOrDefault();
                      updateTrnBorrow.BorrowNumber = objTrnBorrow.BorrowNumberr;
                      updateTrnBorrow.BookNumber = objTrnBorrow.BookNumber;
                      updateTrnBorrow.BorrowDate = objTrnBorrow.BorrowDate;
                      updateTrnBorrow.ManualBorrowNumber = objTrnBorrow.ManualBorrowNumber;
                      updateTrnBorrow.BorrowerId = objTrnBorrow.BorrowerId;
                      updateTrnBorrow.LibraryCardId = objTrnBorrow.LibraryCardId;
                      updateTrnBorrow.PreparedByUser = objTrnBorrow.PreparedByUser;
                      updateTrnBorrow.CreatedByUserId = objTrnBorrow.CreatedByUserId;
                      updateTrnBorrow.CreatedDate = objTrnBorrow.CreatedBy;
                      updateTrnBorrow.UpdatedByUserId = objTrnBorrow.UpdatedByUserId;
                      updateTrnBorrow.UpdatedDate = objTrnBorrow.UpdatedDate;
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
             [Authorize, HttpDelete, Route("api/trnborrow/delete/{id}")]
        public HttpResponseMessage DeleteTrnBorrow(String id)
        {
            try
            {
                var borrows = from d in db.TrnBorrow
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (borrows.Any())
                {
                    db.TrnBorrow.DeleteOnSubmit(borrows.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Trn Borrow data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
