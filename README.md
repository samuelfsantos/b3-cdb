# b3-cdb

Projeto contruido para atender um processo seletivo:

-> Implementação do seguinte endpoint:
* Investmentos
* POST api/v1/investmentos/cdb: Este endpoint realiza o calculo do CDB baseado em seu Valor Inicial e o Prazo em Meses

-> Estilos e Padrões de arquitetura utilizados no Backend
* Domain-Driven Design (DDD)
* Clean Architecture
* SOLID
* Documentação com Swagger
* TDD: XUnit

-> Tecnologias utilizados no Frontend
* AngularJS 18.1.4
* Node: 21.6.1
* TypeScritp
* Material Design
* Flexbox

-> DevOps
* CI/CD com GitHub Actions
* O SITE está empacotado em imagem docker com Nginx
* A Web API utiliza o .NET Framework 4.8
* Hospedagem da API: Azure Web App (S.O. Windows)
* Hospedagem do SITE: Azure Web App para Contêiner (S.O. Linux)
* Criação de um projeto no SonarQube na nuvem Digital Ocean (S.O. Linux + Conteiner Docker)

-> Links úteis
* API: https://b3-cdb-api-fhbcapeadccdfmbc.eastus-01.azurewebsites.net/swagger/ui/index
* SITE: https://b3-cdb-site-ddfmdtazekfqbse4.eastus-01.azurewebsites.net/
* Pipeline API: https://github.com/samuelfsantos/b3-cdb/actions/workflows/build-and-deploy-api.yml
* Pipeline SITE: https://github.com/samuelfsantos/b3-cdb/actions/workflows/build-and-deploy-site.yml
* Link do projeto com o conteiner sonarqube: http://104.248.228.214:9000/dashboard?id=b3-cdb-api

-> Para executar o projeto local, faça o clone do repositório github

* Frontend:
1 - Instalar o Node versão 21.6.1
2 - Navegar até o local do projeto angular "src\B3.Cdb\B3.Cdb.Site\B3CdbSite"
3 - Executar o comando: npm install -g @angular/cli@18.1.4
4 - Executar o comando: ng s
5 - Abrir o navegador no seguinte endereço: http://localhost:4200/

* Backend:
1 - Abrir o arquivo de solução "B3.Cdb.sln" localizado em "src\B3.Cdb" com o software Microsoft Visual Studio
2 - Pressionar a tecla F5
3 - Abrir o navegador no seguinte endereço: https://localhost:44310/swagger/ui/index