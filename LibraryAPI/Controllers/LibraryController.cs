using LibraryAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class LibraryController : ApiController
    {
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/Library/InsertBook")]
        public String InsertBook([FromBody]Book book)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            var book_id = db.InsertBook(book.userid, book.title, book.genre, book.publication_year, book.authors, book.book_status, book.cover);
            return JsonConvert.SerializeObject(book_id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/Library/InsertReader")]
        public String InsertReader([FromBody]Reader reader)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            var reader_id = db.InsertReader(reader.userid, reader.first_name, reader.last_name, reader.email, reader.has_book);
            return JsonConvert.SerializeObject(reader_id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/Library/InsertLoan")]
        public String InsertLoan([FromBody]Loan loan)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            var loan_id = db.InsertLoan(loan.userid, loan.reader_id, loan.book_id, loan.loan_date, loan.if_closed);
            return JsonConvert.SerializeObject(loan_id);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/Library/GetBookByID/{bookID}")]
        public String GetBookByID(int bookID)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            var book = db.GetBookByID(bookID);
            return JsonConvert.SerializeObject(book);
        }


        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/Library/{userid}/GetAllBooks")]
        public String GetAllBooks(string userid)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            var books = db.GetAllBooks(userid);
            return JsonConvert.SerializeObject(books);
        }


        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        [Route("api/Library/UpdateBook")]
        public HttpResponseMessage UpdateBook([FromBody]Book book)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.UpdateBook(book.book_id, book.userid, book.title, book.genre, book.publication_year, book.authors, book.book_status, book.cover);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        [Route("api/Library/UpdateReader")]
        public HttpResponseMessage UpdateReader([FromBody]Reader reader)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.UpdateReader(reader.reader_id, reader.userid, reader.first_name, reader.last_name, reader.email, reader.has_book);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        [Route("api/Library/UpdateLoan")]
        public HttpResponseMessage UpdateLoan([FromBody]Loan loan)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.UpdateLoan(loan.loan_id, loan.userid, loan.reader_id, loan.book_id, loan.loan_date, loan.if_closed);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        [Route("api/Library/DeleteBook/{book_id}")]
        public HttpResponseMessage DeleteBook(int book_id)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.DeleteBook(book_id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        [Route("api/Library/DeleteReader/{reader_id}")]
        public HttpResponseMessage DeleteReader(int reader_id)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.DeleteReader(reader_id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        [Route("api/Library/DeleteLoan/{loan_id}")]
        public HttpResponseMessage DeleteLoan(int loan_id)
        {
            plibrarydbEntities db = new plibrarydbEntities();
            db.DeleteLoan(loan_id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
