# Rota Viagens API

## Descrição

Bem-vindo à documentação da API Rota. Esta API permite gerenciar e consultar rotas entre diferentes cidades. A seguir, estão os detalhes das operações disponíveis.
Consta nesse projeto duas APIs, sendo uma Minimal API na camada de APLICATION e outra normal com Conttrolers na camada de API.

## Tecnologias Utilizadas

- **.NET Core 8.0**
- **SQLite para o banco de dados**
- **Entity in memory para os testes**

## Funcionalidades

- **Gerenciamento de Rotas**: 
  - Cadastro de rota.
  - Edição de rota.
  - Exclusão de rota.
  - Obter todas as rotas disponíveis.
  - Consulta a melhor rota entre dois pontos.

## Requisitos para Rodar a Aplicação

- SDK do .NET 8.0: Certifique-se de ter o SDK do .NET 8.0 instalado. 
- SQLite: Instalando o pacote do SQLite e configurando um banco de dados para ser usado pela aplicação.

## Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/MatheusCavalari/rota-app.git
    cd RotasViagemINDT
    cd src
    ```

2. Restaure os pacotes NuGet:
    ```sh
    dotnet restore
    ```
3. Compile e execute o projeto:
    ```sh
    dotnet build
    dotnet run
    ```

### Endpoints
1. **GET /api/rotas
- **URL**: `/api/rotas`
- **Método**: `GET`
- **Resposta de Sucesso**:
    - Código: `200 OK`
    - Corpo: Lista de rotas

2. **POST /api/rota
- **URL**: `/api/rotas`
- **M�todo**: `POST`
- **Corpo da Requisição**:
  ```json
  {
  "id": 0
  "origem": "GRU",
  "destino": "BRC",
  "valor": 10
  }
  ```
- **Resposta de Sucesso**:
    - Código: `201 CREATED`
    - Corpo: Rota criada

3. **PUT /api/rotas/1
- **URL**: `/api/rotas/1`
- **Método**: `PUT`
- **Corpo da Requisição**:
  ```json
  {
  "origem": "GRU",
  "destino": "BRC",
  "valor": 12
  }
  ```
- **Resposta de Sucesso**:
    - Código: `204 NO CONTENT`

4. **DELETE /api/rotas/1
- **URL**: `/api/rotas/1`
- **M�todo**: `DELETE`
- **Resposta de Sucesso**:
    - Código: `204 NO CONTENT`

5. **GET /api/rotas/melhor-rota?origem=GRU&destino=BRC
- **URL**: `/api/rotas/melhor-rota?origem=GRU&destino=BRC`
- **M�todo**: `GET`
- **Resposta de Sucesso**:
  ```json
  {
  "rota": "GRU - BRC ao custo de $10"
  }
  ```

## Autor

José Ribeiro Carvalho
