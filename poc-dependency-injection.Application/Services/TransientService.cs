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
            return @"Temporário, passageiro como tradução literal. Será criada uma nova instância do objeto toda vez que fizer uma requisição. Mas, uma vez que eles são criados, eles usarão mais memória e recursos, e podem ter o impacto negativo no desempenho. Então use para o serviço leve com pouco ou nenhum estado.";
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