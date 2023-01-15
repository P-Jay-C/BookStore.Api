using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;

namespace BookStore.Api.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
