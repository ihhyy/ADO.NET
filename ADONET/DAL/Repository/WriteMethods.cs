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

            for (int i = 0; i < goods.Count; i++)
            {
                cmd = AddParameter(connection, goods[i]);
                cmd.Connection = connection;
                await cmd.ExecuteNonQueryAsync();
            }
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
            SqlCommand cmd = AddParameter(connection, good);
            cmd.CommandText  = $"UPDATE Goods SET GoodName=@GoodName, GoodType=@GoodType, Quantity=@Quantity, Price=@Price WHERE Id='{Id}'";
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task AddGood(SqlConnection connection, GoodModel good)
        {
            SqlCommand cmd = AddParameter(connection, good);
            cmd.Connection = connection;

            await cmd.ExecuteNonQueryAsync();
        }

        private static SqlCommand AddParameter(SqlConnection connection, GoodModel good)
        {
            string commandText = $"INSERT INTO Goods (GoodName, GoodType, Quantity, Price) " +
                $"VALUES(@GoodName, @GoodType, @Quantity, @Price)";

            SqlCommand cmd = new(commandText, connection);

            SqlParameter parameter = new()
            {
                ParameterName = "@GoodName",
                Value = good.GoodName,
                SqlDbType = System.Data.SqlDbType.Char,
                Size = good.GoodName.Length
            }; 
                
            cmd.Parameters.Add(parameter);
                
            parameter = new()
            {
                ParameterName = "@GoodType",
                Value = good.GoodType,
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 2
            };

            cmd.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "@Quantity",
                Value = good.Quantity,
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 4
            };

            cmd.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "@Price",
                Value = good.Price,
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 6
            };

            cmd.Parameters.Add(parameter);

            return cmd;
        }
    }
}
