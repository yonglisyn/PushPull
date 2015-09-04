using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using PushPull.DataAccessLayer.Repositories.Interfaces;
using PushPull.Models;

namespace PushPull.DataAccessLayer.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        public async Task<List<Asset>> GetAssetListAsync(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var assetList = db.Assets.Where(x => x.UserId == userId);
                return await assetList.ToListAsync();
            }
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Assets.AddOrUpdate(asset);
                await db.SaveChangesAsync();
            }
        }
    }
}