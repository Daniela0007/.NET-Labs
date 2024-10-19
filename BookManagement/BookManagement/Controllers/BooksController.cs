using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            command.Id = id; // comanda ia Id-ul din URL

            await mediator.Send(command);

            return NoContent();

        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteBook(Guid id, DeleteBookCommand command)
        //{
        //    await mediator.Send(new DeleteBookCommand { Id = id });

        //    return NoContent();
        //} 

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
