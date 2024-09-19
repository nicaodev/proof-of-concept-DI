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
            return @"No ciclo de vida Singleton, apenas uma instância do serviço é criada e compartilhada por toda a aplicação. Ela é reutilizada sempre que solicitada por qualquer componente.
                    Uso recomendado: Ideal para serviços que mantêm dados globais ou precisam ser persistidos, como - Configurações: Armazenamento de parâmetros que não mudam durante a execução. Serviços de log: Registro de eventos de forma consistente. Cache de dados: Dados acessados com frequência que precisam ser consistentes. Cuidado: Como é compartilhado, evite armazenar estado mutável para prevenir problemas de concorrência.";
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