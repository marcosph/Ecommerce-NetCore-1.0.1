using AutoMapper;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Domain.CommandHandlers;
using Ecommerce.Domain.Commands;
using Ecommerce.Domain.Core.Bus;
using Ecommerce.Domain.Core.Events;
using Ecommerce.Domain.Core.Notifications;
using Ecommerce.Domain.EventHandlers;
using Ecommerce.Domain.Events;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.CrossCutting.Bus;
using Ecommerce.Infra.CrossCutting.Identity.Authorization;
using Ecommerce.Infra.CrossCutting.Identity.Models;
using Ecommerce.Infra.CrossCutting.Identity.Services;
using Ecommerce.Infra.Data.Context;
using Ecommerce.Infra.Data.EventSourcing;
using Ecommerce.Infra.Data.Repository;
using Ecommerce.Infra.Data.Repository.EventSourcing;
using Ecommerce.Infra.Data.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }

    }
}
