using System.Collections.Generic;
using System.Threading.Tasks;
using TestHBSISExercicio1.DTO;

namespace TestHBSISExercicio1.Services
{
    public interface IBookService
    {
        Task<BookDTO> GetById(long Id);
        Task<List<BookDTO>> GetAllOrderByName();
        Task<BookDTO> Save(BookDTO dto);
        Task Edit(long Id, BookDTO dto);
        Task<BookDTO> Delete(long id);
    }
}
