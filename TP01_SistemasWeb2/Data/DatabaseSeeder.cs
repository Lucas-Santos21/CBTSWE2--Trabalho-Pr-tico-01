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

            using SqliteTransaction transaction = connection.BeginTransaction();

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
                ('Jane Smith', 'jane@email.com', 'F');
            """;

            command.ExecuteNonQuery();

            command.CommandText = """
            INSERT INTO Book (Name, Price, Qty)
            VALUES ('Clean Code', 89.90, 5);
            """;

            command.ExecuteNonQuery();

            command.CommandText = """
            INSERT INTO BookAuthor (BookId, AuthorId)
            SELECT
                (SELECT Id FROM Book WHERE Name = 'Clean Code'),
                Id
            FROM Author
            WHERE Name IN ('Robert C. Martin', 'John Doe');
            """;

            command.ExecuteNonQuery();

            transaction.Commit();
        }
    }
}
