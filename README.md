# TP01 - Sistemas Web II

Este repositório contém a resolução do Trabalho Prático 01 (TP01) da disciplina de Sistemas Web II do curso de Análise e Desenvolvimento de Sistemas (ADS). 

O projeto demonstra a evolução de uma aplicação Console padrão para um **Servidor Web** funcional utilizando C# e .NET, implementando rotas HTTP, injeção de dependência e persistência de dados.

## 🚀 Tecnologias e Conceitos Utilizados

* **Linguagem:** C# (.NET 10)
* **IDE:** Visual Studio 2026
* **Servidor Web:** Kestrel
* **Banco de Dados:** SQLite (com ADO.NET puro)
* **Arquitetura:** Padrão MVC inicial (Models, Repositories, Data) com Injeção de Dependência (Singleton).

## ⚙️ Funcionalidades

1. **Aplicação Console:** Inicializa o banco de dados, aplica o *seed* (popula com dados iniciais caso esteja vazio) e executa testes da classe de domínio `Book`.
2. **Servidor Web:** Sobe um host Kestrel na porta `5000` respondendo a requisições HTTP via pipeline de roteamento (`IApplicationBuilder`).

## 🛣️ Rotas Disponíveis (Endpoints)

O servidor responde no endereço base `http://localhost:5000`.

| Método | Rota | Descrição |
| :--- | :--- | :--- |
| **GET** | `/` | Rota raiz, retorna o status do servidor. |
| **GET** | `/livro/nome` | Retorna apenas o nome do livro cadastrado em texto puro. |
| **GET** | `/livro/tostring` | Retorna os dados completos do livro formatados pelo método `ToString()`. |
| **GET** | `/livro/autores` | Retorna uma string com os nomes dos autores do livro separados por vírgula. |
| **GET** | `/livro/ApresentarLivro` | Retorna uma página **HTML** renderizada com o título do livro e uma lista não ordenada (`<ul>`) de seus autores. |

## 🛠️ Como Executar o Projeto

1. Clone este repositório para a sua máquina local.
2. Abra a solução (`TP01_SistemasWeb2.sln`) no **Visual Studio 2026**.
3. Certifique-se de que o projeto principal está definido como *Startup Project*.
4. Execute o projeto (F5 ou Ctrl+F5).
5. O console exibirá os testes das classes e o aviso de que o Kestrel está rodando.
6. Abra o navegador e acesse as rotas listadas acima.

> **Nota:** O arquivo do banco de dados (`livros.db`) é gerado automaticamente na raiz do projeto durante a primeira execução.

---
**Autor:** Lucas Santos
**Autor:** Kaueh Farias