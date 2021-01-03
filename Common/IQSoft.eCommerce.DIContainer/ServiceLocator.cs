using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.BusinessAccess.Implementation;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using IQSoft.eCommerce.ResourceAccess.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IQSoft.eCommerce.DIContainer
{
    public sealed class ServiceLocator
    {
        #region Variables
        private static ServiceLocator _Instance = default(ServiceLocator);
        private static Object _syncLock = new object();

        private IServiceCollection _serviceCollection = default(IServiceCollection);
        private IServiceProvider _serviceProvider = default(IServiceProvider);

        #endregion

        #region Constructor
        private ServiceLocator()
        {

        }
        #endregion

        #region Methods
        public void LoadContainer(IServiceCollection services)
        {
            /*
             * Transient: A new instance of the type is used every time the type is requested.
             * Scoped: A new instance of the type is created the first time it’s requested within a given HTTP request, and then re-used for all subsequent types resolved during that HTTP request.
             * Singleton: A single instance of the type is created once, and used by all subsequent requests for that type.
             */
            _serviceCollection = services;

            //_serviceCollection.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            //Data Access
            _serviceCollection.AddScoped<IUserDataAccess, UserDataAccess>();
            _serviceCollection.AddScoped<IPropertyDataAccess, PropertyDataAccess>();
            _serviceCollection.AddScoped<IGlobalizationDataAccess, GlobalizationDataAccess>();
            _serviceCollection.AddScoped<IDtsDataAccess, DtsDataAccess>();
            _serviceCollection.AddScoped<IActivityDataAccess, ActivityDataAccess>();
            
            //Business Access
            _serviceCollection.AddScoped<IUserBusinessAccess, UserBusinessAccess>();
            _serviceCollection.AddScoped<IPropertyBusinessAccess, PropertyBusinessAccess>();
            _serviceCollection.AddScoped<IGlobalizationBusinessAccess, GlobalizationBusinessAccess>();
            _serviceCollection.AddScoped<IDtsBusinessAccess, DtsBusinessAccess>();
            _serviceCollection.AddScoped<IActivityBusinessAccess, ActivityBusinessAccess>();

            _serviceCollection.AddScoped<UserContext, UserContext>();

            //Build Service Provider
            _serviceProvider = services.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return this._serviceProvider.GetService<T>();
        }

        #endregion

        #region Properties
        public static ServiceLocator Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_Instance == null) _Instance = new ServiceLocator();
                }
                return _Instance;
            }
        }

        #endregion
    }
}
