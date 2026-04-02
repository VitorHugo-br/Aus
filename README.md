# Aus — Sistema de Gestão

Projeto full-stack composto por:

- **Frontend**: Angular 20 com DevExtreme (`Aus-Front`)
- **Backend**: ASP.NET Core 10 com arquitetura em camadas (`ProjetoAus`)
- **Banco de dados**: MySQL 9.0

---

## 🐳 Rodando com Docker (recomendado)

> Pré-requisitos: [Docker](https://www.docker.com/) e [Docker Compose](https://docs.docker.com/compose/) instalados.

Na raiz do projeto, execute:

```bash
docker compose up --build
```

Isso irá subir três containers:

| Container         | Serviço       | Porta          |
|-------------------|---------------|----------------|
| `MySQL-Database`  | Banco de dados| `3306`         |
| `API-Aus`         | Backend API   | `8080`         |
| `Front-Aus`       | Frontend      | `4200`         |

Acesse o sistema em: [http://localhost:4200](http://localhost:4200)

A API estará disponível em: [http://localhost:8080](http://localhost:8080)

Para parar os containers:

```bash
docker compose down
```

---

## 🛠️ Rodando manualmente (desenvolvimento)

### Pré-requisitos

- [Node.js](https://nodejs.org/) (versão LTS recomendada)
- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [MySQL 9.0](https://dev.mysql.com/downloads/) em execução local

---

### 1. Banco de dados

Certifique-se de ter o MySQL rodando localmente com as seguintes configurações (ou ajuste a connection string da API):

```
Servidor : localhost
Porta    : 3306
Database : Aus
Usuário  : vitor_hugo
Senha    : vitorh
```

---

### 2. Backend — ProjetoAus (ASP.NET Core)

```bash
cd ProjetoAus
dotnet restore
dotnet run --project ProjetoAus.Api/ProjetoAus.Api.csproj
```

A API ficará disponível em: `http://localhost:8080`

A documentação interativa (Scalar) estará em: `http://localhost:8080/scalar`

> **Variáveis de ambiente (opcional):** Você pode substituir as configurações do `appsettings.json` via variáveis de ambiente, por exemplo:
> ```
> ConnectionStrings__DefaultConnection=Server=localhost;Database=Aus;Uid=vitor_hugo;Pwd=vitorh;
> Jwt__SecretKey=sua-chave-secreta
> ```

---

### 3. Frontend — Aus-Front (Angular)

```bash
cd Aus-Front
npm install
npm start
```

O frontend ficará disponível em: [http://localhost:4200](http://localhost:4200)

---

## 📁 Estrutura do projeto

```
Aus/
├── Aus-Front/          # Aplicação Angular (frontend)
├── ProjetoAus/         # Solução .NET (backend)
│   ├── ProjetoAus.Api/     # Camada de API (Controllers, Endpoints)
│   ├── ProjetoAus.BLL/     # Camada de negócio (Business Logic Layer)
│   ├── ProjetoAus.Data/    # Camada de dados (EF Core, Repositórios)
│   └── ProjetoAus.Models/  # Modelos e interfaces compartilhadas
└── docker-compose.yml  # Orquestração dos containers
```

---

## 🔑 Credenciais padrão (desenvolvimento)

> ⚠️ Não utilize estas credenciais em produção.

| Recurso    | Usuário     | Senha    |
|------------|-------------|----------|
| MySQL      | `vitor_hugo`| `vitorh` |
| MySQL root | `root`      | `suppwd` |
