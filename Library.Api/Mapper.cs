using System.Data;
using AutoMapper;
using Library.Api.PostModel;
using Library.Core.Entities;

namespace Library.Api
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Book, BookPostModel>().ReverseMap();
            CreateMap<Branch, BranchPostModel>().ReverseMap();
            CreateMap<Partner, PartnerPostModel>().ReverseMap();
        }
    }
}


