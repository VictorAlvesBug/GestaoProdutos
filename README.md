# GestaoProdutos
Exemplo de API em C# DotNet Core, utilizando o padrão DDD, responsável por gerenciar produtos

## Script de Criação da tabela Produto

```sql
CREATE TABLE master.dbo.Produto
(
    Codigo               INT           PRIMARY KEY IDENTITY(1,1),
    Descricao            VARCHAR(255)  NOT NULL,
    DataFabricacao       DATE          NULL,
    DataValidade         DATE          NULL,
    CodigoFornecedor     INT           NULL,
    DescricaoFornecedor  VARCHAR(255)  NULL,
    CnpjFornecedor       CHAR(14)      NULL,
    IsAtivo              BIT           NOT NULL DEFAULT 1
);
```