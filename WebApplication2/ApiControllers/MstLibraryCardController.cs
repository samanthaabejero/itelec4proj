
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstLibraryCardController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/librarycard/list")]
        public List<ApiModels.MstLibraryCardModel> ListLibraryCard()
        {
            var libcards = from d in db.MstLibraryCard
                          select new ApiModels.MstLibraryCardModel
                          {
                              Id = d.Id,
                              LibraryCardNumber = d.LibraryCardNumber,
                              ManualLibraryCardNumber = d.ManualLibraryCardNumber,
                              BorrowerId = d.BorrowerId,
                              IsPrinted = d.IsPrinted,
                              LibraryInChargeUserId = d.LibraryInChargeUserId,
                              FootNote = d.FootNote,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate
                          };

            return libcards.ToList();

        }

        [Authorize, HttpGet, Route("api/librarycard/detail/{id}")]
        public ApiModels.MstLibraryCardModel DetailLibraryCard(String id)
        {
            var libcards = from d in db.MstLibraryCard
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstLibraryCardModel
                         {
                              LibraryCardNumber = d.LibraryCardNumber,
                              ManualLibraryCardNumber = d.ManualLibraryCardNumber,
                              BorrowerId = d.BorrowerId,
                              IsPrinted = d.IsPrinted,
                              LibraryInChargeUserId = d.LibraryInChargeUserId,
                              FootNote = d.FootNote,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedDate = d.UpdatedDate
                         };

            return libcards.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/librarycard/add")]
        public HttpResponseMessage AddLibraryCard(ApiModels.MstLibraryCardModel objLibraryCard)
        {
            try
            {
                Data.MstLibraryCard newLibraryCard = new Data.MstLibraryCard
                {
                      LibraryCardNumber = objLibraryCard.LibraryCardNumber,
                      ManualLibraryCardNumber = objLibraryCard.ManualLibraryCardNumber,
                      BorrowerId = objLibraryCard.BorrowerId,
                      IsPrinted = objLibraryCard.IsPrinted,
                      LibraryInChargeUserId = objLibraryCard.LibraryInChargeUserId,
                      FootNote = objLibraryCard.FootNote,
                      CreatedByUserId = objLibraryCard.CreatedByUserId,
                      CreatedDate = objLibraryCard.CreatedDate,
                      UpdatedByUserId = objLibraryCard.UpdatedByUserId,
                      UpdatedDate = objLibraryCard.UpdatedDate
                };
                db.MstLibraryCard.InsertOnSubmit(newLibraryCard);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/librarycard/update/{id}")]
        public HttpResponseMessage UpdateLibraryCard(ApiModels.MstLibraryCardModel objLibraryCard, String id)
        {
            try
            {
                var libcards = from d in db.MstLibraryCard
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (libcards.Any())
                {
                    var updateLibraryCard = libcards.FirstOrDefault();
                      updateLibraryCard.LibraryCardNumber = objLibraryCard.LibraryCardNumber;
                      updateLibraryCard.ManualLibraryCardNumber = objLibraryCard.ManualLibraryCardNumber; 
                      updateLibraryCard.BorrowerId = objLibraryCard.BorrowerId;
                      updateLibraryCard.IsPrinted = objLibraryCard.IsPrinted;
                      updateLibraryCard.LibraryInChargeUserId = objLibraryCard.LibraryInChargeUserId;
                      updateLibraryCard.FootNote = objLibraryCard.FootNote;
                      updateLibraryCard.CreatedByUserId = objLibraryCard.CreatedByUserId;
                      updateLibraryCard.CreatedDate = objLibraryCard.CreatedDate;
                      updateLibraryCard.UpdatedByUserId = objLibraryCard.UpdatedByUserId;
                      updateLibraryCard.UpdatedDate = objLibraryCard.UpdatedDate;
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
             [Authorize, HttpDelete, Route("api/librarycard/delete/{id}")]
        public HttpResponseMessage DeleteLibraryCard(String id)
        {
            try
            {
                var libcards = from d in db.MstLibraryCard
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (libcards.Any())
                {
                    db.MstLibraryCard.DeleteOnSubmit(libcards.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Library card data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
