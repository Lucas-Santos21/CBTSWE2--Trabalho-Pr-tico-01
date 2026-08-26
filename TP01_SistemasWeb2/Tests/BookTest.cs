//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;
using TP01_SistemasWeb2.Data;
using TP01_SistemasWeb2.Models;

namespace TP01_SistemasWeb2.Tests
{
    public static class BookTest
    {
        public static void Run()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("TESTE DA CLASSE BOOK");
            Console.WriteLine("========================================");

            Author author1 = new Author(
                "Robert C. Martin",
                "robert@email.com",
                'M'
            );

            Author author2 = new Author(
                "John Doe",
                "john@email.com",
                'M'
            );

            Author[] authors =
            {
            author1,
            author2
        };

            Book book = new Book(
                "Clean Code",
                authors,
                89.90,
                5
            );

            Console.WriteLine();
            Console.WriteLine("1 - GetName()");
            Console.WriteLine(book.GetName());

            Console.WriteLine();
            Console.WriteLine("2 - GetAuthors()");
            foreach (Author author in book.GetAuthors())
            {
                Console.WriteLine(author);
            }

            Console.WriteLine();
            Console.WriteLine("3 - GetPrice()");
            Console.WriteLine(book.GetPrice());

            Console.WriteLine();
            Console.WriteLine("4 - SetPrice()");
            book.SetPrice(99.90);
            Console.WriteLine(book.GetPrice());

            Console.WriteLine();
            Console.WriteLine("5 - GetQty()");
            Console.WriteLine(book.GetQty());

            Console.WriteLine();
            Console.WriteLine("6 - SetQty()");
            book.SetQty(10);
            Console.WriteLine(book.GetQty());

            Console.WriteLine();
            Console.WriteLine("7 - ToString()");
            Console.WriteLine(book);

            Console.WriteLine();
            Console.WriteLine("8 - GetAuthorNames()");
            Console.WriteLine(book.GetAuthorNames());

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("TESTE FINALIZADO");
            Console.WriteLine("========================================");
        }
    }
}
