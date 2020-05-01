using System;
using AutoMapper;
using Fox.Common.Models;
using Fox.Repository.Models;

namespace Fox.Core.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //From Model to DTO
            CreateMap<Fox.Common.Models.BaseModel, Fox.Repository.Models.BaseModel>();
            CreateMap<Item, ItemDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Image, ImageDto>();

            //From DTO to Model
            CreateMap<Fox.Repository.Models.BaseModel, Fox.Common.Models.BaseModel>();
            CreateMap<ItemDto, Item>();
            CreateMap<CartItemDto, CartItem>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ImageDto, Image>();
        }
    }
}
