using BookLibrary.Application.Services;
using BookLibrary.Application.Services.Interfaces;
using BookLibrary.Domain.Core.Interfaces;
using BookLibrary.Domain.UnitOfWork;
using BookLibrary.Infra.Data.Repositories;
using BookLibrary.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infra.CrossCutting.IoC
{
    public static class InjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(IServiceCollection services) =>
            services
                .RegisterApplicationLayer()
                .RegisterDataLayer();

        private static IServiceCollection RegisterApplicationLayer(this IServiceCollection services) =>
            services
                .AddTransient(typeof(IBookService), typeof(BookService));

        private static IServiceCollection RegisterDataLayer(this IServiceCollection services) =>
             services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}