using DAL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADONET
{   
    class AdoNet
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";

            List<GoodModel> goodModels = new()
            {
                new GoodModel()
                {
                    GoodName = "testName1",
                    GoodType = 1,
                    Quantity = 1,
                    Price = 2
                },

                new GoodModel()
                {
                    GoodName = "testName2",
                    GoodType = 2,
                    Quantity = 3,
                    Price = 4
                },
                
                new GoodModel()
                {
                    GoodName = "EDIT",
                    GoodType = 2222,
                    Quantity = 3333,
                    Price = 4444
                }
            };

            using (SqlConnection connection = new(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    //await CreateDataBase(connection);
                    //await CreateTable(connection);
                    //await AddData(connection, goodModels);
                    //await UpdateData(connection, 1, goodModels[2]);
                    await DeleteData(connection, 1);
                    Console.WriteLine("sucess");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error message: {ex.Message}");
                }
            }
        }

        public static async Task CreateDataBase(SqlConnection connection)
        {
            SqlCommand cmd = new();
            cmd.CommandText = "CREATE DATABASE adonetdb";
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public static async Task CreateTable(SqlConnection connection)
        {
            SqlCommand cmd = new();
            cmd.CommandText = "CREATE TABLE Goods(Id INT PRIMARY KEY IDENTITY, GoodName NVARCHAR(50) NOT NULL, GoodType INT NOT NULL, Quantity INT, Price INT NOT NULL)";
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public static async Task AddData(SqlConnection connection, List<GoodModel> goods)
        {
            SqlCommand cmd = new();
            string commandText = "INSERT INTO Goods (GoodName, GoodType, Quantity, Price) VALUES";

            for(int i = 0; i < goods.Count; i++)
            {
                if(!(i == goods.Count - 1))
                {
                    commandText += WriteComponentsToAddDataComand(goods[i]) + $", ";
                }
                else
                {
                    commandText += WriteComponentsToAddDataComand(goods[i]);
                }
            }

            cmd.CommandText = commandText;
            cmd.Connection = connection;
            await cmd.ExecuteNonQueryAsync();

        }

        public static async Task UpdateData(SqlConnection connection, int Id, GoodModel good)
        {
            SqlCommand cmd = new();
            string commandText = $"UPDATE Goods SET {WriteComponentsToUpdateDataComand(good)} WHERE Id='{Id}'";
            cmd.CommandText = commandText;
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public static async Task DeleteData(SqlConnection connection, int Id)
        {
            SqlCommand cmd = new();
            string commandText = $"DELETE FROM Goods WHERE Id='{Id}'";
            cmd.CommandText = commandText;
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        private static string WriteComponentsToAddDataComand(GoodModel good)
        {
            string comand = $"('{good.GoodName}', '{good.GoodType}', '{good.Quantity}', '{good.Price}')";

            return comand;
        }

        private static string WriteComponentsToUpdateDataComand(GoodModel good)
        {
            string comand = $"GoodName='{good.GoodName}'," +
                $" GoodType='{good.GoodType}', " +
                $"Quantity='{good.Quantity}'," +
                $"Price='{good.Price}'";

            return comand;
        }
    }
}

