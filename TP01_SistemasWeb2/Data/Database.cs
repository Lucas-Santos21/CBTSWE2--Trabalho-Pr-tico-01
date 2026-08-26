//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace TP01_SistemasWeb2.Data
{
    public static class Database
    {
        private const string ConnectionString = "Data Source=livros.db";

        public static SqliteConnection GetConnection()
        {
            SqliteConnection connection = new SqliteConnection(ConnectionString);

            connection.Open();

            return connection;
        }

        public static void Initialize()
        {
            using SqliteConnection connection = GetConnection();

            using SqliteCommand command = connection.CreateCommand();

            command.CommandText = """
            PRAGMA foreign_keys = ON;

            CREATE TABLE IF NOT EXISTS Author
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                Gender TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Book
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Price REAL NOT NULL,
                Qty INTEGER NOT NULL DEFAULT 0
            );

            CREATE TABLE IF NOT EXISTS BookAuthor
            (
                BookId INTEGER NOT NULL,
                AuthorId INTEGER NOT NULL,

                PRIMARY KEY (BookId, AuthorId),

                FOREIGN KEY (BookId)
                    REFERENCES Book(Id)
                    ON DELETE CASCADE,

                FOREIGN KEY (AuthorId)
                    REFERENCES Author(Id)
                    ON DELETE CASCADE
            );
            """;

            command.ExecuteNonQuery();
        }
    }
}
