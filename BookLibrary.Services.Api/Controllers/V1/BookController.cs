using Asp.Versioning;
using BookLibrary.Application.Dtos;
using BookLibrary.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookLibrary.Services.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	public class BookController : ApiController
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}


		[SwaggerOperation(Summary = "Get all books")]
		[HttpGet("books", Name = nameof(GetAll))]
		public async Task<IEnumerable<BookDto>> GetAll() => await _bookService.GetAll();
	}
}
