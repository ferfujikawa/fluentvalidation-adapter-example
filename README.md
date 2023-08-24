# fluentvalidation-adapter-example

Projeto de exemplo de criação de adaptador para utilização do pacote [FluentValidation](https://github.com/FluentValidation/FluentValidation).

## Explicação quanto à arquitetura

Os namespaces `Domain` e `Infra` foram criados no mesmo projeto para facilitar a compreensão, porém estão implementados de forma que as classes de `Domain` não dependem de nenhuma implementação de `Infra`.
