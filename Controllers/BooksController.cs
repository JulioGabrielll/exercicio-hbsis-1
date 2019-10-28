using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHBSISExercicio1.DTO;
using TestHBSISExercicio1.Services;

namespace TestHBSISExercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return await _bookService.GetAllOrderByName();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(long id)
        {
            var bookDTO = await _bookService.GetById(id);

            if (bookDTO == null)
            {
                return NotFound();
            }

            return bookDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, BookDTO dto)
        {
            await _bookService.Edit(id, dto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO dto)
        {
            return await _bookService.Save(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDTO>> DeleteBook(long id)
        {
            try
            {
                return await _bookService.Delete(id);
            } catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
