using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHBSISExercicio1.DTO;
using TestHBSISExercicio1.Models;
using TestHBSISExercicio1.Translator;

namespace TestHBSISExercicio1.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;
        private readonly BookTranslator _bookTranslator;

        public BookService(BookContext context, BookTranslator bookTranslator) : base()
        {
            _context = context;
            _bookTranslator = bookTranslator;
        }

        public async Task Edit(long Id, BookDTO dto)
        {
            _context.Entry(_bookTranslator.ToEntity(dto)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
        }

        public async Task<List<BookDTO>> GetAllOrderByName()
        {
            var books = await _context.Books.OrderBy(book => book.Name).ToListAsync();
            var booksDTO = books.ConvertAll(book => _bookTranslator.ToDTO(book));
            return booksDTO;
        }

        public async Task<BookDTO> GetById(long Id)
        {
            var book = await _context.Books.FindAsync(Id);
            return book != null ? _bookTranslator.ToDTO(book) : null;
        }

        public async Task<BookDTO> Save(BookDTO dto)
        {
            var SavedBook = _context.Books.Add(_bookTranslator.ToEntity(dto));
            await _context.SaveChangesAsync();

            return _bookTranslator.ToDTO(SavedBook.Entity);
        }
        public async Task<BookDTO> Delete(long Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return _bookTranslator.ToDTO(book);
        }
    }
}
