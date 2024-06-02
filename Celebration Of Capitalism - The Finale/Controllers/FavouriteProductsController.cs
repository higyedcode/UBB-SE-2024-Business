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

        // GET: FavouriteProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var favouriteProduct = await _context.FavouriteProduct
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (favouriteProduct == null)
            //{
            //    return NotFound();
            //}

            return View(null);
        }

        // GET: FavouriteProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavouriteProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,UserId")] FavouriteProduct favouriteProduct)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(favouriteProduct);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favouriteProduct);
        }

        // GET: FavouriteProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var favouriteProduct = await _context.FavouriteProduct.FindAsync(id);
            //if (favouriteProduct == null)
            //{
            //    return NotFound();
            //}
            return View(null);
        }

        // POST: FavouriteProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,UserId")] FavouriteProduct favouriteProduct)
        {
            if (id != favouriteProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(favouriteProduct);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!FavouriteProductExists(favouriteProduct.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(favouriteProduct);
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

        private bool FavouriteProductExists(int id)
        {
            //return _context.FavouriteProduct.Any(e => e.Id == id);
            return false;
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
