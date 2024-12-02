# Sistema de Fluxo de Caixa

## Requisitos Funcionais
- Serviço para controle de lançamentos
- Serviço para consolidação de lançamentos para Fluxo de Caixa

## Requisitos não funcionais
1. O serviço de controle de lançamento não deve ficar indisponível se o sistema de consolidado diário cair. 
2. Em dias de picos, o serviço de consolidado diário recebe 50 requisições por segundo, com no máximo 5% de perda de requisições.

## Proposta arquitetural

A solução proposta terá os seguintes componentes

- Serviço para controle de lançamentos
    - API REST para registro de lançamento de fluxo de caixa
    - Banco de dados relacional para persistência

- Message Broker para comunicação entre serviços

- Serviço para consolidação de lançamentos
    - Worker para coleta de lançamentos 
    - API REST para emissão de relatório de fluxo de caixa consolidado por dia
    - Banco de dados NoSQL para leitura rápida

## Componentes de suporte

- SSO para Autenticação
- OpenTelemtry Collector
- ELK

## Diagrama de Componentes


## Diagrama de Implantação


## Atendimento de RNF's

1. O serviço de controle de lançamento não deve ficar indisponível se o sistema de consolidado diário cair. 

- Serviço de controle de lançamentos: 
    - Será construído na arquitetura de microsserviço, com sua base de própria e exclusiva; 
    - Baixo acoplamento, tendo sua comunicação toda realizada através de mensageria, de forma assíncrona;
    - Hospedado em Kubernetes ou serviço similar como AKS, garantindo escalabilidade mesmo em momentos de pico de uso;

2. Em dias de picos, o serviço de consolidado diário recebe 50 requisições por segundo, com no máximo 5% de perda de requisições.

- Serviço de consolidação
    - Será construído na arquitetura de microsserviço, com sua base de própria e exclusiva; 
    - Receberá registros de forma assíncrona, via mensageria, garantindo estabilidade e escalabilidade;
    - Hospedado em Kubernetes ou serviço similar como AKS, garantindo escalabilidade mesmo em momentos de pico de uso;
    - Utilizará banco de dados que seja escalável e clusterizável (como MongoDB)

## Análise de Tradeoffs

## Atributos de qualidade

## RNF

 > O serviço de controle de lançamento não deve ficar indisponível se o sistema de consolidado diário cair. 
 
 > Em dias de picos, o serviço de consolidado diário recebe 50 requisições por segundo, com no máximo 5% de perda de requisições.

FLUXO
Venda de notebook   Credito  5200,00  29/11    Receita de Venda
Retirada manoel     Debito   1000,00  29/11    Pgto Forn 
Retirada joao       Debito   4000,00  30/11    Pgto Forn 
Retirada manoel     Debito   500,00  30/11    Pgto Forn 
Compra terreno      Debito   80000,00 01/12  

CONSOLIDADO
| GrupoRelatorio | TipoRegistro | Data | Saldo | 
|-|-|
| Operacional | Vendas Diretas | 29/11 | 5200,00 | 
| Operacional | Pgto For | 1000,00 | 29/11 | 1000,00 | 
| Operacional | Pgto For | 1500,00 | 30/11 | 4000,00 |
| Investimentos | Imoveis | 80000,00 | 01/12 | 80000,00 |

Exemplo de consolidado:
![alt text](image.png)

Consistência ?


Lancamento

Tipo de lancamento
- Receita de Vendas
- Pagamentos de Fornecedores
...

Operacao (Credito/Debito)

Grupo de lancamento 
- Atividades operacionais 
- Atividades de investimento
- Atividades de financiamento


[1] MAP REDUCE
Como a fila funcionará:

- Todo o lançamento realizado será publicado na fila 
- O serviço de consolidado consumirá a fila
- Ao processar uma mensagem o serviço:
    - Verificar o Grupo de relatório e Registro de relatório e Dia;
    - Obtem o último saldo do Registro de relatório
    - Soma ou subtrai o saldo com valor do lançamento

- Eu posso processar mais de uma mensagem por vez ?

* Mutex/Semaforo por Dia/RegistroRelatorio


Worker (escalável verticalmente) / BD / Emissor de relatório (escalável horizontalmente)
Velocidade de leitura e escrita

Tradeoffs
Rapidez na emissão do relatório, afinal saldo estarão prontos e calculados
Worker não escala horizontalmente
Fila será processada de forma serial e não paralela
Consistência eventual (saldo só será real no final do processamento das mensagens)


[2] MAP (SELECT)
Como a fila funcionará:

- Todo o lançamento realizado será publicado na fila 
- O serviço de consolidado consumirá a fila
- Ao processar uma mensagem o serviço:
    - Gravar lançamento simplificado Grupo de relatório e Registro de relatório e Dia;
    - Ao emitir relatório será feito agrupamento

Tradeoffs
Worker escala horizontal e verticalmente
Consistencia quase imediata
Emissão do relatório será mais lenta (dependerá de agrupamento de banco de dados)



fluxo01+




 dotnet ef migrations add InicialMigration --project Fluxo.Data --startup-project Fluxo.Api