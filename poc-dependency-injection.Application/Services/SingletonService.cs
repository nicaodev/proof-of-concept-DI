using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Application.Services
{
    public class SingletonService : ISingletonService
    {
        private readonly Guid _id;
        private readonly DateTime _dateTime;

        public SingletonService()
        {
            _id = Guid.NewGuid();
            _dateTime = DateTime.Now;
        }

        public string GetDescription()
        {
            return @"Significa que apenas uma única instância será criada. Essa instância é compartilhada entre todos os componentes que exigem isso. A mesma instância é, portanto, usada sempre.
                    Onde você precisa reutilizar o serviço em várias pontas de sua aplicação como por exemplo: configurações do aplicativo ou parâmetros, serviço de log, armazenamento em cache de dados.";
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