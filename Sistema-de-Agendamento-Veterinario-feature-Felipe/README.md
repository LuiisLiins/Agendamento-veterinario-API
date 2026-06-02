# 🐾 Agendamento Veterinário

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Status: Em Desenvolvimento](https://img.shields.io/badge/Status-Em%20Desenvolvimento-blue)](https://github.com)
[![Node.js](https://img.shields.io/badge/Node.js-18+-green)]()
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18.2-61DAFB?logo=react)](https://reactjs.org/)

Um sistema completo de agendamento de consultas veterinárias com arquitetura moderna, integração full-stack e experiência de usuário otimizada.

---

## 📋 Descrição ##

### Objetivo do Sistema
O **Agendamento Veterinário** é uma solução web completa que facilita o agendamento de consultas, permitindo que tutores de animais de estimação marquem atendimentos com veterinários de forma prática e intuitiva, enquanto oferece aos clínicas ferramentas de gestão eficientes.

### Problema Resolvido
- 🔴 Dificuldade em marcar consultas via telefone
- 🔴 Falta de histórico de agendamentos
- 🔴 Indisponibilidade de informações sobre veterinários
- 🔴 Gerenciamento manual e desorganizado

### Público-Alvo
- 👥 Tutores de animais de estimação
- 👥 Veterinários e clínicas veterinárias
- 👥 Gestores de clínicas

### Contexto do Projeto
Projeto desenvolvido como trabalho acadêmico para o curso de **Arquitetura e Desenvolvimento Full Stack** (5º semestre), com foco em aplicar padrões modernos de desenvolvimento, boas práticas de engenharia de software e arquitetura em camadas.

---

## 🎨 Preview do Sistema

### Telas Principais

```
┌─────────────────────────────────────────┐
│  Dashboard - Página Inicial             │
│  ├─ Agendamentos Próximos               │
│  ├─ Meus Pets                           │
│  ├─ Histórico de Atendimentos           │
│  └─ Perfil do Usuário                   │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  Novo Agendamento (Stepper)             │
│  ├─ Passo 1: Seleção do Pet             │
│  ├─ Passo 2: Seleção de Veterinário     │
│  ├─ Passo 3: Seleção de Serviço         │
│  ├─ Passo 4: Seleção de Horário         │
│  └─ Passo 5: Confirmação                │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  Lista de Veterinários                  │
│  ├─ Filtros por Especialidade           │
│  ├─ Avaliação e Comentários             │
│  └─ Disponibilidade em Tempo Real       │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  Meus Agendamentos                      │
│  ├─ Filtro por Status                   │
│  ├─ Opções de Cancelamento              │
│  └─ Detalhes do Atendimento             │
└─────────────────────────────────────────┘
```

**Para visualizar screenshots**, acesse a pasta `/assets/screenshots` ou visite nosso [Figma](https://figma.com).

---

## 🛠️ Tecnologias Utilizadas

### Frontend
| Tecnologia | Versão | Descrição |
|-----------|--------|-----------|
| React | 18.2+ | Biblioteca UI |
| Vite | 5.0+ | Build tool e dev server |
| Axios | 1.6+ | Cliente HTTP |
| React Router | 6.0+ | Roteamento |
| Context API | - | Gerenciamento de estado |
| Tailwind CSS | 3.0+ | Estilização |
| Vite Plugin React | 4.0+ | Otimização React |

### Backend
| Tecnologia | Versão | Descrição |
|-----------|--------|-----------|
| .NET Core | 8.0 | Framework |
| ASP.NET Core | 8.0 | Web API |
| Entity Framework Core | 8.0 | ORM |
| SQL Server | 2022+ | Banco de dados |
| AutoMapper | 13.0+ | Mapeamento de objetos |
| FluentValidation | 11.0+ | Validação de dados |

### Banco de Dados
| Tecnologia | Descrição |
|-----------|-----------|
| SQL Server | Banco de dados relacional |
| Entity Framework Core | ORM e migrations |
| Fluent API | Configuração de modelos |

### Arquitetura & Padrões
| Padrão | Descrição |
|--------|-----------|
| Clean Architecture | Separação de responsabilidades |
| DDD (Domain-Driven Design) | Modelagem orientada ao domínio |
| Repository Pattern | Abstração de acesso a dados |
| Service Layer | Lógica de negócio centralizada |
| Dependency Injection | Inversão de controle |

### Ferramentas & DevOps
| Ferramenta | Descrição |
|-----------|-----------|
| Git | Controle de versão |
| Visual Studio Code | Editor |
| Visual Studio 2022 | IDE .NET |
| Postman | Testes de API |
| npm | Gerenciador de pacotes Node |

### Infraestrutura
| Componente | Descrição |
|-----------|-----------|
| REST API | Comunicação cliente-servidor |
| CORS | Compartilhamento de recursos |
| JWT | Autenticação |
| HTTPS | Segurança |

---

## ✨ Funcionalidades

### 🔐 Autenticação & Usuários
- [x] Registro de novo usuário
- [x] Login com email e senha
- [x] Recuperação de senha
- [x] Perfil do usuário
- [x] Edição de dados pessoais
- [x] Logout

### 🐶 Gerenciamento de Pets
- [x] Cadastro de pets
- [x] Edição de informações do pet
- [x] Histórico médico do pet
- [x] Exclusão de pet
- [x] Upload de foto do pet
- [x] Raças e espécies

### 📅 Agendamentos
- [x] Criar novo agendamento (Stepper)
- [x] Visualizar agendamentos próximos
- [x] Cancelar agendamento
- [x] Reagendar consulta
- [x] Confirmação por email
- [x] Lembretes

### 👨‍⚕️ Veterinários
- [x] Listagem de veterinários
- [x] Filtro por especialidade
- [x] Visualizar disponibilidade
- [x] Avaliações e comentários
- [x] Experiência profissional
- [x] Horário de funcionamento

### 💼 Serviços
- [x] Listagem de serviços oferecidos
- [x] Filtro por tipo
- [x] Descrição e preços
- [x] Duração estimada

### 📊 Dashboard
- [x] Resumo de agendamentos
- [x] Pets cadastrados
- [x] Histórico de atendimentos
- [x] Estatísticas
- [x] Notificações

### 📱 Responsividade
- [x] Layout mobile-first
- [x] Design responsivo
- [x] Teste em múltiplos dispositivos

---

## 🏗️ Arquitetura do Projeto

### 📐 Padrões Arquiteturais

#### Clean Architecture
```
┌─────────────────────────────────────────────────────┐
│         Presentation Layer (Controllers)            │
├─────────────────────────────────────────────────────┤
│         Application Layer (Services)                │
├─────────────────────────────────────────────────────┤
│         Domain Layer (Entities, Interfaces)         │
├─────────────────────────────────────────────────────┤
│         Infrastructure Layer (Repositories, DbContext)│
└─────────────────────────────────────────────────────┘
```

#### Domain-Driven Design (DDD)

**Bounded Contexts:**

1. **Usuarios Context** - Gerenciamento de usuários e autenticação
2. **Pets Context** - Gerenciamento de animais de estimação
3. **Veterinarios Context** - Gerenciamento de veterinários
4. **Agendamentos Context** - Lógica de reservas e agendamentos
5. **Servicos Context** - Catálogo de serviços oferecidos

#### Comunicação Entre Camadas

```
Frontend (React)
      ↕
    Axios
      ↕
API Gateway (ASP.NET Core)
      ↕
Services (Regras de Negócio)
      ↕
Repositories (Repository Pattern)
      ↕
Entity Framework Core
      ↕
SQL Server
```

#### Repository Pattern

```csharp
// Interface no Domain
public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario> ObterPorEmailAsync(string email);
}

// Implementação na Infrastructure
public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    // Implementação
}
```

#### Service Layer

```csharp
public interface IAgendamentoService
{
    Task<AgendamentoDTO> CriarAgendamentoAsync(CriarAgendamentoDTO dto);
    Task CancelarAgendamentoAsync(int id);
    Task<List<AgendamentoDTO>> ObterPorUsuarioAsync(int usuarioId);
}
```

---

## 📁 Estrutura de Pastas

### Backend

```
Agendamento Veterinario - Back/
├── Agendamento Veterinario - Back.sln
├── Agendamento Veterinario - Back/
│   ├── Program.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   │
│   ├── Controllers/
│   │   ├── UsuariosController.cs
│   │   ├── PetsController.cs
│   │   ├── VeterinariansController.cs
│   │   ├── AgendamentosController.cs
│   │   └── ServicosController.cs
│   │
│   ├── Services/
│   │   ├── UsuarioService.cs
│   │   ├── PetService.cs
│   │   ├── VeterinarioService.cs
│   │   ├── AgendamentoService.cs
│   │   └── AuthService.cs
│   │
│   ├── Repositories/
│   │   ├── UsuarioRepository.cs
│   │   ├── PetRepository.cs
│   │   ├── VeterinarioRepository.cs
│   │   ├── AgendamentoRepository.cs
│   │   └── IRepository.cs (Generic)
│   │
│   ├── Models/
│   │   ├── Usuario.cs
│   │   ├── Pet.cs
│   │   ├── Veterinario.cs
│   │   ├── Agendamento.cs
│   │   └── Servico.cs
│   │
│   ├── DTOs/
│   │   ├── UsuarioDTO.cs
│   │   ├── PetDTO.cs
│   │   ├── VeterinarioDTO.cs
│   │   ├── AgendamentoDTO.cs
│   │   └── CriarAgendamentoDTO.cs
│   │
│   ├── Data/
│   │   ├── ApplicationDbContext.cs
│   │   ├── Migrations/
│   │   └── Seeds/
│   │
│   ├── Validators/
│   │   ├── UsuarioValidator.cs
│   │   ├── AgendamentoValidator.cs
│   │   └── PetValidator.cs
│   │
│   ├── Middleware/
│   │   ├── ExceptionHandlingMiddleware.cs
│   │   └── AuthMiddleware.cs
│   │
│   ├── Config/
│   │   ├── AutoMapperProfile.cs
│   │   └── ServiceConfiguration.cs
│   │
│   ├── Exceptions/
│   │   ├── NotFoundException.cs
│   │   ├── UnauthorizedAccessException.cs
│   │   └── BusinessException.cs
│   │
│   └── Properties/
│       └── launchSettings.json
│
└── bin/ & obj/
```

### Frontend

```
Agendamento Veterinario - Front/
├── src/
│   ├── main.jsx
│   ├── index.css
│   ├── App.jsx
│   │
│   ├── components/
│   │   ├── common/
│   │   │   ├── Button.jsx
│   │   │   ├── Modal.jsx
│   │   │   ├── Loading.jsx
│   │   │   ├── Card.jsx
│   │   │   └── Badge.jsx
│   │   │
│   │   ├── layout/
│   │   │   ├── MainLayout.jsx
│   │   │   ├── Sidebar.jsx
│   │   │   ├── Navbar.jsx
│   │   │   └── Footer.jsx
│   │   │
│   │   ├── booking/
│   │   │   ├── Stepper.jsx
│   │   │   ├── PetCard.jsx
│   │   │   ├── ServiceCard.jsx
│   │   │   └── BookingCard.jsx
│   │   │
│   │   └── veterinarian/
│   │       ├── VeterinarianCard.jsx
│   │       ├── VeterinarianFilter.jsx
│   │       └── RatingStars.jsx
│   │
│   ├── pages/
│   │   ├── Home/
│   │   │   └── index.jsx
│   │   │
│   │   ├── Login/
│   │   │   └── index.jsx
│   │   │
│   │   ├── DashBoard/
│   │   │   └── index.jsx
│   │   │
│   │   ├── MyPets/
│   │   │   └── Index.jsx
│   │   │
│   │   ├── MyBookings/
│   │   │   └── index.jsx
│   │   │
│   │   ├── Veterinarians/
│   │   │   └── Index.jsx
│   │   │
│   │   └── NewBooking/
│   │       └── Index.jsx
│   │
│   ├── Semi-Page/
│   │   └── booking/
│   │       ├── ConfirmBooking.jsx
│   │       ├── PetSelectionSection.jsx
│   │       ├── ServiceSelectionSection.jsx
│   │       ├── VetSelectionSection.jsx
│   │       └── HoursSelectionSection.jsx
│   │
│   ├── context/
│   │   ├── AuthContext.jsx
│   │   ├── BookingContext.jsx
│   │   └── PetContext.jsx
│   │
│   ├── hooks/
│   │   ├── useAuth.js
│   │   ├── useAxios.js
│   │   ├── useBooking.js
│   │   └── usePet.js
│   │
│   ├── services/
│   │   ├── api.js
│   │   ├── authService.js
│   │   ├── bookingService.js
│   │   ├── petService.js
│   │   └── veterinarianService.js
│   │
│   ├── routes/
│   │   ├── AppRoutes.jsx
│   │   └── PrivateRoute.jsx
│   │
│   ├── utils/
│   │   ├── formatDate.js
│   │   ├── validators.js
│   │   ├── constants.js
│   │   └── helpers.js
│   │
│   └── assets/
│       ├── images/
│       ├── icons/
│       └── screenshots/
│
├── public/
├── index.html
├── package.json
├── vite.config.js
├── tailwind.config.js
├── postcss.config.js
└── eslint.config.js
```

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- **Node.js** 18+ ([Download](https://nodejs.org/))
- **.NET 8.0** ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **SQL Server** 2022+ ([Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads))
- **Git** ([Download](https://git-scm.com/))

### 1️⃣ Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/agendamento-veterinario.git
cd agendamento-veterinario
```

### 2️⃣ Configurar Backend (ASP.NET Core)

#### 2.1 - Acessar a pasta do backend
```bash
cd "Agendamento Veterinario - Back"
```

#### 2.2 - Restaurar dependências
```bash
dotnet restore
```

#### 2.3 - Configurar banco de dados

**Editar arquivo `appsettings.Development.json`:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AgendamentoVeterinarioDb;Integrated Security=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

#### 2.4 - Executar migrations
```bash
dotnet ef database update
```

#### 2.5 - Inicializar seeds (dados de exemplo)
```bash
dotnet ef database update --seed
```

#### 2.6 - Rodar o servidor backend
```bash
dotnet watch run
```

> O backend estará disponível em: `https://localhost:7001`

---

### 3️⃣ Configurar Frontend (React + Vite)

#### 3.1 - Abrir nova aba no terminal e acessar a pasta do frontend
```bash
cd "Agendamento Veterinario - Front"
```

#### 3.2 - Instalar dependências
```bash
npm install
```

#### 3.3 - Configurar variáveis de ambiente

**Criar arquivo `.env.local`:**
```bash
VITE_API_URL=https://localhost:7001/api
VITE_APP_NAME=Agendamento Veterinário
```

#### 3.4 - Rodar servidor de desenvolvimento
```bash
npm run dev
```

> O frontend estará disponível em: `http://localhost:5173`

---

### 4️⃣ Verificação

✅ Frontend carregando: http://localhost:5173  
✅ Backend respondendo: https://localhost:7001/swagger  
✅ Banco de dados conectado  
✅ Testes executando com sucesso

---

## 🔧 Variáveis de Ambiente

### Backend - `appsettings.Development.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AgendamentoVeterinarioDb;Integrated Security=true;TrustServerCertificate=true;"
  },
  "Jwt": {
    "SecretKey": "sua-chave-secreta-super-segura-aqui-com-minimo-32-caracteres",
    "Issuer": "AgendamentoVeterinario",
    "Audience": "AgendamentoVeterinarioClient",
    "ExpirationHours": 24
  },
  "Email": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "seu-email@gmail.com",
    "SenderPassword": "sua-senha-app"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Frontend - `.env.local`
```bash
# API Configuration
VITE_API_URL=https://localhost:7001/api
VITE_API_TIMEOUT=30000

# App Configuration
VITE_APP_NAME=Agendamento Veterinário
VITE_ENVIRONMENT=development

# Feature Flags
VITE_ENABLE_ANALYTICS=false
VITE_ENABLE_NOTIFICATIONS=true
```

---

## 💾 Banco de Dados

### 📊 Estrutura

#### Tabelas Principais

| Tabela | Descrição |
|--------|-----------|
| `Usuarios` | Dados dos usuários (tutores e admin) |
| `Pets` | Pets cadastrados |
| `Veterinarios` | Dados dos veterinários |
| `Servicos` | Serviços oferecidos |
| `Agendamentos` | Registros de agendamentos |
| `Avaliacoes` | Ratings e comentários |
| `Especialidades` | Especialidades dos veterinários |

#### Relacionamentos
```
Usuario (1) ──→ (∞) Pet
Usuario (1) ──→ (∞) Agendamento
Veterinario (1) ──→ (∞) Agendamento
Pet (1) ──→ (∞) Agendamento
Servico (1) ──→ (∞) Agendamento
Especialidade (1) ──→ (∞) Veterinario
```

### 🔄 Migrations

#### Criação de nova migration
```bash
dotnet ef migrations add NomeMigration
```

#### Aplicar migration
```bash
dotnet ef database update
```

#### Rollback
```bash
dotnet ef database update NomeMigrationAnterior
```

### 🌱 Seeds

Dados de exemplo já estão configurados em `Data/Seeds/DatabaseSeeder.cs`:

```csharp
public static class DatabaseSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Especialidades
        var especialidades = new[]
        {
            new Especialidade { Id = 1, Nome = "Clinica Geral", Descricao = "..." },
            new Especialidade { Id = 2, Nome = "Cirurgia", Descricao = "..." }
        };
        
        // Veterinarios
        var veterinarios = new[]
        {
            new Veterinario { Id = 1, Nome = "Dr. João Silva", ... }
        };
        
        modelBuilder.Entity<Especialidade>().HasData(especialidades);
        modelBuilder.Entity<Veterinario>().HasData(veterinarios);
    }
}
```

---

## 🔌 Endpoints da API

### Autenticação

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "usuario@email.com",
  "senha": "senha123"
}

Response (200 OK):
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "usuario": {
    "id": 1,
    "nome": "João Silva",
    "email": "joao@email.com"
  }
}
```

#### Registro
```http
POST /api/auth/registrar
Content-Type: application/json

{
  "nome": "João Silva",
  "email": "joao@email.com",
  "senha": "senha123",
  "confirmarSenha": "senha123"
}

Response (201 Created):
{
  "id": 1,
  "nome": "João Silva",
  "email": "joao@email.com"
}
```

---

### Pets

#### Listar todos os pets do usuário
```http
GET /api/pets
Authorization: Bearer {token}

Response (200 OK):
{
  "data": [
    {
      "id": 1,
      "nome": "Fluffy",
      "especie": "Gato",
      "raca": "Persa",
      "dataNascimento": "2020-05-15",
      "peso": 4.5
    }
  ],
  "total": 1
}
```

#### Criar novo pet
```http
POST /api/pets
Authorization: Bearer {token}
Content-Type: application/json

{
  "nome": "Fluffy",
  "especie": "Gato",
  "raca": "Persa",
  "dataNascimento": "2020-05-15",
  "peso": 4.5,
  "observacoes": "Alérgico a frango"
}

Response (201 Created):
{
  "id": 1,
  "nome": "Fluffy",
  "especie": "Gato",
  "raca": "Persa"
}
```

#### Atualizar pet
```http
PUT /api/pets/{id}
Authorization: Bearer {token}
Content-Type: application/json

{
  "nome": "Fluffy",
  "peso": 5.0
}

Response (200 OK):
{
  "id": 1,
  "nome": "Fluffy",
  "peso": 5.0
}
```

#### Deletar pet
```http
DELETE /api/pets/{id}
Authorization: Bearer {token}

Response (204 No Content)
```

---

### Veterinários

#### Listar todos os veterinários
```http
GET /api/veterinarios?especialidade=Clinica&pagina=1&tamanho=10

Response (200 OK):
{
  "data": [
    {
      "id": 1,
      "nome": "Dr. João Silva",
      "especialidade": "Clinica Geral",
      "telefone": "(11) 99999-9999",
      "horarioAbertura": "08:00",
      "horarioFechamento": "18:00",
      "avaliacao": 4.8,
      "avaliacoes": 125
    }
  ],
  "total": 50,
  "pagina": 1,
  "tamanho": 10
}
```

#### Detalhes do veterinário
```http
GET /api/veterinarios/{id}

Response (200 OK):
{
  "id": 1,
  "nome": "Dr. João Silva",
  "especialidade": "Clinica Geral",
  "telefone": "(11) 99999-9999",
  "email": "dr.joao@veterinaria.com",
  "experiencia": 15,
  "horariosDisponiveis": ["08:00", "09:00", "10:00"],
  "comentarios": [
    {
      "autor": "Maria Silva",
      "nota": 5,
      "comentario": "Excelente atendimento!"
    }
  ]
}
```

---

### Agendamentos

#### Criar agendamento
```http
POST /api/agendamentos
Authorization: Bearer {token}
Content-Type: application/json

{
  "petId": 1,
  "veterinarioId": 1,
  "servicoId": 2,
  "dataAgendamento": "2024-06-15",
  "horaAgendamento": "14:30",
  "observacoes": "Pet está com coceira"
}

Response (201 Created):
{
  "id": 1,
  "status": "Agendado",
  "dataAgendamento": "2024-06-15",
  "horaAgendamento": "14:30",
  "confirmacao": {
    "codigoConfirmacao": "AGD-001-2024",
    "linkConfirmacao": "https://..."
  }
}
```

#### Listar agendamentos do usuário
```http
GET /api/agendamentos?status=Agendado&ordenar=data

Response (200 OK):
{
  "data": [
    {
      "id": 1,
      "pet": { "nome": "Fluffy" },
      "veterinario": { "nome": "Dr. João" },
      "servico": { "nome": "Consulta Geral" },
      "dataAgendamento": "2024-06-15",
      "horaAgendamento": "14:30",
      "status": "Agendado"
    }
  ]
}
```

#### Cancelar agendamento
```http
DELETE /api/agendamentos/{id}
Authorization: Bearer {token}

Response (204 No Content)
```

---

### Serviços

#### Listar serviços
```http
GET /api/servicos?tipo=consulta

Response (200 OK):
{
  "data": [
    {
      "id": 1,
      "nome": "Consulta Geral",
      "descricao": "Avaliação geral do pet",
      "preco": 150.00,
      "duracao": 30,
      "tipo": "Consulta"
    }
  ]
}
```

---

## 🧪 Testes

### Testes Unitários

#### Executar testes
```bash
dotnet test
```

#### Cobertura de testes
```bash
dotnet test /p:CollectCoverage=true /p:CoverageFormat=lcov
```

### Testes de Integração

```bash
dotnet test --filter Category=Integration
```

### Exemplo de Teste

```csharp
[TestClass]
public class UsuarioServiceTests
{
    private IUsuarioService _service;
    private Mock<IUsuarioRepository> _repositoryMock;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IUsuarioRepository>();
        _service = new UsuarioService(_repositoryMock.Object);
    }

    [TestMethod]
    public async Task CriarUsuario_DeveRetornarSucessoComDadosValidos()
    {
        // Arrange
        var usuario = new Usuario { Nome = "João", Email = "joao@email.com" };
        _repositoryMock.Setup(r => r.AdicionarAsync(It.IsAny<Usuario>()))
            .ReturnsAsync(usuario);

        // Act
        var resultado = await _service.CriarAsync(usuario);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual("João", resultado.Nome);
    }
}
```

### Ferramentas de Teste

| Ferramenta | Descrição |
|-----------|-----------|
| MSTest | Framework de testes |
| Moq | Mocking framework |
| FluentAssertions | Assertions fluentes |
| xUnit | (Alternativa) |

---

## 🎯 Decisões Técnicas

### 1️⃣ Por que React + Vite?

- ✅ Ecossistema robusto e maduro
- ✅ Performance com Vite (build rápido)
- ✅ Component-based reusability
- ✅ Large community e muitas bibliotecas
- ✅ SEO friendly com otimizações

**Trade-off:** Requer compreensão de JavaScript/TypeScript

### 2️⃣ Por que ASP.NET Core 8?

- ✅ Performance superior (benchmarks TechEmpower)
- ✅ Type-safe backend
- ✅ Entity Framework Core poderoso
- ✅ Segurança integrada (HTTPS, JWT)
- ✅ Escalabilidade

**Trade-off:** Curva de aprendizado em C#

### 3️⃣ Por que SQL Server?

- ✅ Confiabilidade enterprise
- ✅ ACID compliance total
- ✅ Excelente para relacionamentos complexos
- ✅ Integração natural com .NET

**Trade-off:** Recursos necessários

### 4️⃣ Clean Architecture

- ✅ Separação clara de responsabilidades
- ✅ Facilita testes
- ✅ Manutenibilidade a longo prazo
- ✅ Independência de frameworks

### 5️⃣ Repository Pattern

- ✅ Abstração de acesso a dados
- ✅ Facilita testes unitários
- ✅ Troca de DB sem impacto no código

### 6️⃣ Autenticação JWT

- ✅ Stateless (escalável)
- ✅ Seguro para APIs
- ✅ Funciona bem com SPAs
- ✅ Standard da indústria

---

## 🚗 Roadmap & Melhorias Futuras

### v1.1 (Próximo Sprint)
- [ ] Notificações em tempo real com SignalR
- [ ] Sistema de avaliações e comentários
- [ ] Histórico completo de agendamentos
- [ ] Dashboard para veterinários

### v1.2 (Sprint Seguinte)
- [ ] Sistema de pagamento integrado (Stripe/PagSeguro)
- [ ] Agendamento recorrente
- [ ] Lembretes por SMS/Email
- [ ] Exportar relatórios (PDF)

### v1.3 (Futuro)
- [ ] App mobile (React Native)
- [ ] Inteligência artificial para recomendações
- [ ] Integração com sistemas de clínicas (ERP)
- [ ] Telemedicina veterinária
- [ ] Marketplace de produtos
- [ ] Sistema de loyalty points

### v2.0 (Longo Prazo)
- [ ] Microserviços
- [ ] GraphQL
- [ ] Machine Learning
- [ ] Integração IoT (colares inteligentes)
- [ ] Blockchain para histórico médico imutável

---

## 🌐 Deploy

### Frontend - Vercel

```bash
# Configurar Vercel CLI
npm i -g vercel

# Fazer deploy
vercel
```

**URL:** [https://agendamento-veterinario.vercel.app](https://agendamento-veterinario.vercel.app)

### Backend - Azure App Service

```bash
# Publicar para Azure
dotnet publish -c Release -o ./publish

# Deploy com CLI do Azure
az webapp up --resource-group seu-grupo --name seu-app
```

**URL:** [https://agendamento-vet-api.azurewebsites.net](https://agendamento-vet-api.azurewebsites.net)

### Documentação Swagger

```
https://agendamento-vet-api.azurewebsites.net/swagger
```

### Figma (Protótipos)

```
https://figma.com/seu-projeto-aqui
```

### Status de Serviços

| Serviço | Status | Link |
|---------|--------|------|
| Frontend | ✅ Online | [Acessar](https://agendamento-veterinario.vercel.app) |
| Backend | ✅ Online | [API](https://agendamento-vet-api.azurewebsites.net/swagger) |
| Banco de Dados | ✅ Online | - |

---

## 👨‍💻 Autores

### Desenvolvedoras

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/seu-usuario-1">
        <img src="https://avatars.githubusercontent.com/u/seu-id?v=4" width="100px;" alt=""/>
        <br />
        <sub><b>Seu Nome 1</b></sub>
      </a>
      <br />
      <sub>Full Stack Developer</sub>
    </td>
    <td align="center">
      <a href="https://github.com/seu-usuario-2">
        <img src="https://avatars.githubusercontent.com/u/seu-id?v=4" width="100px;" alt=""/>
        <br />
        <sub><b>Seu Nome 2</b></sub>
      </a>
      <br />
      <sub>Full Stack Developer</sub>
    </td>
    <td align="center">
      <a href="https://github.com/seu-usuario-3">
        <img src="https://avatars.githubusercontent.com/u/seu-id?v=4" width="100px;" alt=""/>
        <br />
        <sub><b>Seu Nome 3</b></sub>
      </a>
      <br />
      <sub>UI/UX Designer</sub>
    </td>
  </tr>
</table>

---

## 📚 Recursos Adicionais

### Documentação
- 📖 [Clean Architecture - Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- 📖 [Domain-Driven Design - Eric Evans](https://domainlanguage.com/ddd/)
- 📖 [Microsoft - ASP.NET Core Best Practices](https://docs.microsoft.com/en-us/aspnet/core/)
- 📖 [React Documentation](https://react.dev)

### Comunidades
- 💬 [Stack Overflow](https://stackoverflow.com)
- 💬 [Dev Community](https://dev.to)
- 💬 [Reddit - r/webdev](https://reddit.com/r/webdev)

---

## 📝 Licença

Este projeto está licenciado sob a **MIT License** - veja o arquivo [LICENSE](./LICENSE) para detalhes.

```
MIT License

Copyright (c) 2024 Agendamento Veterinário

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
```

---

## 🙏 Agradecimentos

Agradeço aos:
- Professores do curso de Arquitetura e Desenvolvimento Full Stack
- Comunidade de desenvolvedores
- Todos os contribuidores e testadores
- Inspiração em projetos open source

---

## 💡 Contribuições

Contribuições são bem-vindas! Para reportar bugs ou sugerir features:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

---

## ❓ FAQ

### Qual é a versão do Node.js necessária?
A versão 18 ou superior é recomendada. Verifique com `node --version`.

### Posso usar outro banco de dados?
Sim! O projeto usa Entity Framework Core, que suporta múltiplos bancos. Atualize a string de conexão e o provider.

### Como faço deploy do projeto?
Veja a seção **Deploy** para instruções completas de Vercel e Azure.

### O projeto tem autenticação?
Sim! Usamos JWT com suporte completo a login, registro e recuperação de senha.

---

<div align="center">

**[⬆ Voltar ao topo](#-agendamento-veterinário)**

Desenvolvido com ❤️ em 2024

</div>