using DAL.Models;
using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IReadMethodsRepository
    {
        Task<List<GoodModel>> GetAllGoodsAsync(SqlConnection connection);
        Task<GoodModel> GetGoodByIdAsync(SqlConnection connection, int Id);
    }
}
