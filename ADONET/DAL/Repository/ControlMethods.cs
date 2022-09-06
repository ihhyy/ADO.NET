using DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace DAL.Repository
{
    public class ControlMethods : IControlMethodsRepository
    {
        public async Task CreateDataBase()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new();
                cmd.CommandText = "CREATE DATABASE adonetdb";
                cmd.Connection = connection;

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateTable()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new();
                cmd.CommandText = "CREATE TABLE Goods(Id INT PRIMARY KEY IDENTITY, GoodName NVARCHAR(50) NOT NULL, GoodType INT NOT NULL, Quantity INT, Price INT NOT NULL)";
                cmd.Connection = connection;

                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
