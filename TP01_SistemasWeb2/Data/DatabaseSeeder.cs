//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace TP01_SistemasWeb2.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed()
        {
            using SqliteConnection connection = Database.GetConnection();

            using SqliteTransaction transaction =
                connection.BeginTransaction();

            using SqliteCommand command = connection.CreateCommand();

            command.Transaction = transaction;

            command.CommandText = "SELECT COUNT(*) FROM Book;";

            long bookCount = (long)command.ExecuteScalar()!;

            if (bookCount > 0)
            {
                transaction.Commit();
                return;
            }

            command.CommandText = """
            INSERT INTO Author (Name, Email, Gender)
            VALUES
                ('Robert C. Martin', 'robert@email.com', 'M'),
                ('John Doe', 'john@email.com', 'M'),
                ('Corinthians', 'Timao@email.com', 'T'),
                ('Anemona do nemo', 'mcnemao@email.com', 'N');
            """;

            command.ExecuteNonQuery();

            command.CommandText = """
            INSERT INTO Book (Name, Price, Qty)
            VALUES
                ('Clean Code', 89.90, 5),
                ('Oloko bicho', 295.50, 10);
            """;

            command.ExecuteNonQuery();

            command.CommandText = """
            INSERT INTO BookAuthor (BookId, AuthorId)
            VALUES
                (
                    (SELECT Id FROM Book WHERE Name = 'Clean Code'),
                    (SELECT Id FROM Author WHERE Name = 'Robert C. Martin')
                ),
                (
                    (SELECT Id FROM Book WHERE Name = 'Clean Code'),
                    (SELECT Id FROM Author WHERE Name = 'John Doe')
                ),
                (
                    (SELECT Id FROM Book WHERE Name = 'Oloko bicho'),
                    (SELECT Id FROM Author WHERE Name = 'Corinthians')
                ),
                (
                    (SELECT Id FROM Book WHERE Name = 'Oloko bicho'),
                    (SELECT Id FROM Author WHERE Name = 'Anemona do nemo')
                );
            """;

            command.ExecuteNonQuery();

            transaction.Commit();
        }
    }
}
