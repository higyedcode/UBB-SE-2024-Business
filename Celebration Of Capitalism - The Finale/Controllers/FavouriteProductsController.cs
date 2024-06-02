using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Celebration_Of_Capitalism___The_Finale.Services;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
    public class FavouriteProductsController : Controller
    {
/*        private readonly CoCContext _context;*/
        private readonly IFavouriteProductService favouriteProductService;
        private readonly IProductService productService;

        public FavouriteProductsController(FavouriteProductService favouriteProductService, ProductService productService)
        {
            this.favouriteProductService = favouriteProductService;
            this.productService = productService;
        }

        // GET: FavouriteProducts
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.Keys.Contains("userID"))
            {
                return View();
            }

            int userID;
            try
            {
                userID = int.Parse(HttpContext.Session.GetString("userID"));
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            var favoriteProductList = favouriteProductService.GetAllFavouriteProductsOfUser(userID);
            foreach (var item in favoriteProductList)
            {
                item.Product = productService.GetProduct(item.ProductId);
            }

            return View(favoriteProductList.ToList());
        }

        // GET: FavouriteProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedProduct = favouriteProductService.GetFavouriteProduct((int)id);
            selectedProduct.Product = productService.GetProduct(selectedProduct.ProductId);

            return View(selectedProduct);
        }

        // POST: FavouriteProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            favouriteProductService.DeleteFavouriteProductFromUser(favouriteProductService.GetFavouriteProduct((int)id));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult MarkAsFavourite(int? id)
        {
            if(id == null)
                { return NotFound(); }

            var productToAdd = new FavouriteProduct
            {
                UserId = int.Parse(HttpContext.Session.GetString("userID")),
                ProductId = (int)id
            };

            favouriteProductService.AddFavouriteProduct(productToAdd);
            return RedirectToAction("Index", "FavouriteProducts");
        }
    }
}
