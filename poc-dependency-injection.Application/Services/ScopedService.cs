using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Application.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _id;
        private readonly DateTime _dateTime;

        public ScopedService()
        {
            _id = Guid.NewGuid();
            _dateTime = DateTime.Now;
        }

        public string GetDescription()
        {
            return @"Uma instância é criada uma vez por escopo. Um escopo é criado em cada solicitação para o aplicativo (cada pedido é um escopo), portanto,
                    todos os componentes registrados como scoped serão criados uma vez por solicitação.";
        }

        public async Task<BaseResultModel> GetResult()
        {
            return new BaseResultModel
            {
                DateTime = _dateTime,
                Id = _id
            };
        }
    }
}