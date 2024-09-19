# proof-of-concept-dependency-injection


How to use:
AddScoped<I,C>();
AddTransient<I,C>();
AddSingleton<I,C>();

### Singleton
No ciclo de vida Singleton, apenas uma instância do serviço é criada e compartilhada por toda a aplicação. Ela é reutilizada sempre que solicitada por qualquer componente.

**Uso recomendado:** Ideal para serviços que mantêm dados globais ou precisam ser persistidos, como:
Configurações: Armazenamento de parâmetros que não mudam durante a execução.
Serviços de log: Registro de eventos de forma consistente.
Cache de dados: Dados acessados com frequência que precisam ser consistentes.
Cuidado: Como é compartilhado, evite armazenar estado mutável para prevenir problemas de concorrência.
___
### Scoped
Uma nova instância do serviço é criada para cada requisição HTTP ou escopo definido, e é descartada ao fim da requisição.

**Uso recomendado:** Serviços que precisam manter estado durante uma requisição, mas não além dela. Exemplos:
Contexto de banco de dados: O DbContext é criado por requisição para garantir consistência durante a operação.
Serviços temporários: Como o carrinho de compras, que precisa de persistência de estado durante o processamento.
Escopos personalizados: Permitem definir ciclos de vida customizados para operações que não são baseadas em HTTP.
___
### Transient
O serviço é recriado toda vez que solicitado, mesmo dentro da mesma requisição.

**Uso recomendado:** Ideal para serviços leves e sem estado, como:
- Validações: Que não precisam manter estado entre chamadas.
- Utilitários: Operações como formatação ou cálculos rápidos.
- Desempenho: O uso excessivo de serviços Transient pode impactar o desempenho devido à criação constante de instâncias, especialmente em serviços pesados.

___
### Considerações sobre Concorrência
**Singleton:** Como é compartilhado globalmente, deve-se evitar estado mutável ou garantir sincronização para prevenir concorrência.

**Scoped:** É seguro para concorrência, pois cada requisição tem sua própria instância.

**Transient:** Não apresenta problemas diretos de concorrência, mas pode aumentar o uso de memória e recursos devido à criação constante de novas instâncias.