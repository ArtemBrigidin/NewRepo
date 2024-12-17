using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using Tanki_ASP.NET.Game.Interfaces;

namespace Tanki_ASP.NET.Game
{
    public class Profile : IProfile
    {
        private readonly string _connectionString;

        public Profile(string connectionString)
        {
            Batteries.Init();
            _connectionString = connectionString;
        }

        public void AddProfile(string username, string login, string password)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Profiles (Username, Login, Password)
                    VALUES (@username, @login, @password);
                ";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }
        }

        public bool ValidateProfile(string login, string password)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT COUNT(1)
                    FROM Profiles
                    WHERE Login = @login AND Password = @password;
                ";
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                var count = (long)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
