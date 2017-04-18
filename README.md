# DBServerVote
BDD com SpecFlow + MSTest
Projeto padrão MVC + WEBAPI
Base DAO EntityFramework SQL Azure
Base Autenticação Azure B2C (OpenId e OAuth2)
Base FrontEnd Bootstrap + font awesome


Projeto de demonstração utilizando camada de banco de dados, autenticação via azure ad b2c.
Possui restrição devido a claims do b2c não configurados, validando usuário pelo nome. ponto de melhoria, utilizar email.

FrontEnd bastante simples. Pode evoluir para um angular para ficar mais robusto.

Vote > Projeto Web, frontend e inicio de camada webapi

Vote.DAO > Projeto responsável pelo acesso aos dados no SQL Azure

Vote.Roles > Projeto com implementação dos cenários

Vote.Specs > Projeto com testes baseados em BDD


Site publicado em:
  http://dbservervote.azurewebsites.net/
liberada federação no aad b2c para usuários convidados.

Todos os serviços estão em modo gratuito, podendo estar indisponível acesso devido a limitações.
