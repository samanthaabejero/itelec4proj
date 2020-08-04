

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.ApiControllers
{
    public class MstLibraryBookController : ApiController
    {
        Data.SampledbDataContext db = new Data.SampledbDataContext();

        [Authorize, HttpGet, Route("api/librarybook/list")]
        public List<ApiModels.MstLibraryBookModel> ListLibraryBook()
        {
            var libbooks = from d in db.MstLibraryBook
                          select new ApiModels.MstLibraryBookModel
                          {
                              Id = d.Id,
                              BookNumber = d.BookNumber,
                              Title = d.Title,
                              Author = d.Author,
                              EditionNumber = d.EditionNumber,
                              PlaceOfPublication = d.PlaceOfPublication,
                              CopyRightDate = d.CopyRightDate,
                              ISBN = d.ISBN,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedBy = d.CreatedBy,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedBy = d.UpdatedBy,
                              UpdatedDate = d.UpdatedDate
                          };

            return libbooks.ToList();

        }

        [Authorize, HttpGet, Route("api/librarybook/detail/{id}")]
        public ApiModels.MstLibraryBookModel DetailLibraryBook(String id)
        {
            var libbooks = from d in db.MstLibraryBook
                         where d.Id == Convert.ToInt32(id)
                         select new ApiModels.MstLibraryBookModel
                         {
                              BookNumber = d.BookNumber,
                              Title = d.Title,
                              Author = d.Author,
                              EditionNumber = d.EditionNumber,
                              PlaceOfPublication = d.PlaceOfPublication,
                              CopyRightDate = d.CopyRightDate,
                              ISBN = d.ISBN,
                              CreatedByUserId = d.CreatedByUserId,
                              CreatedBy = d.CreatedBy,
                              CreatedDate = d.CreatedDate,
                              UpdatedByUserId = d.UpdatedByUserId,
                              UpdatedBy = d.UpdatedBy,
                              UpdatedDate = d.UpdatedDate
                         };

            return libbooks.FirstOrDefault();
        }

        [Authorize, HttpPost, Route("api/librarybook/add")]
        public HttpResponseMessage AddLibraryBook(ApiModels.MstLibraryBookModel objLibraryBook)
        {
            try
            {
                Data.MstLibraryBook newLibraryBook = new Data.MstLibraryBook
                {
                              BookNumber = objLibraryBook.BookNumber,
                              Title =objLibraryBook.Title,
                              Author = objLibraryBook.Author,
                              EditionNumber = objLibraryBook.EditionNumber,
                              PlaceOfPublication = objLibraryBook.PlaceOfPublication,
                              CopyRightDate = objLibraryBook.CopyRightDate,
                              ISBN = objLibraryBook.ISBN,
                              CreatedByUserId = objLibraryBook.CreatedByUserId,
                              CreatedBy = objLibraryBook.CreatedBy,
                              CreatedDate = objLibraryBook.CreatedDate,
                              UpdatedByUserId = objLibraryBook.UpdatedByUserId,
                              UpdatedBy = objLibraryBook.UpdatedBy,
                              UpdatedDate = objLibraryBook.UpdatedDate
                };
                db.MstLibraryBook.InsertOnSubmit(newLibraryBook);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize, HttpPut, Route("api/librarybook/update/{id}")]
        public HttpResponseMessage UpdateLibraryBook(ApiModels.MstLibraryBookModel objLibraryBook, String id)
        {
            try
            {
                var libbooks = from d in db.MstLibraryBook
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (libbooks.Any())
                {
                    var updateLibraryBook = libbooks.FirstOrDefault();
                      updateLibraryBook.BookNumber = objLibraryBook.BookNumber;
                      updateLibraryBook.Title =objLibraryBook.Title;
                      updateLibraryBook.Author = objLibraryBook.Author;
                      updateLibraryBook.EditionNumber = objLibraryBook.EditionNumber;
                      updateLibraryBook.PlaceOfPublication = objLibraryBook.PlaceOfPublication;
                      updateLibraryBook.CopyRightDate = objLibraryBook.CopyRightDate;
                      updateLibraryBook.ISBN = objLibraryBook.ISBN;
                      updateLibraryBook.CreatedByUserId = objLibraryBook.CreatedByUserId;
                      updateLibraryBook.CreatedBy = objLibraryBook.CreatedBy;
                      updateLibraryBook.CreatedDate = objLibraryBook.CreatedDate;
                      updateLibraryBook.UpdatedByUserId = objLibraryBook.UpdatedByUserId;
                      updateLibraryBook.UpdatedBy = objLibraryBook.UpdatedBy;
                      updateLibraryBook.UpdatedDate = objLibraryBook.UpdatedDate;
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
             [Authorize, HttpDelete, Route("api/librarybook/delete/{id}")]
        public HttpResponseMessage DeleteLibraryBook(String id)
        {
            try
            {
                var libbooks = from d in db.MstLibraryBook
                             where d.Id == Convert.ToInt32(id)
                             select d;

                if (libbooks.Any())
                {
                    db.MstLibraryBook.DeleteOnSubmit(libbooks.FirstOrDefault());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Library book data not found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }
   
