using DAL.Interfaces;
using DAL.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Repository
{
    public class WriteMethods : IWriteMethodsRepository
    {
        public async Task AddListOfGoods(SqlConnection connection, List<GoodModel> goods)
        {
            SqlCommand cmd = new();
            string commandText = "INSERT INTO Goods (GoodName, GoodType, Quantity, Price) VALUES";

            for (int i = 0; i < goods.Count; i++)
            {
                if (!(i == goods.Count - 1))
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



        public async Task DeleteData(SqlConnection connection, int Id)
        {
            SqlCommand cmd = new();
            string commandText = $"DELETE FROM Goods WHERE Id='{Id}'";
            cmd.CommandText = commandText;
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateData(SqlConnection connection, int Id, GoodModel good)
        {
            SqlCommand cmd = new();
            string commandText = $"UPDATE Goods SET {WriteComponentsToUpdateDataComand(good)} WHERE Id='{Id}'";
            cmd.CommandText = commandText;
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task AddGood(SqlConnection connection, GoodModel good)
        {
            SqlCommand cmd = new();
            string commandText = $"INSERT INTO Goods (GoodName, GoodType, Quantity, Price) " +
                $"VALUES('{good.GoodName}', '{good.GoodType}', '{good.Quantity}', '{good.Price}')";
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
