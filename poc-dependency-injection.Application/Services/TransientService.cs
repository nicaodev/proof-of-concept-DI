using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.Application.Services
{
    public class TransientService : ITransientService
    {
        private readonly Guid _id;
        private readonly DateTime _dateTime;

        public TransientService()
        {
            _id = Guid.NewGuid();
            _dateTime = DateTime.Now;
        }

        public string GetDescription()
        {
            return @"O serviço é recriado toda vez que solicitado, mesmo dentro da mesma requisição.
                     Uso recomendado: Ideal para serviços leves e sem estado, como:
                     Validações: Que não precisam manter estado entre chamadas.
                     Utilitários: Operações como formatação ou cálculos rápidos.
                     Desempenho: O uso excessivo de serviços Transient pode impactar o desempenho devido à criação constante de instâncias, especialmente em serviços pesados.";
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