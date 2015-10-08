using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PushPull.Models;

namespace PushPull.DataAccessLayer.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetOneWeekAssetListAsync(int userId, DateTime endDate);
        Task UpdateAssetAsync(Asset asset);
    }
}