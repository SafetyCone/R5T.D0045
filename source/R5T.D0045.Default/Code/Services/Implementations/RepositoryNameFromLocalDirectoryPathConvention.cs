using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0010;


namespace R5T.D0045.Default
{
    public class RepositoryNameFromLocalDirectoryPathConvention : IRepositoryNameFromLocalDirectoryPathConvention
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public RepositoryNameFromLocalDirectoryPathConvention(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public Task<RepositoryName> GetRepositoryNameFromLocalDirectoryPath(LocalRepositoryDirectoryPath localRepositoryDirectoryPath)
        {
            var directoryPath = localRepositoryDirectoryPath.Value;

            var repositoryDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(directoryPath);

            var organizationDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(directoryPath);

            var organizationDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(organizationDirectoryPath);

            var remoteRepositoryProviderDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(organizationDirectoryPath);

            var remoteRepositoryProviderDirectoryName = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(remoteRepositoryProviderDirectoryPath);

            // Convention is to directly use the directory names.
            var repositoryNameValue = $"{remoteRepositoryProviderDirectoryName}/{organizationDirectoryName}/{repositoryDirectoryName}";

            var repositoryName = RepositoryName.From(repositoryNameValue);

            return Task.FromResult(repositoryName);
        }
    }
}
