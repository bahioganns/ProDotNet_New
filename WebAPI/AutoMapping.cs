using AutoMapper;

using DataAccess.Entities;
using DTO;
using Domain;
using Domain.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        // Visitor
        CreateMap<Domain.Visitor, DataAccess.Entities.Visitor>().ReverseMap();
        CreateMap<VisitorUpdateModel, DataAccess.Entities.Visitor>().ReverseMap();
        CreateMap<VisitorDTO, VisitorUpdateModel>().ReverseMap();
        CreateMap<Domain.Visitor, VisitorDTO>().ReverseMap();
        // Book
        CreateMap<Domain.Book, DataAccess.Entities.Book>().ReverseMap();
        CreateMap<BookUpdateModel, DataAccess.Entities.Book>().ReverseMap();
        CreateMap<BookDTO, BookUpdateModel>().ReverseMap();
        CreateMap<Domain.Book, BookDTO>().ReverseMap();
    }
}