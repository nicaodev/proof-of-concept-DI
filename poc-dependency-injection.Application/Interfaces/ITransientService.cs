using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Application.Interfaces
{
    public interface ITransientService
    {
        Task<BaseResultModel> GetResult();

        string GetDescription();
    }
}