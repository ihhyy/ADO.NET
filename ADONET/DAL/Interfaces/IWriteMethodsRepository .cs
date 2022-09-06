using DAL.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IWriteMethodsRepository
    {
        Task AddGood(SqlConnection connection, GoodModel goods);
        Task AddListOfGoods(SqlConnection connection, List<GoodModel> goods);
        Task UpdateData(SqlConnection connection, int Id, GoodModel good);
        Task DeleteData(SqlConnection connection, int Id);
    }
}
