using TestHBSISExercicio1.DTO;
using TestHBSISExercicio1.Models;

namespace TestHBSISExercicio1.Translator
{
    public class BookTranslator
    {

        public BookDTO ToDTO(Book book)
        {
            BookDTO dto = new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Amount = book.Amount
            };
            return dto;
        }

        public Book ToEntity(BookDTO dto)
        {
            Book book = new Book
            {
                Id = dto.Id,
                Name = dto.Name,
                Amount = dto.Amount
            };
            return book;
        }
    }
}
