using AutoMapper;
using WebShop.Data.Entities.Shopping;
using WebShop.Services.Models.Shopping;
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
            Mapper.CreateMap<OrderModel, OrderEntity>();
            Mapper.CreateMap<OrderLineModel, OrderLineEntity>();
            Mapper.CreateMap<CustomerModel, CustomerEntity>();
        }
    }
}