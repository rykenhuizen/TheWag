﻿namespace TheWag.Api.WagDB
{
    using AutoMapper;
    using TheWag.Api.WagDB.EF;
    using TheWag.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Tag, TagDTO>();
        }
    }
}
