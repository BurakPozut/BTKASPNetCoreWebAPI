﻿using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public BooksController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllbooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.BookService.GetOneBookById(id, false);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            if (book is null) 
                return BadRequest();

            _manager.BookService.CreateOneBook(book);

            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            if (book is null)
                return BadRequest(); // 400

            _manager.BookService.UpdateOneBook(id, book, true);

            return NoContent(); // 204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
           [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = _manager.BookService.GetOneBookById(id, true);

            bookPatch.ApplyTo(entity);
            _manager.BookService.UpdateOneBook(id,entity,true);

            return NoContent();
        }
    }
}
