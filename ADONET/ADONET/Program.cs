using DAL.Models;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using DAL.Repository;

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
                    GoodName = "testName3",
                    GoodType = 3,
                    Quantity = 35,
                    Price = 43
                }
            };

            GoodModel editData = new()
            {
                GoodName = "EDIT",
                GoodType = 2222,
                Quantity = 3333,
                Price = 4444
            };

            IReadMethodsRepository read = new ReadMethods();
            IControlMethodsRepository control = new ControlMethods();
            IWriteMethodsRepository write = new WriteMethods();

            //await control.CreateDataBase();
            //await control.CreateTable();

            using (SqlConnection connection = new(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    //await write.AddGood(connection, goodModels[0]);
                    //await write.AddListOfGoods(connection, goodModels);
                    //await write.UpdateData(connection, 1, goodModels[2]);
                    //await write.DeleteData(connection, 1);

                    //await read.GetAllGoodsAsync(connection);
                    //await read.GetGoodByIdAsync(connection, 2);
                    Console.WriteLine("sucess");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error message: {ex.Message}");
                }
            }
        }
    }
}

