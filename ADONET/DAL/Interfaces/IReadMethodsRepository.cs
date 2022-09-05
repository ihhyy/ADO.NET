using DAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReadMethodsRepository
    {
        Task<List<GoodModel>> GetAllGoodsAsync(SqlConnection connection);
        Task<GoodModel> GetGoodByIdAsync(SqlConnection connection, int Id);
    }
}
