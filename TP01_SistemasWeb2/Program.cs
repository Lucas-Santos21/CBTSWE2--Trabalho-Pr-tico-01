//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TP01_SistemasWeb2.Data;
using TP01_SistemasWeb2.Tests;

namespace TP01_SistemasWeb2;

public class Program
{
    public static void Main(string[] args)
    {
        Database.Initialize();

        DatabaseSeeder.Seed();

        Console.WriteLine("Banco de dados SQLite inicializado.");
        Console.WriteLine();

        Tests.BookTest.Run();

        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("INICIANDO SERVIDOR WEB");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Servidor disponível em:");
        Console.WriteLine("http://localhost:5000");
        Console.WriteLine();
        Console.WriteLine("Rotas:");
        Console.WriteLine("GET /livro/nome");
        Console.WriteLine("GET /livro/tostring");
        Console.WriteLine("GET /livro/autores");
        Console.WriteLine("GET /livro/ApresentarLivro");
        Console.WriteLine();
        Console.WriteLine("Pressione Ctrl+C para encerrar.");
        Console.WriteLine();

        CreateHostBuilder(args)
            .Build()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseKestrel()
                    .UseUrls("http://localhost:5000")
                    .UseStartup<Startup>();
            });
    }
}