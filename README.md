# dotnet-ci-lab

Laboratório prático e profissional de **CI/CD, testes e infraestrutura** usando **.NET (C#)**, desenvolvido passo a passo em formato de curso técnico.

Este projeto não é um exemplo trivial: ele simula **práticas reais de mercado**, com separação clara entre testes unitários, testes de integração, pipeline de CI e validações de saúde da aplicação.

---

## 🎯 Objetivo do projeto

Construir um ambiente de estudos sólido para:

* Testes unitários e de integração em .NET
* Uso correto de **Testcontainers**
* Pipelines com **GitHub Actions**
* Validação de aplicação viva (*health checks*) no CI
* Organização profissional de projetos e pastas

Tudo isso **sem pular etapas** e mantendo o histórico consistente.

---

## 🧱 Arquitetura

O laboratório é composto por **dois serviços simples**:

### 📦 CatalogService

* API HTTP
* Endpoint de catálogo
* Health check (`/health/live`)
* Repositório em memória

### 🛒 OrderService

* Domínio isolado
* Regras de negócio puras
* Usado como base para testes unitários

A arquitetura foi mantida **intencionalmente simples**, para focar em CI, testes e infraestrutura — não em complexidade de domínio.

---

## 📂 Estrutura de diretórios

```
.
├── src/
│   ├── CatalogService/
│   │   ├── Program.cs
│   │   ├── Repositories/
│   │   └── Properties/
│   └── OrderService/
│       └── Domain/
│           └── OrderItem.cs
│
├── tests/
│   └── CatalogService.Tests/
│       ├── CatalogApiTests.cs
│       ├── CustomWebApplicationFactory.cs
│       └── Fixtures/
│           └── PostgresFixture.cs
│
├── .github/
│   └── workflows/
│       └── ci.yml
│
├── .gitignore
└── README.md
```

---

## 🧪 Estratégia de testes

### ✅ Testes Unitários

* Foco em regras de negócio
* Não usam infraestrutura
* Executam rápido
* Rodam sempre no CI

Executados com:

```bash
dotnet test --filter "Category!=Integration"
```

---

### 🔌 Testes de Integração

* Usam **Testcontainers**
* Sobem dependências reais (PostgreSQL)
* Testam API rodando de verdade

Marcados explicitamente com:

```csharp
[Trait("Category", "Integration")]
```

Executados com:

```bash
dotnet test --filter "Category=Integration"
```

---

## 🧠 Observação importante sobre Traits

A separação por `Trait` foi usada **de forma consciente**, sabendo que:

* Existe risco humano (esquecer a categoria)
* Em projetos maiores, alternativas como assemblies separados ou pipelines distintos podem ser preferíveis

Aqui, o foco foi **clareza didática e controle explícito**.

---

## 🩺 Health Check

O serviço expõe:

```
GET /health/live
```

* Retorna **200 OK** se a aplicação estiver viva
* Não depende de banco ou serviços externos

Esse endpoint é usado como **gate do CI**.

---

## 🚦 Pipeline de CI (GitHub Actions)

O pipeline executa, em ordem:

1. Restore
2. Build
3. Testes unitários
4. Testes de integração
5. Subida do serviço
6. Health check via `curl`

Se qualquer etapa falhar → **pipeline falha**.

Isso garante que:

> Código que passa no CI realmente funciona.

---

## 🐳 Containers

* **Não** usamos Docker para rodar a aplicação no CI
* Containers são usados **somente** para dependências de integração (Testcontainers)

Isso reflete uma prática comum em pipelines modernos.

---

## 🚀 Executando localmente (GitHub Codespaces)

```bash
dotnet run --project src/CatalogService
```

Endpoints:

* API: `http://localhost:5055/api/v1/catalog`
* Health: `http://localhost:5055/health/live`

---

## 🏁 Status do projeto

✅ Curso concluído na **Aula 16**
✅ Pipeline funcional
✅ Testes unitários e de integração separados
✅ Health check validado no CI

---

## 🧠 Nível técnico atingido

Ao final deste laboratório, você praticou conceitos esperados de **nível pleno/sênior** em CI:

* Testes como contrato
* CI como sistema
* Diagnóstico de falhas reais
* Infraestrutura mínima validada automaticamente

---

## 📌 Observação final

Este projeto é um **laboratório de aprendizado**, não um produto final.

A simplicidade do domínio é proposital — o valor está no **processo, não no CRUD**.

---

✍️ Desenvolvido como parte de um curso técnico estruturado, passo a passo, sem atalhos.
