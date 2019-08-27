# Lancamento
Utilizando .NET Core, RabbitMQ e XUnity

# Como Utilizar
<b>Debug:</b> é necessário subir os containers localizados na pasta docker no arquivo "mongo.yml"<br/>
<b>Via Containers:</b> é necessário subir os containers no arquivo "docker-compose.yml", a API está disponível na porta 5101.

<b>Comando para subir os containers completos:</b> docker-compose up -d <br/>
<b>Comando para subir somente rabbitmq e mongo para debug:</b> docker-compose -f mongo.yml up -d <br/><br/>
<b>Necessário adicionar a linha abaixo no hosts da máquina</b> <br/>
<b>127.0.0.1	mongodb</b> <br/>

# Informações sobre os projetos
A API possui documentação com o Swashbuckle, para acessar é necessário acessar a porta na qual a API está disponível, adicionando a rota /swagger.
<br/> EX: http://localhost:5101/swagger.<br/><br/>
Está disponível também o admin-mongo para visualizar a estrutura de banco NoSQL atraves da url: http://localhost:8082, adicionando uma conexão com a connectionString abaixo.<br/>
<b>ConnectionString:</b> mongodb://mongodb:27017<br/>

# Exemplos de chamadas para a API de Lançamento
curl -X POST \
  http://localhost:5101/api/lancamento \
  -H 'Content-Type: application/json' \
  -H 'cache-control: no-cache' \
  -d '{
  "contaOrigem": 1,
  "contaDestino": 2,
  "valor": 10
}'



curl -X GET \
  http://localhost:5101/api/lancamento \
  -H 'Postman-Token: c488d07c-a497-4770-928f-c4daf68a905c' \
  -H 'cache-control: no-cache'
