using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DTO;
using BusinessLogic.Contracts;
using Domain;
using Domain.Models;
using static BusinessLogic.Contracts.IBookServices;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private IMapper Mapper { get; }
        private IBookCreateService BookCreateService { get; }
        private IBookGetService BookGetService { get; }
        private IBookUpdateService BookUpdateService { get; }
        private IBookDeleteService BookDeleteService { get; }

        public BookController(ILogger<BookController> logger, IMapper mapper, IBookCreateService noteCreateService, IBookGetService noteGetService, IBookUpdateService noteUpdateService, IBookDeleteService noteDeleteService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.BookCreateService = noteCreateService;
            this.BookGetService = noteGetService;
            this.BookUpdateService = noteUpdateService;
            this.BookDeleteService = noteDeleteService;
        }

        [HttpGet("{id}")]
        public BookDTO GetBook(int id)
        {
            return Mapper.Map<BookDTO>(BookGetService.GetBook(new BookIdentityModel(id)));
        }

        [HttpPut("{id}")]
        public BookDTO UpdateBook(int id, BookDTO note)
        {
            var identityModel = new BookIdentityModel(id);
            var updateModel = Mapper.Map<BookUpdateModel>(note);

            Book res = BookUpdateService.UpdateBook(identityModel, updateModel);

            return Mapper.Map<BookDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            var identityModel = new BookIdentityModel(id);
            BookDeleteService.DeleteBook(identityModel);
        }
    }
}