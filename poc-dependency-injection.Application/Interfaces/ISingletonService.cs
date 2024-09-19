using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Application.Interfaces
{
    public interface ISingletonService
    {
        Task<BaseResultModel> GetResult();

        string GetDescription();
    }
}