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
            return @"Uma nova instância do serviço é criada para cada requisição HTTP ou escopo definido, e é descartada ao fim da requisição.
                    Uso recomendado: Serviços que precisam manter estado durante uma requisição, mas não além dela. Exemplos: Contexto de banco de dados: O DbContext é criado por requisição para garantir consistência durante a operação. Serviços temporários: Como o carrinho de compras, que precisa de persistência de estado durante o processamento. Escopos personalizados: Permitem definir ciclos de vida customizados para operações que não são baseadas em HTTP.";
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