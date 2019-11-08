#language: pt-br

Funcionalidade: Busca de Passagem
	Como um usuário
	Desejo efetuar uma busca de passagem
	Assim posso usar a funcionalidade de busca e encontrar a passagem


Cenário: 1) Acesso a página principal, o formulário de busca de passagem deverá ser exibido
	Dado que um usuário acesse a página principal
	Quando clicar no botão Comprar Passagem 
	E preencher todos os dados de busca: Aeroporto Saída, Aeroporto Chegada, Data Ida, Data Volta, Adultos, Crianças e Bebês
	E efetuar a busca de passagem cliando no botão Compre Aqui
	Então os dados de cadastro serão validados
	E serão exibidos os resultados da busca