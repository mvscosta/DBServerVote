Feature: Profissional Votacao

Scenario: Um profissional pode votar em seu restaurante favorito
	Given Funcionario 1 esta votando em 1
	When Votar funcionario 1 restaurante 1 no dia "17/04/2017 10:00:00"
	Then A resposta deve ser "Voto computado!"

Scenario: Um profissional so pode votar uma vez por dia
	Given Funcionario 3 esta votando em 1
	When Votar funcionario 3 restaurante 1 no dia "13/04/2017 10:00:00"
	Then A resposta deve ser "Funcionário já votou hoje!"

Scenario: Um restaurante não pode ser repetido na mesma semana
	Given Funcionario 1 esta votando em 1
	When Votar funcionario 1 restaurante 1 no dia "14/04/2017 10:00:00"
	Then A resposta deve ser "Este restaurante já foi votado esta semana!"

Scenario: O Profissional precisa saber o resultado antes do meio dia
	Given Funcionario 1 esta votando em 1
	When Votar funcionario 1 restaurante 1 no dia "16/04/2017 11:31:00"
	Then A resposta deve ser "Prazo de votação encerrado para o hoje. Aguardamos seu voto amanhã!"