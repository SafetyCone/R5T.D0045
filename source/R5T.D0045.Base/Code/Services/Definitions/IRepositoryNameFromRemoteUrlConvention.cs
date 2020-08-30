using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0045
{
    public interface IRepositoryNameFromRemoteUrlConvention
    {
        Task<RepositoryName> GetRepositoryNameFromRemoteUrl(RemoteRepositoryUrl remoteRepositoryUrl);
    }
}
