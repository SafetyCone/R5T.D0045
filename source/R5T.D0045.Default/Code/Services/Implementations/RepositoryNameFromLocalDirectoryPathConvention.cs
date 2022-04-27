using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0010;
using R5T.T0064;


namespace R5T.D0045.Default
{
    [ServiceImplementationMarker]
    public class RepositoryNameFromLocalDirectoryPathConvention : IRepositoryNameFromLocalDirectoryPathConvention,
        IServiceImplementation
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public RepositoryNameFromLocalDirectoryPathConvention(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public Task<RepositoryName> GetRepositoryNameFromLocalDirectoryPath(LocalRepositoryDirectoryPath localRepositoryDirectoryPath)
        {
            // Example: C:\Code\DEV\Git\GitHub\SafetyCone\R5T.Aalborg\
            var directoryPath = localRepositoryDirectoryPath.Value;

            var repositoryDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(directoryPath);

            var organizationDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(directoryPath);

            var organizationDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(organizationDirectoryPath);

            var remoteRepositoryProviderDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(organizationDirectoryPath);

            var remoteRepositoryProviderDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(remoteRepositoryProviderDirectoryPath);

            // Convention is to directly use the directory names.
            var remoteRepositoryProviderNameToken = remoteRepositoryProviderDirectoryName;
            var organizationNameToken = organizationDirectoryName;
            var repositoryNameToken = repositoryDirectoryName;

            var repositoryNameValue = $"{remoteRepositoryProviderNameToken}/{organizationNameToken}/{repositoryNameToken}";

            var repositoryName = RepositoryName.From(repositoryNameValue);

            return Task.FromResult(repositoryName);
        }
    }
}
