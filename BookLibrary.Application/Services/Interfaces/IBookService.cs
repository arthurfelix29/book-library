using BookLibrary.Application.Dtos;

namespace BookLibrary.Application.Services.Interfaces
{
	public interface IBookService
	{
		Task<IEnumerable<BookDto>> GetAll();
	}
}