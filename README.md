# Jogo da velha em .NET Core

Api REST para um jogo da velha em .NET Core 3.1.

## Build

Para executar esse projeto basta navegar até a pasta dele e executar os comandos:

```bash
dotnet restore
dotnet run
```

Você pode executá-lo no Visual Studio ou no Visual Studio Code também.

## Build automático com docker

Para rodar o projeto no docker basta executar os comandos a seguir dentro da pasta do projeto:

```bash
docker-compose build
docker-compose up -d
```

Após os comandos executados, o projeto estará rodando na porta 5000.

Para conferir se o container está em execução, basta executar o comando:

```bash
docker ps
```

## Dependências

Nesse projeto foram usadas duas dependências:

- AutoMapper - usado para mapear a entidade do Game para o Dto.

- Newtonsoft - usado para serializar e deserializar a classe Game para um JSON para salvar e recuperar as informações em um arquivo.

## Endpoints

POST /game - endpoint para a inicialização do jogo. Retorna o id e o primeiro player do jogo.

POST /game/{id}/movement - endpoint para fazer um jogada. Recebe o id do jogo como parametro da rota e um objeto contento o jogador e as posições x e y do tabuleiro no corpo da requisição.

## Observações

Esse exemplo foi feito no Ubuntu, portanto, no arquivo "GameRepository.cs" nas linhas 15 e 33, caso for executado no windows, as "/" devem ser trocadas por "\\".

De:

```c#
using (StreamWriter file = File.CreateText($@"{path}/saves/{game.Id}.json"))
```

Para:

```c#
using (StreamWriter file = File.CreateText($@"{path}\saves\{game.Id}.json"))
```
