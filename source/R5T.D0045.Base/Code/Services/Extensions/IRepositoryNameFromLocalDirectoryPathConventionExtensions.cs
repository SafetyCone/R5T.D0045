using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0045
{
    public static class IRepositoryNameFromLocalDirectoryPathConventionExtensions
    {
        public static async Task<RepositoryNameAndLocalDirectoryPathMapping> GetRepositoryNameAndLocalDirectoryPathMapping(
            this IRepositoryNameFromLocalDirectoryPathConvention repositoryNameFromLocalDirectoryPathConvention,
            LocalRepositoryDirectoryPath localRepositoryDirectoryPath)
        {
            var repositoryName = await repositoryNameFromLocalDirectoryPathConvention.GetRepositoryNameFromLocalDirectoryPath(localRepositoryDirectoryPath);

            var mapping = new RepositoryNameAndLocalDirectoryPathMapping(repositoryName, localRepositoryDirectoryPath);
            return mapping;
        }
    }
}
