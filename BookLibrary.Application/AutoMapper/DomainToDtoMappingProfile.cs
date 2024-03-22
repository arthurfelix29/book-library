using AutoMapper;
using BookLibrary.Application.Dtos;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}