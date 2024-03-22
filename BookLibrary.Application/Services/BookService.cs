using AutoMapper;
using BookLibrary.Application.Dtos;
using BookLibrary.Application.Services.Interfaces;
using BookLibrary.Domain.UnitOfWork;

namespace BookLibrary.Application.Services
{
	public class BookService : IBookService
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public BookService(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<BookDto>> GetAll() => _mapper.Map<IEnumerable<BookDto>>(await _unitOfWork.BookRepository.GetAllAsync());
	}
}