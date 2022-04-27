using System;
using System.Threading.Tasks;

using R5T.T0010;
using R5T.T0064;


namespace R5T.D0045
{
    [ServiceDefinitionMarker]
    public interface IRepositoryNameFromLocalDirectoryPathConvention : IServiceDefinition
    {
        Task<RepositoryName> GetRepositoryNameFromLocalDirectoryPath(LocalRepositoryDirectoryPath localRepositoryDirectoryPath);
    }
}
