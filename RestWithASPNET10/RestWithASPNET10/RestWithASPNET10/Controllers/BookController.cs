using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Models;
using RestWithASPNET10.Services.Book.Interface;

namespace RestWithASPNET10.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookController : ControllerBase
    {
		private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
			_bookService = bookService;
            _logger = logger;
        }

		[HttpGet]
		public IActionResult Get()
		{
			_logger.LogInformation("Fetching all books");
			return Ok(_bookService.FindAll());
		}

		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			_logger.LogInformation("Fetching books with ID {id}", id);
			var book = _bookService.FindById(id);

			if (book == null)
			{
				_logger.LogWarning("Book with ID {id} not found", id);
				return NotFound();
			}
			;

			return Ok(book);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Book book)
		{
			_logger.LogInformation("Creating new book: {title}", book.Title);
			var createdBook = _bookService.Create(book);

			if (createdBook == null)
			{
				_logger.LogError("Failed to create book: {title}", book.Title);
				return NotFound();
			};

			_logger.LogDebug("Book created with successfully: {title}", createdBook.Title);
			return Ok(createdBook);
		}

		[HttpPut]
		public IActionResult Put([FromBody] Book book)
		{
			_logger.LogInformation("Updating book with ID {id}", book.Id);
			var createdBook = _bookService.Update(book);

			if (createdBook == null)
			{
				_logger.LogError("Book with ID {id} not found for update", book.Id);
				return NotFound();
			}
			;

			_logger.LogDebug("Book updated successfully: {title}", createdBook.Title);
			return Ok(createdBook);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_logger.LogInformation("Deleting book with ID {id}", id);
			_bookService.Delete(id);

			_logger.LogDebug("Book with ID {id} deleted successfully", id);
			return NoContent();
		}
	}
}
