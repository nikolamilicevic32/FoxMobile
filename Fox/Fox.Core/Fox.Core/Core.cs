using System.Threading.Tasks;
using AutoMapper;
using Fox.Common.Models;
using Fox.Core.Services;
using Fox.Core.ViewModels;
using Fox.DataProvider;
using Fox.DataProvider.InterfaceServices;
using Fox.DataProvider.Services;
using Fox.MailServices;
using Fox.Presentation.Abstraction;
using Fox.Presentation.Infrastructure;
using Fox.Repository;
using Fox.Repository.Models;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Fox.Core
{
    public class Core : MvxApplication
    {
        public override void Initialize()
        {
            //DEPENDECY INJECTION CONTAINER
            //The next line tells the IoC Container that whenever any code requests an ISomeInterface reference,
            //an object of type SomeService should be created and returned.

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMapper>(config.CreateMapper);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICategoryService, CategoryService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IItemService, ItemService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IGenericRepository<ItemDto>, GenericRepository<ItemDto>>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IGenericRepository<CartItemDto>, GenericRepository<CartItemDto>>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IGenericRepository<CategoryDto>, GenericRepository<CategoryDto>>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMailService, MailService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<INavigationService, NavigationService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICartItemPresentation, CartItemPresentation>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IItemPresnetation, ItemPresentation>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICategoryPresentation, CategoryPresentation>();

            RegisterAppStart<MasterDetailViewModel>();

            //Task.Run(async () => await Mvx.IoCProvider.Resolve<IItemPresnetation>().GetLatestItemsFromApi()).ConfigureAwait(false);
        }
    }
}
