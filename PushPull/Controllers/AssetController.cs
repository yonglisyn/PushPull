using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PushPull.DataAccessLayer.Repositories;
using PushPull.Models;

namespace PushPull.Controllers
{
    public class AssetController:Controller 
    {
        private readonly AssetRepository _AssetRepository;

        public AssetController()
        {
            _AssetRepository = new AssetRepository();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var assets =await _AssetRepository.GetAssetListAsync(userId);
            return View("Index", new AssetViewModel(assets));
        }
    }
}