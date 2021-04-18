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
using static BusinessLogic.Contracts.IVisitorServices;
using static BusinessLogic.Contracts.IBookServices;




namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly ILogger<VisitorController> _logger;

        private IMapper Mapper { get; }
        private IVisitorCreateService VisitorCreateService { get; }
        private IVisitorGetService VisitorGetService { get; }
        private IVisitorUpdateService VisitorUpdateService { get; }
        private IVisitorDeleteService VisitorDeleteService { get; }

        private IBookCreateService BookCreateService { get; }
        private IBookGetService BookGetService { get; }

        public VisitorController(ILogger<VisitorController> logger, IMapper mapper, IVisitorCreateService userCreateService, IVisitorGetService userGetService, IVisitorUpdateService userUpdateService, IVisitorDeleteService userDeleteService, IBookGetService noteGetService, IBookCreateService noteCreateService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.VisitorCreateService = userCreateService;
            this.VisitorGetService = userGetService;
            this.VisitorUpdateService = userUpdateService;
            this.VisitorDeleteService = userDeleteService;

            this.BookCreateService = noteCreateService;
            this.BookGetService = noteGetService;
        }

        [HttpPost]
        public VisitorDTO CreateVisitor(VisitorDTO user)
        {
            var updateModel = Mapper.Map<VisitorUpdateModel>(user);

            VisitorCreateService.ValidateVisitor(updateModel);
            Visitor res = VisitorCreateService.CreateVisitor(updateModel);

            return Mapper.Map<VisitorDTO>(res);
        }

        [HttpPost("{id}/notes")]
        public BookDTO CreateVisitorBook(int id, BookDTO note)
        {
            note.VisitorId = id;

            return Mapper.Map<BookDTO>(BookCreateService.CreateBook(Mapper.Map<BookUpdateModel>(note)));
        }

        [HttpGet]
        public IEnumerable<VisitorDTO> GetAllVisitors()
        {
            return VisitorGetService.GetAllVisitors().Select(x => Mapper.Map<VisitorDTO>(x)).ToList();
        }

        [HttpGet("{id}")]
        public VisitorDTO GetVisitor(int id)
        {
            return Mapper.Map<VisitorDTO>(VisitorGetService.GetVisitor(new VisitorIdentityModel(id)));
        }

        [HttpGet("{id}/notes")]
        public IEnumerable<BookDTO> GetVisitorBooks(int id)
        {
            return BookGetService.GetVisitorBooks(new VisitorIdentityModel(id)).Select(x => Mapper.Map<BookDTO>(x)).ToList();
        }

        [HttpPut("{id}")]
        public VisitorDTO UpdateVisitor(int id, VisitorDTO user)
        {
            var identityModel = new VisitorIdentityModel(id);
            var updateModel = Mapper.Map<VisitorUpdateModel>(user);

            Visitor res = VisitorUpdateService.UpdateVisitor(identityModel, updateModel);

            return Mapper.Map<VisitorDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeleteVisitor(int id)
        {
            var identityModel = new VisitorIdentityModel(id);
            VisitorDeleteService.DeleteVisitor(identityModel);
        }
    }
}
