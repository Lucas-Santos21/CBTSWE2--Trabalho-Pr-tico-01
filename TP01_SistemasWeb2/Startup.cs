//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
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
                        context.RequestServices.GetRequiredService<IBookRepository>();

                    var book = repository.GetBook();

                    if (book == null)
                    {
                        context.Response.StatusCode = 404;

                        await context.Response.WriteAsync(
                            "Livro não encontrado."
                        );

                        return;
                    }

                    context.Response.ContentType = "text/plain; charset=utf-8";

                    await context.Response.WriteAsync(
                        book.GetName()
                    );
                });

                endpoints.MapGet("/livro/tostring", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices.GetRequiredService<IBookRepository>();

                    var book = repository.GetBook();

                    if (book == null)
                    {
                        context.Response.StatusCode = 404;

                        await context.Response.WriteAsync(
                            "Livro não encontrado."
                        );

                        return;
                    }

                    context.Response.ContentType = "text/plain; charset=utf-8";

                    await context.Response.WriteAsync(
                        book.ToString()
                    );
                });

                endpoints.MapGet("/livro/autores", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices.GetRequiredService<IBookRepository>();

                    var book = repository.GetBook();

                    if (book == null)
                    {
                        context.Response.StatusCode = 404;

                        await context.Response.WriteAsync(
                            "Livro não encontrado."
                        );

                        return;
                    }

                    context.Response.ContentType = "text/plain; charset=utf-8";

                    await context.Response.WriteAsync(
                        book.GetAuthorNames()
                    );
                });

                endpoints.MapGet("/livro/ApresentarLivro", async context =>
                {
                    IBookRepository repository =
                        context.RequestServices.GetRequiredService<IBookRepository>();

                    var book = repository.GetBook();

                    if (book == null)
                    {
                        context.Response.StatusCode = 404;

                        await context.Response.WriteAsync(
                            "<h1>Livro não encontrado</h1>"
                        );

                        return;
                    }

                    context.Response.ContentType =
                        "text/html; charset=utf-8";

                    string html = $"""
                    <!DOCTYPE html>
                    <html lang="pt-BR">
                    <head>
                        <meta charset="UTF-8">
                        <title>Apresentação do Livro</title>
                    </head>

                    <body>
                        <h1>{book.GetName()}</h1>

                        <h2>Autores</h2>

                        <ul>
                    """;

                    foreach (var author in book.GetAuthors())
                    {
                        html += $"""
                            <li>{author.GetName()}</li>
                        """;
                    }

                    html += """
                        </ul>
                    </body>
                    </html>
                    """;

                    await context.Response.WriteAsync(html);
                });
            });
        }
    }
}
