# Repom Galdino

Este repositório contém a solução **Repom.Galdino**, uma aplicação modular em .NET com suporte a testes unitários, orquestração Docker com PostgreSQL e observabilidade via ELK (Elasticsearch, Logstash, Kibana).

---

## 🧱 Estrutura do Projeto

src/
├── repom.application # Lógica de aplicação
├── repom.application.api # API principal
├── repom.bootstrapper # Configuração de injeção de dependências
├── repom.domain.core # Entidades e contratos de domínio
├── repom.persistence # Acesso a dados
├── repom.presentation.api # Camada de apresentação
├── repom.unitest # Testes unitários
├── repom.utils # Utilitários
├── repom.galdino.sln # Solution file
compose.yml # Docker Compose para serviços


---

## 🚀 Executando a Aplicação com Docker

A aplicação pode ser executada completamente com Docker. Isso inclui:

- **API .NET**
- **PostgreSQL**
- **Elasticsearch**
- **Kibana**

### ✅ Pré-requisitos

- Docker instalado
- Docker Compose instalado

### ▶️ Comando para subir a aplicação:

```bash
docker-compose -f src/compose.yml up --build
```

### 🧪 Executando Testes Unitários
```bash
dotnet test src/repom.unitest/repom.unitest.csproj
```

### ▶️ Para rodar localmente:
```bash
dotnet test src/repom.unitest/repom.unitest.csproj
```
### 🧬 Executando testes no GitHub Actions
```bash
.github/workflows/build.yml
```

### 📦 Build Manual
```bash
dotnet restore src/repom.galdino.sln
dotnet build src/repom.galdino.sln --configuration Release
```

---

Se você quiser, posso gerar esse `README.md` direto como arquivo ou adicionar seções específicas como **variáveis de ambiente**, **scripts SQL**, ou **documentação das APIs**. Deseja que eu adicione mais alguma parte?
