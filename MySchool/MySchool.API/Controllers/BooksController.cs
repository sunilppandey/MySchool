using AutoMapper;
using MySchool.API.Models;
using MySchool.Infrastructure;
using MySchool.Model.Entities;
using MySchool.Model.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySchool.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the BooksController class.
        /// </summary>
        public BooksController(IBookRepository bookRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _bookRepository = bookRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        [Authorize]
        [Route("books")]
        public HttpResponseMessage GetBooks()
        {
            HttpResponseMessage response = null;

            var books = _bookRepository.FindAll();

            IEnumerable<BookModel> bookVM = Mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);

            response = Request.CreateResponse(HttpStatusCode.OK, bookVM);

            return response;
        }

        [Authorize]
        [Route("add")]
        public HttpResponseMessage Add(BookModel bookModel)
        {
            HttpResponseMessage response = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var book = new Book()
                    {
                        Title = bookModel.Title,
                        Description = bookModel.Description,
                        Author = bookModel.Author
                    };

                    using (_unitOfWorkFactory.Create())
                    {
                        _bookRepository.Add(book);
                    }

                    if (book.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Created, book);
                    }
                    else
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                    }
                }

                return response;
            }
            finally
            {

            }
        }

        [Route("findByAuthor/{author}")]
        public HttpResponseMessage FindByAuthor(string author)
        {
            HttpResponseMessage response = null;

            var books = _bookRepository.FindByAuthor(author);

            BookModel bookVM = Mapper.Map<BookModel>(books);
            //Mapper.Map(books, bookVM);

            response = Request.CreateResponse(HttpStatusCode.OK, bookVM);

            return response;
        }
    }
}
