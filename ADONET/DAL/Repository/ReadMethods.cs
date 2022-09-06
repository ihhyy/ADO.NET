using DAL.Interfaces;
using DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReadMethods : IReadMethodsRepository
    {
        public async Task<List<GoodModel>> GetAllGoodsAsync(SqlConnection connection)
        {
            connection.Open();
            List<GoodModel> goods = new();
            string sqlExpression = "SELECT * FROM Goods";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                goods.Add(new GoodModel()
                {
                    GoodName = await reader.GetFieldValueAsync<string>(1),
                    GoodType = await reader.GetFieldValueAsync<int>(2),
                    Quantity = await reader.GetFieldValueAsync<int>(3),
                    Price = await reader.GetFieldValueAsync<int>(4)
                });
            }

            return goods;
        }

        public async Task<GoodModel> GetGoodByIdAsync(SqlConnection connection, int Id)
        {
            connection.Open();
            GoodModel data = new();
            string sqlExpression = $"SELECT * FROM Goods WHERE Id='{Id}'";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                data.GoodName = await reader.GetFieldValueAsync<string>(1);
                data.GoodType = await reader.GetFieldValueAsync<int>(2);
                data.Quantity = await reader.GetFieldValueAsync<int>(3);
                data.Price = await reader.GetFieldValueAsync<int>(4);
            }

            return data;
        }
    }
}
