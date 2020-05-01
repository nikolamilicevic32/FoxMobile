using System;
namespace Fox.Repository.Models
{
    public class CartItemDto : ItemDto
    {

        public CartItemDto()
        {
        }

        public CartItemDto(ItemDto itemModel)
        { 
            Id = new Guid();
            Name = itemModel.Name;
            Description = itemModel.Description;
            Cover = itemModel.Cover;
            Price = itemModel.Price;
            Featured = itemModel.Featured;
            OnPromotion = itemModel.OnPromotion;
            IsNew = itemModel.IsNew;
            Date = itemModel.Date;
            Images = itemModel.Images;
            CategoryId = itemModel.CategoryId;
            CategoryName = itemModel.CategoryName;
        }
    }
}
