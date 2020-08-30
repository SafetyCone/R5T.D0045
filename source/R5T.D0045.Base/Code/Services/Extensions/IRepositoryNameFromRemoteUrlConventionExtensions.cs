using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0045
{
    public static class IRepositoryNameFromRemoteUrlConventionExtensions
    {
        public static async Task<RepositoryNameAndRemoteUrlMapping> GetRepositoryNameAndRemoteUrlMapping(
            this IRepositoryNameFromRemoteUrlConvention repositoryNameFromRemoteUrlConvention,
            RemoteRepositoryUrl remoteRepositoryUrl)
        {
            var repositoryName = await repositoryNameFromRemoteUrlConvention.GetRepositoryNameFromRemoteUrl(remoteRepositoryUrl);

            var mapping = new RepositoryNameAndRemoteUrlMapping(repositoryName, remoteRepositoryUrl);
            return mapping;
        }
    }
}
