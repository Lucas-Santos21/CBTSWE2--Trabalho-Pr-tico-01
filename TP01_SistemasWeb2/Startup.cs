//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TP01_SistemasWeb2.Data;
using TP01_SistemasWeb2.Models;
using TP01_SistemasWeb2.Repositories;

namespace TP01_SistemasWeb2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(
                        "Servidor Web do TP Sistemas Web 2 funcionando!"
                    );
                });

                endpoints.MapGet("/livro/nome", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices
                            .GetRequiredService<IBookRepository>();

                    List<Book> books = repository.GetBooks();

                    context.Response.ContentType =
                        "text/plain; charset=utf-8";

                    foreach (Book book in books)
                    {
                        await context.Response.WriteAsync(
                            $"Livro: {book.GetName()}\n"
                        );
                    }
                });

                endpoints.MapGet("/livro/tostring", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices
                            .GetRequiredService<IBookRepository>();

                    List<Book> books = repository.GetBooks();

                    context.Response.ContentType =
                        "text/plain; charset=utf-8";

                    foreach (Book book in books)
                    {
                        await context.Response.WriteAsync(
                            book.ToString() + "\n\n"
                        );
                    }
                });

                endpoints.MapGet("/livro/autores", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices
                            .GetRequiredService<IBookRepository>();

                    List<Book> books = repository.GetBooks();

                    context.Response.ContentType =
                        "text/plain; charset=utf-8";

                    int contador = 1;

                    foreach (Book book in books)
                    {
                        await context.Response.WriteAsync(
                            $"Livro {contador}: {book.GetName()}\n"
                        );

                        await context.Response.WriteAsync(
                            $"Autores: {book.GetAuthorNames()}\n\n"
                        );

                        contador++;
                    }
                });

                endpoints.MapGet(
                    "/livro/ApresentarLivro",
                    async context =>
                    {
                        IBookRepository repository =
                            context.RequestServices
                                .GetRequiredService<IBookRepository>();

                        List<Book> books = repository.GetBooks();

                        context.Response.ContentType =
                            "text/html; charset=utf-8";

                        string html = """
                        <!DOCTYPE html>
                        <html lang="pt-BR">

                        <head>
                            <meta charset="UTF-8">

                            <title>
                                Livros
                            </title>
                        </head>

                        <body>

                            <h1>Livros cadastrados</h1>
                        """;

                        int contador = 1;

                        foreach (Book book in books)
                        {
                            html += $"""
                            <hr>

                            <h2>
                                Livro {contador}: {book.GetName()}
                            </h2>

                            <h3>Autores</h3>

                            <ul>
                            """;

                            foreach (Author author in book.GetAuthors())
                            {
                                html += $"""
                                <li>
                                    {author.GetName()}
                                </li>
                                """;
                            }

                            html += """
                            </ul>
                            """;

                            contador++;
                        }

                        html += """
                        </body>
                        </html>
                        """;

                        await context.Response.WriteAsync(html);
                    }
                );
            });
        }
    }
}
