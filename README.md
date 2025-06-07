# 📦 API Catálogo

Este projeto foi desenvolvido como parte de um curso de Web APIs com .NET 8, tendo como foco a construção de uma API RESTful para gerenciar um catálogo de produtos. Ele serve como base para estudos de conceitos como arquitetura em camadas, uso do Entity Framework, boas práticas de desenvolvimento, e integração com o My SQL.

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/) – Framework principal para desenvolvimento da API.
- **ASP.NET Core Web API** – Para a criação dos endpoints REST.
- **C#** – Linguagem de programação utilizada.
- **Entity Framework Core** – ORM para manipulação do banco de dados.
- **My SQL** – Sistema gerenciador de banco de dados relacional.
- **Swagger / Swashbuckle** – Para documentação e teste dos endpoints.

## 📚 Funcionalidades da API

A API permite o gerenciamento de um catálogo de produtos, com os seguintes recursos:

- 🔍 **Listagem de Produtos** – Retorna todos os produtos cadastrados.
- 📄 **Detalhes do Produto** – Retorna os dados de um produto específico por ID.
- ➕ **Criação de Produto** – Permite o cadastro de um novo produto.
- ✏️ **Atualização de Produto** – Atualiza os dados de um produto existente.
- ❌ **Exclusão de Produto** – Remove um produto do banco de dados.

Todos os endpoints seguem as boas práticas REST, utilizando os métodos HTTP corretos (GET, POST, PUT, DELETE).

## 🗂️ Estrutura do Projeto

```
api-catalogo/
│
├── Controllers/          # Controladores da API (endpoints)
├── Models/               # Classes de domínio (Produto, Categoria, etc.)
├── Data/                 # DbContext e Seed de dados
├── Migrations/           # Histórico de migrações do Entity Framework
├── Program.cs            # Ponto de entrada da aplicação
├── appsettings.json      # Configurações da aplicação (ex: string de conexão)
└── README.md             # Este arquivo
```

## ⚙️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/GMarcolla/api-catalogo.git
   cd api-catalogo
   ```

2. Abra o projeto no Visual Studio 2022 ou superior.

3. Configure a string de conexão com o server My SQL no arquivo `appsettings.json`.

4. Aplique as migrações e crie o banco de dados:
   ```bash
   Update-Database
   ```

5. Execute o projeto (F5 ou `dotnet run`).

6. Acesse a documentação interativa Swagger em:
   ```
   https://localhost:<porta>/swagger
   ```

## 🤝 Contribuições

Contribuições são bem-vindas! Caso tenha sugestões de melhorias, correções ou novos recursos, fique à vontade para abrir uma issue ou enviar um pull request.

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Desenvolvido com 💻 por [GMarcolla](https://github.com/GMarcolla)
