//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using TP01_SistemasWeb2.Data;
using TP01_SistemasWeb2.Models;

namespace TP01_SistemasWeb2.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Book? GetBook()
        {
            using SqliteConnection connection = Database.GetConnection();

            using SqliteCommand command = connection.CreateCommand();

            command.CommandText = """
            SELECT
                b.Id,
                b.Name,
                b.Price,
                b.Qty
            FROM Book b
            LIMIT 1;
            """;

            using SqliteDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            int bookId = reader.GetInt32(0);
            string name = reader.GetString(1);
            double price = reader.GetDouble(2);
            int qty = reader.GetInt32(3);

            Author[] authors = GetAuthors(connection, bookId);

            return new Book(name, authors, price, qty);
        }

        private Author[] GetAuthors(SqliteConnection connection, int bookId)
        {
            List<Author> authors = new List<Author>();

            using SqliteCommand command = connection.CreateCommand();

            command.CommandText = """
            SELECT
                a.Name,
                a.Email,
                a.Gender
            FROM Author a
            INNER JOIN BookAuthor ba
                ON a.Id = ba.AuthorId
            WHERE ba.BookId = $bookId
            ORDER BY a.Id;
            """;

            command.Parameters.AddWithValue("$bookId", bookId);

            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(0);
                string email = reader.GetString(1);
                char gender = reader.GetString(2)[0];

                authors.Add(new Author(name, email, gender));
            }

            return authors.ToArray();
        }
    }
}
