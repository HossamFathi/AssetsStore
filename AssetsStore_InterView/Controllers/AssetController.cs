using AssetsStore_InterView.BussinessLayer.Helper;
using AssetsStore_InterView.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetsStore_InterView.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetHelper _Asset;
        public AssetController(IAssetHelper asset)
        {
            _Asset = asset; 
        }

        public ActionResult Index()
        {
            
            return View(_Asset.GetAllAssets());
        }

        // GET: AssetController/Details/5
        public ActionResult Details(int id)
        {
           AssetDetailViewModel assetDetail = _Asset.GetAssetDetail(id);
            if (assetDetail == null)
                return BadRequest();
            return View(assetDetail);
        }

        // GET: AssetController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: AssetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetDetailViewModel Asset)
        {
            try
            {
                
                    var AssetInserted = _Asset.Create(Asset);
                    if (AssetInserted == null)
                        return View(Asset);
                    return RedirectToAction(nameof(Index));
                
            }
            catch(Exception ex)
            {
                return View(Asset);
            }
        }

        public ActionResult Search(string Asset)
        {
            ;
            return View(nameof(Index), _Asset.SearchAsset(Asset));
        }
        // GET: AssetController/Edit/5
        public ActionResult Edit(int id)
        {
           AssetDetailViewModel asset = _Asset.GetAssetDetail(id);
            return View(asset);
        }


        // POST: AssetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetDetailViewModel assetDetail)
        {
            try
            {
                _Asset.Update(assetDetail);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetController/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(_Asset.GetAssetDetail(id));
        }

        // POST: AssetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               if(_Asset.Delete(id))
                 return RedirectToAction(nameof(Index));
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
