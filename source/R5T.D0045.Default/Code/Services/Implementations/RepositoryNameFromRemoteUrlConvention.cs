using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar.Extensions;

using R5T.T0010;
using R5T.T0064;


namespace R5T.D0045.Default
{
    [ServiceImplementationMarker]
    public class RepositoryNameFromRemoteUrlConvention : IRepositoryNameFromRemoteUrlConvention, IServiceImplementation
    {
        public Task<RepositoryName> GetRepositoryNameFromRemoteUrl(RemoteRepositoryUrl remoteRepositoryUrl)
        {
            // Example: https://api.github.com/repos/SafetyCone/R5T.Aalborg
            var url = new Uri(remoteRepositoryUrl.Value);

            var hostTokens = url.Host.Split('.');

            var hostToken = hostTokens[1];

            var isGitHub = hostToken == "github";
            var remoteRepositoryProviderNameToken = isGitHub ? "GitHub" : throw new Exception($"Unrecognized host token: '{hostToken}'");

            var segments = url.Segments;
            var organizationNameToken = segments.SecondToLast().ExceptLast();
            var repositoryNameToken = segments.Last();

            var repositoryNameValue = $"{remoteRepositoryProviderNameToken}/{organizationNameToken}/{repositoryNameToken}";

            var repositoryName = RepositoryName.From(repositoryNameValue);

            return Task.FromResult(repositoryName);
        }
    }
}
