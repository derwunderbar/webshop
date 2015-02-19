using AutoMapper;
using WebShop.Data.Entities.Profile;
using WebShop.Data.Entities.Shopping;
using WebShop.Services.Models;
using WebShop.Services.Models.Catalog;
using WebShop.Services.Models.Shopping;
using WebShop.ViewModels;
using WebShop.ViewModels.Catalog;
using WebShop.ViewModels.Shopping;

namespace WebShop
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            RegisterModelViewModelMappings();
            RegisterModelEntityMappings();
        }

        public static void RegisterModelViewModelMappings()
        {
            // Catalog types
            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<Author, AuthorViewModel>();
            Mapper.CreateMap<Publisher, PublisherViewModel>();

            // Shopping types
            Mapper.CreateMap<CustomerViewModel, CustomerModel>();
            Mapper.CreateMap<CheckoutViewModel, OrderModel>()
                .ForMember(d => d.Lines, o => o.ResolveUsing(s => s.Items));
            Mapper.CreateMap<ShoppingCartItemViewModel, OrderLineModel>()
                .ForMember(d => d.ArticleId, o => o.ResolveUsing(s => s.Id))
                .ForMember(d => d.Id, o => o.Ignore());
        }

        public static void RegisterModelEntityMappings()
        {
            Mapper.CreateMap<OrderModel, OrderEntity>()
                .ForMember(d => d.UserId, o => o.ResolveUsing(s => s.UserId));
            Mapper.CreateMap<OrderLineModel, OrderLineEntity>();
            Mapper.CreateMap<CustomerModel, CustomerEntity>();
            Mapper.CreateMap<UserProfileEntity, UserProfile>();
        }
    }
}