using AutoMapper;
using BookLibrary.Application.Dtos;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}