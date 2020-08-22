using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.D0045.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RepositoryNameFromLocalDirectoryPathConvention"/> implementation of <see cref="IRepositoryNameFromLocalDirectoryPathConvention"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRepositoryNameFromLocalDirectoryPathConvention(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<IRepositoryNameFromLocalDirectoryPathConvention, RepositoryNameFromLocalDirectoryPathConvention>()
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RepositoryNameFromLocalDirectoryPathConvention"/> implementation of <see cref="IRepositoryNameFromLocalDirectoryPathConvention"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRepositoryNameFromLocalDirectoryPathConvention> AddRepositoryNameFromLocalDirectoryPathConventionAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IRepositoryNameFromLocalDirectoryPathConvention>(() => services.AddRepositoryNameFromLocalDirectoryPathConvention(
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
