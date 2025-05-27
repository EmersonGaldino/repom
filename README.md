# Repom Galdino

Este repositório contém a solução **Repom.Galdino**, uma aplicação modular em .NET com suporte a testes unitários, orquestração Docker com PostgreSQL e observabilidade via ELK (Elasticsearch, Logstash, Kibana).

---

## 🧱 Estrutura do Projeto

```
src/
├── repom.application          # Acesso a infraestrutura que aplicacao precisar
├── repom.application.api      # API principal
├── repom.bootstrapper         # Configuração de injeção de dependências
├── repom.domain.core          # Entidades e contratos de domínio
├── repom.persistence          # Acesso a dados
├── repom.unitest              # Testes unitários
├── repom.utils                # Utilitários
├── repom.galdino.sln          # Solution file
compose.yml                    # Docker Compose para serviços
```

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

> A primeira execução pode demorar um pouco para baixar as imagens e restaurar os pacotes.

### 🔍 Acessando os serviços

- **Swagger da API:** [http://localhost:5000/swagger](http://localhost:5000/swagger)
- **Kibana:** [http://localhost:5601](http://localhost:5601)
- **PostgreSQL:** porta `5432` (usuário/senha definidos no `compose.yml`)

---

## 🧪 Executando Testes Unitários

Os testes unitários estão localizados no projeto:

```
src/repom.unitest
```

### ▶️ Para rodar localmente:

```bash
dotnet test src/repom.unitest/repom.unitest.csproj
```

> Certifique-se de estar usando o .NET SDK correto (versão recomendada: `.NET 8`)

### 🧬 Executando testes no GitHub Actions

O repositório já possui uma pipeline configurada em:

```
.github/workflows/build.yml
```

A pipeline executa automaticamente:

- Build da solução
- Execução dos testes unitários

Você pode visualizar os testes diretamente nos **Actions** do GitHub após um push para o branch `main`.

---

## 📦 Build Manual

Se preferir build manual:

```bash
dotnet restore src/repom.galdino.sln
dotnet build src/repom.galdino.sln --configuration Release
```

---

## 👨‍💻 Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Commit suas mudanças:
   ```bash
   git commit -m 'feat: minha nova funcionalidade'
   ```
4. Faça push para sua branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request

---

## 🧾 Licença

Este projeto é licenciado sob a [MIT License](LICENSE).

---

## 📬 Contato

Dúvidas, sugestões ou bugs? Fique à vontade para abrir uma [issue](https://github.com/seu-repo/issues) ou contribuir diretamente!